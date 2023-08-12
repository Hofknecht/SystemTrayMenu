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
        public bool IsLoadingMenu { get; internal set; }

        private void InitializeComponentControlsTheDesignerRemoves()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new();
            DataGridViewCellStyle dataGridViewCellStyle2 = new();
            DataGridViewCellStyle dataGridViewCellStyle3 = new();

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
            labelTitle.Font = new Font("Segoe UI", 8.25F * Scaling.Factor, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(0, 0);
            labelTitle.Margin = new Padding(0);
            labelTitle.Name = "labelTitle";
            labelTitle.Padding = new Padding(3, 0, 0, 1);
            labelTitle.Size = new Size(70, 14);
            labelTitle.Text = "SystemTrayMenu";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelTitle.MouseWheel += new MouseEventHandler(DgvMouseWheel);
            labelTitle.MouseDown += Menu_MouseDown;
            labelTitle.MouseUp += Menu_MouseUp;
            labelTitle.MouseMove += Menu_MouseMove;

            // tableLayoutPanelMenu
            tableLayoutPanelMenu.MouseDown += Menu_MouseDown;
            tableLayoutPanelMenu.MouseUp += Menu_MouseUp;
            tableLayoutPanelMenu.MouseMove += Menu_MouseMove;

            // tableLayoutPanelBottom
            tableLayoutPanelBottom.MouseDown += Menu_MouseDown;
            tableLayoutPanelBottom.MouseUp += Menu_MouseUp;
            tableLayoutPanelBottom.MouseMove += Menu_MouseMove;

            // ColumnIcon
            ColumnIcon.DataPropertyName = "ColumnIcon";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "System.Drawing.Icon";
            dataGridViewCellStyle1.Padding = new Padding(3, 1, 2, 1);
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

            dataGridViewCellStyle3.Font = new Font("Segoe UI", 7F * Scaling.Factor, FontStyle.Regular, GraphicsUnit.Pixel, 0);
            dgv.RowsDefaultCellStyle = dataGridViewCellStyle3;

            dgv.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 9F * Scaling.Factor, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgv.RowTemplate.Height = 20;
            dgv.RowTemplate.ReadOnly = true;

            textBoxSearch.ContextMenuStrip = new()
            {
                BackColor = SystemColors.Control,
            };

            textBoxSearch.ContextMenuStrip.Items.Add(Translator.GetText("To cut out"), null, TextBoxSearchCut);
            textBoxSearch.ContextMenuStrip.Items.Add(Translator.GetText("Copy"), null, TextBoxSearchCopy);
            textBoxSearch.ContextMenuStrip.Items.Add(Translator.GetText("To paste"), null, TextBoxSearchPaste);
            textBoxSearch.ContextMenuStrip.Items.Add(Translator.GetText("Undo"), null, TextBoxSearchUndo);
            textBoxSearch.ContextMenuStrip.Items.Add(Translator.GetText("Selecting All"), null, TextBoxSearchSelectAll);

            tableLayoutPanelMenu.Controls.Add(labelTitle, 0, 0);

            // customScrollbar
            customScrollbar.Location = new Point(0, 0);
            customScrollbar.Name = "customScrollbar";
            customScrollbar.Size = new Size(Scaling.Scale(15), 40);

            pictureBoxOpenFolder.Size = new Size(
                Scaling.Scale(pictureBoxOpenFolder.Width),
                Scaling.Scale(pictureBoxOpenFolder.Height));

            pictureBoxMenuAlwaysOpen.Size = new Size(
                Scaling.Scale(pictureBoxMenuAlwaysOpen.Width),
                Scaling.Scale(pictureBoxMenuAlwaysOpen.Height));

            pictureBoxSettings.Size = new Size(
                Scaling.Scale(pictureBoxSettings.Width),
                Scaling.Scale(pictureBoxSettings.Height));

            pictureBoxRestart.Size = new Size(
                Scaling.Scale(pictureBoxRestart.Width),
                Scaling.Scale(pictureBoxRestart.Height));

            pictureBoxSearch.Size = new Size(
                Scaling.Scale(pictureBoxSearch.Width),
                Scaling.Scale(pictureBoxSearch.Height));

            labelItems.Font = new Font("Segoe UI", 7F * Scaling.Factor, FontStyle.Bold, GraphicsUnit.Point, 0);

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

        private void TextBoxSearchUndo(object sender, EventArgs e)
        {
            textBoxSearch.Undo();
            textBoxSearch.ClearUndo();
        }

        private void TextBoxSearchSelectAll(object sender, EventArgs e)
        {
            textBoxSearch.SelectAll();
        }

        private void TextBoxSearchCopy(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, textBoxSearch.SelectedText);
        }

        private void TextBoxSearchPaste(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                textBoxSearch.SelectedText
                    = Clipboard.GetData(DataFormats.Text).ToString();
            }
        }

        private void TextBoxSearchCut(object sender, EventArgs e)
        {
            textBoxSearch.Cut();
        }
    }
}