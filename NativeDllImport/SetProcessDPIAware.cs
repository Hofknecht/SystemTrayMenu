using System.Runtime.InteropServices;

namespace SystemTrayMenu.NativeDllImport
{
    public static partial class NativeMethods
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        public static void User32SetProcessDPIAware()
        {
            _ = SetProcessDPIAware();
        }
    }
}
