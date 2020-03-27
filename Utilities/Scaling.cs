using System;
using System.Drawing;

namespace SystemTrayMenu.Helper
{
    internal static class Scaling
    {
        internal static float Factor = 1;

        private enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,
        }

        internal static void Initialize()
        {
            CalculateScalingFactor();
            SetProcessDPIAwareWhenNecessary();
            void SetProcessDPIAwareWhenNecessary()
            {
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    NativeMethods.NativeMethods.User32SetProcessDPIAware();
                }
            }
        }

        private static void CalculateScalingFactor()
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int LogicalScreenHeight = NativeMethods.NativeMethods.Gdi32GetDeviceCaps(
                desktop, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = NativeMethods.NativeMethods.Gdi32GetDeviceCaps(
                desktop, (int)DeviceCap.DESKTOPVERTRES);
            Factor = PhysicalScreenHeight / (float)LogicalScreenHeight;
        }
    }
}
