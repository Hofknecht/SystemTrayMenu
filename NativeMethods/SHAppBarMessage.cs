using System;
using System.Runtime.InteropServices;

namespace SystemTrayMenu.NativeMethods
{
    public static partial class NativeMethods
    {
        [DllImport("shell32.dll", SetLastError = true)]
        private static extern IntPtr SHAppBarMessage(ABM dwMessage, [In] ref APPBARDATA pData);

        public static IntPtr Shell32SHAppBarMessage(ABM dwMessage, [In] ref APPBARDATA pData)
        {
            return SHAppBarMessage(dwMessage, ref pData);
        }
    }
}
