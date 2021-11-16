// <copyright file="FileLnk.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.IO;
    using System.Net.NetworkInformation;
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
                Thread staThread = new(new ParameterizedThreadStart(StaThreadMethod));
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

        public static bool IsNetworkRoot(string path)
        {
            return path.StartsWith(@"\\", StringComparison.InvariantCulture) &&
                !path[2..].Contains(@"\", StringComparison.InvariantCulture);
        }

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException ex)
            {
                Log.Warn($"Ping {nameOrAddress} failed", ex);
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }

        private static string GetShortcutFileNamePath(object shortcutFilename)
        {
            string resolvedFilename = string.Empty;
            string pathOnly = Path.GetDirectoryName((string)shortcutFilename);
            string filenameOnly = Path.GetFileName((string)shortcutFilename);

            Shell shell = new();
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
                    Log.Warn($"shortcutFilename:'{shortcutFilename}'", ex);
                }
            }

            return resolvedFilename;
        }
    }
}