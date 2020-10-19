// <copyright file="StrCmpLogicalW.cs" company="PlaceholderCompany">
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
        public static int ShlwapiStrCmpLogicalW(string x, string y)
        {
            return StrCmpLogicalW(x, y);
        }

        [DllImport("shlwapi.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Unicode)]

        private static extern int StrCmpLogicalW(string x, string y);
    }
}
