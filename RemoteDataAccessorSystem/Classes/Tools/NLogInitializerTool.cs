using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using NLog;

namespace RemoteDataAccessorSystem.Classes.Tools
{
    public class NLogInitializerTool
    {
        public static void Initialize(string componentsPath)
        {
            GlobalDiagnosticsContext.Set("logDir", $@"{componentsPath}\logs");
        }
    }
}
