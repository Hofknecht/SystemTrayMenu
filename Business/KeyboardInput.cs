// <copyright file="KeyboardInput.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Handler
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.Helper;
    using SystemTrayMenu.Utilities;
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

        public event Action HotKeyPressed;

        public event Action ClosePressed;

        public event Action<DataGridView, int> RowSelected;

        public event Action<DataGridView, int> RowDeselected;

        public event Action<DataGridView, int> EnterPressed;

        public event Action Cleared;

        public bool InUse { get; set; }

        public void Dispose()
        {
            hook.KeyPressed -= Hook_KeyPressed;
            hook.Dispose();
        }

        public void RegisterHotKey()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.HotKey))
            {
                try
                {
                    hook.RegisterHotKey();
                    hook.KeyPressed += Hook_KeyPressed;
                }
                catch (InvalidOperationException ex)
                {
                    Log.Warn($"key:'{Properties.Settings.Default.HotKey}'", ex);
                    Properties.Settings.Default.HotKey = string.Empty;
                    Properties.Settings.Default.Save();
                }
            }
        }

        public void ResetSelectedByKey()
        {
            iRowKey = -1;
            iMenuKey = 0;
        }

        public void CmdKeyProcessed(object sender, Keys keys)
        {
            sender ??= menus[iMenuKey];

            switch (keys)
            {
                case Keys.Enter:
                    SelectByKey(keys);
                    menus[iMenuKey]?.FocusTextBox();
                    break;
                case Keys.Left:
                    SelectByKey(keys);
                    break;
                case Keys.Right:
                    SelectByKey(keys);
                    break;
                case Keys.Home:
                case Keys.End:
                case Keys.Up:
                case Keys.Down:
                case Keys.Escape:
                case Keys.Alt | Keys.F4:
                    SelectByKey(keys);
                    break;
                case Keys.Control | Keys.F:
                    menus[iMenuKey]?.FocusTextBox();
                    break;
                case Keys.Tab:
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
                case Keys.Tab | Keys.Shift:
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
                case Keys.Apps:
                    {
                        DataGridView dgv = menus[iMenuKey]?.GetDataGridView();

                        if (iRowKey > -1 &&
                            dgv.Rows.Count > iRowKey)
                        {
                            Point point = dgv.GetCellDisplayRectangle(2, iRowKey, false).Location;
                            RowData trigger = (RowData)dgv.Rows[iRowKey].Cells[2].Value;
                            MouseEventArgs mouseEventArgs = new(MouseButtons.Right, 1, point.X, point.Y, 0);
                            trigger.MouseDown(dgv, mouseEventArgs);
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

        public void SearchTextChanging()
        {
            ClearIsSelectedByKey();
        }

        public void SearchTextChanged(Menu menu, bool isSearchStringEmpty)
        {
            DataGridView dgv = menu.GetDataGridView();
            if (isSearchStringEmpty)
            {
                ClearIsSelectedByKey();
            }
            else if (dgv.Rows.Count > 0)
            {
                Select(dgv, 0, true);
            }
        }

        public void ClearIsSelectedByKey()
        {
            ClearIsSelectedByKey(iMenuKey, iRowKey);
        }

        public void Select(DataGridView dgv, int i, bool refreshview)
        {
            int newiMenuKey = ((Menu)dgv.TopLevelControl).Level;
            if (i != iRowKey || newiMenuKey != iMenuKey)
            {
                ClearIsSelectedByKey();
            }

            iRowKey = i;
            iMenuKey = newiMenuKey;

            if (dgv.Rows.Count > i)
            {
                DataGridViewRow row = dgv.Rows[i];
                RowData rowData = (RowData)row.Cells[2].Value;
                if (rowData != null)
                {
                    rowData.IsSelected = true;
                }

                if (refreshview)
                {
                    row.Selected = false;
                    row.Selected = true;
                }
            }
        }

        private void Hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            HotKeyPressed?.Invoke();
        }

        private bool IsAnyMenuSelectedByKey(
            ref DataGridView dgv,
            ref Menu menuFromSelected,
            ref string textselected)
        {
            Menu menu = menus[iMenuKey];
            bool isStillSelected = false;
            if (menu != null &&
                iRowKey > -1)
            {
                dgv = menu.GetDataGridView();
                if (dgv.Rows.Count > iRowKey)
                {
                    RowData rowData = (RowData)dgv.
                        Rows[iRowKey].Cells[2].Value;
                    if (rowData.IsSelected)
                    {
                        isStillSelected = true;
                        menuFromSelected = rowData.SubMenu;
                        textselected = dgv.Rows[iRowKey].
                            Cells[1].Value.ToString();
                    }
                }
            }

            return isStillSelected;
        }

        private void SelectByKey(Keys keys, string keyInput = "", bool keepSelection = false)
        {
            int iRowBefore = iRowKey;
            int iMenuBefore = iMenuKey;

            Menu menu = menus[iMenuKey];
            DataGridView dgv = null;
            DataGridView dgvBefore = null;
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
                case Keys.Enter:
                    if (iRowKey > -1 && dgv.Rows.Count > iRowKey)
                    {
                        RowData trigger = (RowData)dgv.Rows[iRowKey].Cells[2].Value;
                        if (trigger.IsMenuOpen || !trigger.ContainsMenu)
                        {
                            trigger.MouseClick(null, out bool toCloseByMouseClick);
                            trigger.DoubleClick(
                                new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0),
                                out bool toCloseByDoubleClick);
                            if (toCloseByMouseClick || toCloseByDoubleClick)
                            {
                                ClosePressed?.Invoke();
                            }

                            if (iRowKey > -1 && dgv.Rows.Count > iRowKey)
                            {
                                // Raise Dgv_RowPostPaint to show ProcessStarted
                                dgv.InvalidateRow(iRowKey);
                            }
                        }
                        else
                        {
                            RowDeselected(dgvBefore, iRowBefore);
                            SelectRow(dgv, iRowKey);
                            EnterPressed.Invoke(dgv, iRowKey);
                        }
                    }

                    break;
                case Keys.Up:
                    if (SelectMatchedReverse(dgv, iRowKey) ||
                        SelectMatchedReverse(dgv, dgv.Rows.Count - 1))
                    {
                        RowDeselected(dgvBefore, iRowBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                    }

                    break;
                case Keys.Down:
                    if (SelectMatched(dgv, iRowKey) ||
                        SelectMatched(dgv, 0))
                    {
                        RowDeselected(dgvBefore, iRowBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                    }

                    break;
                case Keys.Home:
                    if (SelectMatched(dgv, 0))
                    {
                        RowDeselected(dgvBefore, iRowBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                    }

                    break;
                case Keys.End:
                    if (SelectMatchedReverse(dgv, dgv.Rows.Count - 1))
                    {
                        RowDeselected(dgvBefore, iRowBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                    }

                    break;
                case Keys.Left:
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
                case Keys.Right:
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
                case Keys.Escape:
                case Keys.Alt | Keys.F4:
                    RowDeselected(dgvBefore, iRowBefore);
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
                            RowDeselected(null, iRowBefore);
                            SelectRow(dgv, iRowKey);
                            toClear = true;
                        }
                        else if (isStillSelected)
                        {
                            iRowKey = iRowBefore - 1;
                            if (SelectMatched(dgv, iRowKey, keyInput) ||
                                SelectMatched(dgv, 0, keyInput))
                            {
                                RowDeselected(null, iRowBefore);
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

        private void SelectPreviousMenu(int iRowBefore, ref Menu menu, ref DataGridView dgv, DataGridView dgvBefore, ref bool toClear)
        {
            if (iMenuKey > 0)
            {
                if (menus[iMenuKey - 1] != null)
                {
                    iMenuKey -= 1;
                    iRowKey = -1;
                    menu = menus[iMenuKey];
                    dgv = menu.GetDataGridView();
                    if ((dgv.SelectedRows.Count > 0 &&
                        SelectMatched(dgv, dgv.SelectedRows[0].Index)) ||
                        SelectMatched(dgv, 0))
                    {
                        RowDeselected(dgvBefore, iRowBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                    }
                }
            }
            else
            {
                RowDeselected(dgvBefore, iRowBefore);
                iMenuKey = 0;
                iRowKey = -1;
                toClear = true;
                Cleared?.Invoke();
            }
        }

        private void SelectNextMenu(int iRowBefore, ref DataGridView dgv, DataGridView dgvBefore, Menu menuFromSelected, bool isStillSelected, ref bool toClear)
        {
            int iMenuKeyNext = iMenuKey + 1;
            if (isStillSelected)
            {
                if (menuFromSelected != null &&
                    menuFromSelected == menus[iMenuKeyNext])
                {
                    dgv = menuFromSelected.GetDataGridView();
                    if (dgv.Rows.Count > 0)
                    {
                        iMenuKey += 1;
                        iRowKey = -1;
                        if (SelectMatched(dgv, iRowKey) ||
                            SelectMatched(dgv, 0))
                        {
                            RowDeselected(dgvBefore, iRowBefore);
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
                        RowDeselected(dgvBefore, iRowBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                    }
                }
            }
        }

        private void SelectRow(DataGridView dgv, int iRowKey)
        {
            InUse = true;
            RowSelected(dgv, iRowKey);
        }

        private bool SelectMatched(DataGridView dgv, int indexStart, string keyInput = "")
        {
            bool found = false;
            for (int i = indexStart; i < dgv.Rows.Count; i++)
            {
                if (Select(dgv, i, keyInput))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        private bool SelectMatchedReverse(DataGridView dgv, int indexStart, string keyInput = "")
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

        private bool Select(DataGridView dgv, int i, string keyInput = "")
        {
            bool found = false;
            if (i > -1 &&
                i != iRowKey &&
                dgv.Rows.Count > i)
            {
                DataGridViewRow row = dgv.Rows[i];
                RowData rowData = (RowData)row.Cells[2].Value;
                string text = row.Cells[1].Value.ToString();
                if (text.StartsWith(keyInput, true, CultureInfo.InvariantCulture))
                {
                    iRowKey = rowData.RowIndex;
                    rowData.IsSelected = true;
                    row.Selected = false;
                    row.Selected = true;
                    if (row.Index < dgv.FirstDisplayedScrollingRowIndex)
                    {
                        dgv.FirstDisplayedScrollingRowIndex = row.Index;
                    }
                    else if (row.Index >=
                        dgv.FirstDisplayedScrollingRowIndex +
                        dgv.DisplayedRowCount(false))
                    {
                        dgv.FirstDisplayedScrollingRowIndex = row.Index -
                        dgv.DisplayedRowCount(false) + 1;
                    }

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
                DataGridView dgv = menu.GetDataGridView();
                if (dgv.Rows.Count > rowIndex)
                {
                    DataGridViewRow row = dgv.Rows[rowIndex];
                    row.Selected = false;
                    RowData rowData = (RowData)row.Cells[2].Value;
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