using Microsoft.Win32;
using System;
using System.Windows.Forms;
using SystemTrayMenu.Business;
using SystemTrayMenu.DataClasses;
using SystemTrayMenu.Helper;
using SystemTrayMenu.UserInterface;
using SystemTrayMenu.Utilities;

namespace SystemTrayMenu
{
    internal class App : IDisposable
    {
        private readonly MenuNotifyIcon menuNotifyIcon = new MenuNotifyIcon();
        private readonly Menus menus = new Menus();
        private TaskbarForm taskbarForm = new TaskbarForm();

        public App()
        {
            Screen screen = Screen.PrimaryScreen;
            Statics.ScreenHeight = screen.Bounds.Height;
            Statics.ScreenWidth = screen.Bounds.Width;
            Statics.ScreenRight = screen.Bounds.Right;
            Statics.TaskbarHeight = new WindowsTaskbar().Size.Height;
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
            taskbarForm.Activated += TasbkarItemActivated;
            taskbarForm.Resize += TaskbarForm_Resize;
            taskbarForm.FormClosed += TaskbarForm_FormClosed;
            DllImports.NativeMethods.User32ShowInactiveTopmost(taskbarForm);
        }

        private void TaskbarForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TaskbarForm_Resize(object sender, EventArgs e)
        {
            if (taskbarForm.WindowState != FormWindowState.Minimized)
            {
                taskbarForm.WindowState = FormWindowState.Minimized;
            }
        }

        internal void TasbkarItemActivated(object sender, EventArgs e)
        {
            menus.SwitchOpenCloseByTaskbarItem();
        }

        public void Dispose()
        {
            taskbarForm.Dispose();
            menus.Dispose();
            menuNotifyIcon.Dispose();
        }
    }
}