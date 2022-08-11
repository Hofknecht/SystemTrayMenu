// <copyright file="FormsExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Windows.Forms;

    internal static class FormsExtensions
    {
        public static void HandleInvoke(this Control instance, Action action)
        {
            if (instance.InvokeRequired)
            {
                instance.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
