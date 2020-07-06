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
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int StrCmpLogicalW(string x, string y);

        public static int ShlwapiStrCmpLogicalW(string x, string y)
        {
            return StrCmpLogicalW(x, y);
        }
    }
}
