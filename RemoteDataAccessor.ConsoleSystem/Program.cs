using System;
using System.IO;
using System.Threading;

using RemoteDataAccessor.Common.Classes.Logs;
using RemoteDataAccessor.ConsoleSystem.Classes.Tools;

using NLog;

namespace RemoteDataAccessor.ConsoleSystem
{
    class Program
    {
        public static readonly string ComponentsPath = Directory.GetCurrentDirectory() + @"\Modules";

        private static Thread _starterThread;

        static void Main(string[] args)
        {
            Thread.Sleep(15 * 1000);

            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            _starterThread = new Thread(StarterThreadHandler) { IsBackground = true };
            _starterThread.Start();

            Console.ReadLine();
        }

        private static void StarterThreadHandler()
        {
            NLogInitializerTool.Initialize(ComponentsPath);

            ComponentRegistrationTool componentRegistrationTool = new ComponentRegistrationTool();
            componentRegistrationTool.InitializeSystem();
            componentRegistrationTool.Run();
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            LogTools logTools = new LogTools();
            string message = logTools.GetMessage($"{nameof(AppDomain.CurrentDomain.UnhandledException)}.", (Exception)e.ExceptionObject);

            logTools.WriteLogToFile<Fatal>(message);
            logTools.WriteLogToConsole<Fatal>(message);

            LogManager.Flush();
            Environment.Exit(-1);
        }
    }
}
