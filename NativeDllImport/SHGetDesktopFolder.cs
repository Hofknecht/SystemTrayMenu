// <copyright file="SHGetDesktopFolder.cs" company="PlaceholderCompany">
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
        // Retrieves the IShellFolder interface for the desktop folder, which is the root of the Shell's namespace.
        [DllImport("shell32.dll")]
        private static extern int SHGetDesktopFolder(out IntPtr ppshf);

        public static int Shell32SHGetDesktopFolder(out IntPtr ppshf)
        {
            return SHGetDesktopFolder(out ppshf);
        }
    }
}
