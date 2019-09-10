using System;
using System.IO;
using System.ServiceProcess;
using System.Threading;

using RemoteDataAccessor.WindowsServiceSystem.Classes.Tools;

using NLog;

namespace RemoteDataAccessor.WindowsServiceSystem
{
    public partial class WindowsServiceSystemCore : ServiceBase
    {
        public static readonly string ComponentsPath = Directory.GetCurrentDirectory() + @"\Modules";

        private Thread _starterThread;

        public WindowsServiceSystemCore()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _starterThread = new Thread(StarterThreadMethod) { IsBackground = true };
            _starterThread.Start();
        }

        protected override void OnStop()
        {
            LogManager.Flush();

            base.OnStop();
        }

        private void StarterThreadMethod()
        {
            NLogInitializerTool.Initialize(ComponentsPath);

            ComponentRegistrationTool componentRegistrationTool = new ComponentRegistrationTool();
            componentRegistrationTool.InitializeSystem();
            componentRegistrationTool.Run();
        }

        public void RunConsole(string[] args)
        {
            ConsoleTool.CreateConsole();

            Console.WriteLine("Service running ... press <ENTER> to stop");

            this.OnStart(args);

            Console.ReadLine();

            ConsoleTool.FreeConsole();

            this.OnStop();
        }
    }
}
