// <copyright file="ShellContextMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Interop;

    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1124:Do not use regions", Justification = "Mark SystemTrayMenu modifications made to original source.")]

    /// <summary>
    /// source: https://www.codeproject.com/Articles/22012/Explorer-Shell-Context-Menu
    /// modified to fit SystemTrayMenu.
    ///
    /// "Stand-alone" shell context menu
    ///
    /// It isn't really debugged but is mostly working.
    /// Create an instance and call ShowContextMenu with a list of FileInfo for the files.
    /// Limitation is that it only handles files in the same directory but it can be fixed
    /// by changing the way files are translated into PIDLs.
    ///
    /// Based on FileBrowser in C# from CodeProject
    /// http://www.codeproject.com/useritems/FileBrowser.asp
    ///
    /// Hooking class taken from MSDN Magazine Cutting Edge column
    /// http://msdn.microsoft.com/msdnmag/issues/02/10/CuttingEdge/
    ///
    /// Andreas Johansson
    /// afjohansson@hotmail.com
    /// http://afjohansson.spaces.live.com
    /// .
    /// </summary>
    /// <example>
    ///    ShellContextMenu scm = new ShellContextMenu();
    ///    FileInfo[] files = new FileInfo[1];
    ///    files[0] = new FileInfo(@"c:\windows\notepad.exe");
    ///    scm.ShowContextMenu(this.Handle, files, Cursor.Position);.
    /// </example>
    public class ShellContextMenu : HwndSource
    {
        private const int MaxPath = 260;
        private const uint CmdFirst = 1;
        private const uint CmdLast = 30000;
        private const int ResultOK = 0;

        private static readonly int CbMenuItemInfo = Marshal.SizeOf(typeof(MENUITEMINFO));
        private static readonly int CbInvokeCommand = Marshal.SizeOf(typeof(CMINVOKECOMMANDINFOEX));

        private static Guid iidIShellFolder = new("{000214E6-0000-0000-C000-000000000046}");
        private static Guid iidIContextMenu = new("{000214e4-0000-0000-c000-000000000046}");
        private static Guid iidIContextMenu2 = new("{000214f4-0000-0000-c000-000000000046}");
        private static Guid iidIContextMenu3 = new("{bcfce0a0-ec17-11d0-8d10-00a0c90f2719}");

        private readonly HwndSourceHook hook;

        private IContextMenu? oContextMenu;
        private IContextMenu2? oContextMenu2;
        private IContextMenu3? oContextMenu3;
        private IShellFolder? oDesktopFolder;
        private IShellFolder? oParentFolder;
        private IntPtr[]? arrPIDLs;
        private string? strParentFolder;

        public ShellContextMenu()
                : base(default)
        {
            hook = new HwndSourceHook(WndProc);
            AddHook(hook);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="ShellContextMenu"/> class.
        /// </summary>
        ~ShellContextMenu()
        {
            ReleaseAll();
            RemoveHook(hook);
        }

        // Defines the values used with the IShellFolder::GetDisplayNameOf and IShellFolder::SetNameOf
        // methods to specify the type of file or folder names used by those methods
        [Flags]
        private enum SHGNO
        {
            NORMAL = 0x0000,
            INFOLDER = 0x0001,
            FOREDITING = 0x1000,
            FORADDRESSBAR = 0x4000,
            FORPARSING = 0x8000,
        }

        // The attributes that the caller is requesting, when calling IShellFolder::GetAttributesOf
        [Flags]
        private enum SFGAO : uint
        {
            BROWSABLE = 0x8000000,
            CANCOPY = 1,
            CANDELETE = 0x20,
            CANLINK = 4,
            CANMONIKER = 0x400000, // HASSTORAGE = 0x400000, //STREAM = 0x400000,
            CANMOVE = 2,
            CANRENAME = 0x10,
            CAPABILITYMASK = 0x177,
            COMPRESSED = 0x4000000,
            CONTENTSMASK = 0x80000000, // HASSUBFOLDER = 0x80000000,
            DISPLAYATTRMASK = 0xfc000,
            DROPTARGET = 0x100,
            ENCRYPTED = 0x2000,
            FILESYSANCESTOR = 0x10000000,
            FILESYSTEM = 0x40000000,
            FOLDER = 0x20000000,
            GHOSTED = 0x8000,
            HASPROPSHEET = 0x40,
            HIDDEN = 0x80000,
            ISSLOW = 0x4000,
            LINK = 0x10000,
            NEWCONTENT = 0x200000,
            NONENUMERATED = 0x100000,
            READONLY = 0x40000,
            REMOVABLE = 0x2000000,
            SHARE = 0x20000,
            STORAGE = 8,
            STORAGEANCESTOR = 0x800000,
            STORAGECAPMASK = 0x70c50008,
            VALIDATE = 0x1000000,
        }

        // Determines the type of items included in an enumeration.
        // These values are used with the IShellFolder::EnumObjects method
        [Flags]
        private enum SHCONTF
        {
            FOLDERS = 0x0020,
            NONFOLDERS = 0x0040,
            INCLUDEHIDDEN = 0x0080,
            INIT_ON_FIRST_NEXT = 0x0100,
            NETPRINTERSRCH = 0x0200,
            SHAREABLE = 0x0400,
            STORAGE = 0x0800,
        }

        // Specifies how the shortcut menu can be changed when calling IContextMenu::QueryContextMenu
        [Flags]
        private enum CMF : uint
        {
            NORMAL = 0x00000000,
            DEFAULTONLY = 0x00000001,
            VERBSONLY = 0x00000002,
            EXPLORE = 0x00000004,
            NOVERBS = 0x00000008,
            CANRENAME = 0x00000010,
            NODEFAULT = 0x00000020,
            INCLUDESTATIC = 0x00000040,
            EXTENDEDVERBS = 0x00000100,
            RESERVED = 0xffff0000,
        }

        // Flags specifying the information to return when calling IContextMenu::GetCommandString
        [Flags]
        private enum GCS : uint
        {
            VERBA = 0,
            HELPTEXTA = 1,
            VALIDATEA = 2,
            VERBW = 4,
            HELPTEXTW = 5,
            VALIDATEW = 6,
        }

        // The cmd for a custom added menu item
        private enum CMD_CUSTOM
        {
            ExpandCollapse = (int)CmdLast + 1,
        }

        // Flags used with the CMINVOKECOMMANDINFOEX structure
        [Flags]
        private enum CMIC : uint
        {
            HOTKEY = 0x00000020,
            ICON = 0x00000010,
            FLAG_NO_UI = 0x00000400,
            UNICODE = 0x00004000,
            NO_CONSOLE = 0x00008000,
            ASYNCOK = 0x00100000,
            NOZONECHECKS = 0x00800000,
            SHIFT_DOWN = 0x10000000,
            CONTROL_DOWN = 0x40000000,
            FLAG_LOG_USAGE = 0x04000000,
            PTINVOKE = 0x20000000,
        }

        // Specifies how the window is to be shown
        [Flags]
        private enum SW : uint
        {
            HIDE = 0,
            SHOWNORMAL = 1, // NORMAL = 1,
            SHOWMINIMIZED = 2,
            SHOWMAXIMIZED = 3, // MAXIMIZE = 3,
            SHOWNOACTIVATE = 4,
            SHOW = 5,
            MINIMIZE = 6,
            SHOWMINNOACTIVE = 7,
            SHOWNA = 8,
            RESTORE = 9,
            SHOWDEFAULT = 10,
        }

        // Window message flags
        [Flags]
        private enum WM : uint
        {
            ACTIVATE = 0x6,
            ACTIVATEAPP = 0x1C,
            AFXFIRST = 0x360,
            AFXLAST = 0x37F,
            APP = 0x8000,
            ASKCBFORMATNAME = 0x30C,
            CANCELJOURNAL = 0x4B,
            CANCELMODE = 0x1F,
            CAPTURECHANGED = 0x215,
            CHANGECBCHAIN = 0x30D,
            CHAR = 0x102,
            CHARTOITEM = 0x2F,
            CHILDACTIVATE = 0x22,
            CLEAR = 0x303,
            CLOSE = 0x10,
            COMMAND = 0x111,
            COMPACTING = 0x41,
            COMPAREITEM = 0x39,
            CONTEXTMENU = 0x7B,
            COPY = 0x301,
            COPYDATA = 0x4A,
            CREATE = 0x1,
            CTLCOLORBTN = 0x135,
            CTLCOLORDLG = 0x136,
            CTLCOLOREDIT = 0x133,
            CTLCOLORLISTBOX = 0x134,
            CTLCOLORMSGBOX = 0x132,
            CTLCOLORSCROLLBAR = 0x137,
            CTLCOLORSTATIC = 0x138,
            CUT = 0x300,
            DEADCHAR = 0x103,
            DELETEITEM = 0x2D,
            DESTROY = 0x2,
            DESTROYCLIPBOARD = 0x307,
            DEVICECHANGE = 0x219,
            DEVMODECHANGE = 0x1B,
            DISPLAYCHANGE = 0x7E,
            DRAWCLIPBOARD = 0x308,
            DRAWITEM = 0x2B,
            DROPFILES = 0x233,
            ENABLE = 0xA,
            ENDSESSION = 0x16,
            ENTERIDLE = 0x121,
            ENTERMENULOOP = 0x211,
            ENTERSIZEMOVE = 0x231,
            ERASEBKGND = 0x14,
            EXITMENULOOP = 0x212,
            EXITSIZEMOVE = 0x232,
            FONTCHANGE = 0x1D,
            GETDLGCODE = 0x87,
            GETFONT = 0x31,
            GETHOTKEY = 0x33,
            GETICON = 0x7F,
            GETMINMAXINFO = 0x24,
            GETOBJECT = 0x3D,
            GETSYSMENU = 0x313,
            GETTEXT = 0xD,
            GETTEXTLENGTH = 0xE,
            HANDHELDFIRST = 0x358,
            HANDHELDLAST = 0x35F,
            HELP = 0x53,
            HOTKEY = 0x312,
            HSCROLL = 0x114,
            HSCROLLCLIPBOARD = 0x30E,
            ICONERASEBKGND = 0x27,
            IME_CHAR = 0x286,
            IME_COMPOSITION = 0x10F, // IME_KEYLAST = 0x10F,
            IME_COMPOSITIONFULL = 0x284,
            IME_CONTROL = 0x283,
            IME_ENDCOMPOSITION = 0x10E,
            IME_KEYDOWN = 0x290,
            IME_KEYUP = 0x291,
            IME_NOTIFY = 0x282,
            IME_REQUEST = 0x288,
            IME_SELECT = 0x285,
            IME_SETCONTEXT = 0x281,
            IME_STARTCOMPOSITION = 0x10D,
            INITDIALOG = 0x110,
            INITMENU = 0x116,
            INITMENUPOPUP = 0x117,
            INPUTLANGCHANGE = 0x51,
            INPUTLANGCHANGEREQUEST = 0x50,
            KEYDOWN = 0x100, // KEYFIRST = 0x100,
            KEYLAST = 0x108,
            KEYUP = 0x101,
            KILLFOCUS = 0x8,
            LBUTTONDBLCLK = 0x203,
            LBUTTONDOWN = 0x201,
            LBUTTONUP = 0x202,
            LVM_GETEDITCONTROL = 0x1018,
            LVM_SETIMAGELIST = 0x1003,
            MBUTTONDBLCLK = 0x209,
            MBUTTONDOWN = 0x207,
            MBUTTONUP = 0x208,
            MDIACTIVATE = 0x222,
            MDICASCADE = 0x227,
            MDICREATE = 0x220,
            MDIDESTROY = 0x221,
            MDIGETACTIVE = 0x229,
            MDIICONARRANGE = 0x228,
            MDIMAXIMIZE = 0x225,
            MDINEXT = 0x224,
            MDIREFRESHMENU = 0x234,
            MDIRESTORE = 0x223,
            MDISETMENU = 0x230,
            MDITILE = 0x226,
            MEASUREITEM = 0x2C,
            MENUCHAR = 0x120,
            MENUCOMMAND = 0x126,
            MENUDRAG = 0x123,
            MENUGETOBJECT = 0x124,
            MENURBUTTONUP = 0x122,
            MENUSELECT = 0x11F,
            MOUSEACTIVATE = 0x21,
            MOUSEFIRST = 0x200, // MOUSEMOVE = 0x200,
            MOUSEHOVER = 0x2A1,
            MOUSELAST = 0x20A, // MOUSEWHEEL = 0x20A,
            MOUSELEAVE = 0x2A3,
            MOVE = 0x3,
            MOVING = 0x216,
            NCACTIVATE = 0x86,
            NCCALCSIZE = 0x83,
            NCCREATE = 0x81,
            NCDESTROY = 0x82,
            NCHITTEST = 0x84,
            NCLBUTTONDBLCLK = 0xA3,
            NCLBUTTONDOWN = 0xA1,
            NCLBUTTONUP = 0xA2,
            NCMBUTTONDBLCLK = 0xA9,
            NCMBUTTONDOWN = 0xA7,
            NCMBUTTONUP = 0xA8,
            NCMOUSEHOVER = 0x2A0,
            NCMOUSELEAVE = 0x2A2,
            NCMOUSEMOVE = 0xA0,
            NCPAINT = 0x85,
            NCRBUTTONDBLCLK = 0xA6,
            NCRBUTTONDOWN = 0xA4,
            NCRBUTTONUP = 0xA5,
            NEXTDLGCTL = 0x28,
            NEXTMENU = 0x213,
            NOTIFY = 0x4E,
            NOTIFYFORMAT = 0x55,
            NULL = 0x0,
            PAINT = 0xF,
            PAINTCLIPBOARD = 0x309,
            PAINTICON = 0x26,
            PALETTECHANGED = 0x311,
            PALETTEISCHANGING = 0x310,
            PARENTNOTIFY = 0x210,
            PASTE = 0x302,
            PENWINFIRST = 0x380,
            PENWINLAST = 0x38F,
            POWER = 0x48,
            PRINT = 0x317,
            PRINTCLIENT = 0x318,
            QUERYDRAGICON = 0x37,
            QUERYENDSESSION = 0x11,
            QUERYNEWPALETTE = 0x30F,
            QUERYOPEN = 0x13,
            QUEUESYNC = 0x23,
            QUIT = 0x12,
            RBUTTONDBLCLK = 0x206,
            RBUTTONDOWN = 0x204,
            RBUTTONUP = 0x205,
            RENDERALLFORMATS = 0x306,
            RENDERFORMAT = 0x305,
            SETCURSOR = 0x20,
            SETFOCUS = 0x7,
            SETFONT = 0x30,
            SETHOTKEY = 0x32,
            SETICON = 0x80,
            SETMARGINS = 0xD3,
            SETREDRAW = 0xB,
            SETTEXT = 0xC,
            SETTINGCHANGE = 0x1A, // WININICHANGE = 0x1A,
            SHOWWINDOW = 0x18,
            SIZE = 0x5,
            SIZECLIPBOARD = 0x30B,
            SIZING = 0x214,
            SPOOLERSTATUS = 0x2A,
            STYLECHANGED = 0x7D,
            STYLECHANGING = 0x7C,
            SYNCPAINT = 0x88,
            SYSCHAR = 0x106,
            SYSCOLORCHANGE = 0x15,
            SYSCOMMAND = 0x112,
            SYSDEADCHAR = 0x107,
            SYSKEYDOWN = 0x104,
            SYSKEYUP = 0x105,
            TCARD = 0x52,
            TIMECHANGE = 0x1E,
            TIMER = 0x113,
            TVM_GETEDITCONTROL = 0x110F,
            TVM_SETIMAGELIST = 0x1109,
            UNDO = 0x304,
            UNINITMENUPOPUP = 0x125,
            USER = 0x400,
            USERCHANGED = 0x54,
            VKEYTOITEM = 0x2E,
            VSCROLL = 0x115,
            VSCROLLCLIPBOARD = 0x30A,
            WINDOWPOSCHANGED = 0x47,
            WINDOWPOSCHANGING = 0x46,
            SH_NOTIFY = 0x0401,
        }

        // Specifies the content of the new menu item
        [Flags]
        private enum MFT : uint
        {
            GRAYED = 0x00000003, // DISABLED = 0x00000003,
            CHECKED = 0x00000008,
            SEPARATOR = 0x00000800,
            RADIOCHECK = 0x00000200,
            BITMAP = 0x00000004,
            OWNERDRAW = 0x00000100,
            MENUBARBREAK = 0x00000020,
            MENUBREAK = 0x00000040,
            RIGHTORDER = 0x00002000,
            BYCOMMAND = 0x00000000,
            BYPOSITION = 0x00000400,
            POPUP = 0x00000010,
        }

        // Specifies the state of the new menu item
        [Flags]
        private enum MFS : uint
        {
            GRAYED = 0x00000003, // DISABLED = 0x00000003,
            CHECKED = 0x00000008,
            HILITE = 0x00000080,
            ENABLED = 0x00000000, // UNCHECKED = 0x00000000, // UNHILITE = 0x00000000,
            DEFAULT = 0x00001000,
        }

        // Specifies the content of the new menu item
        [Flags]
        private enum MIIM : uint
        {
            BITMAP = 0x80,
            CHECKMARKS = 0x08,
            DATA = 0x20,
            FTYPE = 0x100,
            ID = 0x02,
            STATE = 0x01,
            STRING = 0x40,
            SUBMENU = 0x04,
            TYPE = 0x10,
        }

        // Indicates the type of storage medium being used in a data transfer
        [Flags]
        private enum TYMED
        {
            ENHMF = 0x40,
            FILE = 2,
            GDI = 0x10,
            HGLOBAL = 1,
            ISTORAGE = 8,
            ISTREAM = 4,
            MFPICT = 0x20,
            NULL = 0,
        }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("000214E6-0000-0000-C000-000000000046")]
        private interface IShellFolder
        {
            // Translates a file object's or folder's display name into an item identifier list.
            // Return value: error code, if any
            [PreserveSig]
            int ParseDisplayName(
                IntPtr hwnd,
                IntPtr pbc,
                [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName,
                ref uint pchEaten,
                out IntPtr ppidl,
                ref SFGAO pdwAttributes);

            // Allows a client to determine the contents of a folder by creating an item
            // identifier enumeration object and returning its IEnumIDList interface.
            // Return value: error code, if any
            [PreserveSig]
            int EnumObjects(
                IntPtr hwnd,
                SHCONTF grfFlags,
                out IntPtr enumIDList);

            // Retrieves an IShellFolder object for a subfolder.
            // Return value: error code, if any
            [PreserveSig]
            int BindToObject(
                IntPtr pidl,
                IntPtr pbc,
                ref Guid riid,
                out IntPtr ppv);

            // Requests a pointer to an object's storage interface.
            // Return value: error code, if any
            [PreserveSig]
            int BindToStorage(
                IntPtr pidl,
                IntPtr pbc,
                ref Guid riid,
                out IntPtr ppv);

            // Determines the relative order of two file objects or folders, given their
            // item identifier lists. Return value: If this method is successful, the
            // CODE field of the HRESULT contains one of the following values (the code
            // can be retrived using the helper function GetHResultCode): Negative A
            // negative return value indicates that the first item should precede
            // the second (pidl1 < pidl2).

            // Positive A positive return value indicates that the first item should
            // follow the second (pidl1 > pidl2).  Zero A return value of zero
            // indicates that the two items are the same (pidl1 = pidl2).
            [PreserveSig]
            int CompareIDs(
                IntPtr lParam,
                IntPtr pidl1,
                IntPtr pidl2);

            // Requests an object that can be used to obtain information from or interact
            // with a folder object.
            // Return value: error code, if any
            [PreserveSig]
            int CreateViewObject(
                IntPtr hwndOwner,
                Guid riid,
                out IntPtr ppv);

            // Retrieves the attributes of one or more file objects or subfolders.
            // Return value: error code, if any
            [PreserveSig]
            int GetAttributesOf(
                uint cidl,
                [MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl,
                ref SFGAO rgfInOut);

            // Retrieves an OLE interface that can be used to carry out actions on the
            // specified file objects or folders.
            // Return value: error code, if any
            [PreserveSig]
            int GetUIObjectOf(
                IntPtr hwndOwner,
                uint cidl,
                [MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl,
                ref Guid riid,
                IntPtr rgfReserved,
                out IntPtr ppv);

            // Retrieves the display name for the specified file object or subfolder.
            // Return value: error code, if any
            [PreserveSig]
            int GetDisplayNameOf(
                IntPtr pidl,
                SHGNO uFlags,
                IntPtr lpName);

            // Sets the display name of a file object or subfolder, changing the item
            // identifier in the process.
            // Return value: error code, if any
            [PreserveSig]
            int SetNameOf(
                IntPtr hwnd,
                IntPtr pidl,
                [MarshalAs(UnmanagedType.LPWStr)] string pszName,
                SHGNO uFlags,
                out IntPtr ppidlOut);
        }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("000214e4-0000-0000-c000-000000000046")]
        private interface IContextMenu
        {
            // Adds commands to a shortcut menu
            [PreserveSig]
            int QueryContextMenu(
                IntPtr hmenu,
                uint iMenu,
                uint idCmdFirst,
                uint idCmdLast,
                CMF uFlags);

            // Carries out the command associated with a shortcut menu item
            [PreserveSig]
            int InvokeCommand(
                ref CMINVOKECOMMANDINFOEX info);

            // Retrieves information about a shortcut menu command,
            // including the help string and the language-independent,
            // or canonical, name for the command
            [PreserveSig]
            int GetCommandString(
                uint idcmd,
                GCS uflags,
                uint reserved,
                [MarshalAs(UnmanagedType.LPArray)] byte[] commandstring,
                int cch);
        }

        [ComImport]
        [Guid("000214f4-0000-0000-c000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IContextMenu2
        {
            // Adds commands to a shortcut menu
            [PreserveSig]
            int QueryContextMenu(
                IntPtr hmenu,
                uint iMenu,
                uint idCmdFirst,
                uint idCmdLast,
                CMF uFlags);

            // Carries out the command associated with a shortcut menu item
            [PreserveSig]
            int InvokeCommand(
                ref CMINVOKECOMMANDINFOEX info);

            // Retrieves information about a shortcut menu command,
            // including the help string and the language-independent,
            // or canonical, name for the command
            [PreserveSig]
            int GetCommandString(
                uint idcmd,
                GCS uflags,
                uint reserved,
                [MarshalAs(UnmanagedType.LPWStr)] StringBuilder commandstring,
                int cch);

            // Allows client objects of the IContextMenu interface to
            // handle messages associated with owner-drawn menu items
            [PreserveSig]
            int HandleMenuMsg(
                uint uMsg,
                IntPtr wParam,
                IntPtr lParam);
        }

        [ComImport]
        [Guid("bcfce0a0-ec17-11d0-8d10-00a0c90f2719")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IContextMenu3
        {
            // Adds commands to a shortcut menu
            [PreserveSig]
            int QueryContextMenu(
                IntPtr hmenu,
                uint iMenu,
                uint idCmdFirst,
                uint idCmdLast,
                CMF uFlags);

            // Carries out the command associated with a shortcut menu item
            [PreserveSig]
            int InvokeCommand(
                ref CMINVOKECOMMANDINFOEX info);

            // Retrieves information about a shortcut menu command,
            // including the help string and the language-independent,
            // or canonical, name for the command
            [PreserveSig]
            int GetCommandString(
                uint idcmd,
                GCS uflags,
                uint reserved,
                [MarshalAs(UnmanagedType.LPWStr)] StringBuilder commandstring,
                int cch);

            // Allows client objects of the IContextMenu interface to
            // handle messages associated with owner-drawn menu items
            [PreserveSig]
            int HandleMenuMsg(
                uint uMsg,
                IntPtr wParam,
                IntPtr lParam);

            // Allows client objects of the IContextMenu3 interface to
            // handle messages associated with owner-drawn menu items
            [PreserveSig]
            int HandleMenuMsg2(
                uint uMsg,
                IntPtr wParam,
                IntPtr lParam,
                IntPtr plResult);
        }

        #region System Tray Menu Helpers

        /// <summary>
        /// Creates and shows a shell context menu.
        /// </summary>
        /// <param name="directoryInfo">Context of given directory.</param>
        /// <param name="position">Position where the menu show be shown.</param>
        public static void OpenShellContextMenu(DirectoryInfo directoryInfo, Point position)
        {
            ShellContextMenu ctxMnu = new();
            DirectoryInfo[] dir = new DirectoryInfo[1];
            dir[0] = directoryInfo;
            ctxMnu.ShowContextMenu(dir, position);
        }

        /// <summary>
        /// Creates and shows a shell context menu.
        /// </summary>
        /// <param name="fileInfo">Context of given file.</param>
        /// <param name="position">Position where the menu show be shown.</param>
        public static void OpenShellContextMenu(FileInfo fileInfo, Point position)
        {
            ShellContextMenu ctxMnu = new();
            FileInfo[] arrFI = new FileInfo[1];
            arrFI[0] = fileInfo;
            ctxMnu.ShowContextMenu(arrFI, position);
        }

        #endregion

        /// <summary>
        /// Shows the context menu.
        /// </summary>
        /// <param name="files">FileInfos (should all be in same directory).</param>
        /// <param name="pointScreen">Where to show the menu.</param>
        public void ShowContextMenu(FileInfo[] files, Point pointScreen)
        {
            // Release all resources first.
            ReleaseAll();
            arrPIDLs = GetPIDLs(files);
            ShowContextMenu(pointScreen);
        }

        /// <summary>
        /// Shows the context menu.
        /// </summary>
        /// <param name="dirs">DirectoryInfos (should all be in same directory).</param>
        /// <param name="pointScreen">Where to show the menu.</param>
        public void ShowContextMenu(DirectoryInfo[] dirs, Point pointScreen)
        {
            // Release all resources first.
            ReleaseAll();
            arrPIDLs = GetPIDLs(dirs);
            ShowContextMenu(pointScreen);
        }

        /// <summary>
        /// Shows the context menu.
        /// </summary>
        /// <param name="pointScreen">Where to show the menu.</param>
        public void ShowContextMenu(Point pointScreen)
        {
            IntPtr pMenu = IntPtr.Zero,
                iContextMenuPtr = IntPtr.Zero,
                iContextMenuPtr2 = IntPtr.Zero,
                iContextMenuPtr3 = IntPtr.Zero;

            try
            {
                if (arrPIDLs == null || oParentFolder == null)
                {
                    ReleaseAll();
                    return;
                }

                if (!GetContextMenuInterfaces(oParentFolder, arrPIDLs, out iContextMenuPtr))
                {
                    ReleaseAll();
                    return;
                }

                pMenu = DllImports.NativeMethods.User32CreatePopupMenu();
                int nResult = oContextMenu.QueryContextMenu(
                    pMenu,
                    0,
                    CmdFirst,
                    CmdLast,
                    CMF.EXPLORE | CMF.NORMAL | ((Keyboard.Modifiers & ModifierKeys.Shift) != 0 ? CMF.EXTENDEDVERBS : 0));
                Marshal.QueryInterface(iContextMenuPtr, ref iidIContextMenu2, out iContextMenuPtr2);
                Marshal.QueryInterface(iContextMenuPtr, ref iidIContextMenu3, out iContextMenuPtr3);

                oContextMenu2 = (IContextMenu2)Marshal.GetTypedObjectForIUnknown(iContextMenuPtr2, typeof(IContextMenu2));
                oContextMenu3 = (IContextMenu3)Marshal.GetTypedObjectForIUnknown(iContextMenuPtr3, typeof(IContextMenu3));

                uint nSelected = DllImports.NativeMethods.User32TrackPopupMenuEx(
                    pMenu,
                    DllImports.NativeMethods.TPM.RETURNCMD,
                    (int)pointScreen.X,
                    (int)pointScreen.Y,
                    Handle,
                    IntPtr.Zero);

                // First invoke menu item, then destroy menu
                // (otherwise: Right click on items to choose "Send to" doesn't work #225)
                if (nSelected != 0)
                {
                    InvokeCommand(oContextMenu, nSelected, strParentFolder, pointScreen);
                }

                DllImports.NativeMethods.User32DestroyMenu(pMenu);
                pMenu = IntPtr.Zero;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (pMenu != IntPtr.Zero)
                {
                    DllImports.NativeMethods.User32DestroyMenu(pMenu);
                }

                if (iContextMenuPtr != IntPtr.Zero)
                {
                    Marshal.Release(iContextMenuPtr);
                }

                if (iContextMenuPtr2 != IntPtr.Zero)
                {
                    Marshal.Release(iContextMenuPtr2);
                }

                if (iContextMenuPtr3 != IntPtr.Zero)
                {
                    Marshal.Release(iContextMenuPtr3);
                }

                ReleaseAll();
            }
        }

        /// <summary>
        /// Free the PIDLs.
        /// </summary>
        /// <param name="arrPIDLs">Array of PIDLs (IntPtr).</param>
        protected static void FreePIDLs(IntPtr[] arrPIDLs)
        {
            if (arrPIDLs != null)
            {
                for (int n = 0; n < arrPIDLs.Length; n++)
                {
                    if (arrPIDLs[n] != IntPtr.Zero)
                    {
                        Marshal.FreeCoTaskMem(arrPIDLs[n]);
                        arrPIDLs[n] = IntPtr.Zero;
                    }
                }
            }
        }

        /// <summary>
        /// This method receives WindowMessages. It will make the "Open With" and "Send To" work
        /// by calling HandleMenuMsg and HandleMenuMsg2. It will also call the OnContextMenuMouseHover
        /// method of Browser when hovering over a ContextMenu item.
        /// </summary>
        /// <param name="hwnd">The window handle.</param>
        /// <param name="msg">The message ID.</param>
        /// <param name="wParam">The message's wParam value.</param>
        /// <param name="lParam">The message's lParam value.</param>
        /// <param name="handled">A value that indicates whether the message was handled.
        /// Set the value to true if the message was handled; otherwise, false.</param>
        /// <returns>The appropriate return value depends on the particular message.
        /// See the message documentation details for the Win32 message being handled.</returns>
        protected IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (oContextMenu2 != null &&
                (msg == (int)WM.INITMENUPOPUP ||
                 msg == (int)WM.MEASUREITEM ||
                 msg == (int)WM.DRAWITEM))
            {
                if (oContextMenu2.HandleMenuMsg(
                    (uint)msg, wParam, lParam) == ResultOK)
                {
                    handled = true;
                    return IntPtr.Zero;
                }
            }

            if (oContextMenu3 != null &&
                msg == (int)WM.MENUCHAR)
            {
                if (oContextMenu3.HandleMenuMsg2(
                    (uint)msg, wParam, lParam, IntPtr.Zero) == ResultOK)
                {
                    handled = true;
                    return IntPtr.Zero;
                }
            }

            handled = false;
            return IntPtr.Zero;
        }

        /// <summary>
        /// Get the PIDLs.
        /// </summary>
        /// <param name="arrFI">Array of FileInfo.</param>
        /// <returns>Array of PIDLs.</returns>
        protected IntPtr[]? GetPIDLs(FileInfo[] arrFI)
        {
            if (arrFI == null || arrFI.Length == 0)
            {
                return null;
            }

            IShellFolder? oParentFolder = GetParentFolder(arrFI[0].DirectoryName);
            if (oParentFolder == null)
            {
                return null;
            }

            IntPtr[] arrPIDLs = new IntPtr[arrFI.Length];
            int n = 0;
            foreach (FileInfo fi in arrFI)
            {
                // Get the file relative to folder
                uint pchEaten = 0;
                SFGAO pdwAttributes = 0;
                IntPtr pPIDL = IntPtr.Zero;
                int nResult = oParentFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, fi.Name, ref pchEaten, out pPIDL, ref pdwAttributes);
                if (nResult != ResultOK)
                {
                    FreePIDLs(arrPIDLs);
                    return null;
                }

                arrPIDLs[n] = pPIDL;
                n++;
            }

            return arrPIDLs;
        }

        /// <summary>
        /// Get the PIDLs.
        /// </summary>
        /// <param name="arrFI">Array of DirectoryInfo.</param>
        /// <returns>Array of PIDLs.</returns>
        protected IntPtr[]? GetPIDLs(DirectoryInfo[] arrFI)
        {
            if (arrFI == null || arrFI.Length == 0 || arrFI[0].Parent == null)
            {
                return null;
            }

            IShellFolder? oParentFolder = GetParentFolder(arrFI[0].Parent?.FullName);
            if (oParentFolder == null)
            {
                return null;
            }

            IntPtr[] arrPIDLs = new IntPtr[arrFI.Length];
            int n = 0;
            foreach (DirectoryInfo fi in arrFI)
            {
                // Get the file relative to folder
                uint pchEaten = 0;
                SFGAO pdwAttributes = 0;
                IntPtr pPIDL = IntPtr.Zero;
                int nResult = oParentFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, fi.Name, ref pchEaten, out pPIDL, ref pdwAttributes);
                if (nResult != ResultOK)
                {
                    FreePIDLs(arrPIDLs);
                    return null;
                }

                arrPIDLs[n] = pPIDL;
                n++;
            }

            return arrPIDLs;
        }

        private static void InvokeCommand(IContextMenu contextMenu, uint nCmd, string? strFolder, Point pointInvoke)
        {
            CMINVOKECOMMANDINFOEX invoke = new()
            {
                CbSize = CbInvokeCommand,
                LpVerb = (IntPtr)(nCmd - CmdFirst),
                LpDirectory = strFolder,
                LpVerbW = (IntPtr)(nCmd - CmdFirst),
                LpDirectoryW = strFolder,
                FMask = CMIC.UNICODE | CMIC.PTINVOKE |
                ((Keyboard.Modifiers & ModifierKeys.Control) != 0 ? CMIC.CONTROL_DOWN : 0) |
                ((Keyboard.Modifiers & ModifierKeys.Shift) != 0 ? CMIC.SHIFT_DOWN : 0),
                PtInvoke = new POINT((int)pointInvoke.X, (int)pointInvoke.Y),
                NShow = SW.SHOWNORMAL,
            };
            _ = contextMenu.InvokeCommand(ref invoke);
        }

        /// <summary>Gets the interfaces to the context menu.</summary>
        /// <param name="oParentFolder">Parent folder.</param>
        /// <param name="arrPIDLs">PIDLs.</param>
        /// <returns>true if it got the interfaces, otherwise false.</returns>
        [MemberNotNullWhen(true, nameof(oContextMenu))]
        private bool GetContextMenuInterfaces(IShellFolder oParentFolder, IntPtr[] arrPIDLs, out IntPtr ctxMenuPtr)
        {
            int nResult = oParentFolder.GetUIObjectOf(
                IntPtr.Zero,
                (uint)arrPIDLs.Length,
                arrPIDLs,
                ref iidIContextMenu,
                IntPtr.Zero,
                out ctxMenuPtr);

            if (nResult == ResultOK)
            {
                oContextMenu = (IContextMenu)Marshal.GetTypedObjectForIUnknown(ctxMenuPtr, typeof(IContextMenu));

                /*IntPtr pUnknownContextMenu2 = IntPtr.Zero;
                if (S_OK == Marshal.QueryInterface(pUnknownContextMenu, ref IID_IContextMenu2, out pUnknownContextMenu2))
                {
                    _oContextMenu2 = (IContextMenu2)Marshal.GetTypedObjectForIUnknown(pUnknownContextMenu2, typeof(IContextMenu2));
                }
                IntPtr pUnknownContextMenu3 = IntPtr.Zero;
                if (S_OK == Marshal.QueryInterface(pUnknownContextMenu, ref IID_IContextMenu3, out pUnknownContextMenu3))
                {
                    _oContextMenu3 = (IContextMenu3)Marshal.GetTypedObjectForIUnknown(pUnknownContextMenu3, typeof(IContextMenu3));
                }*/

                return true;
            }
            else
            {
                ctxMenuPtr = IntPtr.Zero;
                oContextMenu = null;
                return false;
            }
        }

        /// <summary>
        /// Release all allocated interfaces, PIDLs.
        /// </summary>
        private void ReleaseAll()
        {
            if (oContextMenu != null)
            {
                Marshal.ReleaseComObject(oContextMenu);
                oContextMenu = null;
            }

            if (oContextMenu2 != null)
            {
                Marshal.ReleaseComObject(oContextMenu2);
                oContextMenu2 = null;
            }

            if (oContextMenu3 != null)
            {
                Marshal.ReleaseComObject(oContextMenu3);
                oContextMenu3 = null;
            }

            if (oDesktopFolder != null)
            {
                Marshal.ReleaseComObject(oDesktopFolder);
                oDesktopFolder = null;
            }

            if (oParentFolder != null)
            {
                Marshal.ReleaseComObject(oParentFolder);
                oParentFolder = null;
            }

            if (arrPIDLs != null)
            {
                FreePIDLs(arrPIDLs);
                arrPIDLs = null;
            }
        }

        /// <summary>
        /// Gets the desktop folder.
        /// </summary>
        /// <returns>IShellFolder for desktop folder.</returns>
        private IShellFolder GetDesktopFolder()
        {
            if (oDesktopFolder == null)
            {
                // Get desktop IShellFolder
                int nResult = DllImports.NativeMethods.Shell32SHGetDesktopFolder(out IntPtr pUnkownDesktopFolder);
                if (nResult != ResultOK)
                {
                    throw new COMException("Failed to get the desktop shell folder", nResult);
                }

                oDesktopFolder = (IShellFolder)Marshal.GetTypedObjectForIUnknown(pUnkownDesktopFolder, typeof(IShellFolder));
            }

            return oDesktopFolder;
        }

        /// <summary>
        /// Gets the parent folder.
        /// </summary>
        /// <param name="folderName">Folder path.</param>
        /// <returns>IShellFolder for the folder (relative from the desktop).</returns>
        private IShellFolder? GetParentFolder(string? folderName)
        {
            if (oParentFolder == null)
            {
                IShellFolder oDesktopFolder = GetDesktopFolder();
                if (oDesktopFolder == null || folderName == null)
                {
                    return null;
                }

                // Get the PIDL for the folder file is in
                uint pchEaten = 0;
                SFGAO pdwAttributes = 0;
                int nResult = oDesktopFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, folderName, ref pchEaten, out IntPtr pPIDL, ref pdwAttributes);
                if (nResult != ResultOK)
                {
                    return null;
                }

                IntPtr pStrRet = Marshal.AllocCoTaskMem((MaxPath * 2) + 4);
                Marshal.WriteInt32(pStrRet, 0, 0);
                _ = oDesktopFolder.GetDisplayNameOf(pPIDL, SHGNO.FORPARSING, pStrRet);
                StringBuilder strFolder = new(MaxPath);
                _ = DllImports.NativeMethods.ShlwapiStrRetToBuf(pStrRet, pPIDL, strFolder, MaxPath);
                Marshal.FreeCoTaskMem(pStrRet);
                strParentFolder = strFolder.ToString();

                // Get the IShellFolder for folder
                nResult = oDesktopFolder.BindToObject(pPIDL, IntPtr.Zero, ref iidIShellFolder, out IntPtr pUnknownParentFolder);

                // Free the PIDL first
                Marshal.FreeCoTaskMem(pPIDL);
                if (nResult != ResultOK)
                {
                    return null;
                }

                oParentFolder = (IShellFolder)Marshal.GetTypedObjectForIUnknown(pUnknownParentFolder, typeof(IShellFolder));
            }

            return oParentFolder;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct CWPSTRUCT
        {
            public IntPtr Lparam;
            public IntPtr Wparam;
            public int Message;
            public IntPtr Hwnd;
        }

        // Contains extended information about a shortcut menu command
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]

        private struct CMINVOKECOMMANDINFOEX
        {
            public int CbSize;
            public CMIC FMask;
            public IntPtr Hwnd;
            public IntPtr LpVerb;
            [MarshalAs(UnmanagedType.LPStr)]
            public string LpParameters;
            [MarshalAs(UnmanagedType.LPStr)]
            public string? LpDirectory;
            public SW NShow;
            public int DwHotKey;
            public IntPtr HIcon;
            [MarshalAs(UnmanagedType.LPStr)]
            public string LpTitle;
            public IntPtr LpVerbW;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string LpParametersW;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string? LpDirectoryW;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string LpTitleW;
            public POINT PtInvoke;
        }

        // Contains information about a menu item
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]

        private readonly struct MENUITEMINFO
        {
            private readonly int cbSize;
            private readonly MIIM fMask;
            private readonly MFT fType;
            private readonly MFS fState;
            private readonly uint wID;
            private readonly IntPtr hSubMenu;
            private readonly IntPtr hbmpChecked;
            private readonly IntPtr hbmpUnchecked;
            private readonly IntPtr dwItemData;
            [MarshalAs(UnmanagedType.LPTStr)]
            private readonly string dwTypeData;
            private readonly int cch;
            private readonly IntPtr hbmpItem;

            public MENUITEMINFO(string text)
            {
                cbSize = CbMenuItemInfo;
                dwTypeData = text;
                cch = text.Length;
                fMask = 0;
                fType = 0;
                fState = 0;
                wID = 0;
                hSubMenu = IntPtr.Zero;
                hbmpChecked = IntPtr.Zero;
                hbmpUnchecked = IntPtr.Zero;
                dwItemData = IntPtr.Zero;
                hbmpItem = IntPtr.Zero;
            }
        }

        // A generalized global memory handle used for data transfer operations by the
        // IAdviseSink, IDataObject, and IOleCache interfaces
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct STGMEDIUM
        {
            public TYMED Tymed;
            public IntPtr HBitmap;
            public IntPtr HMetaFilePict;
            public IntPtr HEnhMetaFile;
            public IntPtr HGlobal;
            public IntPtr LpszFileName;
            public IntPtr Pstm;
            public IntPtr Pstg;
            public IntPtr PUnkForRelease;
        }

        // Defines the x- and y-coordinates of a point
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]

        private struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
