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
        private static IShellDispatch4 iShellDispatch4;

        internal static void Initialize()
        {
            try
            {
                iShellDispatch4 = (IShellDispatch4)Activator.CreateInstance(
                    Type.GetTypeFromProgID("Shell.Application"));

                // Using SHGetSetSettings would be much better in performance but the results are not accurate.
                // We have to go for the shell interface in order to receive the correct settings:
                // https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch4-getsetting
                const int SSF_SHOWALLOBJECTS = 0x00000001;
                hideHiddenEntries = !iShellDispatch4.GetSetting(
                    SSF_SHOWALLOBJECTS);

                const int SSF_SHOWSUPERHIDDEN = 0x00040000;
                hideSystemEntries = !iShellDispatch4.GetSetting(
                    SSF_SHOWSUPERHIDDEN);
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
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                    Log.Warn("Get Shell COM instance failed", ex);
#pragma warning restore CA1303 //=> Exceptions not translated in logfile => OK
                }
                else
                {
                    throw;
                }
            }
        }

        internal static bool IsHidden(string path, ref bool hiddenEntry)
        {
            bool isDirectoryToHide = false;
            if (path.Length < 260)
            {
                try
                {
                    FileAttributes attributes = File.GetAttributes(path);
                    hiddenEntry = attributes.HasFlag(FileAttributes.Hidden);
                    bool systemEntry = attributes.HasFlag(
                        FileAttributes.Hidden | FileAttributes.System);
                    if ((hideHiddenEntries && hiddenEntry) ||
                        (hideSystemEntries && systemEntry))
                    {
                        isDirectoryToHide = true;
                    }
                }
                catch (Exception ex)
                {
                    if (ex is UnauthorizedAccessException ||
                        ex is IOException)
                    {
                        Log.Warn($"path:'{path}'", ex);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                Log.Info($"path too long (>=260):'{path}'");
            }

            return isDirectoryToHide;
        }
    }
}
