// <copyright file="DestroyIcon.cs" company="PlaceholderCompany">
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
        [DllImport("User32.dll")]
        private static extern int DestroyIcon(IntPtr hIcon);

        public static void User32DestroyIcon(IntPtr hIcon)
        {
            _ = DestroyIcon(hIcon);
        }
    }
}
