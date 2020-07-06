// <copyright file="MenuData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.DataClasses
{
    using System.Collections.Generic;

    internal enum MenuDataValidity
    {
        AbortedOrUnknown,
        Valid,
        Empty,
        NoAccess,
    }

    internal struct MenuData
    {
        internal List<RowData> RowDatas;
        internal MenuDataValidity Validity;
        internal int Level;
        internal RowData RowDataParent;
    }
}