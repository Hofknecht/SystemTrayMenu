// <copyright file="WaitToLoadMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Handler
{
    using System;
    using System.Windows.Threading;
    using SystemTrayMenu.DataClasses;

    internal class WaitToLoadMenu : IDisposable
    {
        private readonly DispatcherTimer timerStartLoad = new();
        private ListViewMenuItem? currentItemData;
        private bool alreadyOpened;

        internal WaitToLoadMenu()
        {
            timerStartLoad.Interval = TimeSpan.FromMilliseconds(Properties.Settings.Default.TimeUntilOpens);
            timerStartLoad.Tick += OpenSubMenuByTimer;
        }

        internal event Action? StopLoadMenu;

        internal event Action<ListViewMenuItem>? MouseSelect;

        internal bool MouseActive { get; set; }

        public void Dispose() => timerStartLoad.Stop();

        internal void MouseEnter(ListViewMenuItem itemData)
        {
            if (MouseActive)
            {
                MouseSelect?.Invoke(itemData);
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

        internal void RowSelectionChanged(ListViewMenuItem? itemData)
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

        internal void OpenSubMenuByMouse(ListViewMenuItem itemData)
        {
            timerStartLoad.Stop();
            StopLoadMenu?.Invoke(); // TODO: Missing in v1 ?
            SetData(itemData);
            MouseActive = true;
            OpenSubMenu();
        }

        internal void OpenSubMenuByKey(ListViewMenuItem itemData)
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
            StopLoadMenu?.Invoke(); // TODO: Missing in v1 ?
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

        private void SetData(ListViewMenuItem itemData)
        {
            if (currentItemData != itemData)
            {
                alreadyOpened = false;

                currentItemData = itemData;
            }
        }
    }
}
