using System;
using System.IO;
using System.Threading;

using RemoteDataAccessorSystem.Classes.Tools;
using RemoteDataAccessor.Common.Classes.Logs;

namespace RemoteDataAccessorSystem
{
    class Program
    {
        public static readonly string ComponentsPath = Directory.GetCurrentDirectory() + @"\Modules";

        static void Main(string[] args)
        {
            //Thread.Sleep(15 * 1000);

            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            NLogInitializerTool.Initialize(ComponentsPath);

            ComponentRegistrationTool componentRegistrationTool = new ComponentRegistrationTool();
            componentRegistrationTool.InitializeSystem();
            componentRegistrationTool.Run();


            Console.ReadLine();
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            LogTools logTools = new LogTools();
            string message = logTools.GetMessage($"{nameof(AppDomain.CurrentDomain.UnhandledException)}.", (Exception)e.ExceptionObject);

            logTools.WriteLogToFile<Fatal>(message);
            logTools.WriteLogToConsole<Fatal>(message);

            Thread.Sleep(5 * 1000);
            Environment.Exit(-1);
        }
    }
}
