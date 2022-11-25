// <copyright file="KeyboardInput.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Handler
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Controls;
    using System.Windows.Input;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.Helper;
    using SystemTrayMenu.Utilities;
    using static System.Net.Mime.MediaTypeNames;
    using ListView = System.Windows.Controls.ListView;
    using Menu = SystemTrayMenu.UserInterface.Menu;

    internal class KeyboardInput : IDisposable
    {
        private readonly Menu[] menus;
        private readonly KeyboardHook hook = new();

        private int iRowKey = -1;
        private int iMenuKey;

        public KeyboardInput(Menu[] menus)
        {
            this.menus = menus;
        }

        internal event Action HotKeyPressed;

        internal event Action ClosePressed;

        internal event Action<ListView, int> RowSelected;

        internal event Action<int, ListView> RowDeselected;

        internal event Action<ListView, int> EnterPressed;

        internal event Action Cleared;

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

        internal void CmdKeyProcessed(object sender, Key keys)
        {
            sender ??= menus[iMenuKey];

            switch (keys)
            {
                case Key.Enter:
                    SelectByKey(keys);
                    menus[iMenuKey]?.FocusTextBox();
                    break;
                case Key.Left:
                    SelectByKey(keys);
                    break;
                case Key.Right:
                    SelectByKey(keys);
                    break;
                case Key.Home:
                case Key.End:
                case Key.Up:
                case Key.Down:
                case Key.Escape:
#if TODO // WPF Key Modifier!
                case Key.Alt | Key.F4:
                    SelectByKey(keys);
                    break;
                case Key.Control | Key.F:
                    menus[iMenuKey]?.FocusTextBox();
                    break;
                case Key.Tab:
                    {
                        Menu currentMenu = (Menu)sender;
                        int indexOfTheCurrentMenu = GetMenuIndex(currentMenu);
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

                    break;
                case Key.Tab | Key.LeftShift:
                    {
                        Menu currentMenu = (Menu)sender;
                        int indexOfTheCurrentMenu = GetMenuIndex(currentMenu);
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
#endif
                case Key.Apps:
                    {
                        ListView dgv = menus[iMenuKey]?.GetDataGridView();

                        if (iRowKey > -1 &&
                            dgv.Items.Count > iRowKey)
                        {
#if TODO
                            Point point = dgv.GetCellDisplayRectangle(2, iRowKey, false).Location;
                            RowData trigger = (RowData)dgv.Rows[iRowKey].Cells[2].Value;
                            MouseEventArgs mouseEventArgs = new(MouseButtons.Right, 1, point.X, point.Y, 0);
                            trigger.MouseDown(dgv, mouseEventArgs);
#endif
                        }
                    }

                    break;
                default:
                    break;
            }

            int GetMenuIndex(in Menu currentMenu)
            {
                int index = 0;
                foreach (Menu menuFindIndex in menus.Where(m => m != null))
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
            ListView dgv = menu.GetDataGridView();
            if (isSearchStringEmpty)
            {
                ClearIsSelectedByKey();
            }
            else if (dgv.Items.Count > 0)
            {
                Select(dgv, 0, true);
            }
        }

        internal void ClearIsSelectedByKey()
        {
            ClearIsSelectedByKey(iMenuKey, iRowKey);
        }

        internal void Select(ListView dgv, int index, bool refreshview)
        {
            int newiMenuKey = ((Menu)dgv.GetParentWindow()).Level;
            if (index != iRowKey || newiMenuKey != iMenuKey)
            {
                ClearIsSelectedByKey();
            }

            iRowKey = index;
            iMenuKey = newiMenuKey;

            if (dgv.Items.Count > index)
            {
                Menu.ListViewItemData itemData = (Menu.ListViewItemData)dgv.Items[index];
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
        }

        private bool IsAnyMenuSelectedByKey(
            ref ListView dgv,
            ref Menu menuFromSelected,
            ref string textselected)
        {
            Menu menu = menus[iMenuKey];
            bool isStillSelected = false;
            if (menu != null &&
                iRowKey > -1)
            {
                dgv = menu.GetDataGridView();
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

            return isStillSelected;
        }

        private void SelectByKey(Key keys, string keyInput = "", bool keepSelection = false)
        {
            int iRowBefore = iRowKey;
            int iMenuBefore = iMenuKey;

            Menu menu = menus[iMenuKey];
            ListView dgv = null;
            ListView dgvBefore = null;
            Menu menuFromSelected = null;
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
                dgv = menu.GetDataGridView();
            }

            bool toClear = false;
            switch (keys)
            {
                case Key.Enter:
                    if (iRowKey > -1 && dgv.Items.Count > iRowKey)
                    {
                        RowData trigger = ((Menu.ListViewItemData)dgv.Items[iRowKey]).data;
                        if (trigger.IsMenuOpen || !trigger.ContainsMenu)
                        {
                            trigger.MouseClick(null, out bool toCloseByMouseClick);
#if TODO
                            trigger.DoubleClick(
                                new MouseButtonEventArgs(MouseButtons.Left, 0, 0, 0, 0),
                                out bool toCloseByDoubleClick);
#else
                            bool toCloseByDoubleClick = false;
#endif
                            if (toCloseByMouseClick || toCloseByDoubleClick)
                            {
                                ClosePressed?.Invoke();
                            }
#if TODO
                            if (iRowKey > -1 && dgv.Rows.Count > iRowKey)
                            {
                                // Raise Dgv_RowPostPaint to show ProcessStarted
                                dgv.InvalidateRow(iRowKey);
                            }
#endif
                        }
                        else
                        {
                            RowDeselected(iRowBefore, dgvBefore);
                            SelectRow(dgv, iRowKey);
                            EnterPressed.Invoke(dgv, iRowKey);
                        }
                    }

                    break;
                case Key.Up:
                    if (SelectMatchedReverse(dgv, iRowKey) ||
                        SelectMatchedReverse(dgv, dgv.Items.Count - 1))
                    {
                        RowDeselected(iRowBefore, dgvBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                    }

                    break;
                case Key.Down:
                    if (SelectMatched(dgv, iRowKey) ||
                        SelectMatched(dgv, 0))
                    {
                        RowDeselected(iRowBefore, dgvBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                    }

                    break;
                case Key.Home:
                    if (SelectMatched(dgv, 0))
                    {
                        RowDeselected(iRowBefore, dgvBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                    }

                    break;
                case Key.End:
                    if (SelectMatchedReverse(dgv, dgv.Items.Count - 1))
                    {
                        RowDeselected(iRowBefore, dgvBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                    }

                    break;
                case Key.Left:
                    bool nextMenuLocationIsLeft = menus[iMenuKey + 1] != null && menus[iMenuKey + 1].Location.X < menus[iMenuKey].Location.X;
                    bool previousMenuLocationIsRight = iMenuKey > 0 && menus[iMenuKey]?.Location.X < menus[iMenuKey - 1]?.Location.X;
                    if (nextMenuLocationIsLeft || previousMenuLocationIsRight)
                    {
                        SelectNextMenu(iRowBefore, ref dgv, dgvBefore, menuFromSelected, isStillSelected, ref toClear);
                    }
                    else if (iMenuKey > 0)
                    {
                        SelectPreviousMenu(iRowBefore, ref menu, ref dgv, dgvBefore, ref toClear);
                    }

                    break;
                case Key.Right:
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

                    break;
                case Key.Escape:
#if TODO // WPF Key Modifier!
                case Key.Alt | Key.F4:
#endif
                    RowDeselected(iRowBefore, dgvBefore);
                    iMenuKey = 0;
                    iRowKey = -1;
                    toClear = true;
                    ClosePressed?.Invoke();
                    break;
                default:
                    if (!string.IsNullOrEmpty(keyInput))
                    {
                        if (SelectMatched(dgv, iRowKey, keyInput) ||
                            SelectMatched(dgv, 0, keyInput))
                        {
                            RowDeselected(iRowBefore, null);
                            SelectRow(dgv, iRowKey);
                            toClear = true;
                        }
                        else if (isStillSelected)
                        {
                            iRowKey = iRowBefore - 1;
                            if (SelectMatched(dgv, iRowKey, keyInput) ||
                                SelectMatched(dgv, 0, keyInput))
                            {
                                RowDeselected(iRowBefore, null);
                                SelectRow(dgv, iRowKey);
                            }
                            else
                            {
                                iRowKey = iRowBefore;
                            }
                        }
                    }

                    break;
            }

            if (isStillSelected && toClear)
            {
                ClearIsSelectedByKey(iMenuBefore, iRowBefore);
            }
        }

        private void SelectPreviousMenu(int iRowBefore, ref Menu menu, ref ListView dgv, ListView dgvBefore, ref bool toClear)
        {
            if (iMenuKey > 0)
            {
                if (menus[iMenuKey - 1] != null)
                {
                    iMenuKey -= 1;
                    iRowKey = -1;
                    menu = menus[iMenuKey];
                    dgv = menu.GetDataGridView();
#if TODO
                    if (SelectMatched(dgv, dgv.SelectedRows[0].Index) ||
                        SelectMatched(dgv, 0))
                    {
                        RowDeselected(iRowBefore, dgvBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                    }
#endif
                }
            }
            else
            {
                RowDeselected(iRowBefore, dgvBefore);
                iMenuKey = 0;
                iRowKey = -1;
                toClear = true;
                Cleared?.Invoke();
            }
        }

        private void SelectNextMenu(int iRowBefore, ref ListView dgv, ListView dgvBefore, Menu menuFromSelected, bool isStillSelected, ref bool toClear)
        {
            int iMenuKeyNext = iMenuKey + 1;
            if (isStillSelected)
            {
                if (menuFromSelected != null &&
                    menuFromSelected == menus[iMenuKeyNext])
                {
                    dgv = menuFromSelected.GetDataGridView();
                    if (dgv.Items.Count > 0)
                    {
                        iMenuKey += 1;
                        iRowKey = -1;
                        if (SelectMatched(dgv, iRowKey) ||
                            SelectMatched(dgv, 0))
                        {
                            RowDeselected(iRowBefore, dgvBefore);
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
                if (menus[iMenuKey] != null)
                {
                    dgv = menus[iMenuKey].GetDataGridView();
                    if (SelectMatched(dgv, iRowKey) ||
                        SelectMatched(dgv, 0))
                    {
                        RowDeselected(iRowBefore, dgvBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                    }
                }
            }
        }

        private void SelectRow(ListView dgv, int iRowKey)
        {
            InUse = true;
            RowSelected(dgv, iRowKey);
        }

        private bool SelectMatched(ListView dgv, int indexStart, string keyInput = "")
        {
            bool found = false;
            for (int i = indexStart; i < dgv.Items.Count; i++)
            {
                if (Select(dgv, i, keyInput))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        private bool SelectMatchedReverse(ListView dgv, int indexStart, string keyInput = "")
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

        private bool Select(ListView dgv, int i, string keyInput = "")
        {
            bool found = false;
            if (i > -1 &&
                i != iRowKey &&
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
            Menu menu = menus[menuIndex];
            if (menu != null && rowIndex > -1)
            {
                ListView dgv = menu.GetDataGridView();
                if (dgv.Items.Count > rowIndex)
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