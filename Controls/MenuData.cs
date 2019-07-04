using Clearcove.Logging;
using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using SystemTrayMenu.Helper;
using TAFactory.IconPack;

namespace SystemTrayMenu.Controls
{
    public struct MenuData
    {
        public List<RowData> RowDatas;
        public bool Valid;
        public int Level;
    };
}