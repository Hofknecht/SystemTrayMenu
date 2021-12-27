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

        public App()
        {
            AppRestart.BeforeRestarting += Dispose;
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            menus.LoadStarted += menuNotifyIcon.LoadingStart;
            menus.LoadStopped += menuNotifyIcon.LoadingStop;
            menuNotifyIcon.Click += () => menus.SwitchOpenClose(true);
            menuNotifyIcon.OpenLog += Log.OpenLogFile;
            menus.MainPreload();

            if (Properties.Settings.Default.ShowInTaskbar)
            {
                taskbarForm = new TaskbarForm();
                taskbarForm.Activated += TasbkarItemActivated;
                void TasbkarItemActivated(object sender, EventArgs e)
                {
                    SetStateNormal();
                    taskbarForm.Activate();
                    taskbarForm.Focus();
                    menus.SwitchOpenCloseByTaskbarItem();
                }

                taskbarForm.Resize += TaskbarForm_Resize;
                taskbarForm.FormClosed += TaskbarForm_FormClosed;
                static void TaskbarForm_FormClosed(object sender, FormClosedEventArgs e)
                {
                    Application.Exit();
                }

                taskbarForm.Deactivate += TaskbarForm_Deactivate;
                void TaskbarForm_Resize(object sender, EventArgs e)
                {
                    SetStateNormal();
                }
            }

            DllImports.NativeMethods.User32ShowInactiveTopmost(taskbarForm);
        }

        public void Dispose()
        {
            taskbarForm?.Dispose();
            SystemEvents.DisplaySettingsChanged -= SystemEvents_DisplaySettingsChanged;
            menus.Dispose();
            menuNotifyIcon.Dispose();
        }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            if (menus.IsShortlyAfterOpening())
            {
                Log.Info("Ignored DisplaySettingsChanged, because IsShortlyAfterOpening == true");
            }
            else
            {
                AppRestart.ByDisplaySettings();
            }

            menus.ReAdjustSizeAndLocation();
        }

        private void TaskbarForm_Deactivate(object sender, EventArgs e)
        {
            SetStateNormal();
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