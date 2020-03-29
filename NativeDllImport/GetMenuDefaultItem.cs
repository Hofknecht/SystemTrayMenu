using System;
using System.Runtime.InteropServices;

namespace SystemTrayMenu.DllImports
{
    public static partial class NativeMethods
    {
        // Determines the default menu item on the specified menu
        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetMenuDefaultItem(IntPtr hMenu, bool fByPos, uint gmdiFlags);

        public static int User32GetMenuDefaultItem(IntPtr hMenu, bool fByPos, uint gmdiFlags)
        {
            return GetMenuDefaultItem(hMenu, fByPos, gmdiFlags);
        }
    }
}
