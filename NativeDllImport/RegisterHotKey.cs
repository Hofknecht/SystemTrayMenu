// <copyright file="RegisterHotKey.cs" company="PlaceholderCompany">
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
        public static bool User32RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk)
        {
            return RegisterHotKey(hWnd, id, fsModifiers, vk);
        }

        public static bool User32UnregisterHotKey(IntPtr hWnd, int id)
        {
            return UnregisterHotKey(hWnd, id);
        }

        public static uint User32MapVirtualKey(uint uCode, uint uMapType)
        {
            return MapVirtualKey(uCode, uMapType);
        }

        public static int User32GetKeyNameText(uint lParam, [Out] StringBuilder lpString, int nSize)
        {
            return GetKeyNameText(lParam, lpString, nSize);
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint virtualKeyCode);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        private static extern int GetKeyNameText(uint lParam, [Out] StringBuilder lpString, int nSize);
    }
}
