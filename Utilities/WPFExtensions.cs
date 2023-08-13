// <copyright file="WPFExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2022-2023 Peter Kirmeier

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Threading;

    internal static class WPFExtensions
    {
        internal static void HandleInvoke(this DispatcherObject instance, Action action)
        {
            if (instance!.CheckAccess())
            {
                action();
            }
            else
            {
                instance.Dispatcher.Invoke(action);
            }
        }

        internal static T? FindVisualChildOfType<T>(this DependencyObject depObj, int index = 0)
            where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                if (child != null)
                {
                    if (child is T validChild)
                    {
                        if (index-- == 0)
                        {
                            return validChild;
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
            return child == null ? default : child.TransformToAncestor(parent).Transform(default);
        }
    }
}
