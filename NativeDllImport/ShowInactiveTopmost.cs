using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SystemTrayMenu.DllImports
{
    public static partial class NativeMethods
    {
        private const int SW_SHOWNOACTIVATE = 4;
        private const int HWND_TOPMOST = -1;
        private const uint SWP_NOACTIVATE = 0x0010;

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        private static extern bool SetWindowPos(
             int hWnd,             // Window handle
             int hWndInsertAfter,  // Placement-order handle
             int X,                // Horizontal position
             int Y,                // Vertical position
             int cx,               // Width
             int cy,               // Height
             uint uFlags);         // Window positioning flags

        public static void User32ShowInactiveTopmost(Form form)
        {
            if (form != null)
            {
                _ = ShowWindow(form.Handle, SW_SHOWNOACTIVATE);
                SetWindowPos(form.Handle.ToInt32(), HWND_TOPMOST,
                form.Left, form.Top, form.Width, form.Height,
                SWP_NOACTIVATE);
            }
        }
    }
}
