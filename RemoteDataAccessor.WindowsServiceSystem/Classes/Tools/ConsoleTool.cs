using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace RemoteDataAccessor.WindowsServiceSystem.Classes.Tools
{
    public class ConsoleTool
    {
        // P/Invoke required:
        private const UInt32 StdOutputHandle = 0xFFFFFFF5;
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(UInt32 nStdHandle);
        [DllImport("kernel32.dll")]
        private static extern void SetStdHandle(UInt32 nStdHandle, IntPtr handle);
        [DllImport("kernel32")]
        static extern bool AllocConsole();
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool FreeConsole();

        public static void CreateConsole()
        {
            AllocConsole();

            IntPtr defaultStdout = new IntPtr(7); // stdout's handle seems to always be equal to 7
            IntPtr currentStdout = GetStdHandle(StdOutputHandle);

            if (currentStdout != defaultStdout)
            {
                SetStdHandle(StdOutputHandle, defaultStdout); // reset stdout
            }

            // reopen stdout
            TextWriter writer = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true };
            Console.SetOut(writer);
            Console.OutputEncoding = Encoding.UTF8;
        }
    }
}
