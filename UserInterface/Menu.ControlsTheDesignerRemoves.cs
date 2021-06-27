// <copyright file="Menu.ControlsTheDesignerRemoves.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using SystemTrayMenu.Utilities;

    internal partial class Menu
    {
        private void InitializeComponentControlsTheDesignerRemoves()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();

            labelTitle = new LabelNoCopy();
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnIcon = new DataGridViewImageColumn();

            customScrollbar = new CustomScrollbar();

            tableLayoutPanelDgvAndScrollbar.Controls.Add(customScrollbar, 1, 0);

            // tableLayoutPanelDgvAndScrollbar.SuspendLayout();
            // ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            // tableLayoutPanelSearch.SuspendLayout();
            // ((System.ComponentModel.ISupportInitialize)pictureBoxSearch).BeginInit();
            // tableLayoutPanelMenu.SuspendLayout();
            // SuspendLayout();

            // labelTitle
            labelTitle.AutoEllipsis = true;
            labelTitle.AutoSize = true;
            labelTitle.Dock = DockStyle.Fill;
            labelTitle.Font = new Font("Segoe UI", 8.25F * Scaling.Factor, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(0, 0);
            labelTitle.Margin = new Padding(0);
            labelTitle.Name = "labelTitle";
            labelTitle.Padding = new Padding(3, 0, 0, 1);
            labelTitle.Size = new Size(70, 14);
            labelTitle.Text = "STM";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelTitle.MouseWheel += new MouseEventHandler(DgvMouseWheel);

            // ColumnIcon
            ColumnIcon.DataPropertyName = "ColumnIcon";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "System.Drawing.Icon";
            dataGridViewCellStyle1.Padding = new Padding(3, 2, 6, 2);
            ColumnIcon.DefaultCellStyle = dataGridViewCellStyle1;
            ColumnIcon.Frozen = true;
            ColumnIcon.HeaderText = "ColumnIcon";
            ColumnIcon.ImageLayout = DataGridViewImageCellLayout.Zoom;
            ColumnIcon.Name = "ColumnIcon";
            ColumnIcon.ReadOnly = true;
            ColumnIcon.Resizable = DataGridViewTriState.False;
            ColumnIcon.Width = 25;

            // ColumnText
            ColumnText.DataPropertyName = "ColumnText";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Padding = new Padding(0, 0, 3, 0);
            ColumnText.DefaultCellStyle = dataGridViewCellStyle2;
            ColumnText.Frozen = true;
            ColumnText.HeaderText = "ColumnText";
            ColumnText.MaxInputLength = 40;
            ColumnText.Name = "ColumnText";
            ColumnText.ReadOnly = true;
            ColumnText.Resizable = DataGridViewTriState.False;
            ColumnText.SortMode = DataGridViewColumnSortMode.Programmatic;
            ColumnText.Width = 25;

            dgv.Columns.AddRange(new DataGridViewColumn[]
            {
                ColumnIcon,
                ColumnText,
            });

            dataGridViewCellStyle3.Font = new Font("Segoe UI", 7F * Scaling.Factor, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            dgv.RowsDefaultCellStyle = dataGridViewCellStyle3;

            dgv.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 9F * Scaling.Factor, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            dgv.RowTemplate.Height = 20;
            dgv.RowTemplate.ReadOnly = true;

            textBoxSearch.ContextMenuStrip = new ContextMenuStrip();

            tableLayoutPanelTitle.Controls.Add(labelTitle, 1, 0);

            // customScrollbar
            customScrollbar.Location = new Point(0, 0);
            customScrollbar.Name = "customScrollbar";
            customScrollbar.Size = new Size(Scaling.Scale(15), 40);

            pictureBoxMenuAlwaysOpen.Size = new Size(
                Scaling.Scale(pictureBoxMenuAlwaysOpen.Width),
                Scaling.Scale(pictureBoxMenuAlwaysOpen.Height));

            pictureBoxOpenFolder.Size = new Size(
                Scaling.Scale(pictureBoxOpenFolder.Width),
                Scaling.Scale(pictureBoxOpenFolder.Height));

            pictureBoxSearch.Size = new Size(
                Scaling.Scale(pictureBoxSearch.Width),
                Scaling.Scale(pictureBoxSearch.Height));

            // tableLayoutPanelDgvAndScrollbar.ResumeLayout(false);
            // ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            // tableLayoutPanelSearch.ResumeLayout(false);
            // tableLayoutPanelSearch.PerformLayout();
            // ((System.ComponentModel.ISupportInitialize)pictureBoxSearch).EndInit();
            // tableLayoutPanelMenu.ResumeLayout(false);
            // tableLayoutPanelMenu.PerformLayout();
            // customScrollbar.PerformLayout();
            // ResumeLayout(false);
            // PerformLayout();
        }
    }
}