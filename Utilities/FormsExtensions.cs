// <copyright file="FormsExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Windows.Interop;

    public static class FormsExtensions
    {
        public enum DialogResult
        {
            OK,
            Cancel,
            Ignore,
            Retry,
        }

        public class NativeWindow : HwndSource
        {
            private HwndSourceHook hook;

            public NativeWindow()
                : base(new())
            {
                hook = new HwndSourceHook(WndProc);
                AddHook(hook);
            }

            ~NativeWindow()
            {
                RemoveHook(hook);
            }

            protected virtual IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
            {
                throw new NotImplementedException();
            }
        }
    }
}
