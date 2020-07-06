// <copyright file="SetProcessDPIAware.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DllImports
{
    using System.Runtime.InteropServices;
    /// <summary>
    /// wraps the methodcalls to native windows dll's.
    /// </summary>
    public static partial class NativeMethods
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        public static void User32SetProcessDPIAware()
        {
            _ = SetProcessDPIAware();
        }
    }
}
