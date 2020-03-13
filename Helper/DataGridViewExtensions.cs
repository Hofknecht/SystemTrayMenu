using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SystemTrayMenu.Helper
{
    public static class DataGridViewExtensions
    {
        public static void FastAutoSizeColumns(this DataGridView dgv)
        {
            var rows = dgv.Rows
               .Cast<DataGridViewRow>();
            using (var gfx = dgv.CreateGraphics())
            {
                int i = 1;
                gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                float widthMax = dgv.Columns[i].HeaderCell.Size.Width;
                foreach (DataGridViewRow row in rows)
                {
                    var checkWidth = gfx.MeasureString(
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
