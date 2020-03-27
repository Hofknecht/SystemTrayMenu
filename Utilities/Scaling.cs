using System;
using System.Drawing;

namespace SystemTrayMenu.Utilities
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
                    NativeDllImport.NativeMethods.User32SetProcessDPIAware();
                }
            }
        }

        private static void CalculateScalingFactor()
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int LogicalScreenHeight = NativeDllImport.NativeMethods.Gdi32GetDeviceCaps(
                desktop, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = NativeDllImport.NativeMethods.Gdi32GetDeviceCaps(
                desktop, (int)DeviceCap.DESKTOPVERTRES);
            Factor = PhysicalScreenHeight / (float)LogicalScreenHeight;
        }
    }
}
