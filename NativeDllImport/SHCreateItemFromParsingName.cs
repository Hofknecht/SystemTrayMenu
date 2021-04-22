// <copyright file="SHCreateItemFromParsingName.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DllImports
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    /// <summary>
    /// wraps the methodcalls to native windows dll's.
    /// </summary>
    public static partial class NativeMethods
    {
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void SHCreateItemFromParsingName(
       [In][MarshalAs(UnmanagedType.LPWStr)] string pszPath,
       [In] IntPtr pbc,
       [In][MarshalAs(UnmanagedType.LPStruct)] Guid riid,
       [Out][MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out IShellItem ppv);
    }
}
