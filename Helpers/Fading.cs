using System;
using System.Windows.Forms;
using SystemTrayMenu.Utilities;

namespace SystemTrayMenu.UserInterface
{
    public class Fading : IDisposable
    {
        internal event EventHandlerEmpty Hide;
        internal event EventHandlerEmpty Show;
        internal event EventHandler<double> ChangeOpacity;
        internal enum FadingState { Idle, Show, ShowTransparent, Hide };
        internal bool IsHiding => state == FadingState.Hide;

        private const int Interval60FPS = 16; //60fps=>1s/60fps=~16.6ms

        private const double StepIn = 0.20;
        private const double StepOut = 0.05;
        private const double Transparent = 0.80;
        private const double TransparentMinus = 0.60; //Transparent - StepIn
        private const double TransparentPlus = 0.85; //Transparent + StepOut
        private const double Shown = 1.00;
        private const double ShownMinus = 0.80; //Shown - StepIn

        private readonly Timer timer = new Timer();
        private static readonly object lockTimerEnable = new object();
        private FadingState state = FadingState.Idle;
        private double opacity = 0.00;
        private bool visible = false;

        internal Fading()
        {
            timer.Interval = Interval60FPS;
            timer.Tick += FadeStep;
            void FadeStep(object sender, EventArgs e)
            {
                switch (state)
                {
                    case FadingState.Show:
                        if (!visible)
                        {
                            visible = true;
                            Show?.Invoke();
                            opacity = 0;
                            ChangeOpacity?.Invoke(this, opacity);
                        }
                        else if (opacity < ShownMinus)
                        {
                            opacity += StepIn;
                            ChangeOpacity?.Invoke(this, opacity);
                        }
                        else if (opacity != Shown)
                        {
                            opacity = Shown;
                            ChangeOpacity?.Invoke(this, Shown);
                            StartStopTimer(FadingState.Idle);
                        }
                        break;
                    case FadingState.ShowTransparent:
                        if (!visible)
                        {
                            visible = true;
                            Show?.Invoke();
                            opacity = 0;
                            ChangeOpacity?.Invoke(this, opacity);
                        }
                        else if (opacity < TransparentMinus)
                        {
                            opacity += StepIn;
                            ChangeOpacity?.Invoke(this, opacity);
                        }
                        else if (opacity > TransparentPlus)
                        {
                            opacity -= StepOut;
                            ChangeOpacity?.Invoke(this, opacity);
                        }
                        else if (opacity != Transparent)
                        {
                            ChangeOpacity?.Invoke(this, Transparent);
                            StartStopTimer(FadingState.Idle);
                        }
                        break;
                    case FadingState.Hide:
                        if (opacity > StepOut)
                        {
                            opacity -= StepOut;
                            ChangeOpacity?.Invoke(this, opacity);
                        }
                        else if (visible)
                        {
                            opacity = 0;
                            ChangeOpacity?.Invoke(this, opacity);
                            visible = false;
                            Hide?.Invoke();
                            StartStopTimer(FadingState.Idle);
                        }
                        break;
                    case FadingState.Idle:
                    default:
                        StartStopTimer(FadingState.Idle);
                        break;
                }
            }
        }

        internal void Fade(FadingState state)
        {
            StartStopTimer(state);
        }

        private void StartStopTimer(FadingState state)
        {
#warning if too many threads throw some away? win32 exception if too fast here
            lock (lockTimerEnable)
            {
                if (state == FadingState.Idle)
                {
                    this.state = state;
                    timer.Stop();
                }
                else
                {
                    ShowAtLeastTransparentBeforeHideItAgain();
                    void ShowAtLeastTransparentBeforeHideItAgain()
                    {
                        if (state == FadingState.Hide)
                        {
                            while (opacity < TransparentMinus)
                            {
                                Application.DoEvents();
                            }
                        }
                    }
                    this.state = state;
                    timer.Start();
                }
            }
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
                timer.Dispose();
            }
        }
    }
}