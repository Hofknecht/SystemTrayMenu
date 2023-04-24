// <copyright file="DgvMouseRow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Helpers
{
    using System;
    using System.Windows.Threading;

    public class DgvMouseRow<TList, TItem> : IDisposable
        where TList : notnull
        where TItem : notnull
    {
        private readonly DispatcherTimer timerRaiseRowMouseLeave = new DispatcherTimer(DispatcherPriority.Input, Dispatcher.CurrentDispatcher);
        private TList? currentList;
        private TItem? currentItem;

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

        internal event Action<TList, TItem>? RowMouseEnter;

        internal event Action<TList, TItem>? RowMouseLeave;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void CellMouseEnter(TList list, TItem item)
        {
            if (!list.Equals(currentList) || !item.Equals(currentItem))
            {
                if (timerRaiseRowMouseLeave.IsEnabled)
                {
                    timerRaiseRowMouseLeave.Stop();
                    TriggerRowMouseLeave();
                }

                TriggerRowMouseEnter(list, item);
            }
            else
            {
                timerRaiseRowMouseLeave.Stop();
            }

            currentList = list;
            currentItem = item;
        }

        internal void CellMouseLeave()
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
            }
        }

        private void TriggerRowMouseLeave()
        {
            if (currentList != null && currentItem != null)
            {
                RowMouseLeave?.Invoke(currentList, currentItem);
            }

            currentList = default;
            currentItem = default;
        }

        private void TriggerRowMouseEnter(TList list, TItem item)
        {
            RowMouseEnter?.Invoke(list, item);
        }
    }
}