// <copyright file="KeyboardInput.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Handler
{
    using System;
    using System.Windows.Input;
    using SystemTrayMenu.DataClasses;
    using SystemTrayMenu.Helpers;
    using SystemTrayMenu.UserInterface;
    using SystemTrayMenu.Utilities;

    internal class KeyboardInput : IDisposable
    {
        private GlobalHotkeys.HotkeyRegistrationHandle? hotkeyHandle;

        private Menu? focussedMenu;

        internal event Action? HotKeyPressed;

        internal event Action<RowData?>? RowSelectionChanged;

        internal event Action<RowData>? EnterPressed;

        internal bool IsSelectedByKey { get; set; }

        public void Dispose()
        {
            GlobalHotkeys.Unregister(hotkeyHandle);
        }

        internal bool RegisterHotKey(string hotKeyString)
        {
            if (!string.IsNullOrEmpty(hotKeyString))
            {
                try
                {
                    hotkeyHandle = GlobalHotkeys.Register(hotKeyString);
                }
                catch (InvalidOperationException ex)
                {
                    Log.Warn($"Hotkey cannot be set: '{hotKeyString}'", ex);
                    return false;
                }

                hotkeyHandle.KeyPressed += (_) => HotKeyPressed?.Invoke();
            }

            return true;
        }

        internal void ResetSelectedByKey() => focussedMenu = null;

        internal void CmdKeyProcessed(Menu sender, Key key, ModifierKeys modifiers)
        {
            switch (key)
            {
                case Key.Left:
                case Key.Right:
                case Key.Home:
                case Key.End:
                case Key.Up:
                case Key.Down:
                case Key.Enter:
                    if (modifiers == ModifierKeys.None)
                    {
                        if (focussedMenu != null)
                        {
                            SelectByKey(key, focussedMenu);
                        }
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
                        RowData? itemData = menu?.SelectedItem;
                        if (menu != null && itemData != null)
                        {
                            var position = Mouse.GetPosition(menu);
                            position.Offset(menu.Left, menu.Top);
                            itemData.OpenShellContextMenu(position);
                        }
                    }

                    break;
                case Key.Escape:
                    if (modifiers == ModifierKeys.None)
                    {
                        focussedMenu = null;
                        RowSelectionChanged?.Invoke(null); // TODO: Refactor to just a trigger for WaitToLoadMenu ?
                        sender.HideAllMenus();
                    }

                    break;
                default:
                    break;
            }
        }

        internal void SelectByMouse(RowData itemData)
        {
            IsSelectedByKey = false;

            focussedMenu = itemData.Owner!; // function is only called for itemData that have an Owner set
            focussedMenu.GetDataGridView().SelectedItem = itemData;
        }

        private void SelectByKey(Key key, Menu menuBefore)
        {
            RowData? rowBefore = menuBefore.SelectedItem;
            if (rowBefore == null)
            {
                focussedMenu = null;
                return;
            }

            switch (key)
            {
                case Key.Enter:
                    // When not sub menu already open, open the sub menu,
                    // but when already opened, open the actual folder instead.
                    // In case it is a single file, open it right away
                    if (rowBefore.SubMenu != null || !rowBefore.IsPointingToFolder)
                    {
                        rowBefore.OpenItem(0);
                    }
                    else
                    {
                        RowSelectionChanged?.Invoke(rowBefore); // TODO: Refactor to just a trigger for WaitToLoadMenu ?
                        IsSelectedByKey = true;
                        EnterPressed?.Invoke(rowBefore);
                    }

                    menuBefore?.FocusTextBox(); // TODO: focus placed correctly here?

                    break;
                case Key.Up:
                    if (menuBefore.TrySelectAt(menuBefore.GetDataGridView().Items.IndexOf(menuBefore.SelectedItem) - 1, menuBefore.GetDataGridView().Items.Count - 1))
                    {
                        IsSelectedByKey = true;
                    }

                    break;
                case Key.Down:
                    if (menuBefore.TrySelectAt(menuBefore.GetDataGridView().Items.IndexOf(menuBefore.SelectedItem) + 1, 0))
                    {
                        IsSelectedByKey = true;
                    }

                    break;
                case Key.Home:
                    if (menuBefore.TrySelectAt(0, -1))
                    {
                        IsSelectedByKey = true;
                    }

                    break;
                case Key.End:
                    if (menuBefore.TrySelectAt(menuBefore.GetDataGridView().Items.Count - 1, -1))
                    {
                        IsSelectedByKey = true;
                    }

                    break;
                case Key.Left:
                case Key.Right:
                    Menu? next = menuBefore.SubMenu;
                    Menu? prev = menuBefore.ParentMenu;
                    bool nextLeft = next != null && next.Location.X < menuBefore.Location.X;
                    bool prevLeft = prev != null && prev.Location.X < menuBefore.Location.X;

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
                            IsSelectedByKey = true;
                        }
                    }
                    else if (prev != null &&
                        ((prevLeft == (key == Key.Left)) ||
                        (next != null && nextLeft == prevLeft)))
                    {
                        // Select previous/parent menu, when prev exists and
                        // either prev and key point in the same direction
                        // or when next exists while overlapping with prev
                        int index = menuBefore.RowDataParent?.RowIndex ?? -1;
                        if (prev.TrySelectAt(index, 0))
                        {
                            focussedMenu = prev;
                            IsSelectedByKey = true;
                        }
                    }

                    break;
                default:
                    break;
            }
        }
    }
}
