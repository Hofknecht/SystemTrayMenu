// <copyright file="App.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SystemTrayMenu
{
    using System;
    using System.Windows.Forms;
    using Microsoft.Win32;
    using SystemTrayMenu.Business;
    using SystemTrayMenu.UserInterface;
    using SystemTrayMenu.Utilities;

    /// <summary>
    /// App contains the notifyicon, the taskbarform and the menus.
    /// </summary>
    internal class App : IDisposable
    {
        private readonly AppNotifyIcon menuNotifyIcon = new AppNotifyIcon();
        private readonly Menus menus = new Menus();

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            AppRestart.BeforeRestarting += Dispose;
            SystemEvents.DisplaySettingsChanged += AppRestart.ByDisplaySettings;
            menus.LoadStarted += menuNotifyIcon.LoadingStart;
            menus.LoadStopped += menuNotifyIcon.LoadingStop;
            menuNotifyIcon.Exit += Application.Exit;
            menuNotifyIcon.Restart += AppRestart.ByMenuNotifyIcon;
            menuNotifyIcon.Click += MenuNotifyIcon_Click;
            void MenuNotifyIcon_Click()
            {
                menus.SwitchOpenClose(true);
            }

            menuNotifyIcon.OpenLog += Log.OpenLogFile;
            menus.MainPreload();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            SystemEvents.DisplaySettingsChanged -= AppRestart.ByDisplaySettings;
            menus.Dispose();
            menuNotifyIcon.Dispose();
        }
    }
}