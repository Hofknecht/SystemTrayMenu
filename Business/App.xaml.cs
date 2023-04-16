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
        private readonly AppNotifyIcon menuNotifyIcon = new();
        private readonly Menus menus = new();
        private bool isDisposed;

        public App()
        {
            AppRestart.BeforeRestarting += Dispose;
            menus.LoadStarted += menuNotifyIcon.LoadingStart;
            menus.LoadStopped += menuNotifyIcon.LoadingStop;
            menuNotifyIcon.Click += () => menus.SwitchOpenClose(true);
            menus.MainPreload();

            if (Settings.Default.ShowInTaskbar)
            {
                TaskbarLogo = new TaskbarLogo();
                TaskbarLogo.Activated += (_, _) => menus.SwitchOpenCloseByTaskbarItem();
                TaskbarLogo.Show();
            }

            if (Settings.Default.CheckForUpdates)
            {
                Dispatcher.InvokeAsync(
                    () => GitHubUpdate.ActivateNewVersionFormOrCheckForUpdates(showWhenUpToDate: false),
                    DispatcherPriority.ApplicationIdle);
            }
        }

        public static TaskbarLogo? TaskbarLogo { get; private set; } = null;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                TaskbarLogo?.Close();
                TaskbarLogo = null;

                menus.Dispose();
                menuNotifyIcon.Dispose();

                isDisposed = true;
            }
        }
    }
}
