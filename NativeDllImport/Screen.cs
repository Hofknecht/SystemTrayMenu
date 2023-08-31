// <copyright file="Screen.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2022-2023 Peter Kirmeier

namespace SystemTrayMenu.DllImports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Runtime.Versioning;
    using System.Windows;

    /// <summary>
    /// wraps the methodcalls to native windows dll's.
    /// </summary>
    public static partial class NativeMethods
    {
        public static bool IsTouchEnabled()
        {
            const int MAXTOUCHES_INDEX = 95;
            int maxTouches = GetSystemMetrics(MAXTOUCHES_INDEX);

            return maxTouches > 0;
        }

        [SupportedOSPlatform("windows")]
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
        private static extern int GetSystemMetrics(int nIndex);

        public static class Screen
        {
            private static Point LastCursorPosition = new Point(0, 0);

            private static List<Rect>? screens;

            public static List<Rect> Screens
            {
                get
                {
                    if ((screens == null) || (screens.Count == 0))
                    {
                        FetchScreens();
                    }

                    if ((screens == null) || (screens.Count == 0))
                    {
                        return new()
                        {
                            new (0, 0, 800, 600),
                        };
                    }

                    return screens;
                }
            }

            // The primary screen will have x = 0, y = 0 coordinates
            public static Rect PrimaryScreen => Screens.FirstOrDefault((screen) => screen.Left == 0 && screen.Top == 0, Screens[0]);

            public static Point CursorPosition
            {
                get
                {
#if TODO // Maybe use Windows.Desktop instead of Win32 API?
         // See: https://learn.microsoft.com/en-us/dotnet/api/system.windows.input.mouse.getposition?view=windowsdesktop-8.0
                    if (Mouse.Capture(menu))
                    {
                        LastCursorPosition = Mouse.GetPosition(menu);
                        Mouse.Capture(null);
                    }
#else
                    NativeMethods.POINT lpPoint;
                    if (NativeMethods.GetCursorPos(out lpPoint))
                    {
                        LastCursorPosition = new(lpPoint.X, lpPoint.Y);
                    }
#endif
                    return LastCursorPosition;
                }
            }

            public static Rect FromPoint(Point pt)
            {
                foreach (Rect screen in Screens)
                {
                    if (screen.Contains(pt))
                    {
                        return screen;
                    }
                }

                // Use primary screen as fallback
                return Screens[0];
            }

            internal static void FetchScreens()
            {
                var backup = screens;
                screens = new();
                if (!NativeMethods.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorEnumCallback, IntPtr.Zero))
                {
                    screens = backup;
                }
            }

            private static bool MonitorEnumCallback(IntPtr hMonitor, IntPtr hdcMonitor, ref NativeMethods.RECT lprcMonitor, IntPtr dwData)
            {
                try
                {
                    screens!.Add(new()
                    {
                        X = lprcMonitor.left,
                        Y = lprcMonitor.top,
                        Width = lprcMonitor.right - lprcMonitor.left,
                        Height = lprcMonitor.bottom - lprcMonitor.top,
                    });
                }
                catch
                {
                    // Catch everything as this callback runs within a native context
                }

                return true;
            }

            private class NativeMethods
            {
                public delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);

                /// <summary>
                /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumdisplaymonitors .
                /// </summary>
                [SupportedOSPlatform("windows")]
                [DllImport("user32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
                [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
                public static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, IntPtr dwData);

                /// <summary>
                /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getcursorpos .
                /// </summary>
                [SupportedOSPlatform("windows")]
                [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
                [DefaultDllImportSearchPaths(DllImportSearchPath.UserDirectories)]
                public static extern bool GetCursorPos(out POINT lpPoint);

                [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
                internal struct RECT
                {
                    public int left;
                    public int top;
                    public int right;
                    public int bottom;
                }

                [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
                internal struct POINT
                {
                    public int X;
                    public int Y;
                }
            }
        }
    }
}
