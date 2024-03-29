﻿using System;

using RemoteDataAccessor.Common.Classes.Exceptions;
using RemoteDataAccessor.Common.Classes.Logs;
using RemoteDataAccessor.Common.Interfaces.Component;
using RemoteDataAccessor.Common.Interfaces.Settings;
using RemoteDataAccessor.ConsoleSystem.Properties;

using Castle.Core.Configuration;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace RemoteDataAccessor.ConsoleSystem.Classes.Tools
{
    public class ArrayFacility : IFacility
    {
        public void Init(IKernel kernel, IConfiguration facilityConfig)
        {
            kernel.Resolver.AddSubResolver(new ArrayResolver(kernel));
        }

        public void Terminate() { }
    }

    public class ClassesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            BasedOnDescriptor registrations = Castle.MicroKernel.Registration.Classes.FromAssemblyInDirectory(new AssemblyFilter(Program.ComponentsPath))
                .BasedOn<IComponent>()
                .WithService.FromInterface()
                .LifestyleSingleton();

            container.Register(registrations);
        }
    }

    public class ComponentRegistrationTool
    {
        private readonly WindsorContainer _container = new WindsorContainer();

        private IConsoleSystemEngine _engine;

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
                _container.Register(Castle.MicroKernel.Registration.Classes.FromAssemblyInDirectory(new AssemblyFilter(Program.ComponentsPath))
                    .BasedOn<ISettings>()
                    .WithServiceAllInterfaces()
                    .LifestyleSingleton()
                );

                IAPIProviderSettings dataAccessProxySettings = _container.Resolve<IAPIProviderSettings>();
                dataAccessProxySettings.Set = 32;

                IConsoleSystemEngineSettings engineSettings = _container.Resolve<IConsoleSystemEngineSettings>();
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
                _container.Register(Castle.MicroKernel.Registration.Classes.FromAssemblyInDirectory(new AssemblyFilter(Program.ComponentsPath))
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
                _container.Register(Castle.MicroKernel.Registration.Classes.FromAssemblyInDirectory(new AssemblyFilter(Program.ComponentsPath))
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
                _engine = _container.Resolve<IConsoleSystemEngine>();
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
