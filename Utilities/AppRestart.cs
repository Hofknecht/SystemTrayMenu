using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using EventHandler = SystemTrayMenu.Helper.EventHandler;

namespace SystemTrayMenu.Utilities
{
    internal class AppRestart
    {
        public static event EventHandler BeforeRestarting;

        private static void Restart(string reason)
        {
            BeforeRestarting?.Invoke();
            Log.Info($"Restart by '{reason}'");
            Log.Close();
            Process.Start(Assembly.GetExecutingAssembly().
                ManifestModule.FullyQualifiedName);
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
