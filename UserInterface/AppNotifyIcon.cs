// <copyright file="AppNotifyIcon.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Windows.Forms;
    using SystemTrayMenu.Helper;
    using SystemTrayMenu.Utilities;

    internal class AppNotifyIcon : IDisposable
    {
        private readonly NotifyIcon notifyIcon = new();

        public AppNotifyIcon()
        {
            notifyIcon.Text = "SystemTrayMenu";
            notifyIcon.Icon = Config.GetAppIcon();
            notifyIcon.Visible = true;

            AppContextMenu contextMenus = new();

            contextMenus.ClickedOpenLog += ClickedOpenLog;
            void ClickedOpenLog()
            {
                OpenLog?.Invoke();
            }

            notifyIcon.ContextMenuStrip = contextMenus.Create();
            notifyIcon.MouseClick += NotifyIcon_MouseClick;
            void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
            {
                VerifyClick(e);
            }

            notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;
            void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                VerifyClick(e);
            }
        }

        public event Action Click;

        public event Action OpenLog;

        public void Dispose()
        {
            notifyIcon.Icon = null;
            notifyIcon.Dispose();
        }

        public void LoadingStart()
        {
            notifyIcon.Icon = Resources.StaticResources.LoadingIcon;
        }

        public void LoadingStop()
        {
            notifyIcon.Icon = Config.GetAppIcon();
        }

        private void VerifyClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Click?.Invoke();
            }
        }
    }
}