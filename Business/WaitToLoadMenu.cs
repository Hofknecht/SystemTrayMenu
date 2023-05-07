// <copyright file="WaitToLoadMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Handler
{
    using System;
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
        private bool alreadyOpened;
        private bool checkForMouseActive = true;

        internal WaitToLoadMenu()
        {
            timerStartLoad.Interval = TimeSpan.FromMilliseconds(Properties.Settings.Default.TimeUntilOpens);
            timerStartLoad.Tick += WaitStartLoad_Tick;
        }

        internal event Action<RowData>? StartLoadMenu;

        internal event Action<Menu>? CloseMenu;

        internal event Action? StopLoadMenu;

        internal event Action<Menu, ListViewItemData>? MouseEnterOk;

        internal bool MouseActive { get; set; }

        public void Dispose()
        {
            timerStartLoad.Stop();
        }

        internal void MouseEnter(Menu menu, ListViewItemData itemData)
        {
            if (MouseActive)
            {
                MouseEnterOk?.Invoke(menu, itemData);
                timerStartLoad.Stop();
                StopLoadMenu?.Invoke();
                checkForMouseActive = true;
                SetData(menu.GetDataGridView(), itemData);
                timerStartLoad.Start();
            }
        }

        internal void RowSelected(Menu menu, ListViewItemData itemData)
        {
            timerStartLoad.Stop();
            StopLoadMenu?.Invoke();
            SetData(menu.GetDataGridView(), itemData);
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

        internal void RowDeselected(Menu? menu, ListViewItemData? itemData)
        {
            timerStartLoad.Stop();
            StopLoadMenu?.Invoke();
            if (menu != null && itemData != null)
            {
                ResetData(menu.GetDataGridView(), itemData);
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

        internal void EnterOpensInstantly(Menu menu, ListViewItemData itemData)
        {
            timerStartLoad.Stop();
            StopLoadMenu?.Invoke();
            SetData(menu.GetDataGridView(), itemData);
            MouseActive = false;
            checkForMouseActive = false;
            CallOpenMenuNow();
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
            if (!alreadyOpened && dgv != null && dgvItemData != null && dgv.Items.Contains(dgvItemData))
            {
                alreadyOpened = true;

                RowData rowData = dgvItemData.data;
                Menu menu = (Menu)dgv.GetParentWindow();
                rowData.Level = menu.Level;

                // Give the opening window focus
                // if closing window lose focus no window would have focus any more
                menu?.Activate();
                menu?.FocusTextBox();

                Menu? menuToClose = menu?.SubMenu;
                if (menuToClose != null)
                {
                    CloseMenu?.Invoke(menuToClose);
                }

                if (rowData.IsPointingToFolder)
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

            this.dgv = dgv;
            dgvItemData = itemData;
            dgvItemData.data.IsSelected = true;
            dgv.SelectedItem = dgvItemData;
        }

        private void ResetData(ListView dgv, ListViewItemData itemData)
        {
            RowData rowData = itemData.data;
            rowData.IsSelected = false;
            rowData.IsClicking = false;
            dgv.SelectedItem = null;
            this.dgv = null;
            dgvItemData = null;
        }
    }
}
