// <copyright file="DataGridViewExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System.Data;
    using System.Drawing;
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
            using Graphics graphics = dgv.CreateGraphics();
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            float widthMax = WidthMin;
            DataTable data = (DataTable)dgv.DataSource;
            foreach (DataRow row in data.Rows)
            {
                float checkWidth = graphics.MeasureString(
                    ((RowData)row[2]).Text + "___",
                    dgv.RowTemplate.DefaultCellStyle.Font).Width;
                if (checkWidth > widthMax)
                {
                    widthMax = checkWidth;
                }
            }

            int widthMaxInPixel = (int)(Scaling.Factor * Scaling.FactorByDpi *
                400f * (Properties.Settings.Default.WidthMaxInPercent / 100f));
            if (widthMax > widthMaxInPixel)
            {
                widthMax = widthMaxInPixel;
            }

            dgv.Columns[1].Width = (int)(widthMax + 0.5);
            double factorIconSizeInPercent = Properties.Settings.Default.IconSizeInPercent / 100f;

            // IcoWidth 100% = 21px, 175% is 33, +3+2 is padding from ColumnIcon
            float icoWidth = (16 * Scaling.FactorByDpi) + 5;
            dgv.Columns[0].Width = (int)((icoWidth * factorIconSizeInPercent * Scaling.Factor) + 0.5);
        }
    }
}
