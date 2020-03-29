using System;
using System.Drawing;
using System.Runtime.InteropServices;
using static SystemTrayMenu.DllImports.NativeMethods;

namespace SystemTrayMenu.Helper.Taskbar
{
    public enum TaskbarPosition
    {
        Unknown = -1,
        Left,
        Top,
        Right,
        Bottom,
    }

    //Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager do not have the bounds implemented?
    public sealed class Taskbar
    {
        private const string ClassName = "Shell_TrayWnd";

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
        //Always returns false under Windows 7
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

        public Taskbar()
        {
            IntPtr taskbarHandle = DllImports.NativeMethods.User32FindWindow(Taskbar.ClassName, null);

            APPBARDATA data = new APPBARDATA
            {
                cbSize = (uint)Marshal.SizeOf(typeof(APPBARDATA)),
                hWnd = taskbarHandle
            };
            IntPtr result = DllImports.NativeMethods.Shell32SHAppBarMessage(ABM.GetTaskbarPos, ref data);
            if (result == IntPtr.Zero)
            {
                //throw new InvalidOperationException();
                Bounds = new Rectangle(20, 20, 20, 20);
            }
            else
            {
                Position = (TaskbarPosition)data.uEdge;
                Bounds = Rectangle.FromLTRB(data.rc.left, data.rc.top, data.rc.right, data.rc.bottom);

                data.cbSize = (uint)Marshal.SizeOf(typeof(APPBARDATA));
                result = DllImports.NativeMethods.Shell32SHAppBarMessage(ABM.GetState, ref data);
                int state = result.ToInt32();
                AlwaysOnTop = (state & ABS.AlwaysOnTop) == ABS.AlwaysOnTop;
                AutoHide = (state & ABS.Autohide) == ABS.Autohide;
            }
        }
    }
}
