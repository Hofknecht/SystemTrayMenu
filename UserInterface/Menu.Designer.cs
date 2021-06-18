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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanelDgvAndScrollbar = new System.Windows.Forms.TableLayoutPanel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelSearch = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelMenu = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelTitle = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelDgvAndScrollbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.tableLayoutPanelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            this.tableLayoutPanelMenu.SuspendLayout();
            this.tableLayoutPanelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // Controls like the scrollbar are removed when open the designer
            // When adding after InitializeComponent(), then e.g. scrollbar on high dpi not more working
            InitializeComponentControlsTheDesignerRemoves();
            // 
            // tableLayoutPanelDgvAndScrollbar
            // 
            this.tableLayoutPanelDgvAndScrollbar.AutoScroll = true;
            this.tableLayoutPanelDgvAndScrollbar.AutoSize = true;
            this.tableLayoutPanelDgvAndScrollbar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelDgvAndScrollbar.ColumnCount = 2;
            this.tableLayoutPanelDgvAndScrollbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelDgvAndScrollbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelDgvAndScrollbar.Controls.Add(this.dgv, 0, 0);
            this.tableLayoutPanelDgvAndScrollbar.Location = new System.Drawing.Point(0, 14);
            this.tableLayoutPanelDgvAndScrollbar.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelDgvAndScrollbar.Name = "tableLayoutPanelDgvAndScrollbar";
            this.tableLayoutPanelDgvAndScrollbar.RowCount = 1;
            this.tableLayoutPanelDgvAndScrollbar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDgvAndScrollbar.Size = new System.Drawing.Size(55, 40);
            this.tableLayoutPanelDgvAndScrollbar.TabIndex = 3;
            this.tableLayoutPanelDgvAndScrollbar.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.DgvMouseWheel);
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
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Margin = new System.Windows.Forms.Padding(0);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.tableLayoutPanelSearch.Location = new System.Drawing.Point(0, 55);
            this.tableLayoutPanelSearch.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.tableLayoutPanelSearch.Name = "tableLayoutPanelSearch";
            this.tableLayoutPanelSearch.RowCount = 1;
            this.tableLayoutPanelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSearch.Size = new System.Drawing.Size(83, 22);
            this.tableLayoutPanelSearch.TabIndex = 5;
            this.tableLayoutPanelSearch.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.DgvMouseWheel);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.BackColor = System.Drawing.Color.White;
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxSearch.Location = new System.Drawing.Point(25, 4);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.textBoxSearch.MaxLength = 37;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(55, 15);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.TextBoxSearch_TextChanged);
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
            // tableLayoutPanelMenu
            // 
            this.tableLayoutPanelMenu.AutoSize = true;
            this.tableLayoutPanelMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMenu.ColumnCount = 1;
            this.tableLayoutPanelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMenu.Controls.Add(this.tableLayoutPanelTitle, 0, 0);
            this.tableLayoutPanelMenu.Controls.Add(this.tableLayoutPanelSearch, 0, 2);
            this.tableLayoutPanelMenu.Controls.Add(this.tableLayoutPanelDgvAndScrollbar, 0, 1);
            this.tableLayoutPanelMenu.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMenu.Name = "tableLayoutPanelMenu";
            this.tableLayoutPanelMenu.RowCount = 3;
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenu.Size = new System.Drawing.Size(83, 77);
            this.tableLayoutPanelMenu.TabIndex = 4;
            this.tableLayoutPanelMenu.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.DgvMouseWheel);
            // 
            // tableLayoutPanelTitle
            // 
            this.tableLayoutPanelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelTitle.AutoSize = true;
            this.tableLayoutPanelTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelTitle.ColumnCount = 3;
            this.tableLayoutPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTitle.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanelTitle.Controls.Add(this.pictureBox2, 2, 0);
            this.tableLayoutPanelTitle.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelTitle.Name = "tableLayoutPanelTitle";
            this.tableLayoutPanelTitle.RowCount = 1;
            this.tableLayoutPanelTitle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTitle.Size = new System.Drawing.Size(83, 14);
            this.tableLayoutPanelTitle.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(14, 14);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(69, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(14, 14);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(302, 347);
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
            this.tableLayoutPanelTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}