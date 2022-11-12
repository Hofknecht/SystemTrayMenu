﻿// <copyright file="ShowWindow.cs" company="PlaceholderCompany">
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

            if (Environment.Is64BitProcess)
            {
                long exStyle = (long)GetWindowLongPtr(wndHelper.Handle, GWL_EXSTYLE);
                exStyle |= WS_EX_TOOLWINDOW; // do not show when user presses alt + tab
                SetWindowLongPtr(wndHelper.Handle, GWL_EXSTYLE, (IntPtr)exStyle);
            }
            else
            {
                int exStyle = (int)GetWindowLong(wndHelper.Handle, GWL_EXSTYLE);
                exStyle |= WS_EX_TOOLWINDOW; // do not show when user presses alt + tab
                SetWindowLong(wndHelper.Handle, GWL_EXSTYLE, (IntPtr)exStyle);
            }
        }

        /// <summary>
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowlongw .
        /// </summary>
        [SupportedOSPlatform("windows")]
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

        /// <summary>
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowlongptrw .
        /// </summary>
        [SupportedOSPlatform("windows")]
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

        /// <summary>
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowlongw .
        /// </summary>
        [SupportedOSPlatform("windows")]
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        /// <summary>
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowlongptrw .
        /// </summary>
        [SupportedOSPlatform("windows")]
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
    }
}
