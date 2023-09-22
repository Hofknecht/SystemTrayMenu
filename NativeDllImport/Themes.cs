// <copyright file="Themes.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2023 Peter Kirmeier

namespace SystemTrayMenu.DllImports
{
    using System.Runtime.InteropServices;
    using System.Runtime.Versioning;

    /// <summary>
    /// See: https://gist.github.com/rounk-ctrl/b04e5622e30e0d62956870d5c22b7017
    /// See: https://social.msdn.microsoft.com/Forums/windowsdesktop/en-US/e36eb4c0-4370-4933-943d-b6fe22677e6c/dark-mode-apis?forum=windowssdk
    /// Wraps the method calls to native Windows DLLs.
    /// </summary>
    public static partial class NativeMethods
    {
        internal enum PreferredAppMode : int
        {
            Default = 0,
            AllowDark = 1,
            ForceDark = 2,
            ForceLight = 3,
        }

        /// <summary>
        /// No official documentation.
        /// Seems to set mode that the UI shall use for rendering UI elements.
        /// </summary>
        /// <param name="preferredAppMode">Desired mode.</param>
        /// <returns>Undocumented.</returns>
        [SupportedOSPlatform("windows")]
        [DllImport("uxtheme.dll", EntryPoint = "#135", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        internal static extern int SetPreferredAppMode(PreferredAppMode preferredAppMode);

        /// <summary>
        /// No official documentation.
        /// Seems to switch UI mode which was set by SetPreferredAppMode.
        /// </summary>
        [SupportedOSPlatform("windows")]
        [DllImport("uxtheme.dll", EntryPoint = "#136", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        internal static extern void FlushMenuThemes();
    }
}
