using Shell32;
using System;
using System.IO;
using System.Threading;

namespace SystemTrayMenu.Utilities
{
    internal class LnkHelper
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

            return resolvedFilename;
        }

        //        [Flags()]
        //        private enum SLGP_FLAGS
        //        {
        //            /// <summary>Retrieves the standard short (8.3 format) file name</summary>
        //            SLGP_SHORTPATH = 0x1,
        //            /// <summary>Retrieves the Universal Naming Convention (UNC) path name of the file</summary>
        //            SLGP_UNCPRIORITY = 0x2,
        //            /// <summary>Retrieves the raw path name. A raw path is something that might not exist and may include environment variables that need to be expanded</summary>
        //            SLGP_RAWPATH = 0x4
        //        }

        //        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        //        private struct WIN32_FIND_DATAW
        //        {
        //            public uint dwFileAttributes;
        //            public long ftCreationTime;
        //            public long ftLastAccessTime;
        //            public long ftLastWriteTime;
        //            public uint nFileSizeHigh;
        //            public uint nFileSizeLow;
        //            public uint dwReserved0;
        //            public uint dwReserved1;
        //            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        //            public string cFileName;
        //            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        //            public string cAlternateFileName;
        //        }

        //        [Flags()]
        //        private enum SLR_FLAGS
        //        {
        //            /// <summary>
        //            /// Do not display a dialog box if the link cannot be resolved. When SLR_NO_UI is set,
        //            /// the high-order word of fFlags can be set to a time-out value that specifies the
        //            /// maximum amount of time to be spent resolving the link. The function returns if the
        //            /// link cannot be resolved within the time-out duration. If the high-order word is set
        //            /// to zero, the time-out duration will be set to the default value of 3,000 milliseconds
        //            /// (3 seconds). To specify a value, set the high word of fFlags to the desired time-out
        //            /// duration, in milliseconds.
        //            /// </summary>
        //            SLR_NO_UI = 0x1,
        //            /// <summary>Obsolete and no longer used</summary>
        //            SLR_ANY_MATCH = 0x2,
        //            /// <summary>If the link object has changed, update its path and list of identifiers.
        //            /// If SLR_UPDATE is set, you do not need to call IPersistFile::IsDirty to determine
        //            /// whether or not the link object has changed.</summary>
        //            SLR_UPDATE = 0x4,
        //            /// <summary>Do not update the link information</summary>
        //            SLR_NOUPDATE = 0x8,
        //            /// <summary>Do not execute the search heuristics</summary>
        //            SLR_NOSEARCH = 0x10,
        //            /// <summary>Do not use distributed link tracking</summary>
        //            SLR_NOTRACK = 0x20,
        //            /// <summary>Disable distributed link tracking. By default, distributed link tracking tracks
        //            /// removable media across multiple devices based on the volume name. It also uses the
        //            /// Universal Naming Convention (UNC) path to track remote file systems whose drive letter
        //            /// has changed. Setting SLR_NOLINKINFO disables both types of tracking.</summary>
        //            SLR_NOLINKINFO = 0x40,
        //            /// <summary>Call the Microsoft Windows Installer</summary>
        //            SLR_INVOKE_MSI = 0x80
        //        }

        //        /// <summary>The IShellLink interface allows Shell links to be created, modified, and resolved</summary>
        //        [ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214F9-0000-0000-C000-000000000046")]
        //        private interface IShellLinkW
        //        {
        //            /// <summary>Retrieves the path and file name of a Shell link object</summary>
        //            void GetPath([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, out WIN32_FIND_DATAW pfd, SLGP_FLAGS fFlags);
        //            /// <summary>Retrieves the list of item identifiers for a Shell link object</summary>
        //            void GetIDList(out IntPtr ppidl);
        //            /// <summary>Sets the pointer to an item identifier list (PIDL) for a Shell link object.</summary>
        //            void SetIDList(IntPtr pidl);
        //            /// <summary>Retrieves the description string for a Shell link object</summary>
        //            void GetDescription([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);
        //            /// <summary>Sets the description for a Shell link object. The description can be any application-defined string</summary>
        //            void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
        //            /// <summary>Retrieves the name of the working directory for a Shell link object</summary>
        //            void GetWorkingDirectory([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);
        //            /// <summary>Sets the name of the working directory for a Shell link object</summary>
        //            void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
        //            /// <summary>Retrieves the command-line arguments associated with a Shell link object</summary>
        //            void GetArguments([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);
        //            /// <summary>Sets the command-line arguments for a Shell link object</summary>
        //            void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
        //            /// <summary>Retrieves the hot key for a Shell link object</summary>
        //            void GetHotkey(out short pwHotkey);
        //            /// <summary>Sets a hot key for a Shell link object</summary>
        //            void SetHotkey(short wHotkey);
        //            /// <summary>Retrieves the show command for a Shell link object</summary>
        //            void GetShowCmd(out int piShowCmd);
        //            /// <summary>Sets the show command for a Shell link object. The show command sets the initial show state of the window.</summary>
        //            void SetShowCmd(int iShowCmd);
        //            /// <summary>Retrieves the location (path and index) of the icon for a Shell link object</summary>
        //            void GetIconLocation([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath,
        //                int cchIconPath, out int piIcon);
        //            /// <summary>Sets the location (path and index) of the icon for a Shell link object</summary>
        //            void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
        //            /// <summary>Sets the relative path to the Shell link object</summary>
        //            void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
        //            /// <summary>Attempts to find the target of a Shell link, even if it has been moved or renamed</summary>
        //            void Resolve(IntPtr hwnd, SLR_FLAGS fFlags);
        //            /// <summary>Sets the path and file name of a Shell link object</summary>
        //            void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);

        //        }

        //        [ComImport, Guid("0000010c-0000-0000-c000-000000000046"),
        //        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        //        public interface IPersist
        //        {
        //            [PreserveSig]
        //            void GetClassID(out Guid pClassID);
        //        }

        //        [ComImport, Guid("0000010b-0000-0000-C000-000000000046"),
        //        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        //        public interface IPersistFile : IPersist
        //        {
        //            new void GetClassID(out Guid pClassID);

        //            [PreserveSig]
        //            int IsDirty();

        //            [PreserveSig]
        //            void Load([In, MarshalAs(UnmanagedType.LPWStr)]
        //                string pszFileName, uint dwMode);

        //            [PreserveSig]
        //            void Save([In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName,
        //                [In, MarshalAs(UnmanagedType.Bool)] bool fRemember);

        //            [PreserveSig]
        //            void SaveCompleted([In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName);

        //            [PreserveSig]
        //            void GetCurFile([In, MarshalAs(UnmanagedType.LPWStr)] string ppszFileName);
        //        }

        //        private const uint STGM_READ = 0;
        //        private const int MAX_PATH = 260;

        //        // CLSID_ShellLink from ShlGuid.h 
        //        [
        //            ComImport(),
        //            Guid("00021401-0000-0000-C000-000000000046")
        //        ]
        //        public class ShellLink
        //        {
        //        }

        //        public static string ResolveShortcut(string filename)
        //        {
        //            ShellLink link = new ShellLink();
        //#pragma warning disable CA2010 // Always consume the value returned by methods marked with PreserveSigAttribute
        //            ((IPersistFile)link).Load(filename, STGM_READ);
        //#pragma warning restore CA2010 // => Has no returned value => OK
        //            StringBuilder sb = new StringBuilder(MAX_PATH);
        //            WIN32_FIND_DATAW data = new WIN32_FIND_DATAW();
        //            ((IShellLinkW)link).GetPath(sb, sb.Capacity, out data, 0);
        //            string resolvedPath = sb.ToString();
        //            if (!IsDirectory(resolvedPath) &&
        //                !File.Exists(resolvedPath))
        //            {
        //                //For some lnk e.g. WinRar SkypeForBuisness
        //                //resolved path wrong to Program Files (x86)
        //#warning Using Shell32 with this method only allow in single thread application. You have to include [STAThread] in main entry point.
        //                resolvedPath = ReplaceFirst(resolvedPath,
        //                @"\Program Files (x86)\",
        //                @"\Program Files\");
        //                if (!File.Exists(resolvedPath))
        //                {
        //                    resolvedPath = string.Empty;

        //                    //Shell32.Folder folder = GetShell32NameSpaceFolder(filename as object);

        //                    //string name1 = string.Empty;
        //                    //string path1 = string.Empty;
        //                    //string description1 = string.Empty;
        //                    //string working_dir1 = string.Empty;
        //                    //string args1 = string.Empty;

        //                    ////string test2 = name1 + path1 + description1 + working_dir1 + args1 + test1;

        //                    //object[] args = new object[] { filename };
        //                    //if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
        //                    //{
        //                    //    //string test1 = 
        //                    //    GetShortcutInfo(filename);
        //                    //}
        //                    //else
        //                    //{
        //                    //    Thread staThread = new Thread(new ParameterizedThreadStart(GetShortcutInfo));
        //                    //    staThread.SetApartmentState(ApartmentState.STA);
        //                    //    staThread.Start(args);
        //                    //    staThread.Join();
        //                    //}
        //                }
        //            }
        //            return resolvedPath;
        //        }

        //        //public static Shell32.Folder GetShell32NameSpaceFolder(Object folder)
        //        //{
        //        //    Type shellAppType = Type.GetTypeFromProgID("Shell.Application");

        //        //    Object shell = Activator.CreateInstance(shellAppType);
        //        //    return (Shell32.Folder)shellAppType.InvokeMember("NameSpace",
        //        //  System.Reflection.BindingFlags.InvokeMethod, null, shell, new object[] { folder }, CultureInfo.InvariantCulture);
        //        //}

        //        //TESTING
        //        // Get information about this link.
        //        // Return an error message if there's a problem.
        //        //static void GetShortcutInfo(object parameters)
        //        //{
        //        //    object[] args = (object[])parameters;
        //        //    string full_name = (string)args[0];
        //        //    string name = "";
        //        //    string path = "";
        //        //    string descr = "";
        //        //    string working_dir = "";
        //        //    //string args = "";

        //        //    try
        //        //    {
        //        //        // Make a Shell object.
        //        //        Shell32.Shell shell = new Shell32.Shell();

        //        //        // Get the shortcut's folder and name.
        //        //        string shortcut_path =
        //        //            full_name.Substring(0, full_name.LastIndexOf("\\"));
        //        //        string shortcut_name =
        //        //            full_name.Substring(full_name.LastIndexOf("\\") + 1);
        //        //        if (!shortcut_name.EndsWith(".lnk"))
        //        //            shortcut_name += ".lnk";

        //        //        // Get the shortcut's folder.
        //        //        Shell32.Folder shortcut_folder =
        //        //            shell.NameSpace(shortcut_path);

        //        //        // Get the shortcut's file.
        //        //        Shell32.FolderItem folder_item =
        //        //            shortcut_folder.Items().Item(shortcut_name);

        //        //        if (folder_item == null)
        //        //        {
        //        //            //return "Cannot find shortcut file '" + full_name + "'";
        //        //        }
        //        //        if (!folder_item.IsLink)
        //        //        {
        //        //            //return "File '" + full_name + "' isn't a shortcut.";
        //        //        }

        //        //        // Display the shortcut's information.
        //        //        Shell32.ShellLinkObject lnk =
        //        //            (Shell32.ShellLinkObject)folder_item.GetLink;
        //        //        name = folder_item.Name;
        //        //        descr = lnk.Description;
        //        //        path = lnk.Path;
        //        //        working_dir = lnk.WorkingDirectory;
        //        //        //args = lnk.Arguments;
        //        //        //return "";
        //        //    }
        //        //    catch (Exception ex)
        //        //    {
        //        //        //return ex.Message;
        //        //    }
        //        //}

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

        //        public static string ReplaceFirst(string text, string search, string replace)
        //        {
        //            int pos = text.IndexOf(search, StringComparison.InvariantCulture);
        //            if (pos < 0)
        //            {
        //                return text;
        //            }
        //            return text.Substring(0, pos) + replace +
        //                text.Substring(pos + search.Length);
        //        }
    }
}