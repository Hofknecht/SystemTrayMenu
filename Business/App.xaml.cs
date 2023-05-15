// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu
{
    using System;
    using System.Windows;
    using System.Windows.Threading;
    using SystemTrayMenu.Business;
    using SystemTrayMenu.Helpers.Updater;
    using SystemTrayMenu.Properties;
    using SystemTrayMenu.UserInterface;
    using SystemTrayMenu.Utilities;

    /// <summary>
    /// App contains the notifyicon, the taskbarform and the menus.
    /// </summary>
    public partial class App : Application, IDisposable
    {
        private static TaskbarLogo? taskbarLogo;
        private readonly AppNotifyIcon menuNotifyIcon = new();
        private readonly Menus menus = new();
        private bool isDisposed;

        public App()
        {
            AppRestart.BeforeRestarting += Dispose;
            menus.LoadStarted += menuNotifyIcon.LoadingStart;
            menus.LoadStopped += menuNotifyIcon.LoadingStop;
            menuNotifyIcon.Click += () => menus.SwitchOpenClose(true, false);

            Activated += (_, _) => IsActiveApp = true;
            Deactivated += (_, _) => IsActiveApp = false;

            Startup += (_, _) =>
            {
                if (Settings.Default.ShowInTaskbar)
                {
                    taskbarLogo = new();
                    taskbarLogo.Activated += (_, _) => menus.SwitchOpenCloseByTaskbarItem();
                    taskbarLogo.Show();
                }
                else
                {
                    menus.SwitchOpenClose(false, true);
                }

                if (Settings.Default.CheckForUpdates)
                {
                    _ = Dispatcher.InvokeAsync(
                        () => GitHubUpdate.ActivateNewVersionFormOrCheckForUpdates(showWhenUpToDate: false),
                        DispatcherPriority.ApplicationIdle);
                }
            };
        }

        internal static bool IsActiveApp { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                taskbarLogo?.Close();
                taskbarLogo = null;

                menus.Dispose();
                menuNotifyIcon.Dispose();

                isDisposed = true;
            }
        }
    }
}
