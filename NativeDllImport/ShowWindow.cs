// <copyright file="ShowWindow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2022-2022 Peter Kirmeier

#nullable enable

namespace SystemTrayMenu.DllImports
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.Versioning;
    using System.Windows;
    using System.Windows.Interop;

    /// <summary>
    /// wraps the methodcalls to native windows dll's.
    /// </summary>
    public static partial class NativeMethods
    {
        private const int WS_EX_TOOLWINDOW = 0x00000080;
        private const int GWL_EXSTYLE = -20;

        internal static void HideFromAltTab(Window window)
        {
            WindowInteropHelper wndHelper = new WindowInteropHelper(window);

            int exStyle = (int)GetWindowLongPtr(wndHelper.Handle, GWL_EXSTYLE);
            exStyle |= WS_EX_TOOLWINDOW; // do not show when user presses alt + tab
            SetWindowLongPtr(wndHelper.Handle, GWL_EXSTYLE, (IntPtr)exStyle);
        }

        /// <summary>
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowlongptrw .
        /// </summary>
        [SupportedOSPlatform("windows")]
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

        /// <summary>
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowlongptrw .
        /// </summary>
        [SupportedOSPlatform("windows")]
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
    }
}
