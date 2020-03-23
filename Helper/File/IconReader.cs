using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace SystemTrayMenu.Helper
{
    // from https://www.codeproject.com/Articles/2532/Obtaining-and-managing-file-and-folder-icons-using
    // added ImageList_GetIcon, IconCache, AddIconOverlay

    /// <summary>
    /// Provides static methods to read system icons for both folders and files.
    /// </summary>
    /// <example>
    /// <code>IconReader.GetFileIcon("c:\\general.xls");</code>
    /// </example>
    public class IconReader
    {
        private static ConcurrentDictionary<string, Icon> dictIconCache = new ConcurrentDictionary<string, Icon>();

        /// <summary>
        /// Options to specify the size of icons to return.
        /// </summary>
        public enum IconSize
        {
            /// <summary>
            /// Specify large icon - 32 pixels by 32 pixels.
            /// </summary>
            Large = 0,
            /// <summary>
            /// Specify small icon - 16 pixels by 16 pixels.
            /// </summary>
            Small = 1
        }

        /// <summary>
        /// Options to specify whether folders should be in the open or closed state.
        /// </summary>
        public enum FolderType
        {
            /// <summary>
            /// Specify open folder.
            /// </summary>
            Open = 0,
            /// <summary>
            /// Specify closed folder.
            /// </summary>
            Closed = 1
        }

        /// <summary>
        /// Returns an icon for a given file - indicated by the name parameter.
        /// </summary>
        /// <returns>System.Drawing.Icon</returns>
        public static Icon GetFileIconWithCache(string filePath, bool linkOverlay,
            IconSize size = IconSize.Small)
        {
            Icon icon = null;
            string extension = Path.GetExtension(filePath);
            bool IsExtensionWitSameIcon(string fileExtension)
            {
                bool isExtensionWitSameIcon = true;
                List<string> extensionsWithDiffIcons = new List<string>
                { ".exe", ".lnk", ".ico", ".url" };
                if (extensionsWithDiffIcons.Contains(fileExtension.ToLower()))
                {
                    isExtensionWitSameIcon = false;
                }
                return isExtensionWitSameIcon;
            }

            if (IsExtensionWitSameIcon(extension))
            {
                icon = dictIconCache.GetOrAdd(extension, GetIcon);
                Icon GetIcon(string keyExtension)
                {
                    return GetFileIcon(filePath, linkOverlay, size);
                }
            }
            else
            {
                icon = GetFileIcon(filePath, linkOverlay, size);
            }

            return icon;
        }

        private static Icon GetFileIcon(string filePath, bool linkOverlay,
            IconSize size = IconSize.Small)
        {
            Icon icon = null;
            Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
            uint flags = Shell32.SHGFI_ICON | Shell32.SHGFI_SYSICONINDEX;

            //MH: Removed, otherwise wrong icon
            // | Shell32.SHGFI_USEFILEATTRIBUTES ;

            if (true == linkOverlay)
            {
                flags += Shell32.SHGFI_LINKOVERLAY;
            }

            /* Check the size specified for return. */
            if (IconSize.Small == size)
            {
                flags += Shell32.SHGFI_SMALLICON;
            }
            else
            {
                flags += Shell32.SHGFI_LARGEICON;
            }

            IntPtr hImageList = Shell32.SHGetFileInfo(filePath,
                Shell32.FILE_ATTRIBUTE_NORMAL,
                ref shfi,
                (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
                flags);
            if (hImageList != IntPtr.Zero) // got valid handle?
            {
                IntPtr hIcon;
                if (linkOverlay)
                {
                    hIcon = shfi.hIcon; // Get icon directly
                }
                else
                {
                    // Get icon from .ink without overlay
                    hIcon = Shell32.ImageList_GetIcon(hImageList, shfi.iIcon, Shell32.ILD_TRANSPARENT);
                }

                try
                {
                    // Copy (clone) the returned icon to a new object, thus allowing us to clean-up properly
                    icon = (Icon)Icon.FromHandle(hIcon).Clone();
                }
                catch (Exception ex)
                {
                    Log.Error($"filePath:'{filePath}'", ex);
                }

                // Cleanup
                if (!linkOverlay)
                {
                    User32.DestroyIcon(hIcon);
                }

                User32.DestroyIcon(shfi.hIcon);
            }

            return icon;
        }

        public static Icon GetFolderIcon(string directoryPath,
            FolderType folderType, bool linkOverlay,
            IconSize size = IconSize.Small)
        {
            Icon icon = null;

            // Need to add size check, although errors generated at present!
            //uint flags = Shell32.SHGFI_ICON | Shell32.SHGFI_USEFILEATTRIBUTES;

            //MH: Removed SHGFI_USEFILEATTRIBUTES, otherwise was wrong folder icon
            uint flags = Shell32.SHGFI_ICON; // | Shell32.SHGFI_USEFILEATTRIBUTES;

            if (true == linkOverlay)
            {
                flags += Shell32.SHGFI_LINKOVERLAY;
            }

            if (FolderType.Open == folderType)
            {
                flags += Shell32.SHGFI_OPENICON;
            }

            if (IconSize.Small == size)
            {
                flags += Shell32.SHGFI_SMALLICON;
            }
            else
            {
                flags += Shell32.SHGFI_LARGEICON;
            }

            // Get the folder icon
            Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
            IntPtr Success = Shell32.SHGetFileInfo(directoryPath,
                Shell32.FILE_ATTRIBUTE_DIRECTORY,
                ref shfi,
                (uint)Marshal.SizeOf(shfi),
                flags);
            if (Success != IntPtr.Zero) // got valid handle?
            {
                try
                {
                    Icon.FromHandle(shfi.hIcon); // Load the icon from an HICON handle

                    // Now clone the icon, so that it can be successfully stored in an ImageList
                    icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();

                }
                catch (Exception ex)
                {
                    Log.Error($"directoryPath:'{directoryPath}'", ex);
                }

                // Cleanup
                User32.DestroyIcon(shfi.hIcon);
            }
            return icon;
        }

        public static Icon AddIconOverlay(Icon originalIcon, Icon overlay)
        {
            var target = new Bitmap(originalIcon.Width, originalIcon.Height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(target);
            graphics.DrawIcon(originalIcon, 0, 0);
            graphics.DrawIcon(overlay, 0, 0);
            target.MakeTransparent(target.GetPixel(1, 1));
            return Icon.FromHandle(target.GetHicon());
        }
    }

    /// <summary>
    /// Wraps necessary Shell32.dll structures and functions required to retrieve Icon Handles using SHGetFileInfo. Code
    /// courtesy of MSDN Cold Rooster Consulting case study.
    /// </summary>
    /// 

    // This code has been left largely untouched from that in the CRC example. The main changes have been moving
    // the icon reading code over to the IconReader type.
    public class Shell32
    {

        public const int MAX_PATH = 256;
        [StructLayout(LayoutKind.Sequential)]
        public struct SHITEMID
        {
            public ushort cb;
            [MarshalAs(UnmanagedType.LPArray)]
            public byte[] abID;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ITEMIDLIST
        {
            public SHITEMID mkid;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BROWSEINFO
        {
            public IntPtr hwndOwner;
            public IntPtr pidlRoot;
            public IntPtr pszDisplayName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszTitle;
            public uint ulFlags;
            public IntPtr lpfn;
            public int lParam;
            public IntPtr iImage;
        }

        // Browsing for directory.
        public const uint BIF_RETURNONLYFSDIRS = 0x0001;
        public const uint BIF_DONTGOBELOWDOMAIN = 0x0002;
        public const uint BIF_STATUSTEXT = 0x0004;
        public const uint BIF_RETURNFSANCESTORS = 0x0008;
        public const uint BIF_EDITBOX = 0x0010;
        public const uint BIF_VALIDATE = 0x0020;
        public const uint BIF_NEWDIALOGSTYLE = 0x0040;
        public const uint BIF_USENEWUI = (BIF_NEWDIALOGSTYLE | BIF_EDITBOX);
        public const uint BIF_BROWSEINCLUDEURLS = 0x0080;
        public const uint BIF_BROWSEFORCOMPUTER = 0x1000;
        public const uint BIF_BROWSEFORPRINTER = 0x2000;
        public const uint BIF_BROWSEINCLUDEFILES = 0x4000;
        public const uint BIF_SHAREABLE = 0x8000;

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public const int NAMESIZE = 80;
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NAMESIZE)]
            public string szTypeName;
        };

        public const uint SHGFI_ICON = 0x000000100;     // get icon
        public const uint SHGFI_DISPLAYNAME = 0x000000200;     // get display name
        public const uint SHGFI_TYPENAME = 0x000000400;     // get type name
        public const uint SHGFI_ATTRIBUTES = 0x000000800;     // get attributes
        public const uint SHGFI_ICONLOCATION = 0x000001000;     // get icon location
        public const uint SHGFI_EXETYPE = 0x000002000;     // return exe type
        public const uint SHGFI_SYSICONINDEX = 0x000004000;     // get system icon index
        public const uint SHGFI_LINKOVERLAY = 0x000008000;     // put a link overlay on icon
        public const uint SHGFI_SELECTED = 0x000010000;     // show icon in selected state
        public const uint SHGFI_ATTR_SPECIFIED = 0x000020000;     // get only specified attributes
        public const uint SHGFI_LARGEICON = 0x000000000;     // get large icon
        public const uint SHGFI_SMALLICON = 0x000000001;     // get small icon
        public const uint SHGFI_OPENICON = 0x000000002;     // get open icon
        public const uint SHGFI_SHELLICONSIZE = 0x000000004;     // get shell size icon
        public const uint SHGFI_PIDL = 0x000000008;     // pszPath is a pidl
        public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;     // use passed dwFileAttribute
        public const uint SHGFI_ADDOVERLAYS = 0x000000020;     // apply the appropriate overlays
        public const uint SHGFI_OVERLAYINDEX = 0x000000040;     // Get the index of the overlay

        public const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        public const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;

        public const int ILD_TRANSPARENT = 0x00000001;

        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability",
            "CA1401:P/Invokes should not be visible", Justification = "<Pending>")]
        public static extern IntPtr SHGetFileInfo(
           string pszPath,
           uint dwFileAttributes,
           ref SHFILEINFO psfi,
           uint cbFileInfo,
           uint uFlags
           );

        [DllImport("comctl32")]
        internal static extern IntPtr ImageList_GetIcon(
          IntPtr himl,
          int i,
          int flags);
    }

    /// <summary>
    /// Wraps necessary functions imported from User32.dll. Code courtesy of MSDN Cold Rooster Consulting example.
    /// </summary>
    public class User32
    {
        /// <summary>
        /// Provides access to function required to delete handle. This method is used internally
        /// and is not required to be called separately.
        /// </summary>
        /// <param name="hIcon">Pointer to icon handle.</param>
        /// <returns>N/A</returns>
        [DllImport("User32.dll")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability",
            "CA1401:P/Invokes should not be visible", Justification = "<Pending>")]
        public static extern int DestroyIcon(IntPtr hIcon);
    }
}