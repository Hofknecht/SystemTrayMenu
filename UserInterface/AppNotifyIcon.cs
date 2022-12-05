// <copyright file="AppNotifyIcon.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Windows;
    using Hardcodet.Wpf.TaskbarNotification;
    using SystemTrayMenu.Helper;
    using SystemTrayMenu.Utilities;

    internal class AppNotifyIcon : IDisposable
    {
        private readonly TaskbarIcon notifyIcon = new ();

        public AppNotifyIcon()
        {
            notifyIcon.ToolTipText = "SystemTrayMenu";
            notifyIcon.Icon = Config.GetAppIcon();
            notifyIcon.Visibility = Visibility.Visible;
            notifyIcon.ContextMenu = new AppContextMenu().Create();
            notifyIcon.LeftClickCommand = new ActionCommand((_) => Click?.Invoke());
            notifyIcon.DoubleClickCommand = new ActionCommand((_) => Click?.Invoke());
        }

        public event Action? Click;

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
    }
}