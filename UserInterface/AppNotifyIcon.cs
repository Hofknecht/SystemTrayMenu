// <copyright file="AppNotifyIcon.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using SystemTrayMenu.Helper;
    using SystemTrayMenu.Utilities;
    using R = SystemTrayMenu.Properties.Resources;
    using Timer = System.Windows.Forms.Timer;

    internal class AppNotifyIcon : IDisposable
    {
        private const int Interval60FPS = 16; // 60fps=>1s/60fps=~16.6ms
        private readonly Timer load = new Timer();
        private readonly NotifyIcon notifyIcon = new NotifyIcon();
        private readonly int indexLoad = 0;
        private readonly List<Icon> bitmapsLoading = new List<Icon>()
        {
            R.L010, R.L020, R.L030,
            R.L040, R.L050, R.L060, R.L070, R.L080, R.L090, R.L100, R.L110, R.L120,
            R.L130, R.L140, R.L150, R.L160, R.L170, R.L180,
        };

        private DateTime timeLoadingStart;
        private bool threadsLoading = false;
        private int loadCount = 0;

        public AppNotifyIcon()
        {
            indexLoad = bitmapsLoading.Count;
            notifyIcon.Icon = bitmapsLoading.First();
            load.Tick += Load_Tick;
            load.Interval = Interval60FPS;
            notifyIcon.Text = Translator.GetText("SystemTrayMenu");
            notifyIcon.Visible = true;
            notifyIcon.Icon = R.SystemTrayMenu;
            AppContextMenu contextMenus = new AppContextMenu();

            contextMenus.ClickedOpenLog += ClickedOpenLog;
            void ClickedOpenLog()
            {
                OpenLog?.Invoke();
            }

            contextMenus.ClickedRestart += ClickedRestart;
            void ClickedRestart()
            {
                Restart?.Invoke();
            }

            contextMenus.ClickedExit += ClickedExit;
            void ClickedExit()
            {
                Exit?.Invoke();
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

        public event EventHandlerEmpty Click;

        public event EventHandlerEmpty OpenLog;

        public event EventHandlerEmpty Restart;

        public event EventHandlerEmpty Exit;

        private void VerifyClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Click?.Invoke();
            }
        }

        public void Dispose()
        {
            notifyIcon.Icon = null;
            notifyIcon.Dispose();
            load.Dispose();
        }

        public void LoadingStart()
        {
            timeLoadingStart = DateTime.Now;
            threadsLoading = true;
            load.Start();
        }

        public void LoadingStop()
        {
            threadsLoading = false;
        }

        private void Load_Tick(object sender, EventArgs e)
        {
            if (threadsLoading)
            {
                if (DateTime.Now - timeLoadingStart > new TimeSpan(0, 0, 0, 0, 500))
                {
                    notifyIcon.Icon = bitmapsLoading[loadCount++ % indexLoad];
                }
            }
            else
            {
                notifyIcon.Icon = R.SystemTrayMenu;
                load.Stop();
            }
        }
    }
}