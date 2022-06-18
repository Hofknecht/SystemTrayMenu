// <copyright file="DataGridViewExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using SystemTrayMenu.DataClasses;

    internal static class DataGridViewExtensions
    {
        private const float WidthMin = 100f;

        /// <summary>
        /// dgv.AutoResizeColumns() was too slow ~45ms.
        /// </summary>
        /// <param name="dgv">datagridview.</param>
        internal static void FastAutoSizeColumns(this DataGridView dgv)
        {
            System.Collections.Generic.IEnumerable<DataGridViewRow> rows =
                dgv.Rows.Cast<DataGridViewRow>();
            using Graphics gfx = dgv.CreateGraphics();
            gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            float widthMax = WidthMin;
            DataTable data = (DataTable)dgv.DataSource;
            foreach (DataRow row in data.Rows)
            {
                float checkWidth = gfx.MeasureString(
                    ((RowData)row[2]).Text + "___",
                    dgv.RowTemplate.DefaultCellStyle.Font).Width;
                if (checkWidth > widthMax)
                {
                    widthMax = checkWidth;
                }
            }

            if (widthMax > Properties.Settings.Default.MaximumMenuWidth)
            {
                widthMax = Properties.Settings.Default.MaximumMenuWidth;
            }

            dgv.Columns[1].Width = (int)(widthMax + 0.5);
            string stringWithWidthLikeIcon = "____";
            float width0 = gfx.MeasureString(
                stringWithWidthLikeIcon,
                dgv.RowTemplate.DefaultCellStyle.Font).Width;

            double factorIconSizeInPercent = Properties.Settings.Default.IconSizeInPercent / 100f;
            dgv.Columns[0].Width = (int)(width0 * factorIconSizeInPercent);
        }
    }
}
