// <copyright file="MenuData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DataClasses
{
    using System.Collections.Generic;

    internal enum MenuDataValidity
    {
        Undefined,
        Valid,
        Empty,
        NoAccess,
    }

    internal struct MenuData
    {
        public MenuData(int level)
        {
            RowDatas = new List<RowData>();
            Validity = MenuDataValidity.Undefined;
            Level = level;
            RowDataParent = null;
            IsNetworkRoot = false;
        }

        internal List<RowData> RowDatas { get; set; }

        internal MenuDataValidity Validity { get; set; }

        internal int Level { get; }

        internal RowData RowDataParent { get; set; }

        internal bool IsNetworkRoot { get; set; }
    }
}