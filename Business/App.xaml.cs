// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu
{
    using System;
    using System.Windows;
    using System.Windows.Threading;
    using SystemTrayMenu.Business;
    using SystemTrayMenu.Helpers;
    using SystemTrayMenu.Helpers.Updater;
    using SystemTrayMenu.Properties;
    using SystemTrayMenu.Utilities;

    /// <summary>
    /// App contains the notifyicon, the taskbarform and the menus.
    /// </summary>
    public partial class App : Application, IDisposable
    {
        private readonly Menus menus = new();
        private JoystickHelper? joystickHelper;
        private bool isDisposed;

        public App()
        {
            AppRestart.BeforeRestarting += Dispose;

            Activated += (_, _) => IsActiveApp = true;
            Deactivated += (_, _) => IsActiveApp = false;
            Startup += (_, _) =>
            {
                menus.Startup();

                if (Settings.Default.SupportGamepad)
                {
                    joystickHelper = new();
                    joystickHelper.KeyPressed += menus.KeyPressed;
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
                if (joystickHelper != null)
                {
                    joystickHelper.KeyPressed -= menus.KeyPressed;
                    joystickHelper.Dispose();
                }

                menus.Dispose();

                isDisposed = true;
            }
        }
    }
}
