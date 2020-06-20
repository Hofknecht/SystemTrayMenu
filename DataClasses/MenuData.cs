using System.Collections.Generic;

namespace SystemTrayMenu.DataClasses
{
    internal enum MenuDataValidity
    {
        AbortedOrUnknown,
        Valid,
        Empty,
        NoAccess
    }

    internal struct MenuData
    {
        internal List<RowData> RowDatas;
        internal MenuDataValidity Validity;
        internal int Level;
        internal RowData RowDataParent;
    };
}