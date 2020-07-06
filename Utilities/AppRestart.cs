// <copyright file="AppRestart.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    internal class AppRestart
    {
        public static event EventHandlerEmpty BeforeRestarting;

        private static void Restart(string reason)
        {
            BeforeRestarting?.Invoke();
            Log.Info($"Restart by '{reason}'");
            Log.Close();

            using (Process p = new Process())
            {
                p.StartInfo = new ProcessStartInfo(
                    Process.GetCurrentProcess().
                    MainModule.FileName);
                p.Start();
            }

            Application.Exit();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        internal static void ByThreadException()
        {
            Restart(GetCurrentMethod());
        }

        internal static void ByMenuNotifyIcon()
        {
            Restart(GetCurrentMethod());
        }

        internal static void ByDisplaySettings(object sender, EventArgs e)
        {
            Restart(GetCurrentMethod());
        }

        internal static void ByConfigChange()
        {
            Restart(GetCurrentMethod());
        }
    }
}
