// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu
{
    using System;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;
    using SystemTrayMenu.Utilities;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            try
            {
                Log.Initialize();
                SingleAppInstance.Initialize();
                Translator.Initialize();

                Config.UpgradeIfNotUpgraded();
                if (Config.LoadOrSetByUser())
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.ThreadException += ThreadException;
                    static void ThreadException(object s, ThreadExceptionEventArgs t)
                    {
                        AskUserSendError(t.Exception);
                    }

                    Scaling.Initialize();
                    FolderOptions.Initialize();

                    using (new App())
                    {
                        Log.WriteApplicationRuns();
                        Application.Run();
                    }
                }
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // => Represents ThreadException during attached to process
            {
                AskUserSendError(ex);
            }
            finally
            {
                Log.Close();
            }

            static void AskUserSendError(Exception ex)
            {
                Log.Error("Application Crashed", ex);

                if (MessageBox.Show(
                    "A problem has been encountered and the application needs to restart. " +
                    "Reporting this error will help us make our product better. " +
                    "Press yes to open your standard email app.",
                    "SystemTrayMenu BugSplat",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Log.ProcessStart("mailto:" + "markus@hofknecht.eu" +
                        "?subject=SystemTrayMenu Bug reported " +
                        Assembly.GetEntryAssembly().GetName().Version +
                        "&body=" + ex.ToString());
                }

                AppRestart.ByThreadException();
            }
        }
    }
}