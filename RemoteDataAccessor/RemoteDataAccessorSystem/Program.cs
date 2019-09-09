using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Configuration;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NLog;
using RemoteDataAccessor.Common.Classes.Constatnts;
using RemoteDataAccessor.Common.Classes.Settings;
using RemoteDataAccessor.Common.Interfaces.Component;
using RemoteDataAccessor.Common.Interfaces.Settings;

namespace RemoteDataAccessorSystem
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
            BasedOnDescriptor registrations = Classes.FromAssemblyInDirectory(new AssemblyFilter(Program.ComponentsPath))
                .BasedOn<IComponent>()
                .WithService.FromInterface()
                .LifestyleSingleton();

            container.Register(registrations);
        }
    }

    class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static readonly string ComponentsPath = Directory.GetCurrentDirectory() + @"\Modules";

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            GlobalDiagnosticsContext.Set("logDir", $@"{ComponentsPath}\logs");

            WindsorContainer container = new WindsorContainer();
            container.AddFacility<ArrayFacility>();

            container.Kernel.ComponentCreated += (componentModel, instance) =>
            {
                string message = $"{instance.GetType().Name} component created";
                Console.WriteLine($"{DateTime.Now.ToString(CommonConstatnts.DateTimeFormat)}. {CommonConstatnts.ApplicationName} Info | {message}");
                Logger.Info(message);
            };

            // Register ISettings.
            container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(ComponentsPath))
                .BasedOn<ISettings>()
                .WithServiceAllInterfaces()
                .LifestyleSingleton()
            );

            IDataAccessHelperSettings dataAccessHelperSettings = container.Resolve<IDataAccessHelperSettings>();
            dataAccessHelperSettings.Set = 32;

            IEngineSettings engineSettings = container.Resolve<IEngineSettings>();
            engineSettings.Set = Int32.MaxValue;

            // Register IComponent.
            container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(ComponentsPath))
                .BasedOn<IComponent>()
                .WithServiceAllInterfaces()
                .LifestyleSingleton()
            );

            // Register IEngine.
            container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(ComponentsPath))
                .BasedOn<IEngine>()
                .WithService.FromInterface()
                .LifestyleSingleton()
            );

            IEngine engine = container.Resolve<IEngine>();
            engine.Initialize();
            engine.Validate();
            engine.Run();

            Console.ReadLine();
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            // TODO
            //List<string> lines = GetErrorMessage("UnhandledException.", (Exception)e.ExceptionObject);
            //Logger.Fatal(string.Join("\n", lines));
            //Console.WriteLine($"{DateTime.Now.ToString(DateTimeFormat)}. {ManagerName} Fatal | {string.Join("\n", lines)}");

            Thread.Sleep(5 * 1000);
            Environment.Exit(-1);
        }
    }
}
