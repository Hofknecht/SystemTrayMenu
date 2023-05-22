// <copyright file="HotKey.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DllImports
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.Versioning;
    using System.Text;

    /// <summary>
    /// wraps the methodcalls to native windows dll's.
    /// </summary>
    public static partial class NativeMethods
    {
        internal static string GetLastErrorHint()
        {
            const int ERROR_HOTKEY_ALREADY_REGISTERED = 1409;

            int error = Marshal.GetLastWin32Error();
            return error switch
            {
                ERROR_HOTKEY_ALREADY_REGISTERED => "ERROR_HOTKEY_ALREADY_REGISTERED",
                _ => error.ToString(),
            };
        }

        [SupportedOSPlatform("windows")]
        [DllImport("user32.dll", EntryPoint = "RegisterHotKey", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool User32RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint virtualKeyCode);

        [SupportedOSPlatform("windows")]
        [DllImport("user32.dll", EntryPoint = "UnregisterHotKey", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        internal static extern bool User32UnregisterHotKey(IntPtr hWnd, int id);

        [SupportedOSPlatform("windows")]
        [DllImport("user32.dll", EntryPoint = "MapVirtualKey", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        internal static extern uint User32MapVirtualKey(uint uCode, uint uMapType);

        [SupportedOSPlatform("windows")]
        [DllImport("user32.dll", EntryPoint = "GetKeyNameText", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        internal static extern int User32GetKeyNameText(uint lParam, [Out] StringBuilder lpString, int nSize);
    }
}
