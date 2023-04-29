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
                    "A problem has been encountered and SystemTrayMenu needs to restart. " +
                    "Reporting this error will help us making our product better." +
                    Environment.NewLine + Environment.NewLine +
                    "We kindly ask you to press 'Yes' and send us the crash report before restarting the application. " +
                    "This will open your standard email app and prepare a mail that you can directly send off. " +
                    "Alternatively, you can also create an issue manually here: https://github.com/Hofknecht/SystemTrayMenu/issues" +
                    Environment.NewLine + Environment.NewLine +
                    "Pressing 'No' will only restart the application." +
                    Environment.NewLine +
                    "Pressing 'Cancel' will quit the application.",
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
