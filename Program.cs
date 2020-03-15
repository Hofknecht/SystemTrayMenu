using Clearcove.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SystemTrayMenu
{
    static class Program
    {
        public static readonly List<string> Languages =
            new List<string>() { "en", "de" };
        public static CultureInfo Culture;
        public static float ScalingFactor = 1;

        private const string IconDir = "Icons\\";


        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Logger log = new Logger(nameof(Program));
            Logger.Start(new FileInfo(GetLogFilePath()));

            if (IsAppAlreadyRunning("SystemTrayMenu"))
            {
                KillOtherSystemTrayMenus();
            }

            GetDefaultLanguage();

            ScalingFactor = GetScalingFactor();
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            try
            {
                bool cancelAppRun = false;
                using (new SystemTrayMenu(ref cancelAppRun))
                {
                    if (!cancelAppRun)
                    {
                        Application.ThreadException += Application_ThreadException;
                        void Application_ThreadException(object sender, ThreadExceptionEventArgs threadException)
                        {
                            AskUserSendErrorAndRestartApp(log, threadException.Exception);
                        }
                        Application.Run();
                    }
                }
            }
            catch (Exception ex)
            {
                AskUserSendErrorAndRestartApp(log, ex);
            }
            finally
            {
                Logger.ShutDown();
            }
        }

        static void AskUserSendErrorAndRestartApp(Logger log, Exception exception)
        {
            log.Error($"{exception.ToString()}");

            if (MessageBox.Show("A problem has been encountered and the application needs to restart. " +
                "Reporting this error will help us make our product better. Press yes to open your standard email app.",
                "SystemTrayMenu BugSplat", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Process.Start("mailto:" + "markus@hofknecht.eu" +
                    "?subject=SystemTrayMenu Bug reported" +
                    "&body=" + exception.ToString());
            }

            Logger.ShutDown();
            Process.Start(Assembly.GetExecutingAssembly().
                ManifestModule.FullyQualifiedName);
        }

        static bool KillOtherSystemTrayMenus()
        {
            bool killedAProcess = false;
            int ownPID = Process.GetCurrentProcess().Id;

            try
            {
                foreach (Process p in
                    Process.GetProcessesByName("SystemTrayMenu").
                    Where(p => p.Id != ownPID))
                {
                    p.Kill();
                    p.WaitForExit();
                    killedAProcess = true;
                }
            }
            catch (Exception exception)
            {
                Logger log = new Logger(nameof(Program));
                log.Warn($"{exception.ToString()}");
            }

            return killedAProcess;
        }

        static bool IsAppAlreadyRunning(string processName)
        {
            foreach (Process p in Process.GetProcessesByName(processName).
                Where(s => s.Id != Process.GetCurrentProcess().Id))
            {
                return true;
            }

            return false;
        }

        internal static string GetLogFilePath()
        {
            return Path.Combine(Path.GetDirectoryName(
               System.Reflection.Assembly.GetExecutingAssembly().Location),
                   $"log-{System.Environment.MachineName}.txt");
        }

        private static void GetDefaultLanguage()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.
                            CurrentCultureInfoName))
            {
                Properties.Settings.Default.CurrentCultureInfoName = "en";
                CultureInfo currentCulture = Thread.CurrentThread.
                    CurrentCulture;
                foreach (string language in Languages)
                {
                    string twoLetter = currentCulture.Name.Substring(0, 2);
                    if (language == currentCulture.Name ||
                        language == twoLetter)
                    {
                        Properties.Settings.Default.CurrentCultureInfoName =
                            language;
                    }
                }
                Properties.Settings.Default.Save();
            }

            Culture = CultureInfo.CreateSpecificCulture(
                Properties.Settings.Default.CurrentCultureInfoName);
        }

        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        public enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,

            // http://pinvoke.net/default.aspx/gdi32/GetDeviceCaps.html
        }

        static float GetScalingFactor()
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);

            float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;

            return ScreenScalingFactor; // 1.25 = 125%
        }

        internal static string Translate(string id)
        {
            ResourceManager rm = new ResourceManager(
                "SystemTrayMenu.Resources.lang",
                typeof(Menu).Assembly);
            return rm.GetString(id, Culture);
        }
    }
}