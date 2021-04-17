// <copyright file="StrRetToBuf.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DllImports
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// wraps the methodcalls to native windows dll's.
    /// </summary>
    public static partial class NativeMethods
    {
        public static int ShlwapiStrRetToBuf(IntPtr pstr, IntPtr pidl, StringBuilder pszBuf, int cchBuf)
        {
            return StrRetToBuf(pstr, pidl, pszBuf, cchBuf);
        }

        // Takes a STRRET structure returned by IShellFolder::GetDisplayNameOf, converts it to a string, and places the result in a buffer.
        [DllImport("shlwapi.dll", EntryPoint = "StrRetToBuf", ExactSpelling = false, SetLastError = true, CharSet = CharSet.Unicode)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        private static extern int StrRetToBuf(IntPtr pstr, IntPtr pidl, StringBuilder pszBuf, int cchBuf);
    }
}
