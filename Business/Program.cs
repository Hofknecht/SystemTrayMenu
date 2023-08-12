// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;
    using SystemTrayMenu.Utilities;

    internal static class Program
    {
        private static bool isStartup = true;

        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                Log.Initialize();
                Translator.Initialize();
                Config.SetFolderByWindowsContextMenu(args);
                Config.LoadOrSetByUser();
                Config.Initialize();
                PrivilegeChecker.Initialize();

                if (SingleAppInstance.Initialize())
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.ThreadException += Application_ThreadException;
                    Scaling.Initialize();
                    FolderOptions.Initialize();

                    using (new App())
                    {
                        isStartup = false;
                        Log.WriteApplicationRuns();
                        Application.Run();
                    }
                }

                Application.ThreadException -= Application_ThreadException;
                Config.Dispose();
            }
            catch (Exception ex)
            {
                AskUserSendError(ex);
            }
            finally
            {
                Log.Close();
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            AskUserSendError(e.Exception);
        }

        private static void AskUserSendError(Exception ex)
        {
            Log.Error("Application Crashed", ex);

            DialogResult dialogResult = MessageBox.Show(
                "A problem has been encountered and the application needs to restart. " +
                "Reporting this error will help us make our product better. " +
                "Press 'Yes' to open your standard email app (emailto: Markus@Hofknecht.eu). " + Environment.NewLine +
                @"You can also create an issue manually here https://github.com/Hofknecht/SystemTrayMenu/issues" + Environment.NewLine +
                "Press 'Cancel' to quit SystemTrayMenu.",
                "SystemTrayMenu Crashed",
                MessageBoxButtons.YesNoCancel);

            if (dialogResult == DialogResult.Yes)
            {
                Log.ProcessStart("mailto:" + "markus@hofknecht.eu" +
                    "?subject=SystemTrayMenu Bug reported " +
                    Assembly.GetEntryAssembly().GetName().Version +
                    "&body=" + ex.ToString());
            }

            if (!isStartup && dialogResult != DialogResult.Cancel)
            {
                AppRestart.ByThreadException();
            }
        }
    }
}