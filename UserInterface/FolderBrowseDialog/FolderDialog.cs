// <copyright file="FolderDialog.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface.FolderBrowseDialog
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.Versioning;
    using System.Windows;
    using System.Windows.Interop;
    using SystemTrayMenu.DllImports;
    using SystemTrayMenu.Utilities;

    public class FolderDialog : IFolderDialog, IDisposable
    {
        private bool isDisposed;

        ~FolderDialog() // the finalizer
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets or sets /sets folder in which dialog will be open.
        /// </summary>
        public string? InitialFolder { get; set; }

        /// <summary>
        /// Gets or sets /sets directory in which dialog will be open
        /// if there is no recent directory available.
        /// </summary>
        public string? DefaultFolder { get; set; }

        /// <summary>
        /// Gets or sets selected folder.
        /// </summary>
        public string? Folder { get; set; }

        /// <summary>
        /// Shows the file dialog and requests user interaction.
        /// </summary>
        /// <param name="owner">The window the dialog is assigned to.</param>
        /// <returns>True is returned on successful user interaction and when not cancelled by the user otherwise false is returned.</returns>
        [SupportedOSPlatform("windows")]
        public bool ShowDialog(Window? owner)
        {
            NativeMethods.IFileDialog frm = (NativeMethods.IFileDialog)new NativeMethods.FileOpenDialogRCW();
            frm.GetOptions(out uint options);
            options |= NativeMethods.FOS_PICKFOLDERS |
                       NativeMethods.FOS_FORCEFILESYSTEM |
                       NativeMethods.FOS_NOVALIDATE |
                       NativeMethods.FOS_NOTESTFILECREATE |
                       NativeMethods.FOS_DONTADDTORECENT;
            frm.SetOptions(options);
            if (InitialFolder != null)
            {
                Guid riid = new("43826D1E-E718-42EE-BC55-A1E261C37BFE"); // IShellItem
                if (NativeMethods.SHCreateItemFromParsingName(
                    InitialFolder,
                    IntPtr.Zero,
                    ref riid,
                    out NativeMethods.IShellItem directoryShellItem) == NativeMethods.S_OK)
                {
                    frm.SetFolder(directoryShellItem);
                }
            }

            if (DefaultFolder != null)
            {
                Guid riid = new("43826D1E-E718-42EE-BC55-A1E261C37BFE"); // IShellItem
                if (NativeMethods.SHCreateItemFromParsingName(
                    DefaultFolder,
                    IntPtr.Zero,
                    ref riid,
                    out NativeMethods.IShellItem directoryShellItem) == NativeMethods.S_OK)
                {
                    frm.SetDefaultFolder(directoryShellItem);
                }
            }

            if (frm.Show(owner == null ? IntPtr.Zero : new WindowInteropHelper(owner).Handle) == NativeMethods.S_OK)
            {
                try
                {
                    if (frm.GetResult(out NativeMethods.IShellItem shellItem) == NativeMethods.S_OK)
                    {
                        if (shellItem.GetDisplayName(
                            NativeMethods.SIGDN_FILESYSPATH,
                            out IntPtr pszString) == NativeMethods.S_OK)
                        {
                            if (pszString != IntPtr.Zero)
                            {
                                try
                                {
                                    Folder = Marshal.PtrToStringAuto(pszString);
                                    return true;
                                }
                                finally
                                {
                                    Marshal.FreeCoTaskMem(pszString);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Warn("Folder Dialog failed", ex);
                }
            }

            return false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
            }

            isDisposed = true;
        }
    }
}
