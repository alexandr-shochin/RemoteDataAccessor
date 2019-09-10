using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDataAccessor.Common.Classes.Constatnts
{
    public static class CommonConstants
    {
        public static readonly string ApplicationName = Process.GetCurrentProcess().ProcessName;

        public const string DateTimeFormat = "dd.MM.yyyy HH:mm:ss:fff";
    }
}
