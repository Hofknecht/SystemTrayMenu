using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SystemTrayMenu.Helper;
using SystemTrayMenu.Utilities;
using R = SystemTrayMenu.Properties.Resources;
using Timer = System.Windows.Forms.Timer;

namespace SystemTrayMenu.UserInterface
{
    internal class MenuNotifyIcon : IDisposable
    {
        public event EventHandlerEmpty HandleClick;
        public event EventHandlerEmpty ChangeFolder;
        public event EventHandlerEmpty OpenLog;
        public event EventHandlerEmpty Restart;
        public event EventHandlerEmpty Exit;

        private const int Interval60FPS = 16; //60fps=>1s/60fps=~16.6ms
        private readonly NotifyIcon notifyIcon = new NotifyIcon();
        private DateTime timeLoadingStart;
        private int threadsLoading = 0;
        private readonly Timer load = new Timer();
        private int loadCount = 0;
        private readonly int indexLoad = 0;
        private readonly List<Icon> bitmapsLoading = new List<Icon>() { R.L010, R.L020, R.L030,
            R.L040, R.L050, R.L060, R.L070, R.L080, R.L090, R.L100, R.L110, R.L120,
            R.L130, R.L140, R.L150, R.L160, R.L170, R.L180};

        public MenuNotifyIcon()
        {
            indexLoad = bitmapsLoading.Count;
            notifyIcon.Icon = bitmapsLoading.First();
            load.Tick += Load_Tick;
            load.Interval = Interval60FPS;
            notifyIcon.Text = MenuDefines.NotifyIconText;
            notifyIcon.Visible = true;
            notifyIcon.Icon = R.SystemTrayMenu;
            AppContextMenu contextMenus = new AppContextMenu();
            contextMenus.ClickedChangeFolder += ClickedChangeFolder;
            void ClickedChangeFolder()
            {
                ChangeFolder.Invoke();
            }

            contextMenus.ClickedOpenLog += ClickedOpenLog;
            void ClickedOpenLog()
            {
                OpenLog.Invoke();
            }

            contextMenus.ClickedRestart += ClickedRestart;
            void ClickedRestart()
            {
                Restart.Invoke();
            }

            contextMenus.ClickedExit += ClickedExit;
            void ClickedExit()
            {
                Exit.Invoke();
            }

            notifyIcon.ContextMenuStrip = contextMenus.Create();
            notifyIcon.MouseClick += NotifyIcon_MouseClick;
            void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    HandleClick.Invoke();
                }
            }

            notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;
            void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    HandleClick.Invoke();
                }
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
            threadsLoading++;
            load.Start();
        }

        public void LoadingStop()
        {
            threadsLoading--;
        }
        public void LoadWait()
        {
            notifyIcon.Icon = bitmapsLoading[loadCount++ % indexLoad];
        }
        public void LoadStop()
        {
            notifyIcon.Icon = R.SystemTrayMenu;
        }

        private void Load_Tick(object sender, EventArgs e)
        {
            if (threadsLoading > 0)
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