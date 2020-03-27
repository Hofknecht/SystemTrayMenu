using System;
using System.Runtime.InteropServices;

namespace SystemTrayMenu.NativeMethods
{
    public static partial class NativeMethods
    {
        // The DestroyMenu function destroys the specified menu and frees any memory that the menu occupies.
        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool DestroyMenu(IntPtr hMenu);

        public static bool User32DestroyMenu(IntPtr hMenu)
        {
            return DestroyMenu(hMenu);
        }
    }
}
