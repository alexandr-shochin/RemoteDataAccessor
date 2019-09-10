using System;
using System.IO;
using System.Threading;
using NLog;
using RemoteDataAccessor.Common.Classes.Logs;

namespace RemoteDataAccessor.ConsoleSystem
{
    class Program
    {
        public static readonly string ComponentsPath = Directory.GetCurrentDirectory() + @"\Modules";

        static void Main(string[] args)
        {
            //Thread.Sleep(15 * 1000);

            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;


            Console.ReadLine();
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
