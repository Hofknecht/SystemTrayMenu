using System;
using System.Runtime.InteropServices;

namespace SystemTrayMenu.DllImports
{
    public static partial class NativeMethods
    {
        // The DestroyMenu function destroys the specified menu and frees any memory that the menu occupies.
        [DllImport("user32", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool DestroyMenu(IntPtr hMenu);

        public static bool User32DestroyMenu(IntPtr hMenu)
        {
            return DestroyMenu(hMenu);
        }
    }
}
