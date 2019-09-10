using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace RemoteDataAccessor.Common.Classes.Logs
{
    public class ExceptionHandlerTool
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly LogTools _logTools = new LogTools();

        public void HandleInfo(Exception ex, string customMessage)
        {
            _logger.Info(_logTools.GetMessage(customMessage, ex));
        }

        public void HandleWarn(Exception ex, string customMessage)
        {
            _logger.Warn(_logTools.GetMessage(customMessage, ex));
        }

        public void HandleError(Exception ex, string customMessage)
        {
            _logger.Error(_logTools.GetMessage(customMessage, ex));
        }

        public void HandleFatal(Exception ex, string customMessage)
        {
            _logger.Fatal(_logTools.GetMessage(customMessage, ex));
        }

        public void HandleDebug(Exception ex, string customMessage)
        {
            _logger.Debug(_logTools.GetMessage(customMessage, ex));
        }

        public void HandleTrace(Exception ex, string customMessage)
        {
            _logger.Trace(_logTools.GetMessage(customMessage, ex));
        }
    }
}
