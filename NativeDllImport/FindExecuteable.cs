// <copyright file="FindExecuteable.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DllImports
{
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// wraps the methodcalls to native windows dll's.
    /// </summary>
    public static partial class NativeMethods
    {
        public static void Shell32FindExecutable(string lpFile, string lpDirectory, [Out] StringBuilder lpResult)
        {
            _ = FindExecutable(lpFile, lpDirectory, lpResult);
        }

        [DllImport("shell32.dll", SetLastError = true, CharSet = CharSet.Unicode)]

        private static extern int FindExecutable(string lpFile, string lpDirectory, [Out] StringBuilder lpResult);
    }
}
