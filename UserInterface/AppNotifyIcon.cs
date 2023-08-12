// <copyright file="AppNotifyIcon.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Drawing;
    using System.Windows.Threading;
    using H.NotifyIcon.Core;

    internal class AppNotifyIcon : IDisposable
    {
        private readonly Dispatcher dispatchter = Dispatcher.CurrentDispatcher;
        private readonly TrayIconWithContextMenu notifyIcon = new ();
        private Icon? loadingIcon;

        public AppNotifyIcon()
        {
            notifyIcon.ToolTip = "SystemTrayMenu";
            notifyIcon.Icon = Config.GetAppIcon().Handle;
            notifyIcon.ContextMenu = new AppContextMenu().Create();
            notifyIcon.MessageWindow.MouseEventReceived += (sender, e) =>
            {
                if (e.MouseEvent == MouseEvent.IconLeftMouseUp ||
                    e.MouseEvent == MouseEvent.IconLeftDoubleClick)
                {
                    dispatchter.Invoke(() => Click?.Invoke());
                }
            };
            notifyIcon.Create();
        }

        public event Action? Click;

        public void Dispose()
        {
            notifyIcon.Dispose();
            loadingIcon?.Dispose();
        }

        public void LoadingStart()
        {
            loadingIcon ??= App.LoadIconFromResource("Resources/Loading.ico");
            notifyIcon.UpdateIcon(loadingIcon.Handle);
        }

        public void LoadingStop()
        {
            notifyIcon.UpdateIcon(Config.GetAppIcon().Handle);
        }
    }
}