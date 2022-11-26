using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AutoTyperGUI.Model
{
    internal class Win32ErrorHandler
    {
        [DllImport("kernel32.dll")]
        private static extern int FormatMessage(FORMAT_MESSAGE dwFlags, IntPtr lpSource, int dwMessageId, uint dwLanguageId, out StringBuilder msgOut, int nSize, IntPtr Arguments);

        [DllImport("kernel32.dll")]
        private static extern uint GetLastError();

        public static string GetLastErrorString()
        {
            uint lastError = GetLastError();
            if (0 == lastError) return ("");
            else
            {
                StringBuilder msgOut = new StringBuilder(256);
                int size = FormatMessage(FORMAT_MESSAGE.ALLOCATE_BUFFER | FORMAT_MESSAGE.FROM_SYSTEM | FORMAT_MESSAGE.IGNORE_INSERTS,
                              IntPtr.Zero, (int)lastError, 0, out msgOut, msgOut.Capacity, IntPtr.Zero);
                return (msgOut.ToString().Trim());
            }
        }

        enum FORMAT_MESSAGE : uint
        {
            ALLOCATE_BUFFER = 0x00000100,
            IGNORE_INSERTS = 0x00000200,
            FROM_SYSTEM = 0x00001000,
            ARGUMENT_ARRAY = 0x00002000,
            FROM_HMODULE = 0x00000800,
            FROM_STRING = 0x00000400
        }
    }
}
