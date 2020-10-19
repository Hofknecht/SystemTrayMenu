// <copyright file="FindWindow.cs" company="PlaceholderCompany">
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
        public static IntPtr User32FindWindow(string lpClassName, string lpWindowName)
        {
            return FindWindow(lpClassName, lpWindowName);
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]

        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    }
}
