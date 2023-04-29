// <copyright file="FolderOptions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using Shell32;

    internal static class FolderOptions
    {
        private static bool hideHiddenEntries;
        private static bool hideSystemEntries;
        private static IShellDispatch4? iShellDispatch4;

        internal static void Initialize()
        {
            try
            {
                iShellDispatch4 = (IShellDispatch4?)Activator.CreateInstance(
                    Type.GetTypeFromProgID("Shell.Application")!);

                // Using SHGetSetSettings would be much better in performance but the results are not accurate.
                // We have to go for the shell interface in order to receive the correct settings:
                // https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch4-getsetting
                const int SSF_SHOWALLOBJECTS = 0x00000001;
                hideHiddenEntries = !(iShellDispatch4?.GetSetting(SSF_SHOWALLOBJECTS) ?? false);

                const int SSF_SHOWSUPERHIDDEN = 0x00040000;
                hideSystemEntries = !(iShellDispatch4?.GetSetting(SSF_SHOWSUPERHIDDEN) ?? false);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException ||
                    ex is NotSupportedException ||
                    ex is TargetInvocationException ||
                    ex is MethodAccessException ||
                    ex is MemberAccessException ||
                    ex is InvalidComObjectException ||
                    ex is MissingMethodException ||
                    ex is COMException ||
                    ex is TypeLoadException)
                {
                    Log.Warn("Get Shell COM instance failed", ex);
                }
                else
                {
                    throw;
                }
            }
        }

        internal static void ReadHiddenAttributes(string path, out bool hasHiddenFlag, out bool isDirectoryToHide)
        {
            isDirectoryToHide = false;
            hasHiddenFlag = false;
            if (path.Length >= 260)
            {
                Log.Info($"path too long (>=260):'{path}'");
                return;
            }

            try
            {
                FileAttributes attributes = File.GetAttributes(path);
                hasHiddenFlag = attributes.HasFlag(FileAttributes.Hidden);
                bool hasSystemFlag = attributes.HasFlag(
                    FileAttributes.Hidden | FileAttributes.System);
                if (Properties.Settings.Default.SystemSettingsShowHiddenFiles)
                {
                    if ((hideHiddenEntries && hasHiddenFlag) ||
                        (hideSystemEntries && hasSystemFlag))
                    {
                        isDirectoryToHide = true;
                    }
                }
                else if (hasHiddenFlag && Properties.Settings.Default.NeverShowHiddenFiles)
                {
                    isDirectoryToHide = true;
                }
            }
            catch (Exception ex)
            {
                Log.Warn($"path:'{path}'", ex);
            }
        }
    }
}
