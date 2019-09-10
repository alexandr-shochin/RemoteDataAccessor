using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using RemoteDataAccessor.Common.Classes.Logs;

using NLog;

namespace RemoteDataAccessor.WindowsServiceSystem
{
    static class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(15 * 1000);

            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            WindowsServiceSystemCore serviceToRun = new WindowsServiceSystemCore();

            if (args.Length > 0 && args[0] == "console")
            {
                serviceToRun.RunConsole(args);
            }
            else
                ServiceBase.Run(serviceToRun);
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            LogTools logTools = new LogTools();
            string message = logTools.GetMessage($"{nameof(AppDomain.CurrentDomain.UnhandledException)}.", (Exception)e.ExceptionObject);

            logTools.WriteLogToFile<Fatal>(message);
            logTools.WriteLogToConsole<Fatal>(message);

            LogManager.Flush();
        }
    }
}
