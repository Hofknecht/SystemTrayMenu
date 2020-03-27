using System;
using System.Runtime.InteropServices;

namespace SystemTrayMenu.NativeDllImport
{
    public static partial class NativeMethods
    {
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
        //public const uint BIF_RETURNONLYFSDIRS = 0x0001;
        //public const uint BIF_DONTGOBELOWDOMAIN = 0x0002;
        //public const uint BIF_STATUSTEXT = 0x0004;
        //public const uint BIF_RETURNFSANCESTORS = 0x0008;
        //public const uint BIF_EDITBOX = 0x0010;
        //public const uint BIF_VALIDATE = 0x0020;
        //public const uint BIF_NEWDIALOGSTYLE = 0x0040;
        //public const uint BIF_USENEWUI = (BIF_NEWDIALOGSTYLE | BIF_EDITBOX);
        //public const uint BIF_BROWSEINCLUDEURLS = 0x0080;
        //public const uint BIF_BROWSEFORCOMPUTER = 0x1000;
        //public const uint BIF_BROWSEFORPRINTER = 0x2000;
        //public const uint BIF_BROWSEINCLUDEFILES = 0x4000;
        //public const uint BIF_SHAREABLE = 0x8000;

        public const uint ShgfiIcon = 0x000000100;     // get icon
        //public const uint SHGFI_DISPLAYNAME = 0x000000200;     // get display name
        //public const uint SHGFI_TYPENAME = 0x000000400;     // get type name
        //public const uint SHGFI_ATTRIBUTES = 0x000000800;     // get attributes
        //public const uint SHGFI_ICONLOCATION = 0x000001000;     // get icon location
        //public const uint SHGFI_EXETYPE = 0x000002000;     // return exe type
        public const uint ShgfiSYSICONINDEX = 0x000004000;     // get system icon index
        public const uint ShgfiLINKOVERLAY = 0x000008000;     // put a link overlay on icon
        //public const uint SHGFI_SELECTED = 0x000010000;     // show icon in selected state
        //public const uint SHGFI_ATTR_SPECIFIED = 0x000020000;     // get only specified attributes
        public const uint ShgfiLARGEICON = 0x000000000;     // get large icon
        public const uint ShgfiSMALLICON = 0x000000001;     // get small icon
        public const uint ShgfiOPENICON = 0x000000002;     // get open icon
        //public const uint SHGFI_SHELLICONSIZE = 0x000000004;     // get shell size icon
        //public const uint SHGFI_PIDL = 0x000000008;     // pszPath is a pidl
        //public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;     // use passed dwFileAttribute
        //public const uint SHGFI_ADDOVERLAYS = 0x000000020;     // apply the appropriate overlays
        //public const uint SHGFI_OVERLAYINDEX = 0x000000040;     // Get the index of the overlay

        public const uint FileAttributeDirectory = 0x00000010;
        public const uint FileAttributeNormal = 0x00000080;

        public const int IldTransparent = 0x00000001;

        [DllImport("comctl32")]
        internal static extern IntPtr ImageList_GetIcon(
          IntPtr himl,
          int i,
          int flags);

        public static void Comctl32ImageList_GetIcon(IntPtr hIcon)
        {
            _ = DestroyIcon(hIcon);
        }
    }
}
