using System;
using System.Collections.Generic;

using RemoteDataAccessor.Common.Classes.Constatnts;
using RemoteDataAccessor.Common.Properties;

using NLog;

namespace RemoteDataAccessor.Common.Classes.Logs
{
    public class LogTools
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public string GetMessage(string customMessage, Exception ex)
        {
            List<string> lines = new List<string>();

            lines.Add($"{customMessage} {ex.Message}");
            lines.Add($"{nameof(ex.StackTrace)}: {ex.StackTrace}");

            if (ex is AggregateException)
            {
                foreach (Exception exception in ((AggregateException)ex).InnerExceptions)
                {
                    lines.Add($"{customMessage} {exception.Message}");
                    lines.Add($"{nameof(exception.StackTrace)}: {exception.StackTrace}");

                    if (exception.InnerException != null)
                    {
                        lines.Add($"{nameof(exception.InnerException)} {nameof(exception.InnerException.Message)}: {exception.InnerException.Message}");
                        lines.Add($"{nameof(exception.InnerException)} {nameof(exception.InnerException.StackTrace)}: {exception.InnerException.StackTrace}");
                    }
                }
            }
            else
            {
                while (ex.InnerException != null)
                {
                    lines.Add($"{nameof(ex.InnerException)} {nameof(ex.InnerException.Message)}: {ex.InnerException.Message}");
                    lines.Add($"{nameof(ex.InnerException)} {nameof(ex.InnerException.StackTrace)}: {ex.InnerException.StackTrace}");

                    ex = ex.InnerException;
                }
            }

            return string.Join("\n", lines);
        }

        public void WriteLogToConsole<TLevel>(string customMessage, Exception ex)
        {
            InternalWriteLogToConsole<TLevel>(GetMessage(customMessage, ex));
        }

        public void WriteLogToConsole<TLevel>(string message)
        {
            InternalWriteLogToConsole<TLevel>(message);
        }

        public void WriteLogToConsole<TLevel>(Exception ex)
        {
            InternalWriteLogToConsole<TLevel>(GetMessage(string.Empty, ex));
        }

        public void WriteLogToFile<TLevel>(string customMessage, Exception ex)
        {
            InternalWriteLogToFile<TLevel>(GetMessage(customMessage, ex));
        }

        public void WriteLogToFile<TLevel>(string message)
        {
            InternalWriteLogToFile<TLevel>(message);
        }

        public void WriteLogToFile<TLevel>(Exception ex)
        {
            InternalWriteLogToFile<TLevel>(GetMessage(string.Empty, ex));
        }

        private void InternalWriteLogToConsole<TLevel>(string message)
        {
            Console.WriteLine(Resources.InternalWriteLogToConsoleMessage, DateTime.Now.ToString(CommonConstatnts.DateTimeFormat), CommonConstatnts.ApplicationName, typeof(TLevel).Name, message);
        }

        private void InternalWriteLogToFile<TLevel>(string message)
        {
            if (typeof(TLevel).Name == typeof(Info).Name)
            {
                _logger.Info(message);
            }
            else if (typeof(TLevel).Name == typeof(Warn).Name)
            {
                _logger.Warn(message);
            }
            else if (typeof(TLevel).Name == typeof(Error).Name)
            {
                _logger.Error(message);
            }
            else if (typeof(TLevel).Name == typeof(Fatal).Name)
            {
                _logger.Fatal(message);
            }
            else if (typeof(TLevel).Name == typeof(Debug).Name)
            {
                _logger.Debug(message);
            }
            else if (typeof(TLevel).Name == typeof(Trace).Name)
            {
                _logger.Trace(message);
            }
        }
    }
}
