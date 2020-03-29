using System.Collections.Generic;

namespace SystemTrayMenu.DataClasses
{
    internal enum MenuDataValidity
    {
        Valid,
        Invalid,
        NoAccess
    }

    internal struct MenuData
    {
        public List<RowData> RowDatas;
        public MenuDataValidity Validity;
        public int Level;
    };
}