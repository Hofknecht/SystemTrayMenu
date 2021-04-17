// <copyright file="DestroyMenu.cs" company="PlaceholderCompany">
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
        public static bool User32DestroyMenu(IntPtr hMenu)
        {
            return DestroyMenu(hMenu);
        }

        // The DestroyMenu function destroys the specified menu and frees any memory that the menu occupies.
        [DllImport("user32", SetLastError = true, CharSet = CharSet.Unicode)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        private static extern bool DestroyMenu(IntPtr hMenu);
    }
}
