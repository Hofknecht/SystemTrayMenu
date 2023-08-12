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
    using System.Globalization;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows;
    using System.Windows.Media.Imaging;
    using SystemTrayMenu.DllImports;
    using SystemTrayMenu.Helpers;

    /// <summary>
    /// Provides static methods to read system icons for folders and files.
    /// </summary>
    internal static class IconReader
    {
        private static readonly ConcurrentDictionary<string, BitmapSource> IconDictPersistent = new();
        private static readonly ConcurrentDictionary<string, BitmapSource> IconDictCache = new();
        private static readonly BitmapSource? OverlayImage = (BitmapSource?)Application.Current.Resources["LinkArrowIconImage"];

        // see https://github.com/Hofknecht/SystemTrayMenu/issues/209.
        internal static bool IsPreloading { get; set; } = true;

        internal static void ClearCacheWhenLimitReached()
        {
            if (IconDictCache.Count > Properties.Settings.Default.ClearCacheIfMoreThanThisNumberOfItems)
            {
                IconDictCache.Clear();
                GC.Collect();
            }
        }

        internal static void RemoveIconFromCache(string path) => IconDictPersistent.Remove(path, out _);

        internal static bool GetFileIconWithCache(
            string path,
            string resolvedPath,
            bool linkOverlay,
            bool checkPersistentFirst,
            Action<BitmapSource?> onIconLoaded)
        {
            bool cacheHit;
            string key;
            string extension = Path.GetExtension(path);
            if (IsExtensionWithSameIcon(extension))
            {
                key = extension + linkOverlay;
            }
            else
            {
                key = path;
            }

            if (!DictIconCache(checkPersistentFirst).TryGetValue(key, out BitmapSource? icon) &&
                !DictIconCache(!checkPersistentFirst).TryGetValue(key, out icon))
            {
                cacheHit = false;

                new Thread(UpdateIconInBackground).Start();
                void UpdateIconInBackground()
                {
                    BitmapSource icon = DictIconCache(checkPersistentFirst).GetOrAdd(key, FactoryIconFile);
                    onIconLoaded(icon);
                }

                BitmapSource FactoryIconFile(string keyExtension)
                {
                    return GetIconAsBitmapSource(path, resolvedPath, linkOverlay, false);
                }
            }
            else
            {
                cacheHit = true;
                onIconLoaded(icon);
            }

            return cacheHit;
        }

        internal static bool GetFolderIconWithCache(
            string path,
            bool linkOverlay,
            bool checkPersistentFirst,
            Action<BitmapSource?> onIconLoaded)
        {
            bool cacheHit;
            string key = path;
            if (!DictIconCache(checkPersistentFirst).TryGetValue(key, out BitmapSource? icon) &&
                !DictIconCache(!checkPersistentFirst).TryGetValue(key, out icon))
            {
                cacheHit = false;

                if (IsPreloading)
                {
                    cacheHit = true;
                    icon = DictIconCache(checkPersistentFirst).GetOrAdd(key, FactoryIconFolder);
                    onIconLoaded(icon);
                }
                else
                {
                    new Thread(UpdateIconInBackground).Start();
                    void UpdateIconInBackground()
                    {
                        BitmapSource icon = DictIconCache(checkPersistentFirst).GetOrAdd(key, FactoryIconFolder);
                        onIconLoaded(icon);
                    }
                }

                BitmapSource FactoryIconFolder(string keyExtension)
                {
                    return GetIconAsBitmapSource(path, path, linkOverlay, true);
                }
            }
            else
            {
                cacheHit = true;
                onIconLoaded(icon);
            }

            return cacheHit;
        }

        internal static Icon? GetRootFolderIcon(string path)
        {
            NativeMethods.SHFILEINFO shFileInfo = default;
            bool linkOverlay = false;
            bool largeIcon = false;
            uint flags = GetFlags(linkOverlay, largeIcon);
            uint attribute = NativeMethods.FileAttributeDirectory;
            IntPtr imageList = NativeMethods.Shell32SHGetFileInfo(path, attribute, ref shFileInfo, (uint)Marshal.SizeOf(shFileInfo), flags);
            return GetIcon(path, linkOverlay, shFileInfo, imageList);
        }

        internal static BitmapSource? TryGetIconAsBitmapSource(string path, string resolvedPath, bool linkOverlay, bool isFolder)
        {
            BitmapSource? result = null;
            Icon? icon;
            if (!isFolder && Path.GetExtension(path).Equals(".ico", StringComparison.InvariantCultureIgnoreCase))
            {
                icon = Icon.ExtractAssociatedIcon(path);
                if (icon != null)
                {
                    result = CreateBitmapSourceFromIcon(icon);
                    icon.Dispose();
                }
            }
            else if (!isFolder && File.Exists(resolvedPath) &&
                Path.GetExtension(resolvedPath).Equals(".ico", StringComparison.InvariantCultureIgnoreCase))
            {
                icon = Icon.ExtractAssociatedIcon(resolvedPath);
                if (icon != null)
                {
                    result = CreateBitmapSourceFromIcon(icon);
                    icon.Dispose();

                    if (linkOverlay && OverlayImage != null)
                    {
                        result = ImagingHelper.CreateIconWithOverlay(result, OverlayImage);
                    }
                }
            }
            else
            {
                NativeMethods.SHFILEINFO shFileInfo = default;
                bool largeIcon = // Note: large returns another folder icon than windows explorer
                    Scaling.Factor >= 1.25f ||
                    Scaling.FactorByDpi >= 1.25f ||
                    Properties.Settings.Default.IconSizeInPercent / 100f >= 1.25f;
                uint flags = GetFlags(linkOverlay, largeIcon);
                uint attribute = isFolder ? NativeMethods.FileAttributeDirectory : NativeMethods.FileAttributeNormal;
                IntPtr imageList = NativeMethods.Shell32SHGetFileInfo(path, attribute, ref shFileInfo, (uint)Marshal.SizeOf(shFileInfo), flags);
                icon = GetIcon(path, linkOverlay, shFileInfo, imageList);
                if (icon != null)
                {
                    result = CreateBitmapSourceFromIcon(icon);
                    icon.Dispose();
                }
            }

            return result;
        }

        private static BitmapSource GetIconAsBitmapSource(string path, string resolvedPath, bool linkOverlay, bool isFolder)
        {
            BitmapSource? bitmapSource = TryGetIconAsBitmapSource(path, resolvedPath, linkOverlay, isFolder);
            bitmapSource ??= (BitmapSource)Application.Current.Resources["NotFoundIconImage"];
            bitmapSource.Freeze(); // Make it accessible for any thread
            return bitmapSource;
        }

        private static ConcurrentDictionary<string, BitmapSource> DictIconCache(bool checkPersistentFirst)
            => checkPersistentFirst ? IconDictPersistent : IconDictCache;

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

        private static uint GetFlags(bool linkOverlay, bool largeIcon)
        {
            uint flags = NativeMethods.ShgfiIcon | NativeMethods.ShgfiSYSICONINDEX;
            if (linkOverlay)
            {
                flags += NativeMethods.ShgfiLINKOVERLAY;
            }

            if (!largeIcon)
            {
                flags += NativeMethods.ShgfiSMALLICON;
            }
            else
            {
                flags += NativeMethods.ShgfiLARGEICON;
            }

            return flags;
        }

        private static Icon? GetIcon(
            string path, bool linkOverlay, NativeMethods.SHFILEINFO shFileInfo, IntPtr imageList)
        {
            Icon? icon = null;
            if (imageList != IntPtr.Zero)
            {
                IntPtr hIcon;
                if (linkOverlay)
                {
                    hIcon = shFileInfo.hIcon;
                }
                else
                {
                    hIcon = NativeMethods.ImageList_GetIcon(imageList, shFileInfo.iIcon, NativeMethods.IldTransparent);
                }

                try
                {
                    // Note: Destroying hIcon after FromHandle will invalidate the Icon, so we do NOT destroy it, despite the request from documentation:
                    //       https://learn.microsoft.com/en-us/dotnet/api/system.drawing.icon.fromhandle?view=dotnet-plat-ext-7.0
                    //       Reason is https://referencesource.microsoft.com/#System.Drawing/commonui/System/Drawing/Icon.cs,555 (FromHandle)
                    //       It is not taking over the ownership, data will be deleted upon destroying the original icon, so a clone is required.
                    //       With Clone we actually get a new handle, so we can free up the original handle without killing our copy.
                    //       Using Clone will also restore the ownership of the new icon handle, so we do not have to call DestroyIcon on it by ourself.
                    icon = (Icon)Icon.FromHandle(hIcon).Clone();
                }
                catch (Exception ex)
                {
                    Log.Warn($"path:'{path}'", ex);
                }

                if (!linkOverlay)
                {
                    _ = NativeMethods.User32DestroyIcon(hIcon);
                }

                _ = NativeMethods.User32DestroyIcon(shFileInfo.hIcon);
            }

            return icon;
        }

        private static BitmapSource CreateBitmapSourceFromIcon(Icon icon)
        {
            return (BitmapSource)new IconToImageSourceConverter().Convert(
                        icon,
                        typeof(BitmapSource),
                        null!,
                        CultureInfo.InvariantCulture);
        }
    }
}
