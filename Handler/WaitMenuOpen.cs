using System;
using Timer = System.Windows.Forms.Timer;

namespace SystemTrayMenu.Handler
{
    internal class WaitMenuOpen : IDisposable
    {
        public event EventHandler DoOpen;

        private Timer waitOpen = new Timer();
        private bool waitedDone = false;
        private bool clicked = false;
        private bool menuLoaded = false;

        public WaitMenuOpen()
        {
            waitOpen.Interval = MenuDefines.WaitMenuOpen;
            waitOpen.Tick += WaitOpen_Tick;
        }

        private void WaitOpen_Tick(object sender, EventArgs e)
        {
            waitOpen.Stop();
            waitedDone = true;
            CheckConditionsToOpenMenu();
        }

        private void CheckConditionsToOpenMenu()
        {
            if ((waitedDone || clicked) &&
                menuLoaded)
            {
                Stop();
                DoOpen?.Invoke();
            }
        }

        // When mouse on menu, wait x ms until open it
        // meanwhile load content, click opens when loaded
        // (to not interrupt user when he moves into a submenu)
        public void Start()
        {
            if (!waitedDone)
            {
                waitOpen.Start();
            }
        }

        public void Stop()
        {
            clicked = false;
            waitedDone = false;
            menuLoaded = false;
            waitOpen.Stop();
        }

        public void Click()
        {
            clicked = true;
            CheckConditionsToOpenMenu();
        }

        public void MenuLoaded()
        {
            menuLoaded = true;
            CheckConditionsToOpenMenu();
        }

        public void Dispose()
        {
            Stop();
            waitOpen.Dispose();
        }
    }
}