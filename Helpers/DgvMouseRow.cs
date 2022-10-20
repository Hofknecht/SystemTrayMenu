// <copyright file="DgvMouseRow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helper
{
    using System;
    using System.Windows.Forms;

    public class DgvMouseRow : IDisposable
    {
        private readonly Timer timerRaiseRowMouseLeave = new();
        private DataGridView dgv;
        private DataGridViewCellEventArgs eventArgs;

        internal DgvMouseRow()
        {
            timerRaiseRowMouseLeave.Interval = 200;
            timerRaiseRowMouseLeave.Tick += TimerRaiseRowMouseLeave_Tick;
        }

        ~DgvMouseRow() // the finalizer
        {
            Dispose(false);
        }

        internal event Action<object, DataGridViewCellEventArgs> RowMouseEnter;

        internal event Action<object, DataGridViewCellEventArgs> RowMouseLeave;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void CellMouseEnter(object sender, DataGridViewCellEventArgs newEventArgs)
        {
            DataGridView newDgv = (DataGridView)sender;

            if (dgv != newDgv || newEventArgs.RowIndex != eventArgs.RowIndex)
            {
                if (timerRaiseRowMouseLeave.Enabled)
                {
                    timerRaiseRowMouseLeave.Stop();
                    TriggerRowMouseLeave();
                }

                TriggerRowMouseEnter(newDgv, newEventArgs);
            }
            else
            {
                timerRaiseRowMouseLeave.Stop();
            }

            dgv = newDgv;
            eventArgs = newEventArgs;
        }

        internal void CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            timerRaiseRowMouseLeave.Start();
        }

        internal void MouseLeave(object sender, EventArgs e)
        {
            if (timerRaiseRowMouseLeave.Enabled)
            {
                timerRaiseRowMouseLeave.Stop();
                TriggerRowMouseLeave();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                timerRaiseRowMouseLeave.Tick -= TimerRaiseRowMouseLeave_Tick;
                timerRaiseRowMouseLeave.Dispose();
                dgv = null;
            }
        }

        private void TimerRaiseRowMouseLeave_Tick(object sender, EventArgs e)
        {
            timerRaiseRowMouseLeave.Stop();
            TriggerRowMouseLeave();
        }

        private void TriggerRowMouseLeave()
        {
            if (dgv != null)
            {
                RowMouseLeave?.Invoke(dgv, eventArgs);
            }

            dgv = null;
            eventArgs = null;
        }

        private void TriggerRowMouseEnter(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            RowMouseEnter?.Invoke(dgv, e);
        }
    }
}