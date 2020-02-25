using Clearcove.Logging;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SystemTrayMenu
{
    public class FadeForm : IDisposable
    {
        public bool IsFadingIn
        {
            get
            {
                return timerFadeIn.Enabled;
            }
        }

        public bool IsFadingOut
        {
            get
            {
                return timerFadeOut.Enabled;
            }
        }

        Timer timerFadeIn = new Timer();
        Timer timerFadeOut = new Timer();
        Timer timerFadeHalf = new Timer();

        Form form = null;
        bool stopFadeInByHalf = false;

        public FadeForm(Form form)
        {
            this.form = form;
            timerFadeIn.Interval = MenuDefines.IntervalFade;
            timerFadeOut.Interval = MenuDefines.IntervalFade;
            timerFadeHalf.Interval = MenuDefines.IntervalFade;
            timerFadeIn.Tick += TimerFadeIn_Tick;
            timerFadeOut.Tick += TimerFadeOut_Tick;
            timerFadeHalf.Tick += TimerFadeHalf_Tick;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                timerFadeIn.Dispose();
                timerFadeOut.Dispose();
                timerFadeHalf.Dispose();
            }
        }

        public void FadeOut()
        {
            timerFadeHalf.Stop();
            timerFadeIn.Stop();
            timerFadeOut.Start();
        }

        public void FadeHalf()
        {
            if (form.Visible &&
                form.Opacity < MenuDefines.OpacityHalfValue)
            {
                stopFadeInByHalf = true;
                timerFadeOut.Stop();
                timerFadeHalf.Stop();
                timerFadeIn.Start();
            }
            else
            {
                timerFadeIn.Stop();
                timerFadeOut.Stop();
                timerFadeHalf.Start();
            }
        }

        public void FadeIn()
        {
            stopFadeInByHalf = false;
            if (form.Visible)
            {
                timerFadeOut.Stop();
                timerFadeHalf.Stop();
                timerFadeIn.Start();
            }
            else if (form.IsDisposed)
            {
                new Logger(nameof(FadeForm)).Warn(
                    $"{Environment.StackTrace.ToString()}");
            }
            else
            {
                ShowInactiveTopmost(form);
                timerFadeOut.Stop();
                timerFadeIn.Start();
            }
        }

        private void TimerFadeIn_Tick(object sender, EventArgs e)
        {
            if (form.Opacity >= 1 ||
                (stopFadeInByHalf && form.Opacity >= MenuDefines.OpacityHalfValue))
            {
                if (stopFadeInByHalf)
                {
                    form.Opacity = MenuDefines.OpacityHalfValue;
                    stopFadeInByHalf = false;
                }
                timerFadeIn.Stop();
            }
            else
            {
                form.Opacity += MenuDefines.OpacityInStep;
            }
        }

        private void TimerFadeOut_Tick(object sender, EventArgs e)
        {
            if (form.Opacity < 0.01)
            {
                form.Hide();
                timerFadeOut.Stop();
            }
            else
            {
                form.Opacity -= MenuDefines.OpacityOutStep;
            }
        }

        private void TimerFadeHalf_Tick(object sender, EventArgs e)
        {
            if (form.Opacity <= MenuDefines.OpacityHalfValue)
            {
                form.Opacity = MenuDefines.OpacityHalfValue;
                timerFadeHalf.Stop();
            }
            else
            {
                form.Opacity -= MenuDefines.OpacityHalfStep;
            }
        }

        private const int SW_SHOWNOACTIVATE = 4;
        private const int HWND_TOPMOST = -1;
        private const uint SWP_NOACTIVATE = 0x0010;

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
             int hWnd,             // Window handle
             int hWndInsertAfter,  // Placement-order handle
             int X,                // Horizontal position
             int Y,                // Vertical position
             int cx,               // Width
             int cy,               // Height
             uint uFlags);         // Window positioning flags

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static void ShowInactiveTopmost(Form frm)
        {
            ShowWindow(frm.Handle, SW_SHOWNOACTIVATE);
            SetWindowPos(frm.Handle.ToInt32(), HWND_TOPMOST,
            frm.Left, frm.Top, frm.Width, frm.Height,
            SWP_NOACTIVATE);
        }
    }
}