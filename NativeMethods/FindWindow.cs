using System;
using System.Runtime.InteropServices;

namespace SystemTrayMenu.NativeMethods
{
    public static partial class NativeMethods
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public static IntPtr User32FindWindow(string lpClassName, string lpWindowName)
        {
            return FindWindow(lpClassName, lpWindowName);
        }
    }
}
