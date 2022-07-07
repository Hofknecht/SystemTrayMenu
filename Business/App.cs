// <copyright file="App.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SystemTrayMenu
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using Microsoft.Win32;
    using SystemTrayMenu.Business;
    using SystemTrayMenu.Helper.Updater;
    using SystemTrayMenu.UserInterface;
    using SystemTrayMenu.Utilities;

    /// <summary>
    /// App contains the notifyicon, the taskbarform and the menus.
    /// </summary>
    internal class App : IDisposable
    {
        private readonly AppNotifyIcon menuNotifyIcon = new();
        private readonly Menus menus = new();
        private readonly TaskbarForm taskbarForm = null;

        public App()
        {
            AppRestart.BeforeRestarting += Dispose;
            SystemEvents.DisplaySettingsChanged += (s, e) => SystemEvents_DisplaySettingsChanged();
            menus.LoadStarted += menuNotifyIcon.LoadingStart;
            menus.LoadStopped += menuNotifyIcon.LoadingStop;
            menuNotifyIcon.Click += () => menus.SwitchOpenClose(true);
            menuNotifyIcon.OpenLog += Log.OpenLogFile;
            menus.MainPreload();

            if (Properties.Settings.Default.ShowInTaskbar)
            {
                taskbarForm = new TaskbarForm();
                taskbarForm.FormClosed += (s, e) => Application.Exit();
                taskbarForm.Deactivate += (s, e) => SetStateNormal();
                taskbarForm.Resize += (s, e) => SetStateNormal();
                taskbarForm.Activated += TasbkarItemActivated;
                void TasbkarItemActivated(object sender, EventArgs e)
                {
                    SetStateNormal();
                    taskbarForm.Activate();
                    taskbarForm.Focus();
                    menus.SwitchOpenCloseByTaskbarItem();
                }
            }

            DllImports.NativeMethods.User32ShowInactiveTopmost(taskbarForm);

            if (Properties.Settings.Default.CheckForUpdates)
            {
                new Thread((obj) => GitHubUpdate.ActivateNewVersionFormOrCheckForUpdates(
                    showWhenUpToDate: false))
                    .Start();
            }
        }

        public void Dispose()
        {
            taskbarForm?.Dispose();
            SystemEvents.DisplaySettingsChanged -= (s, e) => SystemEvents_DisplaySettingsChanged();
            menus.Dispose();
            menuNotifyIcon.Dispose();
        }

        private void SystemEvents_DisplaySettingsChanged()
        {
            menus.ReAdjustSizeAndLocation();
        }

        /// <summary>
        /// This ensures that next click on taskbaritem works as activate event/click event.
        /// </summary>
        private void SetStateNormal()
        {
            if (Form.ActiveForm == taskbarForm)
            {
                taskbarForm.WindowState = FormWindowState.Normal;
            }
        }
    }
}