// <copyright file="WaitLeave.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Handler
{
    using System;
    using SystemTrayMenu.Utilities;
    using Timer = System.Windows.Forms.Timer;

    internal class WaitLeave : IDisposable
    {
        private readonly Timer timerLeaveCheck = new();

        public WaitLeave(int timeUntilTriggered)
        {
            timerLeaveCheck.Interval = timeUntilTriggered;
            timerLeaveCheck.Tick += TimerLeaveCheckTick;
        }

        public event Action LeaveTriggered;

        public void Dispose()
        {
            timerLeaveCheck.Tick -= TimerLeaveCheckTick;
            timerLeaveCheck.Dispose();
        }

        internal void Start()
        {
            timerLeaveCheck.Stop();
            timerLeaveCheck.Start();
        }

        internal void Stop()
        {
            timerLeaveCheck.Stop();
        }

        internal void TimerLeaveCheckTick(object sender, EventArgs e)
        {
            timerLeaveCheck.Stop();
            LeaveTriggered?.Invoke();
        }
    }
}
