// <copyright file="Fading.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helper
{
    using System;
    using System.Windows.Forms;
    using SystemTrayMenu.Utilities;

    public class Fading : IDisposable
    {
        private const int Interval100FPS = 10; // 100fps=>1s/100fps=~10ms

        private const double StepIn = 0.20;
        private const double StepOut = 0.10;
        private const double Transparent = 0.80;
        private const double TransparentMinus = 0.60; // Transparent - StepIn
        private const double TransparentPlus = 0.85; // Transparent + StepOut
        private const double Shown = 1.00;
        private const double ShownMinus = 0.80; // Shown - StepIn

        private readonly Timer timer = new();
        private FadingState state = FadingState.Idle;
        private double opacity;
        private bool visible;

        internal Fading()
        {
            timer.Interval = Interval100FPS;
            timer.Tick += Timer_Tick;
        }

        ~Fading() // the finalizer
        {
            Dispose(false);
        }

        internal event Action Hide;

        internal event Action Show;

        internal event Action<double> ChangeOpacity;

        internal enum FadingState
        {
            Idle,
            Show,
            ShowTransparent,
            Hide,
        }

        internal bool IsHiding => state == FadingState.Hide;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void Fade(FadingState state)
        {
            StartStopTimer(state);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                timer.Tick -= Timer_Tick;
                timer.Dispose();
            }
        }

        private void StartStopTimer(FadingState newState)
        {
            if (newState == FadingState.Idle)
            {
                state = newState;
                timer.Stop();
            }
            else
            {
                state = newState;
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            FadeStep();
        }

        private void FadeStep()
        {
            switch (state)
            {
                case FadingState.Show:
                    if (!visible)
                    {
                        visible = true;
                        Show?.Invoke();
                        opacity = 0;
                        ChangeOpacity?.Invoke(opacity);
                    }
                    else if (Properties.Settings.Default.UseFading &&
                        opacity < ShownMinus)
                    {
                        opacity += StepIn;
                        ChangeOpacity?.Invoke(opacity);
                    }
                    else
                    {
                        if (!Properties.Settings.Default.UseFading)
                        {
                            // #393 provoke a redraw for the CS_DROPSHADOW to work
                            opacity = ShownMinus;
                            ChangeOpacity?.Invoke(opacity);
                        }

                        opacity = Shown;
                        ChangeOpacity?.Invoke(opacity);
                        StartStopTimer(FadingState.Idle);
                    }

                    break;
                case FadingState.ShowTransparent:
                    if (!visible)
                    {
                        visible = true;
                        Show?.Invoke();
                        opacity = 0;
                        ChangeOpacity?.Invoke(opacity);
                    }
                    else if (Properties.Settings.Default.UseFading &&
                        opacity < TransparentMinus)
                    {
                        opacity += StepIn;
                        ChangeOpacity?.Invoke(opacity);
                    }
                    else if (Properties.Settings.Default.UseFading &&
                        opacity > TransparentPlus)
                    {
                        opacity -= StepOut;
                        ChangeOpacity?.Invoke(opacity);
                    }
                    else
                    {
                        opacity = Transparent;
                        ChangeOpacity?.Invoke(opacity);
                        StartStopTimer(FadingState.Idle);
                    }

                    break;
                case FadingState.Hide:
                    if (Properties.Settings.Default.UseFading &&
                        opacity > StepOut)
                    {
                        opacity -= StepOut;
                        ChangeOpacity?.Invoke(opacity);
                    }
                    else if (visible)
                    {
                        opacity = 0;
                        ChangeOpacity?.Invoke(opacity);
                        visible = false;
                        Hide?.Invoke();
                        StartStopTimer(FadingState.Idle);
                    }
                    else
                    {
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
}