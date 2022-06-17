// <copyright file="IconReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// see also: https://www.codeproject.com/Articles/2532/Obtaining-and-managing-file-and-folder-icons-using.

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using SystemTrayMenu.DllImports;

    /// <summary>
    /// Provides static methods to read system icons for folders and files.
    /// </summary>
    public static class IconReader
    {
        private static readonly ConcurrentDictionary<string, Icon> DictIconCacheMainMenu = new();
        private static readonly ConcurrentDictionary<string, Icon> DictIconCacheSubMenus = new();

        public enum IconSize
        {
            Large = 0, // 32x32 pixels
            Small = 1, // 16x16 pixels
        }

        public enum FolderType
        {
            Open = 0,
            Closed = 1,
        }

        // see https://github.com/Hofknecht/SystemTrayMenu/issues/209.
        public static bool MainPreload { get; set; }

        public static void Dispose(bool includingMainMenu = true)
        {
            if (includingMainMenu)
            {
                foreach (Icon icon in DictIconCacheMainMenu.Values)
                {
                    icon?.Dispose();
                }
            }

            foreach (Icon icon in DictIconCacheSubMenus.Values)
            {
                icon?.Dispose();
            }
        }

        public static bool ClearIfCacheTooBig()
        {
            bool cleared = false;
            if (DictIconCacheSubMenus.Count > Properties.Settings.Default.ClearCacheIfMoreThanThisNumberOfItems)
            {
                Dispose(false);
                DictIconCacheSubMenus.Clear();
                cleared = true;
            }

            return cleared;
        }

        public static void RemoveIconFromCache(string path)
        {
            if (DictIconCacheMainMenu.Remove(path, out Icon iconToRemove))
            {
                iconToRemove?.Dispose();
            }
        }

        public static Icon GetFileIconWithCache(
            string path,
            string resolvedPath,
            bool linkOverlay,
            bool updateIconInBackground,
            bool isMainMenu,
            out bool loading,
            string keyPath = "")
        {
            loading = false;
            string extension = Path.GetExtension(path);
            IconSize size = IconSize.Large;

            string key = path;
            if (!string.IsNullOrEmpty(keyPath))
            {
                key = keyPath;
            }

            if (IsExtensionWithSameIcon(extension))
            {
                key = extension + linkOverlay;
            }

            if (!DictIconCache(isMainMenu).TryGetValue(key, out Icon icon) &&
                !DictIconCache(!isMainMenu).TryGetValue(key, out icon))
            {
                icon = Resources.StaticResources.LoadingIcon;
                loading = true;
                if (updateIconInBackground)
                {
                    new Thread(UpdateIconInBackground).Start();
                    void UpdateIconInBackground()
                    {
                        DictIconCache(isMainMenu).GetOrAdd(key, GetIconSTA(path, resolvedPath, linkOverlay, size, false));
                    }
                }
            }

            return icon;
        }

        public static Icon GetFolderIconWithCache(
            string path,
            bool linkOverlay,
            bool updateIconInBackground,
            bool isMainMenu,
            out bool loading)
        {
            loading = false;

            IconSize size = IconSize.Small;
            if (Scaling.Factor >= 1.50f ||
                Properties.Settings.Default.IconSizeInPercent / 100f >= 1.50f)
            {
                // IconSize.Large returns another folder icon than windows explorer
                size = IconSize.Large;
            }

            string key = path;

            if (!DictIconCache(isMainMenu).TryGetValue(key, out Icon icon) &&
                !DictIconCache(!isMainMenu).TryGetValue(key, out icon))
            {
                icon = Resources.StaticResources.LoadingIcon;
                loading = true;

                if (updateIconInBackground)
                {
                    if (MainPreload)
                    {
                        DictIconCache(isMainMenu).GetOrAdd(key, GetFolder);
                    }
                    else
                    {
                        new Thread(UpdateIconInBackground).Start();
                        void UpdateIconInBackground()
                        {
                            DictIconCache(isMainMenu).GetOrAdd(key, GetFolder);
                        }
                    }
                }
            }

            Icon GetFolder(string keyExtension)
            {
                return GetIconSTA(path, path, linkOverlay, size, true);
            }

            return icon;
        }

        public static Icon GetIconSTA(string path, string resolvedPath, bool linkOverlay, IconSize size, bool isFolder)
        {
            Icon icon = null;
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            {
                icon = GetIcon(path, resolvedPath, linkOverlay, size, isFolder);
            }
            else
            {
                Thread staThread = new(new ParameterizedThreadStart(StaThreadMethod));
                void StaThreadMethod(object obj)
                {
                    icon = GetIcon(path, resolvedPath, linkOverlay, size, isFolder);
                }

                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start(icon);
                staThread.Join();
            }

            return icon;
        }

        public static Icon AddIconOverlay(Icon originalIcon, Icon overlay)
        {
            Icon icon = null;
            if (originalIcon != null)
            {
                using Bitmap target = new(originalIcon.Width, originalIcon.Height, PixelFormat.Format32bppArgb);
                using Graphics graphics = Graphics.FromImage(target);
                graphics.DrawIcon(originalIcon, 0, 0);
                graphics.DrawIcon(overlay, new(0, 0, originalIcon.Width + 2, originalIcon.Height + 2));
                target.MakeTransparent(target.GetPixel(1, 1));
                IntPtr hIcon = target.GetHicon();
                icon = (Icon)Icon.FromHandle(hIcon).Clone();
                NativeMethods.User32DestroyIcon(hIcon);
            }

            return icon;
        }

        private static ConcurrentDictionary<string, Icon> DictIconCache(bool isMainMenu)
        {
            if (isMainMenu)
            {
                return DictIconCacheMainMenu;
            }
            else
            {
                return DictIconCacheSubMenus;
            }
        }

        private static bool IsExtensionWithSameIcon(string fileExtension)
        {
            bool isExtensionWithSameIcon = true;
            List<string> extensionsWithDiffIcons = new() { string.Empty, ".EXE", ".LNK", ".ICO", ".URL" };
            if (extensionsWithDiffIcons.Contains(fileExtension.ToUpperInvariant()))
            {
                isExtensionWithSameIcon = false;
            }

            return isExtensionWithSameIcon;
        }

        private static Icon GetIcon(string path, string resolvedPath, bool linkOverlay, IconSize size, bool isFolder)
        {
            Icon icon;
            if (Path.GetExtension(path).Equals(".ico", StringComparison.InvariantCultureIgnoreCase))
            {
                icon = Icon.ExtractAssociatedIcon(path);
            }
            else if (Path.GetExtension(resolvedPath).Equals(".ico", StringComparison.InvariantCultureIgnoreCase) &&
                File.Exists(resolvedPath))
            {
                icon = Icon.ExtractAssociatedIcon(resolvedPath);
                if (linkOverlay)
                {
                    icon = AddIconOverlay(icon, Properties.Resources.LinkArrow);
                }
            }
            else
            {
                NativeMethods.SHFILEINFO shFileInfo = default;
                uint flags = GetFlags(linkOverlay, size);
                uint attribute = isFolder ? NativeMethods.FileAttributeDirectory : NativeMethods.FileAttributeNormal;
                IntPtr imageList = NativeMethods.Shell32SHGetFileInfo(
                    path, attribute, ref shFileInfo, (uint)Marshal.SizeOf(shFileInfo), flags);
                icon = GetIcon(path, linkOverlay, shFileInfo, imageList);
            }

            return icon;
        }

        private static uint GetFlags(bool linkOverlay, IconSize size)
        {
            uint flags = NativeMethods.ShgfiIcon | NativeMethods.ShgfiSYSICONINDEX;
            if (linkOverlay)
            {
                flags += NativeMethods.ShgfiLINKOVERLAY;
            }

            if (size == IconSize.Small)
            {
                flags += NativeMethods.ShgfiSMALLICON;
            }
            else
            {
                flags += NativeMethods.ShgfiLARGEICON;
            }

            return flags;
        }

        private static Icon GetIcon(
            string path, bool linkOverlay, NativeMethods.SHFILEINFO shFileInfo, IntPtr imageList)
        {
            Icon icon = null;
            if (imageList != IntPtr.Zero)
            {
                IntPtr hIcon;
                if (linkOverlay)
                {
                    hIcon = shFileInfo.hIcon;
                }
                else
                {
                    hIcon = NativeMethods.ImageList_GetIcon(
                        imageList, shFileInfo.iIcon, NativeMethods.IldTransparent);
                }

                try
                {
                    icon = (Icon)Icon.FromHandle(hIcon).Clone();
                }
                catch (Exception ex)
                {
                    Log.Warn($"path:'{path}'", ex);
                }

                if (!linkOverlay)
                {
                    NativeMethods.User32DestroyIcon(hIcon);
                }

                NativeMethods.User32DestroyIcon(shFileInfo.hIcon);
            }

            return icon;
        }
    }
}