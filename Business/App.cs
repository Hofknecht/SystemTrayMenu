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
        private readonly AppNotifyIcon menuNotifyIcon = new();
        private readonly Menus menus = new();
        private readonly TaskbarForm taskbarForm = null;
        private readonly Timer timerActivateMenuAfterTaskbarFormMinimizedFinished = new();

        public App()
        {
            AppRestart.BeforeRestarting += Dispose;
            SystemEvents.DisplaySettingsChanged += (s, e) => SystemEvents_DisplaySettingsChanged();
            menus.LoadStarted += menuNotifyIcon.LoadingStart;
            menus.LoadStopped += menuNotifyIcon.LoadingStop;
            menuNotifyIcon.Click += () => menus.SwitchOpenClose(true);
            menuNotifyIcon.OpenLog += Log.OpenLogFile;
            menus.MainPreload();
            timerActivateMenuAfterTaskbarFormMinimizedFinished.Interval = 20;
            timerActivateMenuAfterTaskbarFormMinimizedFinished.Tick += Timer_Tick;

            void Timer_Tick(object sender, EventArgs e)
            {
                timerActivateMenuAfterTaskbarFormMinimizedFinished.Stop();
                if (menus.IsNotNullAndIsUsableAndNotClosing())
                {
                    taskbarForm.Activate();
                    menus.ReActivateIfVisible();
                }
            }

            if (Properties.Settings.Default.ShowInTaskbar)
            {
                taskbarForm = new TaskbarForm();
                taskbarForm.FormClosed += (s, e) => Application.Exit();
                int eachSecondResizeEvent = 1;
                taskbarForm.Resize += (s, e) =>
                {
                    if (eachSecondResizeEvent++ % 2 == 0 && Form.ActiveForm != null)
                    {
                        menus.SwitchOpenCloseByTaskbarItem();
                        timerActivateMenuAfterTaskbarFormMinimizedFinished.Start();
                    }

                    taskbarForm.WindowState = FormWindowState.Minimized;
                };

                taskbarForm.Show();
            }
        }

        public void Dispose()
        {
            taskbarForm?.Dispose();
            timerActivateMenuAfterTaskbarFormMinimizedFinished.Dispose();
            SystemEvents.DisplaySettingsChanged -= (s, e) => SystemEvents_DisplaySettingsChanged();
            menus.Dispose();
            menuNotifyIcon.Dispose();
        }

        private void SystemEvents_DisplaySettingsChanged()
        {
            menus.ReAdjustSizeAndLocation();
        }
    }
}