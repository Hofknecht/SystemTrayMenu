// <copyright file="IShellItemImageFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DllImports
{
    using System;
    using System.Runtime.InteropServices;

    [ComImport]
    [Guid("bcc18b79-ba16-442f-80c4-8a59c30c463b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IShellItemImageFactory
    {
        void GetImage(
        [In, MarshalAs(UnmanagedType.Struct)] SIZE size,
        [In] SIIGBF flags,
        [Out] out IntPtr phbm);
    }
}
