// <copyright file="WPFExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2022-2022 Peter Kirmeier

#nullable enable

namespace SystemTrayMenu.Utilities
{
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

        internal static Point GetRelativeChildPositionTo(this Visual parent, Visual child)
        {
            return child.TransformToAncestor(parent).Transform(new(0, 0));
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
