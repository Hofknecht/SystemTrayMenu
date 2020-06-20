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
                if (widthMax > MenuDefines.MaxMenuWidth)
                {
                    widthMax = MenuDefines.MaxMenuWidth;
                }
                dgv.Columns[i].Width = (int)(widthMax + 0.5);

                string stringWithWidthLikeIcon = "____";
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                float Width0 = gfx.MeasureString(stringWithWidthLikeIcon,
#pragma warning restore CA1303 // Do not pass literals as localized parameters
                       dgv.RowTemplate.DefaultCellStyle.Font
                       ).Width * Scaling.Factor;
                dgv.Columns[0].Width = (int)Width0;
            }
        }
    }
}
