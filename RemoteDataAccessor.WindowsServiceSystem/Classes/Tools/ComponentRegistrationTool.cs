using System;

using RemoteDataAccessor.Common.Classes.Exceptions;
using RemoteDataAccessor.Common.Classes.Logs;
using RemoteDataAccessor.Common.Interfaces.Component;
using RemoteDataAccessor.Common.Interfaces.Settings;
using RemoteDataAccessor.WindowsServiceSystem.Properties;

using Castle.Core.Configuration;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace RemoteDataAccessor.WindowsServiceSystem.Classes.Tools
{
    public class ArrayFacility : IFacility
    {
        public void Init(IKernel kernel, IConfiguration facilityConfig)
        {
            kernel.Resolver.AddSubResolver(new ArrayResolver(kernel));
        }

        public void Terminate() { }
    }

    public class CSPAClassesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            BasedOnDescriptor registrations = Castle.MicroKernel.Registration.Classes.FromAssemblyInDirectory(new AssemblyFilter(WindowsServiceSystemCore.ComponentsPath))
                .BasedOn<IComponent>()
                .WithService.FromInterface()
                .LifestyleSingleton();

            container.Register(registrations);
        }
    }

    public class ComponentRegistrationTool
    {
        private readonly WindsorContainer _container = new WindsorContainer();

        private IEngine _engine;

        public ComponentRegistrationTool()
        {
            _container.AddFacility<ArrayFacility>();

            _container.Kernel.ComponentCreated += (componentModel, instance) =>
            {
                string message = string.Format(Resources.ComponentCreatedMessage, instance.GetType().Name);

                LogTools logTools = new LogTools();
                logTools.WriteLogToConsole<Info>(message);
                logTools.WriteLogToFile<Info>(message);
            };
        }

        public void InitializeSystem()
        {
            RegisterSettings();
            RegisterComponents();
            RegisterEngine();
        }

        private void RegisterSettings()
        {
            try
            {
                _container.Register(Castle.MicroKernel.Registration.Classes.FromAssemblyInDirectory(new AssemblyFilter(WindowsServiceSystemCore.ComponentsPath))
                    .BasedOn<ISettings>()
                    .WithServiceAllInterfaces()
                    .LifestyleSingleton()
                );

                IDataAccessHelperProxySettings dataAccessHelperSettings = _container.Resolve<IDataAccessHelperProxySettings>();
                dataAccessHelperSettings.Set = 32;

                IEngineSettings engineSettings = _container.Resolve<IEngineSettings>();
                engineSettings.Set = Int32.MaxValue;
            }
            catch (Exception ex)
            {
                throw new InitializeSystemException(Resources.RegisterSettingsFailed, ex);
            }
        }

        private void RegisterComponents()
        {
            try
            {
                _container.Register(Castle.MicroKernel.Registration.Classes.FromAssemblyInDirectory(new AssemblyFilter(WindowsServiceSystemCore.ComponentsPath))
                    .BasedOn<IComponent>()
                    .WithServiceAllInterfaces()
                    .LifestyleSingleton()
                );
            }
            catch (Exception ex)
            {
                throw new InitializeSystemException(Resources.RegisterComponentsFailed, ex);
            }
        }

        private void RegisterEngine()
        {
            try
            {
                _container.Register(Castle.MicroKernel.Registration.Classes.FromAssemblyInDirectory(new AssemblyFilter(WindowsServiceSystemCore.ComponentsPath))
                    .BasedOn<IEngine>()
                    .WithService.FromInterface()
                    .LifestyleSingleton()
                );
            }
            catch (Exception ex)
            {
                throw new InitializeSystemException(Resources.RegisterEngineFailed, ex);
            }
        }

        public void Run()
        {
            try
            {
                _engine = _container.Resolve<IEngine>();
                _engine.Initialize();
                _engine.Validate();
                _engine.Run();
            }
            catch (Exception ex)
            {
                throw new RunSystemException(Resources.RunSystemFailed, ex);
            }
        }
    }
}
