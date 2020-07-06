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
        public event EventHandlerEmpty LeaveTriggered;

        private readonly Timer timerLeaveCheck = new Timer();

        public bool IsRunning => timerLeaveCheck.Enabled;

        public WaitLeave(int timeUntilTriggered)
        {
            timerLeaveCheck.Interval = timeUntilTriggered;
            timerLeaveCheck.Tick += TimerLeaveCheckTick;
        }

        public void Start()
        {
            timerLeaveCheck.Stop();
            timerLeaveCheck.Start();
        }

        public void Stop()
        {
            timerLeaveCheck.Stop();
        }

        private void TimerLeaveCheckTick(object sender, EventArgs e)
        {
            timerLeaveCheck.Stop();
            LeaveTriggered?.Invoke();
        }

        public void Dispose()
        {
            timerLeaveCheck.Dispose();
        }
    }
}
