// <copyright file="WPFExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2022-2022 Peter Kirmeier

#nullable enable

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using Point = System.Windows.Point;

    internal static class WPFExtensions
    {
        internal static Window GetParentWindow(this ListView listView)
        {
            var parent = VisualTreeHelper.GetParent(listView);

            while (!(parent is Window))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            return (Window)parent;
        }

        internal static int IndexOfSenderItem(this ListView listView, ListViewItem sender)
        {
            int index = listView.Items.IndexOf(sender.Content);
            if (index < 0)
            {
                // Most likely the sender object is a "DiconnectedItem"
                // Needs to be confirmed:
                //   May happen when focus gets lost while event is handled
                //   As this has not occurred on files but on folders
                //   that spawns a new menu window which will get focus
                //   it may be caused by the loss of focus.
                // Workaround:
                //   If possible take index from selection
                //     we simply assume it is the first one.
                //   Otherwise fall back to index 0 which shall always work
                //     because there must be anything that has sent something.
                index = Math.Min(listView.SelectedIndex, 0);
            }

            return index;
        }

        internal static T? FindVisualChildOfType<T>(this DependencyObject depObj, int index = 0)
            where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                if (child != null)
                {
                    if (child is T)
                    {
                        if (index-- == 0)
                        {
                            return (T)child;
                        }

                        continue;
                    }

                    T? childItem = child.FindVisualChildOfType<T>(index);
                    if (childItem != null)
                    {
                        return childItem;
                    }
                }
            }

            return null;
        }

        internal static Point GetRelativeChildPositionTo(this Visual parent, Visual? child)
        {
            return child == null ? new() : child.TransformToAncestor(parent).Transform(new ());
        }

        // TODO: Find and remove any unnecessary convertions
        internal static ImageSource ToImageSource(this Icon icon)
        {
            return (ImageSource)new IconToImageSourceConverter().Convert(
                        icon,
                        typeof(ImageSource),
                        null,
                        CultureInfo.InvariantCulture);
        }
    }
}
