// <copyright file="AppRestart.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Windows;

    internal class AppRestart
    {
        public static event Action? BeforeRestarting;

        internal static void ByThreadException()
        {
            Restart(GetCurrentMethod());
        }

        internal static void ByAppContextMenu()
        {
            Restart(GetCurrentMethod());
        }

        internal static void ByConfigChange()
        {
            Restart(GetCurrentMethod());
        }

        internal static void ByMenuButton()
        {
            Restart(GetCurrentMethod());
        }

        private static void Restart(string? reason)
        {
            BeforeRestarting?.Invoke();
            Log.Info($"Restart by '{reason ?? "unkown"}'");
            Log.Close();

            using (Process p = new())
            {
                string? fileName = System.Environment.ProcessPath;
                if (string.IsNullOrEmpty(fileName))
                {
                    Log.Warn("Restart failed", new());
                }
                else
                {
                    p.StartInfo = new ProcessStartInfo(fileName);

                    try
                    {
                        p.Start();
                    }
                    catch (Win32Exception ex)
                    {
                        Log.Warn("Restart failed", ex);
                    }
                }
            }

            Application.Current.Shutdown();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string? GetCurrentMethod()
        {
            StackTrace st = new();
            StackFrame? sf = st.GetFrame(1);

            return sf?.GetMethod()?.Name;
        }
    }
}
