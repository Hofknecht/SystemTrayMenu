using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace SystemTrayMenu
{
    public enum TaskbarPosition
    {
        Unknown = -1,
        Left,
        Top,
        Right,
        Bottom,
    }

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
            IntPtr taskbarHandle = NativeMethods.NativeMethods.User32FindWindow(Taskbar.ClassName, null);

            APPBARDATA data = new APPBARDATA
            {
                cbSize = (uint)Marshal.SizeOf(typeof(APPBARDATA)),
                hWnd = taskbarHandle
            };
            IntPtr result = NativeMethods.NativeMethods.Shell32SHAppBarMessage(ABM.GetTaskbarPos, ref data);
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
                result = NativeMethods.NativeMethods.Shell32SHAppBarMessage(ABM.GetState, ref data);
                int state = result.ToInt32();
                AlwaysOnTop = (state & ABS.AlwaysOnTop) == ABS.AlwaysOnTop;
                AutoHide = (state & ABS.Autohide) == ABS.Autohide;
            }
        }
    }

    public enum ABM : uint
    {
        New = 0x00000000,
        Remove = 0x00000001,
        QueryPos = 0x00000002,
        SetPos = 0x00000003,
        GetState = 0x00000004,
        GetTaskbarPos = 0x00000005,
        Activate = 0x00000006,
        GetAutoHideBar = 0x00000007,
        SetAutoHideBar = 0x00000008,
        WindowPosChanged = 0x00000009,
        SetState = 0x0000000A,
    }

    public enum ABE : uint
    {
        Left = 0,
        Top = 1,
        Right = 2,
        Bottom = 3
    }

    public static class ABS
    {
        public const int Autohide = 0x0000001;
        public const int AlwaysOnTop = 0x0000002;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct APPBARDATA
    {
        public uint cbSize;
        public IntPtr hWnd;
        public uint uCallbackMessage;
        public ABE uEdge;
        public RECT rc;
        public int lParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
}
