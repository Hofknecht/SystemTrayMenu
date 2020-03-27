using System;
using System.Runtime.InteropServices;

namespace SystemTrayMenu.NativeDllImport
{
    public static partial class NativeMethods
    {
        [DllImport("User32.dll")]
        private static extern int DestroyIcon(IntPtr hIcon);

        public static void User32DestroyIcon(IntPtr hIcon)
        {
            _ = DestroyIcon(hIcon);
        }
    }
}
