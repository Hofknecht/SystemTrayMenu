// <copyright file="FileLnk.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Threading;

    internal class FileLnk
    {
        public static string GetResolvedFileName(string shortcutFilename, out bool isFolder)
        {
            bool isFolderByShell = false;
            string resolvedFilename = string.Empty;
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            {
                resolvedFilename = GetShortcutFileNamePath(shortcutFilename, out isFolderByShell);
            }
            else
            {
                Thread staThread = new(new ParameterizedThreadStart(StaThreadMethod));
                void StaThreadMethod(object? obj)
                {
                    resolvedFilename = GetShortcutFileNamePath(shortcutFilename, out isFolderByShell);
                }

                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start(shortcutFilename);
                staThread.Join();
            }

            // If path cannot be resolved, write log message and give back original path
            if (string.IsNullOrEmpty(resolvedFilename))
            {
                Log.Info($"Resolved path is empty: '{shortcutFilename}'");
                resolvedFilename = shortcutFilename;
            }

            isFolder = isFolderByShell;

            return resolvedFilename;
        }

        public static bool IsNetworkRoot(string path)
        {
            return path.StartsWith(@"\\", StringComparison.InvariantCulture) &&
                !path[2..].Contains('\\', StringComparison.InvariantCulture);
        }

        private static string GetShortcutFileNamePath(object shortcutFilename, out bool isFolder)
        {
            string resolvedFilename = string.Empty;
            isFolder = false;
            try
            {
                string shortcutPath = (string)shortcutFilename;
                Type? shellType = Type.GetTypeFromProgID("WScript.Shell");
                if (shellType == null)
                {
                    Log.Info($"{nameof(GetShortcutFileNamePath)} WScript.Shell COM type not found for path:'{shortcutFilename}'");
                    return resolvedFilename;
                }

                object shell = Activator.CreateInstance(shellType)!;
                object? shortcut = shellType.InvokeMember(
                    "CreateShortcut",
                    BindingFlags.InvokeMethod,
                    binder: null,
                    target: shell,
                    args: new object[] { shortcutPath });
                if (shortcut == null)
                {
                    Log.Info($"{nameof(GetShortcutFileNamePath)} CreateShortcut returned null for path:'{shortcutFilename}'");
                    return resolvedFilename;
                }

                Type shortcutType = shortcut.GetType();
                object? targetPathObject = shortcutType.InvokeMember(
                    "TargetPath",
                    BindingFlags.GetProperty,
                    binder: null,
                    target: shortcut,
                    args: null);
                string targetPath = targetPathObject as string ?? string.Empty;
                if (!string.IsNullOrEmpty(targetPath))
                {
                    // Keep previous behavior: skip virtual-shell CLSID paths.
                    if (!targetPath.Contains("::{", StringComparison.InvariantCulture))
                    {
                        resolvedFilename = targetPath;
                        isFolder = Directory.Exists(targetPath);
                    }
                }

                if (Marshal.IsComObject(shortcut))
                {
                    _ = Marshal.FinalReleaseComObject(shortcut);
                }

                if (Marshal.IsComObject(shell))
                {
                    _ = Marshal.FinalReleaseComObject(shell);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // https://stackoverflow.com/questions/2934420/why-do-i-get-e-accessdenied-when-reading-public-shortcuts-through-shell32
                // e.g. Administrative Tools\Component Services.lnk which can not be resolved, do not spam the logfile in this case
            }
            catch (Exception ex)
            {
                Log.Warn($"shortcutFilename:'{shortcutFilename}'", ex);
            }

            return resolvedFilename;
        }
    }
}