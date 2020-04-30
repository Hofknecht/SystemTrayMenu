using Microsoft.Win32;
using System;
using System.Windows.Forms;
using SystemTrayMenu.Business;
using SystemTrayMenu.UserInterface;
using SystemTrayMenu.Utilities;

namespace SystemTrayMenu
{
    internal class SystemTrayMenu : IDisposable
    {
        private readonly MenuNotifyIcon menuNotifyIcon = new MenuNotifyIcon();
        private Menus menus = new Menus();

        public SystemTrayMenu()
        {
            AppRestart.BeforeRestarting += Dispose;
            SystemEvents.DisplaySettingsChanged += AppRestart.ByDisplaySettings;
            menus.LoadStarted += menuNotifyIcon.LoadingStart;
            menus.LoadStopped += menuNotifyIcon.LoadingStop;
            menuNotifyIcon.Exit += Application.Exit;
            menuNotifyIcon.Restart += AppRestart.ByMenuNotifyIcon;
            menuNotifyIcon.Click += menus.SwitchOpenClose;
            menuNotifyIcon.OpenLog += Log.OpenLogFile;
            menuNotifyIcon.ChangeFolder += ChangeFolder;
            void ChangeFolder()
            {
                if (Config.SetFolderByUser())
                {
                    AppRestart.ByConfigChange();
                }
            }

            menus.MainPreload();
        }

        public void Dispose()
        {
            menus.Dispose();
            menuNotifyIcon.Dispose();
        }
    }
}