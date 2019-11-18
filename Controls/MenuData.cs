using System.Collections.Generic;

namespace SystemTrayMenu.Controls
{
    public enum MenuDataValidity
    {
        Valid,
        Invalid,
        NoAccess
    }

    public struct MenuData
    {
        public List<RowData> RowDatas;
        public MenuDataValidity Validity;
        public int Level;
    };
}