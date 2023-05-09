// <copyright file="Icon.cs" company="PlaceholderCompany">
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
        public const uint ShgfiIcon = 0x000000100;     // get icon
        public const uint ShgfiSYSICONINDEX = 0x000004000;     // get system icon index
        public const uint ShgfiLINKOVERLAY = 0x000008000;     // put a link overlay on icon
        public const uint ShgfiLARGEICON = 0x000000000;     // get large icon
        public const uint ShgfiSMALLICON = 0x000000001;     // get small icon
        public const uint ShgfiOPENICON = 0x000000002;     // get open icon
        public const uint FileAttributeDirectory = 0x00000010;
        public const uint FileAttributeNormal = 0x00000080;
        public const int IldTransparent = 0x00000001;

        /// <summary>
        /// comctl32 ImageList_GetIcon(IntPtr himl, int i, int flags).
        /// </summary>
        /// <param name="himl">himl.</param>
        /// <param name="i">i.</param>
        /// <param name="flags">flags.</param>
        /// <returns>IntPtr.</returns>
        [SupportedOSPlatform("windows")]
        [DllImport("comctl32", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        internal static extern IntPtr ImageList_GetIcon(
          IntPtr himl,
          int i,
          int flags);

        [SupportedOSPlatform("windows")]
        [DllImport("User32.dll", EntryPoint = "DestroyIcon", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        internal static extern int User32DestroyIcon(IntPtr hIcon);
    }
}
