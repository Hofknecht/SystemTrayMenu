﻿// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable enable

namespace SystemTrayMenu
{
    using System;
    using System.Windows;
    using System.Windows.Threading;
    using Microsoft.Win32;
    using SystemTrayMenu.Business;
    using SystemTrayMenu.Helper.Updater;
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
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            menus.LoadStarted += menuNotifyIcon.LoadingStart;
            menus.LoadStopped += menuNotifyIcon.LoadingStop;
            menuNotifyIcon.Click += () => menus.SwitchOpenClose(true);
            menuNotifyIcon.OpenLog += Log.OpenLogFile;
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

                SystemEvents.DisplaySettingsChanged -= SystemEvents_DisplaySettingsChanged;
                menus.Dispose();
                menuNotifyIcon.Dispose();

                isDisposed = true;
            }
        }

        private void SystemEvents_DisplaySettingsChanged(object? sender, EventArgs e)
        {
            menus.ReAdjustSizeAndLocation();
        }
    }
}
