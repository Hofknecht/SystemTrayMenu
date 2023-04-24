// <copyright file="WaitToLoadMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Handler
{
    using System;
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
        private int rowIndex;
        private ListView? dgvTmp;
        private int rowIndexTmp;
        private bool alreadyOpened;

        private int mouseMoveEvents;
        private DateTime dateTimeLastMouseMoveEvent = DateTime.Now;
        private bool checkForMouseActive = true;

        internal WaitToLoadMenu()
        {
            timerStartLoad.Interval = TimeSpan.FromMilliseconds(Properties.Settings.Default.TimeUntilOpens);
            timerStartLoad.Tick += WaitStartLoad_Tick;
        }

        internal event Action<RowData>? StartLoadMenu;

        internal event Action<int>? CloseMenu;

        internal event Action? StopLoadMenu;

        internal event Action<ListView, int>? MouseEnterOk;

        internal bool MouseActive { get; set; }

        public void Dispose()
        {
            timerStartLoad.Stop();
        }

        internal void MouseEnter(object sender, int rowIndex)
        {
            ListView dgv = (ListView)sender;
            if (MouseActive)
            {
                if (dgv.Items.Count > rowIndex)
                {
                    MouseEnterOk?.Invoke(dgv, rowIndex);
                    timerStartLoad.Stop();
                    StopLoadMenu?.Invoke();
                    checkForMouseActive = true;
                    SetData(dgv, rowIndex);
                    timerStartLoad.Start();
                }
            }
            else
            {
                dgvTmp = dgv;
                rowIndexTmp = rowIndex;
            }
        }

        internal void RowSelected(ListView dgv, int rowIndex)
        {
            if (dgv.Items.Count > rowIndex)
            {
                timerStartLoad.Stop();
                StopLoadMenu?.Invoke();
                SetData(dgv, rowIndex);
                MouseActive = false;
                checkForMouseActive = false;
                timerStartLoad.Start();
            }
        }

        internal void MouseLeave(object sender, int rowIndex)
        {
            if (MouseActive)
            {
                timerStartLoad.Stop();
                StopLoadMenu?.Invoke();
                ResetData((ListView)sender, rowIndex);
            }
        }

        internal void RowDeselected(int rowIndex, ListView? dgv)
        {
            timerStartLoad.Stop();
            StopLoadMenu?.Invoke();
            ResetData(dgv, rowIndex);
            MouseActive = false;
        }

        internal void ClickOpensInstantly(ListView dgv, ListViewItem item)
        {
            timerStartLoad.Stop();
            SetData(dgv, dgv.IndexOfSenderItem(item));
            MouseActive = true;
            checkForMouseActive = false;
            CallOpenMenuNow();
        }

        internal void EnterOpensInstantly(ListView dgv, int rowIndex)
        {
            if (dgv.Items.Count > rowIndex)
            {
                timerStartLoad.Stop();
                StopLoadMenu?.Invoke();
                SetData(dgv, rowIndex);
                MouseActive = false;
                checkForMouseActive = false;
                CallOpenMenuNow();
            }
        }

        internal void MouseMove(object sender, MouseEventArgs e)
        {
            if (!MouseActive)
            {
                if (mouseMoveEvents > 6)
                {
                    MouseActive = true;
                    if (dgvTmp != null)
                    {
                        MouseEnter(dgvTmp, rowIndexTmp);
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
            if (!alreadyOpened && dgv != null && dgv.Items.Count > rowIndex)
            {
                alreadyOpened = true;

                RowData rowData = ((ListViewItemData)dgv.Items[rowIndex]).data;
                Menu menu = (Menu)dgv.GetParentWindow();
                rowData.Level = menu.Level;
                if (rowData.ContainsMenu)
                {
                    CloseMenu?.Invoke(rowData.Level + 2);
                }

                CloseMenu?.Invoke(rowData.Level + 1);

                if (!rowData.IsContextMenuOpen &&
                    rowData.ContainsMenu &&
                    rowData.Level + 1 < MenuDefines.MenusMax)
                {
                    StartLoadMenu?.Invoke(rowData);
                }
            }
        }

        private void SetData(ListView dgv, int rowIndex)
        {
            if (this.dgv == dgv && this.rowIndex == rowIndex)
            {
                return;
            }

            alreadyOpened = false;
            dgvTmp = null;
            this.dgv = dgv;
            this.rowIndex = rowIndex;

            RowData rowData = ((ListViewItemData)dgv.Items[rowIndex]).data;
            if (rowData != null)
            {
                rowData.IsSelected = true;
            }

            dgv.SelectedIndex = rowIndex;
        }

        private void ResetData(ListView? dgv, int rowIndex)
        {
            if (dgv != null && dgv.Items.Count > rowIndex)
            {
                RowData rowData = ((ListViewItemData)dgv.Items[rowIndex]).data;
                if (rowData != null)
                {
                    rowData.IsSelected = false;
                    rowData.IsClicking = false;
                    dgv.SelectedItem = null;
                    this.dgv = null;
                    this.rowIndex = 0;
                }
            }
        }
    }
}