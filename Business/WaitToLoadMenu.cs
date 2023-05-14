// <copyright file="WaitToLoadMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Handler
{
    using System;
    using System.Windows.Threading;
    using SystemTrayMenu.DataClasses;
    using static SystemTrayMenu.UserInterface.Menu;
    using Menu = SystemTrayMenu.UserInterface.Menu;

    internal class WaitToLoadMenu : IDisposable
    {
        private readonly DispatcherTimer timerStartLoad = new();
        private Menu? currentMenu;
        private ListViewItemData? currentItemData;
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
                SetData(menu, itemData);
                timerStartLoad.Start();
            }
        }

        internal void RowSelectionChanged(Menu? menu)
        {
            // Deselect
            timerStartLoad.Stop();
            StopLoadMenu?.Invoke();
            ResetData();
            MouseActive = false;

            // Select (if any)
            if (menu?.SelectedItem != null)
            {
                SetData(menu, menu.SelectedItem);
                checkForMouseActive = false;
                timerStartLoad.Start();
            }
        }

        internal void MouseLeave()
        {
            if (MouseActive)
            {
                timerStartLoad.Stop();
                StopLoadMenu?.Invoke();
                ResetData();
            }
        }

        internal void ClickOpensInstantly(Menu menu, ListViewItemData itemData)
        {
            timerStartLoad.Stop();
            menu.SelectedItem = itemData;
            SetData(menu, itemData);
            MouseActive = true;
            checkForMouseActive = false;
            CallOpenMenuNow();
        }

        internal void EnterOpensInstantly(Menu menu, ListViewItemData itemData)
        {
            timerStartLoad.Stop();
            StopLoadMenu?.Invoke();
            SetData(menu, itemData);
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
            if (!alreadyOpened && (currentMenu?.GetDataGridView().Items.Contains(currentItemData) ?? false))
            {
                alreadyOpened = true; // TODO: Check if this bool is still needed?

                Menu? menuToClose = currentMenu?.SubMenu;
                RowData rowData = currentItemData!.data;

                // only re-open when the menu is not already open
                if (rowData.SubMenu != null && rowData.SubMenu == menuToClose)
                {
                    // Close second level sub menus
                    menuToClose.SelectedItem = null;
                    menuToClose = menuToClose.SubMenu;
                    if (menuToClose != null)
                    {
                        CloseMenu?.Invoke(menuToClose);
                    }
                }
                else
                {
                    if (menuToClose != null)
                    {
                        // Give the opening window focus
                        // if closing window lose focus no window would have focus any more
                        currentMenu?.Activate();
                        currentMenu?.FocusTextBox();

                        CloseMenu?.Invoke(menuToClose);
                    }

                    if (rowData.IsPointingToFolder)
                    {
                        StartLoadMenu?.Invoke(rowData);
                    }
                }
            }
        }

        private void SetData(Menu menu, ListViewItemData itemData)
        {
            if (currentMenu != menu || currentItemData != itemData)
            {
                alreadyOpened = false;

                currentItemData = itemData;
                currentMenu = menu;
            }
        }

        private void ResetData()
        {
            currentItemData = null;
            currentMenu = null;
        }
    }
}
