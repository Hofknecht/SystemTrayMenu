// <copyright file="FileLnk.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;
    using Shell32;

    internal class FileLnk
    {
        public static string GetResolvedFileName(string shortcutFilename)
        {
            string resolvedFilename = string.Empty;
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            {
                resolvedFilename = GetShortcutFileNamePath(shortcutFilename);
            }
            else
            {
                Thread staThread = new Thread(new ParameterizedThreadStart(StaThreadMethod));
                void StaThreadMethod(object obj)
                {
                    resolvedFilename = GetShortcutFileNamePath(shortcutFilename);
                }

                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start(shortcutFilename);
                staThread.Join();
            }

            return resolvedFilename;
        }

        public static bool IsDirectory(string filePath)
        {
            bool isDirectory = false;
            if (Directory.Exists(filePath))
            {
                FileAttributes attributes = File.GetAttributes(filePath);
                if ((attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    isDirectory = true;
                }
            }

            return isDirectory;
        }

        public static bool IsNetworkRoot(string path)
        {
            return !File.Exists(path) &&
                path.StartsWith(@"\\", StringComparison.InvariantCulture) &&
                !path.Substring(2).Contains(@"\", StringComparison.InvariantCulture);
        }

        private static string GetShortcutFileNamePath(object shortcutFilename)
        {
            string resolvedFilename = string.Empty;
            string pathOnly = Path.GetDirectoryName((string)shortcutFilename);
            string filenameOnly = Path.GetFileName((string)shortcutFilename);

            Shell shell = new Shell();
            Folder folder = shell.NameSpace(pathOnly);
            FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null)
            {
                try
                {
                    ShellLinkObject link = (ShellLinkObject)folderItem.GetLink;
                    if (string.IsNullOrEmpty(link.Path))
                    {
                        resolvedFilename = link.Target.Path;
                    }
                    else
                    {
                        resolvedFilename = link.Path;
                    }
                }
                catch (Exception ex)
                {
                    if (ex is COMException ||
                        ex is UnauthorizedAccessException)
                    {
                        Log.Warn($"shortcutFilename:'{shortcutFilename}'", ex);
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return resolvedFilename;
        }
    }
}