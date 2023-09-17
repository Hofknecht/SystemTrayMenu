// <copyright file="WaitToLoadMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Business
{
    using System;
    using System.Windows.Threading;
    using SystemTrayMenu.DataClasses;

    internal class WaitToLoadMenu : IDisposable
    {
        private readonly DispatcherTimer timerStartLoad = new();
        private RowData? currentItemData;
        private bool alreadyOpened;

        internal WaitToLoadMenu()
        {
            timerStartLoad.Interval = TimeSpan.FromMilliseconds(Properties.Settings.Default.TimeUntilOpens);
            timerStartLoad.Tick += OpenSubMenuByTimer;
        }

        internal event Action? StopLoadMenu;

        internal event Action<RowData>? MouseSelect;

        internal bool MouseActive { get; set; }

        public void Dispose() => timerStartLoad.Stop();

        internal void MouseEnter(RowData itemData)
        {
            if (MouseActive)
            {
                timerStartLoad.Stop();
                StopLoadMenu?.Invoke();
                SetData(itemData);
                timerStartLoad.Start();
            }
        }

        internal void MouseLeave()
        {
            if (MouseActive)
            {
                timerStartLoad.Stop();
                StopLoadMenu?.Invoke();
                currentItemData = null;
            }
        }

        internal void RowSelectionChanged(RowData? itemData)
        {
            // Deselect
            timerStartLoad.Stop();
            StopLoadMenu?.Invoke();
            currentItemData = null;
            MouseActive = false;

            // Select (if any)
            if (itemData != null)
            {
                SetData(itemData);
                timerStartLoad.Start();
            }
        }

        internal void OpenSubMenuByMouse(RowData itemData)
        {
            timerStartLoad.Stop();
            StopLoadMenu?.Invoke();
            SetData(itemData);
            MouseActive = true;
            MouseSelect?.Invoke(itemData);
            OpenSubMenu();
        }

        internal void OpenSubMenuByKey(RowData itemData)
        {
            timerStartLoad.Stop();
            StopLoadMenu?.Invoke();
            SetData(itemData);
            MouseActive = false;
            OpenSubMenu();
        }

        private void OpenSubMenuByTimer(object? sender, EventArgs e)
        {
            timerStartLoad.Stop();
            StopLoadMenu?.Invoke();
            if (MouseActive && currentItemData != null)
            {
                MouseSelect?.Invoke(currentItemData);
            }

            OpenSubMenu();
        }

        private void OpenSubMenu()
        {
            if (!alreadyOpened && currentItemData != null)
            {
                alreadyOpened = true; // TODO: Check if this bool is still needed?

                currentItemData.OpenSubMenu();
            }
        }

        private void SetData(RowData itemData)
        {
            if (currentItemData != itemData)
            {
                alreadyOpened = false;

                currentItemData = itemData;
            }
        }
    }
}
