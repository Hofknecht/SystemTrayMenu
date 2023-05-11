// <copyright file="KeyboardInput.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Handler
{
    using System;
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

        internal event Action? HotKeyPressed;

        internal event Action? ClosePressed;

        internal event Action<Menu?>? RowSelectionChanged;

        internal event Action<Menu, ListViewItemData>? EnterPressed;

        internal bool IsSelectedByKey { get; set; }

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

        internal void ResetSelectedByKey() => focussedMenu = null;

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
                        Menu? menu = focussedMenu;
                        ListViewItemData? itemData = menu?.SelectedItem;
                        if (menu != null && itemData != null)
                        {
                            var position = Mouse.GetPosition(menu);
                            position.Offset(menu.Left, menu.Top);
                            itemData.OpenShellContextMenu(position);
                        }
                    }

                    break;
                default:
                    break;
            }
        }

        internal void SearchTextChanged(Menu menu, bool isSearchStringEmpty)
        {
            DeselectFoccussedRow();

            if (!isSearchStringEmpty)
            {
                ListView dgv = menu.GetDataGridView();
                if (dgv.Items.Count > 0)
                {
                    MouseSelect(menu, (ListViewItemData)dgv.Items[0]);
                }
            }
        }

        internal void DeselectFoccussedRow()
        {
            if (focussedMenu != null)
            {
                focussedMenu.SelectedItem = null;
            }
        }

        internal void MouseSelect(Menu menu, ListViewItemData itemData)
        {
            IsSelectedByKey = false;

            DeselectFoccussedRow();

            focussedMenu = menu;
            menu.GetDataGridView().SelectedItem = itemData;
        }

        private void SelectByKey(Key key, ModifierKeys modifiers)
        {
            Menu? menuFromSelected;
            Menu? menuBefore;
            ListViewItemData? rowBefore = focussedMenu?.SelectedItem;
            bool wasSelected = rowBefore != null;

            if (wasSelected)
            {
                menuFromSelected = rowBefore!.data.SubMenu;
                menuBefore = focussedMenu;
            }
            else
            {
                focussedMenu = null;
                menuFromSelected = null;
                menuBefore = null;
            }

            switch (key)
            {
                case Key.Enter:
                    if ((modifiers == ModifierKeys.None) && rowBefore != null && menuBefore != null)
                    {
                        // When not sub menu already open, open the sub menu,
                        // but when already opened, open the actual folder instead.
                        // In case it is a single file, open it right away
                        RowData trigger = rowBefore.data;
                        if (trigger.SubMenu != null || !trigger.IsPointingToFolder)
                        {
                            rowBefore.OpenItem(out bool doCloseAfterOpen);
                            if (doCloseAfterOpen)
                            {
                                ClosePressed?.Invoke();
                            }
                        }
                        else
                        {
                            RaiseRowSelectionChanged();
                            EnterPressed?.Invoke(menuBefore, rowBefore);
                        }
                    }

                    break;
                case Key.Up:
                    if ((modifiers == ModifierKeys.None) &&
                        menuBefore != null &&
                        menuBefore.TrySelectAt(menuBefore.GetDataGridView().Items.IndexOf(menuBefore.SelectedItem) - 1, menuBefore.GetDataGridView().Items.Count - 1))
                    {
                        RaiseRowSelectionChanged();
                    }

                    break;
                case Key.Down:
                    if ((modifiers == ModifierKeys.None) &&
                        menuBefore != null &&
                        menuBefore.TrySelectAt(menuBefore.GetDataGridView().Items.IndexOf(menuBefore.SelectedItem) + 1, 0))
                    {
                        RaiseRowSelectionChanged();
                    }

                    break;
                case Key.Home:
                    if ((modifiers == ModifierKeys.None) &&
                        menuBefore != null &&
                        menuBefore.TrySelectAt(0, -1))
                    {
                        RaiseRowSelectionChanged();
                    }

                    break;
                case Key.End:
                    if ((modifiers == ModifierKeys.None) &&
                        menuBefore != null &&
                        menuBefore.TrySelectAt(menuBefore.GetDataGridView().Items.Count - 1, -1))
                    {
                        RaiseRowSelectionChanged();
                    }

                    break;
                case Key.Left:
                case Key.Right:
                    if (modifiers == ModifierKeys.None &&
                        menuBefore != null &&
                        focussedMenu != null)
                    {
                        Menu? next = focussedMenu.SubMenu;
                        Menu? prev = focussedMenu.ParentMenu;
                        bool nextLeft = next != null && next.Location.X < focussedMenu.Location.X;
                        bool prevLeft = prev != null && prev.Location.X < focussedMenu.Location.X;

                        // P = Parent, N = Next ..
                        // Menues come from right in examples
                        //
                        // Key Pressed: <-
                        //   [N][ ][P]   - Select next as in key direction
                        //      [ ][P/N] - Select prev going left as going right would select next
                        //      [ ][P]   - don't do anything
                        //   [N][ ]      - Select next as in key direction
                        // [P/N][ ]      - Select next as next has priority
                        //
                        // Key Pressed: ->
                        //   [N][ ][P]   - Select prev as in key direction
                        //      [ ][P/N] - Select next as next has priority
                        //      [ ][P]   - Select prev as in key direction
                        //   [N][ ]      - don't do anything
                        // [P/N][ ]      - Select prev going right as going left would select next
                        if (next != null && nextLeft == (key == Key.Left))
                        {
                            // Select next sub menu, when next exists and
                            // next and key point in the same direction
                            if (next!.TrySelectAt(0, -1))
                            {
                                focussedMenu = next;
                                RaiseRowSelectionChanged();
                            }
                        }
                        else if (prev != null &&
                            ((prevLeft == (key == Key.Left)) ||
                            (next != null && nextLeft == prevLeft)))
                        {
                            // Select previous/parent menu, when prev exists and
                            // either prev and key point in the same direction
                            // or when next exists while overlapping with prev
                            int index = focussedMenu.RowDataParent?.RowIndex ?? -1;
                            if (focussedMenu.TrySelectAt(index, 0))
                            {
                                focussedMenu = focussedMenu.ParentMenu;
                                RaiseRowSelectionChanged();
                            }
                        }
                    }

                    break;
                case Key.Escape:
                    if (modifiers == ModifierKeys.None)
                    {
                        focussedMenu = null;
                        RaiseRowSelectionChanged();
                        ClosePressed?.Invoke();
                    }

                    break;
                default:
                    break;
            }
        }

        private void RaiseRowSelectionChanged()
        {
            RowSelectionChanged?.Invoke(focussedMenu);

            if (focussedMenu?.SelectedItem != null)
            {
                IsSelectedByKey = true;
            }
        }
    }
}
