using System;
using EventHandler = SystemTrayMenu.Helper.EventHandler;
using Timer = System.Windows.Forms.Timer;

namespace SystemTrayMenu.Handler
{
    internal class WaitFastLeave : IDisposable
    {
        public event EventHandler Leave;

        private readonly Timer timerSecondLeaveCheck = new Timer();

        public WaitFastLeave()
        {
            timerSecondLeaveCheck.Interval = 200;
            timerSecondLeaveCheck.Tick += LeaveWorkaround_Tick;
        }

        // When menu not activated and mouse leaves menu very fast,
        // mouse still on menu but we not get leave event again
        // as workaround we call the check again (200ms later)
        public void Start()
        {
            Leave.Invoke();
            timerSecondLeaveCheck.Stop();
            timerSecondLeaveCheck.Start();
        }

        private void LeaveWorkaround_Tick(object sender, EventArgs e)
        {
            timerSecondLeaveCheck.Stop();
            Leave.Invoke();
        }

        public void Dispose()
        {
            timerSecondLeaveCheck.Dispose();
        }
    }
}
