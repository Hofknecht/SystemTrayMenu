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

        public App()
        {
            AppRestart.BeforeRestarting += Dispose;
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            menus.LoadStarted += menuNotifyIcon.LoadingStart;
            menus.LoadStopped += menuNotifyIcon.LoadingStop;
            menuNotifyIcon.Exit += Application.Exit;
            menuNotifyIcon.Restart += AppRestart.ByMenuNotifyIcon;
            menuNotifyIcon.Click += () => menus.SwitchOpenClose(true);
            menuNotifyIcon.OpenLog += Log.OpenLogFile;
            menus.MainPreload();
        }

        public void Dispose()
        {
            SystemEvents.DisplaySettingsChanged -= SystemEvents_DisplaySettingsChanged;
            menus.Dispose();
            menuNotifyIcon.Dispose();
        }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            if (!menus.IsOpenCloseStateOpening())
            {
                AppRestart.ByDisplaySettings();
            }
        }
    }
}