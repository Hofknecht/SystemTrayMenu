using System.Runtime.InteropServices;

namespace SystemTrayMenu.DllImports
{
    public static partial class NativeMethods
    {
        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

        public static bool IsTouchEnabled()
        {
            const int MAXTOUCHES_INDEX = 95;
            int maxTouches = GetSystemMetrics(MAXTOUCHES_INDEX);

            return maxTouches > 0;
        }
    }
}
