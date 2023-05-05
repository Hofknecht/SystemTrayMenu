// <copyright file="KeyboardInput.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Handler
{
    using System;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Input;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.Helpers;
    using SystemTrayMenu.Utilities;
    using static SystemTrayMenu.UserInterface.Menu;
    using Menu = SystemTrayMenu.UserInterface.Menu;

    internal class KeyboardInput : IDisposable
    {
        private readonly Menu?[] menus;
        private readonly KeyboardHook hook = new();

        private Menu? focussedMenu;
        private ListViewItemData? focussedRow;

        public KeyboardInput(Menu?[] menus)
        {
            this.menus = menus;
        }

        internal event Action? HotKeyPressed;

        internal event Action? ClosePressed;

        internal event Action<Menu, ListViewItemData>? RowSelected;

        internal event Action<Menu?, ListViewItemData?>? RowDeselected;

        internal event Action<Menu, ListViewItemData>? EnterPressed;

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
            focussedMenu = null;
            focussedRow = null;
        }

        internal void CmdKeyProcessed(Menu sender, Key key, ModifierKeys modifiers)
        {
            switch (key)
            {
                case Key.Enter:
                    if (modifiers == ModifierKeys.None)
                    {
                        SelectByKey(key, modifiers);
                        focussedMenu?.FocusTextBox();
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
                        focussedMenu?.FocusTextBox();
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
                        ListView? dgv = focussedMenu?.GetDataGridView();
                        if (dgv != null)
                        {
                            if (focussedRow != null)
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
                ListView dgv = menu.GetDataGridView();
                if (dgv.Items.Count > 0)
                {
                    Select(menu, (ListViewItemData)dgv.Items[0], true);
                }
            }
        }

        internal void ClearIsSelectedByKey()
        {
            ClearIsSelectedByKey(focussedMenu, focussedRow);
        }

        internal void Select(Menu menu, ListViewItemData itemData, bool refreshview)
        {
            if (itemData != focussedRow || menu != focussedMenu)
            {
                ClearIsSelectedByKey();
            }

            focussedMenu = menu;
            focussedRow = itemData;

            itemData.data.IsSelected = true;

            if (refreshview)
            {
                ListView dgv = menu.GetDataGridView();
                if (dgv.SelectedItems.Contains(itemData))
                {
                    dgv.SelectedItems.Remove(itemData);
                }

                dgv.SelectedItems.Add(itemData);
            }
        }

        private static void ClearIsSelectedByKey(Menu? menu, ListViewItemData? itemData)
        {
            if (menu != null && itemData != null)
            {
                ListView dgv = menu.GetDataGridView();
                if (dgv.SelectedItems.Contains(itemData))
                {
                    dgv.SelectedItems.Remove(itemData);
                }

                itemData.data.IsSelected = false;
                itemData.data.IsClicking = false;
            }
        }

        private void SelectByKey(Key key, ModifierKeys modifiers)
        {
            Menu? menuFromSelected;
            Menu? menuBefore;
            ListView? dgvBefore;
            ListViewItemData? rowBefore = focussedRow;
            bool toClear = false;
            bool isSelected = focussedRow?.data.IsSelected ?? false;

            if (isSelected)
            {
                menuFromSelected = focussedRow?.data.SubMenu;
                menuBefore = focussedMenu;
                dgvBefore = menuBefore?.GetDataGridView();
            }
            else
            {
                ResetSelectedByKey();
                menuFromSelected = null;
                menuBefore = null;
                dgvBefore = null;
            }

            switch (key)
            {
                case Key.Enter:
                    if ((modifiers == ModifierKeys.None) && rowBefore != null && menuBefore != null)
                    {
                        RowData trigger = rowBefore.data;
                        if (trigger.IsMenuOpen || !trigger.IsPointingToFolder)
                        {
                            trigger.OpenItem(out bool doCloseAfterOpen);
                            if (doCloseAfterOpen)
                            {
                                ClosePressed?.Invoke();
                            }
                        }
                        else
                        {
                            RaiseRowSelectionChanged(menuBefore, rowBefore);
                            EnterPressed?.Invoke(menuBefore, rowBefore);
                        }
                    }

                    break;
                case Key.Up:
                    if ((modifiers == ModifierKeys.None) &&
                        dgvBefore != null &&
                        (TrySelectPrevious(dgvBefore, dgvBefore.Items.IndexOf(rowBefore)) ||
                        TrySelectPrevious(dgvBefore, dgvBefore.Items.Count - 1)))
                    {
                        RaiseRowSelectionChanged(menuBefore, rowBefore);
                        toClear = true;
                    }

                    break;
                case Key.Down:
                    if ((modifiers == ModifierKeys.None) &&
                        dgvBefore != null &&
                        (TrySelectNext(dgvBefore, dgvBefore.Items.IndexOf(rowBefore)) ||
                        TrySelectNext(dgvBefore, 0)))
                    {
                        RaiseRowSelectionChanged(menuBefore, rowBefore);
                        toClear = true;
                    }

                    break;
                case Key.Home:
                    if ((modifiers == ModifierKeys.None) &&
                        dgvBefore != null &&
                        TrySelectNext(dgvBefore, 0))
                    {
                        RaiseRowSelectionChanged(menuBefore, rowBefore);
                        toClear = true;
                    }

                    break;
                case Key.End:
                    if ((modifiers == ModifierKeys.None) &&
                        dgvBefore != null &&
                        TrySelectPrevious(dgvBefore, dgvBefore.Items.Count - 1))
                    {
                        RaiseRowSelectionChanged(menuBefore, rowBefore);
                        toClear = true;
                    }

                    break;
                case Key.Left:
                case Key.Right:
                    if (modifiers == ModifierKeys.None &&
                        dgvBefore != null &&
                        focussedMenu != null)
                    {
                        // True, when next is left and key is left = true OR next is right (=not left) and key is right (not left)
                        bool nextMenuInKeyDirection = (focussedMenu?.SubMenu?.Location.X < focussedMenu?.Location.X) == (key == Key.Left);

                        // TODO: Check what this actually does as it is only true for wrap arounds on screen corners
                        //       but why not simply just select prev menu instead?
                        // True, when prev is right (=not left) but key is left = true OR prev is left but key is right (not left)
                        bool prevMenuAgainstKeyDirection = (focussedMenu?.Location.X < focussedMenu?.ParentMenu?.Location.X) == (key == Key.Left);

                        if (nextMenuInKeyDirection || prevMenuAgainstKeyDirection)
                        {
                            // Next is in key direction or prev is opposite of key direction ==> TrySelect sub/next menu
                            if (isSelected)
                            {
                                if (menuFromSelected != null &&
                                    menuFromSelected == focussedMenu?.SubMenu)
                                {
                                    ListView dgv = menuFromSelected.GetDataGridView();
                                    if (dgv != null && dgv.Items.Count > 0)
                                    {
                                        focussedMenu = menuFromSelected;
                                        focussedRow = null;
                                        if (TrySelectNext(dgv, 0))
                                        {
                                            RaiseRowSelectionChanged(menuBefore, rowBefore);
                                            toClear = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                focussedMenu = menus[0];
                                while (focussedMenu?.SubMenu != null)
                                {
                                    focussedMenu = focussedMenu.SubMenu;
                                }

                                focussedRow = null;
                                Menu? lastMenu = focussedMenu;
                                if (lastMenu != null)
                                {
                                    ListView dgv = lastMenu.GetDataGridView();
                                    if (TrySelectNext(dgv, 0))
                                    {
                                        RaiseRowSelectionChanged(menuBefore, rowBefore);
                                        toClear = true;
                                    }
                                }
                            }
                        }
                        else if (focussedMenu?.ParentMenu != null)
                        {
                            // Next is in opposite key direction and prev is in key direction ==> TrySelect parent/prev menu
                            focussedMenu = focussedMenu.ParentMenu;
                            focussedRow = null;
                            ListView dgv = focussedMenu.GetDataGridView();
                            if (TrySelectNext(dgv, dgv.Items.IndexOf(dgv.SelectedItems.Count > 0 ? dgv.SelectedItems[0] : null)) ||
                                TrySelectNext(dgv, 0))
                            {
                                RaiseRowSelectionChanged(menuBefore, rowBefore);
                                toClear = true;
                            }
                        }
                    }

                    break;
                case Key.Escape:
                case Key.F4:
                    if ((key == Key.Escape && modifiers == ModifierKeys.None) ||
                        (key == Key.F4 && modifiers == ModifierKeys.Alt))
                    {
                        RowDeselected?.Invoke(menuBefore, rowBefore);
                        ResetSelectedByKey();
                        toClear = true;
                        ClosePressed?.Invoke();
                    }

                    break;
                default:
                    break;
            }

            if (isSelected && toClear)
            {
                ClearIsSelectedByKey(menuBefore, rowBefore);
            }
        }

        private void RaiseRowSelectionChanged(Menu? menuBefore, ListViewItemData? rowBefore)
        {
            RowDeselected?.Invoke(menuBefore, rowBefore);

            if (focussedMenu != null && focussedRow != null)
            {
                InUse = true;
                RowSelected?.Invoke(focussedMenu, focussedRow);
            }
        }

        private bool TrySelectNext(ListView dgv, int indexStart)
        {
            bool found = false;
            if (indexStart >= 0)
            {
                for (uint i = (uint)indexStart; i < dgv.Items.Count; i++)
                {
                    if (TrySelect(dgv, (ListViewItemData)dgv.Items[(int)i]))
                    {
                        found = true;
                        break;
                    }
                }
            }

            return found;
        }

        private bool TrySelectPrevious(ListView dgv, int indexStart)
        {
            bool found = false;
            if (indexStart > 0)
            {
                if (dgv.Items.Count <= indexStart)
                {
                    indexStart = dgv.Items.Count - 1;
                }

                for (int i = indexStart; i > -1; i--)
                {
                    if (TrySelect(dgv, (ListViewItemData)dgv.Items[i]))
                    {
                        found = true;
                        break;
                    }
                }
            }

            return found;
        }

        private bool TrySelect(ListView dgv, ListViewItemData itemData)
        {
            bool found = false;
            if (itemData != focussedRow)
            {
                focussedRow = itemData;
                itemData.data.IsSelected = true;
                if (dgv.SelectedItems.Contains(itemData))
                {
                    dgv.SelectedItems.Remove(itemData);
                }

                dgv.SelectedItems.Add(itemData);
                dgv.ScrollIntoView(itemData);

                found = true;
            }

            return found;
        }
    }
}
