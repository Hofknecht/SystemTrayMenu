using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SystemTrayMenu.Utilities
{
    internal static class DataGridViewExtensions
    {
        /// <summary>
        /// dgv.AutoResizeColumns() was too slow ~45ms
        /// </summary>
        /// <param name="dgv"></param>
        internal static void FastAutoSizeColumns(this DataGridView dgv)
        {
            System.Collections.Generic.IEnumerable<DataGridViewRow> rows = 
                dgv.Rows.Cast<DataGridViewRow>();
            using (Graphics gfx = dgv.CreateGraphics())
            {
                int i = 1;
                gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                float widthMax = dgv.Columns[i].HeaderCell.Size.Width;
                foreach (DataGridViewRow row in rows)
                {
                    float checkWidth = gfx.MeasureString(
                        row.Cells[i].Value.ToString() + "_",
                        dgv.RowTemplate.DefaultCellStyle.Font
                        ).Width * Scaling.Factor;
                    if (checkWidth > widthMax)
                    {
                        widthMax = checkWidth;
                    }
                }
                dgv.Columns[i].Width = (int)(widthMax + 0.5);
            }
        }
    }
}
