// <copyright file="DgvMouseRow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helpers
{
    using System;
    using System.Windows.Threading;

    public class DgvMouseRow<T> : IDisposable
        where T : notnull
    {
        private readonly DispatcherTimer timerRaiseRowMouseLeave = new DispatcherTimer(DispatcherPriority.Input, Dispatcher.CurrentDispatcher);
        private T? senderObject;
        private int? senderIndex;

        internal DgvMouseRow()
        {
            timerRaiseRowMouseLeave.Interval = TimeSpan.FromMilliseconds(200);
            timerRaiseRowMouseLeave.Tick += Elapsed;
            void Elapsed(object? sender, EventArgs e)
            {
                timerRaiseRowMouseLeave.Stop();
                TriggerRowMouseLeave();
            }
        }

        internal event Action<T, int>? RowMouseEnter;

        internal event Action<T, int>? RowMouseLeave;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void CellMouseEnter(T sender, int index)
        {
            if (!sender.Equals(senderObject) || index != senderIndex)
            {
                if (timerRaiseRowMouseLeave.IsEnabled)
                {
                    timerRaiseRowMouseLeave.Stop();
                    TriggerRowMouseLeave();
                }

                TriggerRowMouseEnter(sender, index);
            }
            else
            {
                timerRaiseRowMouseLeave.Stop();
            }

            senderObject = sender;
            senderIndex = index;
        }

        internal void CellMouseLeave(T sender, int index)
        {
            timerRaiseRowMouseLeave.Start();
        }

        internal void MouseLeave(object sender, EventArgs e)
        {
            if (timerRaiseRowMouseLeave.IsEnabled)
            {
                timerRaiseRowMouseLeave.Stop();
                TriggerRowMouseLeave();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                timerRaiseRowMouseLeave.Stop();
#if TODO // WPF: Can be optimized away?
                senderObject?.Dispose();
#endif
            }
        }

        private void TriggerRowMouseLeave()
        {
            if (senderObject != null && senderIndex.HasValue)
            {
                RowMouseLeave?.Invoke(senderObject, senderIndex.Value);
            }

            senderObject = default(T);
            senderIndex = null;
        }

        private void TriggerRowMouseEnter(T sender, int rowIndex)
        {
            RowMouseEnter?.Invoke(sender, rowIndex);
        }
    }
}