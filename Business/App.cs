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
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            menus.LoadStarted += menuNotifyIcon.LoadingStart;
            menus.LoadStopped += menuNotifyIcon.LoadingStop;
            menuNotifyIcon.Click += MenuNotifyIcon_Click;
            menuNotifyIcon.OpenLog += Log.OpenLogFile;
            menus.MainPreload();

            if (Properties.Settings.Default.ShowInTaskbar)
            {
                taskbarForm = new TaskbarForm();
                taskbarForm.FormClosed += TaskbarForm_FormClosed;
                taskbarForm.Deactivate += SetStateNormal;
                taskbarForm.Resize += SetStateNormal;
                taskbarForm.Activated += TasbkarItemActivated;
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
            if (taskbarForm?.InvokeRequired == true)
            {
                taskbarForm.Invoke(Dispose);
            }
            else
            {
                AppRestart.BeforeRestarting -= Dispose;
                SystemEvents.DisplaySettingsChanged -= SystemEvents_DisplaySettingsChanged;
                menus.LoadStarted -= menuNotifyIcon.LoadingStart;
                menus.LoadStopped -= menuNotifyIcon.LoadingStop;
                menus.Dispose();
                menuNotifyIcon.Click -= MenuNotifyIcon_Click;
                menuNotifyIcon.OpenLog -= Log.OpenLogFile;
                menuNotifyIcon.Dispose();
                if (taskbarForm != null)
                {
                    taskbarForm.FormClosed -= TaskbarForm_FormClosed;
                    taskbarForm.Deactivate -= SetStateNormal;
                    taskbarForm.Resize -= SetStateNormal;
                    taskbarForm.Activated -= TasbkarItemActivated;
                    taskbarForm.Dispose();
                }
            }
        }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            menus.ReAdjustSizeAndLocation();
        }

        private void MenuNotifyIcon_Click()
        {
            menus.SwitchOpenClose(true);
        }

        private void TaskbarForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// This ensures that next click on taskbaritem works as activate event/click event.
        /// </summary>
        private void SetStateNormal(object sender, EventArgs e)
        {
            if (Form.ActiveForm == taskbarForm)
            {
                taskbarForm.WindowState = FormWindowState.Normal;
            }
        }

        private void TasbkarItemActivated(object sender, EventArgs e)
        {
            SetStateNormal(sender, e);
            taskbarForm.Activate();
            taskbarForm.Focus();
            menus.SwitchOpenCloseByTaskbarItem();
        }
    }
}