// <copyright file="DataGridViewExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    internal static class DataGridViewExtensions
    {
        /// <summary>
        /// dgv.AutoResizeColumns() was too slow ~45ms.
        /// </summary>
        /// <param name="dgv">datagridview.</param>
        internal static void FastAutoSizeColumns(this DataGridView dgv)
        {
            System.Collections.Generic.IEnumerable<DataGridViewRow> rows =
                dgv.Rows.Cast<DataGridViewRow>();
            using Graphics gfx = dgv.CreateGraphics();
            int i = 1;
            gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            float widthMax = dgv.Columns[i].HeaderCell.Size.Width;
            foreach (DataGridViewRow row in rows)
            {
                float checkWidth = gfx.MeasureString(
                    row.Cells[i].Value.ToString() + "___",
                    dgv.RowTemplate.DefaultCellStyle.Font)
                    .Width;
                if (checkWidth > widthMax)
                {
                    widthMax = checkWidth;
                }
            }

            if (widthMax > Properties.Settings.Default.MaximumMenuWidth)
            {
                widthMax = Properties.Settings.Default.MaximumMenuWidth;
            }

            dgv.Columns[i].Width = (int)(widthMax + 0.5);

#pragma warning disable CA1303 // Do not pass literals as localized parameters
            string stringWithWidthLikeIcon = "____";
            float width0 = gfx.MeasureString(
                stringWithWidthLikeIcon,
#pragma warning restore CA1303 // Do not pass literals as localized parameters
                dgv.RowTemplate.DefaultCellStyle.Font).Width;

            double factorIconSizeInPercent = Properties.Settings.Default.IconSizeInPercent / 100f;
            dgv.Columns[0].Width = (int)(width0 * factorIconSizeInPercent);
        }
    }
}
