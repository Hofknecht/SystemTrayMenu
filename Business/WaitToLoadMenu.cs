// <copyright file="WaitToLoadMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Handler
{
    using System;
    using System.Collections;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.Utilities;
    using static SystemTrayMenu.UserInterface.Menu;
    using ListView = System.Windows.Controls.ListView;
    using Menu = SystemTrayMenu.UserInterface.Menu;

    internal class WaitToLoadMenu : IDisposable
    {
        private readonly DispatcherTimer timerStartLoad = new();
        private ListView? dgv;
        private ListViewItemData? dgvItemData;
#if TODO // Misc MouseEvents
        private ListView? dgvTmp;
        private ListViewItemData rowItemDataTmp;
#endif
        private bool alreadyOpened;

#if TODO // Misc MouseEvents
        private int mouseMoveEvents;
        private DateTime dateTimeLastMouseMoveEvent = DateTime.Now;
#endif
        private bool checkForMouseActive = true;

        internal WaitToLoadMenu()
        {
            timerStartLoad.Interval = TimeSpan.FromMilliseconds(Properties.Settings.Default.TimeUntilOpens);
            timerStartLoad.Tick += WaitStartLoad_Tick;
        }

        internal event Action<RowData>? StartLoadMenu;

        internal event Action<int>? CloseMenu;

        internal event Action? StopLoadMenu;

        internal event Action<ListView, ListViewItemData>? MouseEnterOk;

        internal bool MouseActive { get; set; }

        public void Dispose()
        {
            timerStartLoad.Stop();
        }

        internal void MouseEnter(ListView dgv, ListViewItemData itemData)
        {
            if (MouseActive)
            {
                MouseEnterOk?.Invoke(dgv, itemData);
                timerStartLoad.Stop();
                StopLoadMenu?.Invoke();
                checkForMouseActive = true;
                SetData(dgv, itemData);
                timerStartLoad.Start();
            }
#if TODO // Misc MouseEvents
            else
            {
                dgvTmp = dgv;
                rowItemDataTmp = itemData;
            }
#endif
        }

        internal void RowSelected(ListView dgv, ListViewItemData itemData)
        {
            timerStartLoad.Stop();
            StopLoadMenu?.Invoke();
            SetData(dgv, itemData);
            MouseActive = false;
            checkForMouseActive = false;
            timerStartLoad.Start();
        }

        internal void MouseLeave(ListView dgv, ListViewItemData itemData)
        {
            if (MouseActive)
            {
                timerStartLoad.Stop();
                StopLoadMenu?.Invoke();
                ResetData(dgv, itemData);
            }
        }

        internal void RowDeselected(int rowIndex, ListView? dgv)
        {
            timerStartLoad.Stop();
            StopLoadMenu?.Invoke();
            if (dgv != null)
            {
                ResetData(dgv, (ListViewItemData)dgv.Items[rowIndex]);
            }

            MouseActive = false;
        }

        internal void ClickOpensInstantly(ListView dgv, ListViewItemData itemData)
        {
            timerStartLoad.Stop();
            SetData(dgv, itemData);
            MouseActive = true;
            checkForMouseActive = false;
            CallOpenMenuNow();
        }

        internal void EnterOpensInstantly(ListView dgv, ListViewItemData itemData)
        {
            timerStartLoad.Stop();
            StopLoadMenu?.Invoke();
            SetData(dgv, itemData);
            MouseActive = false;
            checkForMouseActive = false;
            CallOpenMenuNow();
        }

#if TODO // Misc MouseEvents
        internal void MouseMove(object sender, MouseEventArgs e)
        {
            if (!MouseActive)
            {
                if (mouseMoveEvents > 6)
                {
                    MouseActive = true;
                    if (dgvTmp != null)
                    {
                        MouseEnter(dgvTmp, rowItemDataTmp);
                    }

                    mouseMoveEvents = 0;
                }
                else if (DateTime.Now - dateTimeLastMouseMoveEvent <
                    new TimeSpan(0, 0, 0, 0, 200))
                {
                    mouseMoveEvents++;
                }
                else
                {
                    dateTimeLastMouseMoveEvent = DateTime.Now;
                    mouseMoveEvents = 0;
                }
            }
        }
#endif

        private void WaitStartLoad_Tick(object? sender, EventArgs e)
        {
            timerStartLoad.Stop();
            if (!checkForMouseActive || MouseActive)
            {
                CallOpenMenuNow();
            }
        }

        private void CallOpenMenuNow()
        {
            if (!alreadyOpened && dgv != null && dgvItemData != null && dgv.Items.Contains(dgvItemData))
            {
                alreadyOpened = true;

                RowData rowData = dgvItemData.data;
                Menu menu = (Menu)dgv.GetParentWindow();
                rowData.Level = menu.Level;

                CloseMenu?.Invoke(rowData.Level + 1);

                menu?.FocusTextBox();

                if (rowData.IsPointingToFolder &&
                    rowData.Level + 1 < MenuDefines.MenusMax)
                {
                    StartLoadMenu?.Invoke(rowData);
                }
            }
        }

        private void SetData(ListView dgv, ListViewItemData itemData)
        {
            if (this.dgv == dgv && dgvItemData == itemData)
            {
                return;
            }

            alreadyOpened = false;
#if TODO // Misc MouseEvents
            dgvTmp = null;
#endif
            this.dgv = dgv;
            dgvItemData = itemData;

            RowData rowData = dgvItemData.data;
            if (rowData != null)
            {
                rowData.IsSelected = true;
            }

            dgv.SelectedItem = dgvItemData;
        }

        private void ResetData(ListView dgv, ListViewItemData itemData)
        {
            RowData rowData = itemData.data;
            if (rowData != null)
            {
                rowData.IsSelected = false;
                rowData.IsClicking = false;
                dgv.SelectedItem = null;
                this.dgv = null;
                dgvItemData = null;
            }
        }
    }
}
