// <copyright file="KeyboardInput.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Handler
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Input;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.Helpers;
    using SystemTrayMenu.Utilities;
    using static SystemTrayMenu.UserInterface.Menu;
    using ListView = System.Windows.Controls.ListView;
    using Menu = SystemTrayMenu.UserInterface.Menu;

    internal class KeyboardInput : IDisposable
    {
        private readonly Menu?[] menus;
        private readonly KeyboardHook hook = new();

        private int iRowKey = -1;
        private int iMenuKey;

        public KeyboardInput(Menu?[] menus)
        {
            this.menus = menus;
        }

        internal event Action? HotKeyPressed;

        internal event Action? ClosePressed;

        internal event Action<ListView, ListViewItemData>? RowSelected;

        internal event Action<int, ListView?>? RowDeselected;

        internal event Action<ListView, ListViewItemData>? EnterPressed;

        internal event Action? Cleared;

        internal bool InUse { get; set; }

        public void Dispose()
        {
            hook.Dispose();
        }

        internal void RegisterHotKey()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.HotKey))
            {
                try
                {
                    hook.RegisterHotKey();
                    hook.KeyPressed += (sender, e) => HotKeyPressed?.Invoke();
                }
                catch (InvalidOperationException ex)
                {
                    Log.Warn($"key:'{Properties.Settings.Default.HotKey}'", ex);
                    Properties.Settings.Default.HotKey = string.Empty;
                    Properties.Settings.Default.Save();
                }
            }
        }

        internal void ResetSelectedByKey()
        {
            iRowKey = -1;
            iMenuKey = 0;
        }

        internal void CmdKeyProcessed(Menu? sender, Key key, ModifierKeys modifiers)
        {
            sender ??= menus[iMenuKey];

            switch (key)
            {
                case Key.Enter:
                    if (modifiers == ModifierKeys.None)
                    {
                        SelectByKey(key, modifiers);
                        menus[iMenuKey]?.FocusTextBox();
                    }

                    break;
                case Key.Left:
                case Key.Right:
                case Key.Home:
                case Key.End:
                case Key.Up:
                case Key.Down:
                case Key.Escape:
                    if (modifiers == ModifierKeys.None)
                    {
                        SelectByKey(key, modifiers);
                    }

                    break;
                case Key.F4:
                    if (modifiers == ModifierKeys.Alt)
                    {
                        SelectByKey(key, modifiers);
                    }

                    break;
                case Key.F:
                    if (modifiers == ModifierKeys.Control)
                    {
                        menus[iMenuKey]?.FocusTextBox();
                    }

                    break;
                case Key.Tab:
                    if (modifiers == ModifierKeys.None)
                    {
                        int indexOfTheCurrentMenu = GetMenuIndex(sender);
                        int indexMax = menus.Where(m => m != null).Count() - 1;
                        int indexNew = 0;
                        if (indexOfTheCurrentMenu > 0)
                        {
                            indexNew = indexOfTheCurrentMenu - 1;
                        }
                        else
                        {
                            indexNew = indexMax;
                        }

                        menus[indexNew]?.FocusTextBox();
                    }
                    else if (modifiers == ModifierKeys.Shift)
                    {
                        int indexOfTheCurrentMenu = GetMenuIndex(sender);
                        int indexMax = menus.Where(m => m != null).Count() - 1;
                        int indexNew = 0;
                        if (indexOfTheCurrentMenu < indexMax)
                        {
                            indexNew = indexOfTheCurrentMenu + 1;
                        }
                        else
                        {
                            indexNew = 0;
                        }

                        menus[indexNew]?.FocusTextBox();
                    }

                    break;
                case Key.Apps:
                    if (modifiers == ModifierKeys.None)
                    {
                        ListView? dgv = menus[iMenuKey]?.GetDataGridView();
                        if (dgv != null)
                        {
                            if (iRowKey > -1 && dgv.Items.Count > iRowKey)
                            {
#if TODO // WPF: Better way to open context menu (as it looks like this is the code's intention)
                                Point point = dgv.GetCellDisplayRectangle(2, iRowKey, false).Location;
                                RowData trigger = (RowData)dgv.Rows[iRowKey].Cells[2].Value;
                                MouseEventArgs mouseEventArgs = new(MouseButtons.Right, 1, point.X, point.Y, 0);
                                trigger.MouseDown(dgv, mouseEventArgs);
#endif
                            }
                        }
                    }

                    break;
                default:
                    break;
            }

            int GetMenuIndex(in Menu? currentMenu)
            {
                int index = 0;
                foreach (Menu? menuFindIndex in menus.Where(m => m != null))
                {
                    if (currentMenu == menuFindIndex)
                    {
                        break;
                    }

                    index++;
                }

                return index;
            }
        }

        internal void SearchTextChanging()
        {
            ClearIsSelectedByKey();
        }

        internal void SearchTextChanged(Menu menu, bool isSearchStringEmpty)
        {
            if (isSearchStringEmpty)
            {
                ClearIsSelectedByKey();
            }
            else
            {
                ListView? dgv = menu.GetDataGridView();
                if (dgv != null)
                {
                    if (dgv.Items.Count > 0)
                    {
                        Select(dgv, (ListViewItemData)dgv.Items[0], true);
                    }
                }
            }
        }

        internal void ClearIsSelectedByKey()
        {
            ClearIsSelectedByKey(iMenuKey, iRowKey);
        }

        internal void Select(ListView dgv, ListViewItemData itemData, bool refreshview)
        {
            int index = dgv.Items.IndexOf(itemData); // TODO: Remove index (work with instance instead)
            int newiMenuKey = ((Menu)dgv.GetParentWindow()).Level;
            if (index != iRowKey || newiMenuKey != iMenuKey)
            {
                ClearIsSelectedByKey();
            }

            iRowKey = index;
            iMenuKey = newiMenuKey;

            RowData rowData = itemData.data;
            if (rowData != null)
            {
                rowData.IsSelected = true;
            }

            if (refreshview)
            {
                if (dgv.SelectedItems.Contains(itemData))
                {
                    dgv.SelectedItems.Remove(itemData);
                }

                dgv.SelectedItems.Add(itemData);
            }
        }

        private bool IsAnyMenuSelectedByKey(
            ref ListView? dgv,
            ref Menu? menuFromSelected,
            ref string textselected)
        {
            Menu? menu = menus[iMenuKey];
            bool isStillSelected = false;
            if (menu != null &&
                iRowKey > -1)
            {
                dgv = menu.GetDataGridView();
                if (dgv != null)
                {
                    if (dgv.Items.Count > iRowKey)
                    {
                        Menu.ListViewItemData itemData = (Menu.ListViewItemData)dgv.Items[iRowKey];
                        RowData rowData = itemData.data;
                        if (rowData.IsSelected)
                        {
                            isStillSelected = true;
                            menuFromSelected = rowData.SubMenu;
                            textselected = itemData.ColumnText;
                        }
                    }
                }
            }

            return isStillSelected;
        }

        private void SelectByKey(Key key, ModifierKeys modifiers, string keyInput = "", bool keepSelection = false)
        {
            int iRowBefore = iRowKey;
            int iMenuBefore = iMenuKey;

            Menu? menu = menus[iMenuKey];
            ListView? dgv = null;
            ListView? dgvBefore = null;
            Menu? menuFromSelected = null;
            string textselected = string.Empty;
            bool isStillSelected = IsAnyMenuSelectedByKey(ref dgv, ref menuFromSelected, ref textselected);
            if (isStillSelected)
            {
                if (keepSelection)
                {
                    // If current selection is still valid for this search then skip selecting different item
                    if (textselected.StartsWith(keyInput, true, CultureInfo.InvariantCulture))
                    {
                        return;
                    }
                }

                dgvBefore = dgv;
            }
            else
            {
                ResetSelectedByKey();
                menu = menus[iMenuKey];
                dgv = menu?.GetDataGridView();
            }

            bool toClear = false;
            bool handled = false;
            switch (key)
            {
                case Key.Enter:
                    if ((modifiers == ModifierKeys.None) && (iRowKey > -1 && dgv != null && dgv.Items.Count > iRowKey))
                    {
                        ListViewItemData itemData = (ListViewItemData)dgv.Items[iRowKey];
                        RowData trigger = itemData.data;
                        if (trigger.IsMenuOpen || !trigger.ContainsMenu)
                        {
                            trigger.OpenItem(out bool doCloseAfterOpen);
                            if (doCloseAfterOpen)
                            {
                                ClosePressed?.Invoke();
                            }
                        }
                        else
                        {
                            RowDeselected?.Invoke(iRowBefore, dgvBefore);
                            SelectRow(dgv, iRowKey);
                            EnterPressed?.Invoke(dgv, itemData);
                        }

                        handled = true;
                    }

                    break;
                case Key.Up:
                    if ((modifiers == ModifierKeys.None) &&
                        dgv != null &&
                        (SelectMatchedReverse(dgv, iRowKey) ||
                        SelectMatchedReverse(dgv, dgv.Items.Count - 1)))
                    {
                        RowDeselected?.Invoke(iRowBefore, dgvBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                        handled = true;
                    }

                    break;
                case Key.Down:
                    if ((modifiers == ModifierKeys.None) &&
                        (SelectMatched(dgv, iRowKey) ||
                        SelectMatched(dgv, 0)))
                    {
                        RowDeselected?.Invoke(iRowBefore, dgvBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                        handled = true;
                    }

                    break;
                case Key.Home:
                    if ((modifiers == ModifierKeys.None) && SelectMatched(dgv, 0))
                    {
                        RowDeselected?.Invoke(iRowBefore, dgvBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                        handled = true;
                    }

                    break;
                case Key.End:
                    if ((modifiers == ModifierKeys.None) &&
                        dgv != null &&
                        SelectMatchedReverse(dgv, dgv.Items.Count - 1))
                    {
                        RowDeselected?.Invoke(iRowBefore, dgvBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                        handled = true;
                    }

                    break;
                case Key.Left:
                    if (modifiers == ModifierKeys.None &&
                        dgv != null &&
                        dgvBefore != null)
                    {
                        Menu? nextMenu = menus[iMenuKey + 1];
                        bool nextMenuLocationIsLeft = nextMenu != null && menu != null && nextMenu.Location.X < menu.Location.X;
                        Menu? previousMenu = menus[iMenuKey - 1];
                        bool previousMenuLocationIsRight = iMenuKey > 0 && previousMenu != null && menu != null && menu.Location.X < previousMenu.Location.X;
                        if (nextMenuLocationIsLeft || previousMenuLocationIsRight)
                        {
                            SelectNextMenu(iRowBefore, ref dgv, dgvBefore, menuFromSelected, isStillSelected, ref toClear);
                        }
                        else if (iMenuKey > 0)
                        {
                            SelectPreviousMenu(iRowBefore, ref menu, ref dgv, dgvBefore, ref toClear);
                        }

                        handled = true;
                    }

                    break;
                case Key.Right:
                    if (modifiers == ModifierKeys.None &&
                        dgv != null &&
                        dgvBefore != null)
                    {
                        bool nextMenuLocationIsRight = menus[iMenuKey + 1]?.Location.X > menus[iMenuKey]?.Location.X;
                        bool previousMenuLocationIsLeft = iMenuKey > 0 && menus[iMenuKey]?.Location.X > menus[iMenuKey - 1]?.Location.X;
                        if (nextMenuLocationIsRight || previousMenuLocationIsLeft)
                        {
                            SelectNextMenu(iRowBefore, ref dgv, dgvBefore, menuFromSelected, isStillSelected, ref toClear);
                        }
                        else if (iMenuKey > 0)
                        {
                            SelectPreviousMenu(iRowBefore, ref menu, ref dgv, dgvBefore, ref toClear);
                        }

                        handled = true;
                    }

                    break;
                case Key.Escape:
                case Key.F4:
                    if ((key == Key.Escape && modifiers == ModifierKeys.None) ||
                        (key == Key.F4 && modifiers == ModifierKeys.Alt))
                    {
                        RowDeselected?.Invoke(iRowBefore, dgvBefore);
                        iMenuKey = 0;
                        iRowKey = -1;
                        toClear = true;
                        ClosePressed?.Invoke();

                        handled = true;
                    }

                    break;
                default:
                    break;
            }

            if (!handled)
            {
                if (!string.IsNullOrEmpty(keyInput))
                {
                    if (SelectMatched(dgv, iRowKey, keyInput) ||
                        SelectMatched(dgv, 0, keyInput))
                    {
                        RowDeselected?.Invoke(iRowBefore, null);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                    }
                    else if (isStillSelected)
                    {
                        iRowKey = iRowBefore - 1;
                        if (SelectMatched(dgv, iRowKey, keyInput) ||
                            SelectMatched(dgv, 0, keyInput))
                        {
                            RowDeselected?.Invoke(iRowBefore, null);
                            SelectRow(dgv, iRowKey);
                        }
                        else
                        {
                            iRowKey = iRowBefore;
                        }
                    }
                }
            }

            if (isStillSelected && toClear)
            {
                ClearIsSelectedByKey(iMenuBefore, iRowBefore);
            }
        }

        private void SelectPreviousMenu(int iRowBefore, ref Menu? menu, ref ListView? dgv, ListView? dgvBefore, ref bool toClear)
        {
            if (iMenuKey > 0)
            {
                if (menus[iMenuKey - 1] != null)
                {
                    iMenuKey -= 1;
                    iRowKey = -1;
                    menu = menus[iMenuKey];
                    dgv = menu?.GetDataGridView();
                    if (dgv != null)
                    {
                        if (SelectMatched(dgv, dgv.Items.IndexOf(dgv.SelectedItems.Count > 0 ? dgv.SelectedItems[0] : null)) ||
                            SelectMatched(dgv, 0))
                        {
                            RowDeselected?.Invoke(iRowBefore, dgvBefore);
                            SelectRow(dgv, iRowKey);
                            toClear = true;
                        }
                    }
                }
            }
            else
            {
                RowDeselected?.Invoke(iRowBefore, dgvBefore);
                iMenuKey = 0;
                iRowKey = -1;
                toClear = true;
                Cleared?.Invoke();
            }
        }

        private void SelectNextMenu(int iRowBefore, ref ListView? dgv, ListView dgvBefore, Menu? menuFromSelected, bool isStillSelected, ref bool toClear)
        {
            int iMenuKeyNext = iMenuKey + 1;
            if (isStillSelected)
            {
                if (menuFromSelected != null &&
                    menuFromSelected == menus[iMenuKeyNext])
                {
                    dgv = menuFromSelected?.GetDataGridView();
                    if (dgv != null && dgv.Items.Count > 0)
                    {
                        iMenuKey += 1;
                        iRowKey = -1;
                        if (SelectMatched(dgv, iRowKey) ||
                            SelectMatched(dgv, 0))
                        {
                            RowDeselected?.Invoke(iRowBefore, dgvBefore);
                            SelectRow(dgv, iRowKey);
                            toClear = true;
                        }
                    }
                }
            }
            else
            {
                iRowKey = -1;
                iMenuKey = menus.Where(m => m != null).Count() - 1;
                Menu? lastMenu = menus[iMenuKey];
                if (lastMenu != null)
                {
                    dgv = lastMenu?.GetDataGridView();
                    if (SelectMatched(dgv, iRowKey) ||
                        SelectMatched(dgv, 0))
                    {
                        RowDeselected?.Invoke(iRowBefore, dgvBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                    }
                }
            }
        }

        private void SelectRow(ListView? dgv, int iRowKey)
        {
            if (dgv != null && dgv.Items.Count > iRowKey)
            {
                InUse = true;
                RowSelected?.Invoke(dgv, (ListViewItemData)dgv.Items[iRowKey]);
            }
        }

        private bool SelectMatched(ListView? dgv, int indexStart, string keyInput = "")
        {
            bool found = false;
            if (dgv != null)
            {
                for (int i = indexStart; i < dgv.Items.Count; i++)
                {
                    if (Select(dgv, i, keyInput))
                    {
                        found = true;
                        break;
                    }
                }
            }

            return found;
        }

        private bool SelectMatchedReverse(ListView? dgv, int indexStart, string keyInput = "")
        {
            bool found = false;
            for (int i = indexStart; i > -1; i--)
            {
                if (Select(dgv, i, keyInput))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        private bool Select(ListView? dgv, int i, string keyInput = "")
        {
            bool found = false;
            if (i > -1 &&
                i != iRowKey &&
                dgv != null &&
                dgv.Items.Count > i)
            {
                Menu.ListViewItemData itemData = (Menu.ListViewItemData)dgv.Items[i];
                RowData rowData = itemData.data;
                if (itemData.ColumnText.StartsWith(keyInput, true, CultureInfo.InvariantCulture))
                {
                    iRowKey = rowData.RowIndex;
                    rowData.IsSelected = true;
                    if (dgv.SelectedItems.Contains(itemData))
                    {
                        dgv.SelectedItems.Remove(itemData);
                    }

                    dgv.SelectedItems.Add(itemData);
                    dgv.ScrollIntoView(itemData);

                    found = true;
                }
            }

            return found;
        }

        private void ClearIsSelectedByKey(int menuIndex, int rowIndex)
        {
            Menu? menu = menus[menuIndex];
            if (menu != null && rowIndex > -1)
            {
                ListView? dgv = menu?.GetDataGridView();
                if (dgv != null && dgv.Items.Count > rowIndex)
                {
                    Menu.ListViewItemData itemData = (Menu.ListViewItemData)dgv.Items[rowIndex];
                    RowData rowData = itemData.data;
                    if (dgv.SelectedItems.Contains(itemData))
                    {
                        dgv.SelectedItems.Remove(itemData);
                    }

                    if (rowData != null)
                    {
                        rowData.IsSelected = false;
                        rowData.IsClicking = false;
                    }
                }
            }
        }
    }
}