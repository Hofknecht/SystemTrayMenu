// <copyright file="GetMenuDefaultItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DllImports
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// wraps the methodcalls to native windows dll's.
    /// </summary>
    public static partial class NativeMethods
    {
        public static int User32GetMenuDefaultItem(IntPtr hMenu, bool fByPos, uint gmdiFlags)
        {
            return GetMenuDefaultItem(hMenu, fByPos, gmdiFlags);
        }

        // Determines the default menu item on the specified menu
        [DllImport("user32", SetLastError = true, CharSet = CharSet.Unicode)]

        private static extern int GetMenuDefaultItem(IntPtr hMenu, bool fByPos, uint gmdiFlags);
    }
}
