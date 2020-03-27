using System;
using System.Runtime.InteropServices;

namespace SystemTrayMenu.NativeMethods
{
    public static partial class NativeMethods
    {
        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        public static int Gdi32GetDeviceCaps(IntPtr hdc, int nIndex)
        {
            return GetDeviceCaps(hdc, nIndex);
        }
    }
}
