using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SystemTrayMenu.Utilities
{
    internal static class DataGridViewExtensions
    {
        internal static void FastAutoSizeColumns(this DataGridView dgv)
        {
            System.Collections.Generic.IEnumerable<DataGridViewRow> rows = dgv.Rows
               .Cast<DataGridViewRow>();
            using (System.Drawing.Graphics gfx = dgv.CreateGraphics())
            {
                int i = 1;
                gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                float widthMax = dgv.Columns[i].HeaderCell.Size.Width;
                foreach (DataGridViewRow row in rows)
                {
                    float checkWidth = gfx.MeasureString(
                        row.Cells[i].Value.ToString() + "_",
                        dgv.RowTemplate.DefaultCellStyle.Font).Width;
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
