namespace SystemTrayMenu.UserInterface
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            fading.Dispose();
            customScrollbar.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanelDgvAndScrollbar = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitle = new SystemTrayMenu.UserInterface.LabelNoCopy();
            this.ColumnText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelSearch = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelMenu = new System.Windows.Forms.TableLayoutPanel();
            this.customScrollbar = new UserInterface.CustomScrollbar();
            this.tableLayoutPanelDgvAndScrollbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.tableLayoutPanelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            this.tableLayoutPanelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelDgvAndScrollbar
            // 
            this.tableLayoutPanelDgvAndScrollbar.AutoScroll = true;
            this.tableLayoutPanelDgvAndScrollbar.AutoSize = true;
            this.tableLayoutPanelDgvAndScrollbar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelDgvAndScrollbar.ColumnCount = 2;
            this.tableLayoutPanelDgvAndScrollbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelDgvAndScrollbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelDgvAndScrollbar.Controls.Add(this.customScrollbar, 1, 0);
            this.tableLayoutPanelDgvAndScrollbar.Controls.Add(this.dgv, 0, 0);
            this.tableLayoutPanelDgvAndScrollbar.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelDgvAndScrollbar.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelDgvAndScrollbar.Name = "tableLayoutPanelDgvAndScrollbar";
            this.tableLayoutPanelDgvAndScrollbar.RowCount = 1;
            this.tableLayoutPanelDgvAndScrollbar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDgvAndScrollbar.Size = new System.Drawing.Size(70, 40);
            this.tableLayoutPanelDgvAndScrollbar.TabIndex = 3;
            this.tableLayoutPanelDgvAndScrollbar.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.DgvMouseWheel);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoEllipsis = true;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.BackColor = System.Drawing.Color.Azure;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Padding = new System.Windows.Forms.Padding(3, 0, 0, 1);
            this.labelTitle.Size = new System.Drawing.Size(70, 14);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "STM";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitle.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LabelTitle_MouseDoubleClick);
            this.labelTitle.MouseEnter += new System.EventHandler(this.LabelTitle_MouseEnter);
            this.labelTitle.MouseLeave += new System.EventHandler(this.LabelTitle_MouseLeave);
            this.labelTitle.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.DgvMouseWheel);
            // 
            // ColumnText
            // 
            this.ColumnText.DataPropertyName = "ColumnText";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ColumnText.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnText.Frozen = true;
            this.ColumnText.HeaderText = "ColumnText";
            this.ColumnText.MaxInputLength = 40;
            this.ColumnText.Name = "ColumnText";
            this.ColumnText.ReadOnly = true;
            this.ColumnText.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnText.Width = 25;
            // 
            // ColumnIcon
            // 
            this.ColumnIcon.DataPropertyName = "ColumnIcon";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "System.Drawing.Icon";
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3, 2, 6, 2);
            this.ColumnIcon.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnIcon.Frozen = true;
            this.ColumnIcon.HeaderText = "ColumnIcon";
            this.ColumnIcon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnIcon.Name = "ColumnIcon";
            this.ColumnIcon.ReadOnly = true;
            this.ColumnIcon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnIcon.Width = 25;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.ColumnHeadersVisible = false;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIcon,
            this.ColumnText});
            this.dgv.Location = new System.Drawing.Point(0, 14);
            this.dgv.Margin = new System.Windows.Forms.Padding(0);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowTemplate.Height = 20;
            this.dgv.RowTemplate.ReadOnly = true;
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.ShowCellErrors = false;
            this.dgv.ShowCellToolTips = false;
            this.dgv.ShowEditingIcon = false;
            this.dgv.ShowRowErrors = false;
            this.dgv.Size = new System.Drawing.Size(55, 40);
            this.dgv.TabIndex = 4;
            this.dgv.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.DgvMouseWheel);
            // 
            // tableLayoutPanelSearch
            // 
            this.tableLayoutPanelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelSearch.AutoSize = true;
            this.tableLayoutPanelSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSearch.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelSearch.ColumnCount = 2;
            this.tableLayoutPanelSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSearch.Controls.Add(this.textBoxSearch, 1, 0);
            this.tableLayoutPanelSearch.Controls.Add(this.pictureBoxSearch, 0, 0);
            this.tableLayoutPanelSearch.Location = new System.Drawing.Point(0, 146);
            this.tableLayoutPanelSearch.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.tableLayoutPanelSearch.Name = "tableLayoutPanelSearch";
            this.tableLayoutPanelSearch.RowCount = 1;
            this.tableLayoutPanelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSearch.Size = new System.Drawing.Size(70, 22);
            this.tableLayoutPanelSearch.TabIndex = 5;
            this.tableLayoutPanelSearch.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.DgvMouseWheel);
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.BackColor = System.Drawing.Color.White;
            this.pictureBoxSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxSearch.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxSearch.TabIndex = 1;
            this.pictureBoxSearch.TabStop = false;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.BackColor = System.Drawing.Color.White;
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBoxSearch.Location = new System.Drawing.Point(25, 4);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.textBoxSearch.MaxLength = 37;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(55, 15);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.TextBoxSearch_TextChanged);
            this.textBoxSearch.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            // 
            // tableLayoutPanelMenu
            // 
            this.tableLayoutPanelMenu.AutoSize = true;
            this.tableLayoutPanelMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMenu.ColumnCount = 1;
            this.tableLayoutPanelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMenu.Controls.Add(this.labelTitle, 0, 0);
            this.tableLayoutPanelMenu.Controls.Add(this.tableLayoutPanelSearch, 0, 2);
            this.tableLayoutPanelMenu.Controls.Add(this.tableLayoutPanelDgvAndScrollbar, 0, 1);
            this.tableLayoutPanelMenu.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMenu.Name = "tableLayoutPanelMenu";
            this.tableLayoutPanelMenu.RowCount = 3;
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenu.Size = new System.Drawing.Size(70, 76);
            this.tableLayoutPanelMenu.TabIndex = 4;
            this.tableLayoutPanelMenu.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.DgvMouseWheel);
            // 
            // customScrollbar
            // 
            this.customScrollbar.Location = new System.Drawing.Point(0, 0);
            this.customScrollbar.Name = "customScrollbar";
            this.customScrollbar.Size = new System.Drawing.Size(15, 40);
            this.customScrollbar.TabIndex = 5;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(331, 360);
            this.Controls.Add(this.tableLayoutPanelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.Opacity = 0.01D;
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SystemTrayMenu";
            this.TopMost = true;
            this.tableLayoutPanelDgvAndScrollbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.tableLayoutPanelSearch.ResumeLayout(false);
            this.tableLayoutPanelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
            this.tableLayoutPanelMenu.ResumeLayout(false);
            this.tableLayoutPanelMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SystemTrayMenu.UserInterface.LabelNoCopy labelTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDgvAndScrollbar;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewImageColumn ColumnIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.PictureBox pictureBoxSearch;
        private UserInterface.CustomScrollbar customScrollbar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMenu;
    }
}