// <copyright file="WaitLeave.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Handler
{
    using System;
    using System.Windows.Threading;
    using SystemTrayMenu.Utilities;

    internal class WaitLeave : IDisposable
    {
        private readonly DispatcherTimer timerLeaveCheck = new();

        public WaitLeave(int timeUntilTriggered)
        {
            timerLeaveCheck.Interval = TimeSpan.FromMilliseconds(timeUntilTriggered);
            timerLeaveCheck.Tick += TimerLeaveCheckTick;
        }

        public event Action LeaveTriggered;

        public void Dispose()
        {
            timerLeaveCheck.Stop();
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
