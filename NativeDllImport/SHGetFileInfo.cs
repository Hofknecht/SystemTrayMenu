// <copyright file="SHGetFileInfo.cs" company="PlaceholderCompany">
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
        private const int maxPath = 256;

        internal static IntPtr Shell32SHGetFileInfo(
           string pszPath,
           uint dwFileAttributes,
           ref SHFILEINFO psfi,
           uint cbFileInfo,
           uint uFlags)
        {
            return SHGetFileInfo(
                pszPath,
                dwFileAttributes,
                ref psfi,
                cbFileInfo,
                uFlags);
        }

        [DllImport("Shell32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        private static extern IntPtr SHGetFileInfo(
           string pszPath,
           uint dwFileAttributes,
           ref SHFILEINFO psfi,
           uint cbFileInfo,
           uint uFlags);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]

        internal struct SHFILEINFO
        {
            public const int NAMESIZE = 80;
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = maxPath)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NAMESIZE)]
            public string szTypeName;
        }
    }
}
