// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu
{
    using System;
    using System.Reflection;
    using System.Windows;
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

                if (SingleAppInstance.Initialize())
                {
                    AppDomain currentDomain = AppDomain.CurrentDomain;
                    currentDomain.UnhandledException += (sender, args)
                        => AskUserSendError((Exception)args.ExceptionObject);

                    Scaling.Initialize();
                    FolderOptions.Initialize();

                    using (App app = new App())
                    {
                        app.InitializeComponent();
                        isStartup = false;
                        Log.WriteApplicationRuns();
                        app.Run();
                    }
                }
            }
            catch (Exception ex)
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

                MessageBoxResult dialogResult = MessageBox.Show(
                    "A problem has been encountered and the application needs to restart. " +
                    "Reporting this error will help us make our product better. " +
                    "Press 'Yes' to open your standard email app (emailto: Markus@Hofknecht.eu). " + Environment.NewLine +
                    @"You can also create an issue manually here https://github.com/Hofknecht/SystemTrayMenu/issues" + Environment.NewLine +
                    "Press 'Cancel' to quit SystemTrayMenu.",
                    "SystemTrayMenu Crashed",
                    MessageBoxButton.YesNoCancel);

                if (dialogResult == MessageBoxResult.Yes)
                {
                    Version? version = Assembly.GetEntryAssembly()?.GetName().Version;
                    Log.ProcessStart("mailto:" + "markus@hofknecht.eu" +
                        "?subject=SystemTrayMenu Bug reported " +
                        (version != null ? version.ToString() : string.Empty) +
                        "&body=" + ex.ToString());
                }

                if (!isStartup && dialogResult != MessageBoxResult.Cancel)
                {
                    AppRestart.ByThreadException();
                }
            }
        }
    }
}