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
        private readonly KeyboardHook hook = new KeyboardHook();

        private int iRowKey = -1;
        private int iMenuKey;

        public KeyboardInput(Menu[] menus)
        {
            this.menus = menus;
        }

        internal event EventHandlerEmpty HotKeyPressed;

        internal event EventHandlerEmpty ClosePressed;

        internal event Action<DataGridView, int> RowSelected;

        internal event Action<int, DataGridView> RowDeselected;

        internal event Action<DataGridView, int> EnterPressed;

        internal event EventHandlerEmpty Cleared;

        internal bool InUse { get; set; }

        /// <inheritdoc/>
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
                    hook.KeyPressed += Hook_KeyPressed;
                    void Hook_KeyPressed(object sender, KeyPressedEventArgs e)
                    {
                        HotKeyPressed?.Invoke();
                    }
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

        internal void CmdKeyProcessed(object sender, Keys keys)
        {
            switch (keys)
            {
                case Keys.Enter:
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.Escape:
                    SelectByKey(keys);
                    break;
                case Keys.Control | Keys.F:
                    Menu menu = menus[iMenuKey];
                    menu.FocusTextBox();
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

                        menus[indexNew].FocusTextBox();
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

                        menus[indexNew].FocusTextBox();
                    }

                    break;
                case Keys.Apps:
                    {
                        DataGridView dgv = menus[iMenuKey].GetDataGridView();

                        if (iRowKey > -1 &&
                            dgv.Rows.Count > iRowKey)
                        {
                            Point pt = dgv.GetCellDisplayRectangle(2, iRowKey, false).Location;
                            RowData trigger = (RowData)dgv.Rows[iRowKey].Cells[2].Value;
                            MouseEventArgs mea = new MouseEventArgs(MouseButtons.Right, 1, pt.X, pt.Y, 0);
                            trigger.MouseDown(dgv, mea, out bool toCloseByDoubleClick);
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

        /// <summary>
        /// While menu is open user presses a key to search for specific entries.
        /// </summary>
        /// <param name="sender">not used.</param>
        /// <param name="e">Key data of the pressed key.</param>
        internal void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar) ||
                char.IsWhiteSpace(e.KeyChar) ||
                char.IsSeparator(e.KeyChar))
            {
                string letter = e.KeyChar.ToString(CultureInfo.InvariantCulture);

                Menu menu = menus[iMenuKey];
                menu.KeyPressedSearch(letter);

                e.Handled = true;
            }
        }

        internal void SearchTextChanging()
        {
            ClearIsSelectedByKey();
        }

        internal void SearchTextChanged(Menu menu)
        {
            DataGridView dgv = menu.GetDataGridView();
            if (dgv.Rows.Count > 0)
            {
                Select(dgv, 0, true);
            }
        }

        internal void ClearIsSelectedByKey()
        {
            ClearIsSelectedByKey(iMenuKey, iRowKey);
        }

        internal void Select(DataGridView dgv, int i, bool refreshview)
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
                rowData.IsSelected = true;
                if (refreshview)
                {
                    row.Selected = false;
                    row.Selected = true;
                }
            }
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
                    if (iRowKey > -1 &&
                        dgv.Rows.Count > iRowKey)
                    {
                        RowData trigger = (RowData)dgv.Rows[iRowKey].Cells[2].Value;
                        if (trigger.IsMenuOpen || !trigger.ContainsMenu)
                        {
                            trigger.MouseDown(
                                dgv,
                                null,
                                out bool toCloseByMouseDown);
                            trigger.DoubleClick(
                                new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0),
                                out bool toCloseByDoubleClick);
                            if (toCloseByMouseDown || toCloseByDoubleClick)
                            {
                                ClosePressed?.Invoke();
                            }
                        }
                        else
                        {
                            RowDeselected(iRowBefore, dgvBefore);
                            SelectRow(dgv, iRowKey);
                            EnterPressed.Invoke(dgv, iRowKey);
                        }
                    }

                    break;
                case Keys.Up:
                    if (SelectMatchedReverse(dgv, iRowKey) ||
                        SelectMatchedReverse(dgv, dgv.Rows.Count - 1))
                    {
                        RowDeselected(iRowBefore, dgvBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                    }

                    break;
                case Keys.Down:
                    if (SelectMatched(dgv, iRowKey) ||
                        SelectMatched(dgv, 0))
                    {
                        RowDeselected(iRowBefore, dgvBefore);
                        SelectRow(dgv, iRowKey);
                        toClear = true;
                    }

                    break;
                case Keys.Left:
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

                    break;
                case Keys.Right:
                    if (iMenuKey > 0)
                    {
                        if (menus[iMenuKey - 1] != null)
                        {
                            iMenuKey -= 1;
                            iRowKey = -1;
                            menu = menus[iMenuKey];
                            dgv = menu.GetDataGridView();
                            if (SelectMatched(dgv, dgv.SelectedRows[0].Index) ||
                                SelectMatched(dgv, 0))
                            {
                                RowDeselected(iRowBefore, dgvBefore);
                                SelectRow(dgv, iRowKey);
                                toClear = true;
                            }
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

                    break;
                case Keys.Escape:
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
                    RowData rowData = (RowData)row.Cells[2].Value;
                    rowData.IsSelected = false;
                    row.Selected = false;
                }
            }
        }
    }
}