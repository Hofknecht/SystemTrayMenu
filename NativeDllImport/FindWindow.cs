// <copyright file="FindWindow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DllImports
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.Versioning;

    /// <summary>
    /// wraps the methodcalls to native windows dll's.
    /// </summary>
    public static partial class NativeMethods
    {
        public static IntPtr User32FindWindow(string? lpClassName, string? lpWindowName)
        {
            return FindWindow(lpClassName, lpWindowName);
        }

        /// <summary>
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-findwindoww .
        /// </summary>
        [SupportedOSPlatform("windows")]
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        private static extern IntPtr FindWindow(string? lpClassName, string? lpWindowName);
    }
}
