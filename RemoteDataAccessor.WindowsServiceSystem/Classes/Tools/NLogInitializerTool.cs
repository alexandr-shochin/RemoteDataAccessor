using NLog;

namespace RemoteDataAccessor.WindowsServiceSystem.Classes.Tools
{
    public class NLogInitializerTool
    {
        public static void Initialize(string componentsPath)
        {
            GlobalDiagnosticsContext.Set("logDir", $@"{componentsPath}\logs");
        }
    }
}
