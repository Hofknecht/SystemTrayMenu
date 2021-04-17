// <copyright file="GetDeviceCaps.cs" company="PlaceholderCompany">
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
        public static int Gdi32GetDeviceCaps(IntPtr hdc, int nIndex)
        {
            return GetDeviceCaps(hdc, nIndex);
        }

        [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
    }
}
