using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SystemTrayMenu.Helper
{
    public class WindowToTop
    {
        [DllImport("user32.dll")]
        static extern bool IsIconic(IntPtr hWnd);

        //DLL's for ForceForgroundWindow
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentThreadId();
        [DllImport("user32.dll")]
        public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool BringWindowToTop(IntPtr hWnd);
        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern bool BringWindowToTop(HandleRef hWnd);
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_RESTORE = 9;

        public static void ForceProcessToForeground(string processName)
        {
            Process[] proc = Process.GetProcessesByName(processName);
            ForceForegroundWindow(proc[0].MainWindowHandle);
        }
        public static void ForceForegroundWindow(IntPtr hWnd)
        {
            uint foreThread = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero);
            uint appThread = GetCurrentThreadId();
            const int SW_SHOW = 5;

            int cmdShow = SW_SHOW;

            if (IsIconic(hWnd))
            {
                cmdShow = SW_RESTORE;
            }

            if (foreThread != appThread)
            {
                AttachThreadInput(foreThread, appThread, true);
                BringWindowToTop(hWnd);
                ShowWindow(hWnd, cmdShow);
                AttachThreadInput(foreThread, appThread, false);
            }
            else
            {
                BringWindowToTop(hWnd);
                ShowWindow(hWnd, cmdShow);
            }
        }
    }
}