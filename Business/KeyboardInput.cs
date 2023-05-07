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
        private readonly KeyboardHook hook = new();

        private Menu? focussedMenu;
        private ListViewItemData? focussedRow;

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

        internal bool RegisterHotKey(string hotKey)
        {
            if (!string.IsNullOrEmpty(hotKey))
            {
                try
                {
                    hook.RegisterHotKey();
                    hook.KeyPressed += (sender, e) => HotKeyPressed?.Invoke();
                }
                catch (InvalidOperationException ex)
                {
                    Log.Warn($"Hotkey cannot be set: '{hotKey}'", ex);
                    return false;
                }
            }

            return true;
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
                        // Walk to previous text box and warp around when main menu reached
                        Menu? menu = sender.ParentMenu;
                        if (menu == null)
                        {
                            menu = sender;
                            while (menu.SubMenu != null)
                            {
                                menu = menu.SubMenu;
                            }
                        }

                        menu.FocusTextBox();
                    }
                    else if (modifiers == ModifierKeys.Shift)
                    {
                        // Walk to next text box and warp around back to main menu on last sub menu
                        Menu? menu = sender.SubMenu ?? sender.MainMenu;
                        menu.FocusTextBox();
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
        }

        internal void SearchTextChanged(Menu menu, bool isSearchStringEmpty)
        {
            ClearIsSelectedByKey();

            if (!isSearchStringEmpty)
            {
                ListView dgv = menu.GetDataGridView();
                if (dgv.Items.Count > 0)
                {
                    MouseSelect(menu, (ListViewItemData)dgv.Items[0]);
                }
            }
        }

        internal void ClearIsSelectedByKey()
        {
            ClearIsSelectedByKey(focussedMenu, focussedRow);
        }

        internal void MouseSelect(Menu menu, ListViewItemData itemData)
        {
            InUse = false;

            ClearIsSelectedByKey();

            focussedMenu = menu;
            Select(menu.GetDataGridView(), itemData);
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
            ListViewItemData? rowBefore = focussedRow;
            bool doClearOldSelection = false;
            bool wasSelected = focussedRow?.data.IsSelected ?? false;

            if (wasSelected)
            {
                menuFromSelected = focussedRow?.data.SubMenu;
                menuBefore = focussedMenu;
            }
            else
            {
                ResetSelectedByKey();
                menuFromSelected = null;
                menuBefore = null;
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
                        menuBefore != null &&
                        (TrySelectPrevious(menuBefore, menuBefore.GetDataGridView().Items.IndexOf(rowBefore)) ||
                        TrySelectPrevious(menuBefore, menuBefore.GetDataGridView().Items.Count - 1)))
                    {
                        RaiseRowSelectionChanged(menuBefore, rowBefore);
                        doClearOldSelection = wasSelected;
                    }

                    break;
                case Key.Down:
                    if ((modifiers == ModifierKeys.None) &&
                        menuBefore != null &&
                        (TrySelectNext(menuBefore, menuBefore.GetDataGridView().Items.IndexOf(rowBefore)) ||
                        TrySelectNext(menuBefore, 0)))
                    {
                        RaiseRowSelectionChanged(menuBefore, rowBefore);
                        doClearOldSelection = wasSelected;
                    }

                    break;
                case Key.Home:
                    if ((modifiers == ModifierKeys.None) &&
                        menuBefore != null &&
                        TrySelectNext(menuBefore, 0))
                    {
                        RaiseRowSelectionChanged(menuBefore, rowBefore);
                        doClearOldSelection = wasSelected;
                    }

                    break;
                case Key.End:
                    if ((modifiers == ModifierKeys.None) &&
                        menuBefore != null &&
                        TrySelectPrevious(menuBefore, menuBefore.GetDataGridView().Items.Count - 1))
                    {
                        RaiseRowSelectionChanged(menuBefore, rowBefore);
                        doClearOldSelection = wasSelected;
                    }

                    break;
                case Key.Left:
                case Key.Right:
                    if (modifiers == ModifierKeys.None &&
                        menuBefore != null &&
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
                            // Next is in key direction or prev is opposite of key direction ==> Select sub/next menu
                            if (wasSelected)
                            {
                                if (menuFromSelected != null &&
                                    menuFromSelected == focussedMenu?.SubMenu)
                                {
                                    focussedMenu = menuFromSelected;
                                    focussedRow = null;
                                    if (TrySelectNext(menuFromSelected, 0))
                                    {
                                        RaiseRowSelectionChanged(menuBefore, rowBefore);
                                        doClearOldSelection = wasSelected;
                                    }
                                }
                            }
                            else
                            {
                                while (focussedMenu?.SubMenu != null)
                                {
                                    focussedMenu = focussedMenu.SubMenu;
                                }

                                focussedRow = null;
                                Menu? lastMenu = focussedMenu;
                                if (lastMenu != null && TrySelectNext(lastMenu, 0))
                                {
                                    RaiseRowSelectionChanged(menuBefore, rowBefore);
                                    doClearOldSelection = wasSelected;
                                }
                            }
                        }
                        else if (focussedMenu?.ParentMenu != null)
                        {
                            // Next is in opposite key direction and prev is in key direction ==> Select parent/prev menu
                            focussedMenu = focussedMenu.ParentMenu;
                            focussedRow = null;
                            ListView dgv = focussedMenu.GetDataGridView();
                            if (TrySelectNext(focussedMenu, dgv.Items.IndexOf(dgv.SelectedItems.Count > 0 ? dgv.SelectedItems[0] : null)) ||
                                TrySelectNext(focussedMenu, 0))
                            {
                                RaiseRowSelectionChanged(menuBefore, rowBefore);
                                doClearOldSelection = wasSelected;
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
                        doClearOldSelection = wasSelected;
                        ClosePressed?.Invoke();
                    }

                    break;
                default:
                    break;
            }

            if (doClearOldSelection)
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

        private bool TrySelectNext(Menu menu, int indexStart)
        {
            bool found = false;
            if (indexStart >= 0)
            {
                ListView dgv = menu.GetDataGridView();
                for (uint i = (uint)indexStart; i < dgv.Items.Count; i++)
                {
                    ListViewItemData itemData = (ListViewItemData)dgv.Items[(int)i];
                    if (itemData != focussedRow)
                    {
                        Select(dgv, itemData);
                        dgv.ScrollIntoView(itemData);
                        found = true;
                        break;
                    }
                }
            }

            return found;
        }

        private bool TrySelectPrevious(Menu menu, int indexStart)
        {
            bool found = false;
            if (indexStart > 0)
            {
                ListView dgv = menu.GetDataGridView();
                if (dgv.Items.Count <= indexStart)
                {
                    indexStart = dgv.Items.Count - 1;
                }

                for (int i = indexStart; i > -1; i--)
                {
                    ListViewItemData itemData = (ListViewItemData)dgv.Items[i];
                    if (itemData != focussedRow)
                    {
                        Select(dgv, itemData);
                        dgv.ScrollIntoView(itemData);
                        found = true;
                        break;
                    }
                }
            }

            return found;
        }

        private void Select(ListView dgv, ListViewItemData itemData)
        {
            focussedRow = itemData;
            itemData.data.IsSelected = true;

            // TODO: Refresh ListViewItems - optimize out
            //       ([remove and] add item to procove selection changed handler)
            if (dgv.SelectedItems.Contains(itemData))
            {
                dgv.SelectedItems.Remove(itemData);
            }

            dgv.SelectedItems.Add(itemData);
        }
    }
}
