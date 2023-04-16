// <copyright file="WindowsTaskbar.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helpers
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using static SystemTrayMenu.DllImports.NativeMethods;

    public enum TaskbarPosition
    {
        Unknown = -1,
        Left,
        Top,
        Right,
        Bottom,
    }

    public sealed class WindowsTaskbar
    {
        private const string ClassName = "Shell_TrayWnd";

        public WindowsTaskbar()
        {
            IntPtr taskbarHandle = User32FindWindow(ClassName, null);

            APPBARDATA data = new()
            {
                cbSize = (uint)Marshal.SizeOf(typeof(APPBARDATA)),
                hWnd = taskbarHandle,
            };
            IntPtr result = Shell32SHAppBarMessage(ABM.GetTaskbarPos, ref data);
            if (result == IntPtr.Zero)
            {
                Bounds = new Rectangle(20, 20, 20, 20);
            }
            else
            {
                Position = (TaskbarPosition)data.uEdge;
                Bounds = Rectangle.FromLTRB(data.rc.left, data.rc.top, data.rc.right, data.rc.bottom);

                data.cbSize = (uint)Marshal.SizeOf(typeof(APPBARDATA));
                result = Shell32SHAppBarMessage(ABM.GetState, ref data);
                int state = result.ToInt32();
                AlwaysOnTop = (state & ABS.AlwaysOnTop) == ABS.AlwaysOnTop;
                AutoHide = (state & ABS.Autohide) == ABS.Autohide;
            }
        }

        public Rectangle Bounds
        {
            get;
            private set;
        }

        public TaskbarPosition Position
        {
            get;
            private set;
        }

        public Point Location => Bounds.Location;

        public Size Size => Bounds.Size;

        public bool AlwaysOnTop
        {
            get;
            private set;
        }

        public bool AutoHide
        {
            get;
            private set;
        }
    }
}
