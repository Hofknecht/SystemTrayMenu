// <copyright file="Menu.cs" company="PlaceholderCompany">
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
        /// <summary>
        /// Specifies how TrackPopupMenuEx positions the shortcut menu horizontally.
        /// </summary>
        [Flags]
        internal enum TPM : uint
        {
            LEFTBUTTON = 0x0000, // LEFTALIGN = 0x0000, // TOPALIGN = 0x0000, // HORIZONTAL = 0x0000,
            RIGHTBUTTON = 0x0002,
            CENTERALIGN = 0x0004,
            RIGHTALIGN = 0x0008,
            VCENTERALIGN = 0x0010,
            BOTTOMALIGN = 0x0020,
            VERTICAL = 0x0040,
            NONOTIFY = 0x0080,
            RETURNCMD = 0x0100,
            RECURSE = 0x0001,
            HORPOSANIMATION = 0x0400,
            HORNEGANIMATION = 0x0800,
            VERPOSANIMATION = 0x1000,
            VERNEGANIMATION = 0x2000,
            NOANIMATION = 0x4000,
            LAYOUTRTL = 0x8000,
        }

        // The CreatePopupMenu function creates a drop-down menu, submenu, or shortcut menu. The menu is initially empty. You can insert or append menu items by using the InsertMenuItem function. You can also use the InsertMenu function to insert menu items and the AppendMenu function to append menu items.
        [SupportedOSPlatform("windows")]
        [DllImport("user32", EntryPoint = "CreatePopupMenu", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        internal static extern IntPtr User32CreatePopupMenu();

        // The DestroyMenu function destroys the specified menu and frees any memory that the menu occupies.
        [SupportedOSPlatform("windows")]
        [DllImport("user32", EntryPoint = "DestroyMenu", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        internal static extern bool User32DestroyMenu(IntPtr hMenu);

        /// <summary>
        /// user32 TrackPopupMenuEx.
        /// The TrackPopupMenuEx function displays a shortcut menu at the specified location and
        /// tracks the selection of items on the shortcut menu. The shortcut menu can appear anywhere on the screen.
        /// </summary>
        /// <param name="hmenu">hmenu.</param>
        /// <param name="flags">flags.</param>
        /// <param name="x">x.</param>
        /// <param name="y">y.</param>
        /// <param name="hwnd">hwnd.</param>
        /// <param name="lptpm">lptpm.</param>
        /// <returns>uint.</returns>
        [SupportedOSPlatform("windows")]
        [DllImport("user32.dll", EntryPoint = "TrackPopupMenuEx", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        internal static extern uint User32TrackPopupMenuEx(IntPtr hmenu, TPM flags, int x, int y, IntPtr hwnd, IntPtr lptpm);
    }
}
