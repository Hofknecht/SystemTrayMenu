using System;
using System.Windows.Forms;

namespace SystemTrayMenu.UserInterface
{
    public class FadeForm : IDisposable
    {
        public bool IsFadingIn => timerFadeIn.Enabled;

        public bool IsFadingOut => timerFadeOut.Enabled;

        private readonly Timer timerFadeIn = new Timer();
        private readonly Timer timerFadeOut = new Timer();
        private readonly Timer timerFadeHalf = new Timer();
        private readonly Form form = null;
        private readonly bool disposeForm = false;
        private bool stopFadeInByHalf = false;

        public FadeForm(Form form, bool disposeForm = false)
        {
            this.form = form;
            this.disposeForm = disposeForm;
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
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                timerFadeIn.Dispose();
                timerFadeOut.Dispose();
                timerFadeHalf.Dispose();
                if (disposeForm)
                {
                    form.Dispose();
                }
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
                timerFadeOut.Stop();
                timerFadeHalf.Stop();
                stopFadeInByHalf = true;
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
            else
            {
                DllImports.NativeMethods.User32ShowInactiveTopmost(form);
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
    }
}