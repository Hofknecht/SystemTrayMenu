// <copyright file="MenuData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DataClasses
{
    using System.Collections.Generic;

    internal enum MenuDataDirectoryState
    {
        /// <summary>
        /// State not defined or data still loading
        /// </summary>
        Undefined,

        /// <summary>
        /// Data is available
        /// </summary>
        Valid,

        /// <summary>
        /// Loading finished but no data available
        /// </summary>
        Empty,

        /// <summary>
        /// Loading failed, so no data available
        /// </summary>
        NoAccess,
    }

    internal struct MenuData
    {
        public MenuData(int level)
        {
            RowDatas = new List<RowData>();
            DirectoryState = MenuDataDirectoryState.Undefined;
            Level = level;
            RowDataParent = null;
            IsNetworkRoot = false;
        }

        internal List<RowData> RowDatas { get; set; }

        internal MenuDataDirectoryState DirectoryState { get; set; }

        internal int Level { get; }

        internal RowData RowDataParent { get; set; }

        internal bool IsNetworkRoot { get; set; }
    }
}