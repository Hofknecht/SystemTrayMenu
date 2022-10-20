using System.Windows.Forms;
using SystemTrayMenu.Helper;

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

            timerUpdateIcons.Stop();
            timerUpdateIcons.Tick -= TimerUpdateIcons_Tick;
            timerUpdateIcons.Tick += TimerUpdateIcons_Tick_Loading;
            timerUpdateIcons.Dispose();
            fading.ChangeOpacity -= Fading_ChangeOpacity;
            fading.Show -= Fading_Show;
            fading.Hide -= Hide;
            fading.Dispose();
            dgv.GotFocus -= Dgv_GotFocus;
            dgv.MouseEnter -= ControlsMouseEnter;
            dgv.MouseLeave -= ControlsMouseLeave;
            customScrollbar.GotFocus -= CustomScrollbar_GotFocus;
            customScrollbar.Scroll -= CustomScrollbar_Scroll;
            customScrollbar.MouseEnter -= ControlsMouseEnter;
            customScrollbar.MouseLeave -= ControlsMouseLeave;
            customScrollbar.Dispose();
            labelTitle.MouseEnter -= ControlsMouseEnter;
            labelTitle.MouseLeave -= ControlsMouseLeave;
            textBoxSearch.MouseEnter -= ControlsMouseEnter;
            textBoxSearch.MouseLeave -= ControlsMouseLeave;
            pictureBoxOpenFolder.MouseEnter -= ControlsMouseEnter;
            pictureBoxOpenFolder.MouseLeave -= ControlsMouseLeave;
            pictureBoxMenuAlwaysOpen.MouseEnter -= ControlsMouseEnter;
            pictureBoxMenuAlwaysOpen.MouseLeave -= ControlsMouseLeave;
            pictureBoxMenuAlwaysOpen.Paint -= PictureBoxMenuAlwaysOpen_Paint;
            pictureBoxMenuAlwaysOpen.Paint -= LoadingMenu_Paint;
            pictureBoxSettings.MouseEnter -= ControlsMouseEnter;
            pictureBoxSettings.MouseLeave -= ControlsMouseLeave;
            pictureBoxRestart.MouseEnter -= ControlsMouseEnter;
            pictureBoxRestart.MouseLeave -= ControlsMouseLeave;
            pictureBoxSearch.MouseEnter -= ControlsMouseEnter;
            pictureBoxSearch.MouseLeave -= ControlsMouseLeave;
            tableLayoutPanelMenu.MouseEnter -= ControlsMouseEnter;
            tableLayoutPanelMenu.MouseLeave -= ControlsMouseLeave;
            tableLayoutPanelDgvAndScrollbar.MouseEnter -= ControlsMouseEnter;
            tableLayoutPanelDgvAndScrollbar.MouseLeave -= ControlsMouseLeave;
            tableLayoutPanelBottom.MouseEnter -= ControlsMouseEnter;
            tableLayoutPanelBottom.MouseLeave -= ControlsMouseLeave;
            labelItems.MouseEnter -= ControlsMouseEnter;
            labelItems.MouseLeave -= ControlsMouseLeave;
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
            this.tableLayoutPanelDgvAndScrollbar = new System.Windows.Forms.TableLayoutPanel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelSearch = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.labelItems = new System.Windows.Forms.Label();
            this.tableLayoutPanelMenu = new System.Windows.Forms.TableLayoutPanel();
            this.panelLine = new System.Windows.Forms.Panel();
            this.tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxRestart = new System.Windows.Forms.PictureBox();
            this.pictureBoxSettings = new System.Windows.Forms.PictureBox();
            this.pictureBoxMenuAlwaysOpen = new System.Windows.Forms.PictureBox();
            this.pictureBoxOpenFolder = new System.Windows.Forms.PictureBox();
            this.timerUpdateIcons = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanelDgvAndScrollbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.tableLayoutPanelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            this.tableLayoutPanelMenu.SuspendLayout();
            this.tableLayoutPanelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRestart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenuAlwaysOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolder)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelDgvAndScrollbar
            // 
            this.tableLayoutPanelDgvAndScrollbar.AutoSize = true;
            this.tableLayoutPanelDgvAndScrollbar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelDgvAndScrollbar.ColumnCount = 2;
            this.tableLayoutPanelDgvAndScrollbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelDgvAndScrollbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelDgvAndScrollbar.Controls.Add(this.dgv, 0, 0);
            this.tableLayoutPanelDgvAndScrollbar.Location = new System.Drawing.Point(3, 25);
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
            this.tableLayoutPanelSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanelSearch.AutoSize = true;
            this.tableLayoutPanelSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSearch.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelSearch.ColumnCount = 2;
            this.tableLayoutPanelSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSearch.Controls.Add(this.textBoxSearch, 1, 0);
            this.tableLayoutPanelSearch.Controls.Add(this.pictureBoxSearch, 0, 0);
            this.tableLayoutPanelSearch.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanelSearch.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelSearch.Name = "tableLayoutPanelSearch";
            this.tableLayoutPanelSearch.RowCount = 1;
            this.tableLayoutPanelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSearch.Size = new System.Drawing.Size(128, 22);
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
            this.textBoxSearch.Size = new System.Drawing.Size(100, 15);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.TextBoxSearch_TextChanged);
            this.textBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxSearch_KeyPress);
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.BackColor = System.Drawing.Color.White;
            this.pictureBoxSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxSearch.Location = new System.Drawing.Point(1, 1);
            this.pictureBoxSearch.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxSearch.TabIndex = 1;
            this.pictureBoxSearch.TabStop = false;
            this.pictureBoxSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxSearch_Paint);
            this.pictureBoxSearch.Resize += new System.EventHandler(this.PictureBox_Resize);
            // 
            // labelItems
            // 
            this.labelItems.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelItems.AutoSize = true;
            this.labelItems.ForeColor = System.Drawing.Color.White;
            this.labelItems.Location = new System.Drawing.Point(10, 3);
            this.labelItems.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.labelItems.Name = "labelItems";
            this.labelItems.Size = new System.Drawing.Size(45, 15);
            this.labelItems.TabIndex = 2;
            this.labelItems.Text = "0 items";
            // 
            // tableLayoutPanelMenu
            // 
            this.tableLayoutPanelMenu.AutoSize = true;
            this.tableLayoutPanelMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMenu.ColumnCount = 1;
            this.tableLayoutPanelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMenu.Controls.Add(this.tableLayoutPanelSearch, 0, 1);
            this.tableLayoutPanelMenu.Controls.Add(this.panelLine, 0, 2);
            this.tableLayoutPanelMenu.Controls.Add(this.tableLayoutPanelBottom, 0, 6);
            this.tableLayoutPanelMenu.Controls.Add(this.tableLayoutPanelDgvAndScrollbar, 0, 4);
            this.tableLayoutPanelMenu.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMenu.Name = "tableLayoutPanelMenu";
            this.tableLayoutPanelMenu.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.tableLayoutPanelMenu.RowCount = 7;
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenu.Size = new System.Drawing.Size(159, 89);
            this.tableLayoutPanelMenu.TabIndex = 4;
            this.tableLayoutPanelMenu.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.DgvMouseWheel);
            // 
            // panelLine
            // 
            this.panelLine.AutoSize = true;
            this.panelLine.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelLine.BackColor = System.Drawing.Color.Silver;
            this.panelLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLine.Location = new System.Drawing.Point(3, 22);
            this.panelLine.Margin = new System.Windows.Forms.Padding(0);
            this.panelLine.Name = "panelLine";
            this.panelLine.Size = new System.Drawing.Size(153, 1);
            this.panelLine.TabIndex = 6;
            // 
            // tableLayoutPanelBottom
            // 
            this.tableLayoutPanelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelBottom.AutoSize = true;
            this.tableLayoutPanelBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelBottom.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelBottom.ColumnCount = 8;
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelBottom.Controls.Add(this.pictureBoxRestart, 6, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.pictureBoxSettings, 5, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.pictureBoxMenuAlwaysOpen, 4, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.pictureBoxOpenFolder, 3, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.labelItems, 1, 0);
            this.tableLayoutPanelBottom.Location = new System.Drawing.Point(3, 67);
            this.tableLayoutPanelBottom.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            this.tableLayoutPanelBottom.RowCount = 1;
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBottom.Size = new System.Drawing.Size(153, 22);
            this.tableLayoutPanelBottom.TabIndex = 5;
            // 
            // pictureBoxRestart
            // 
            this.pictureBoxRestart.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxRestart.Location = new System.Drawing.Point(122, 1);
            this.pictureBoxRestart.Margin = new System.Windows.Forms.Padding(1, 5, 1, 1);
            this.pictureBoxRestart.Name = "pictureBoxRestart";
            this.pictureBoxRestart.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxRestart.TabIndex = 3;
            this.pictureBoxRestart.TabStop = false;
            this.pictureBoxRestart.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxRestart_Paint);
            this.pictureBoxRestart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxRestart_MouseClick);
            this.pictureBoxRestart.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxRestart.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            this.pictureBoxRestart.Resize += new System.EventHandler(this.PictureBox_Resize);
            // 
            // pictureBoxSettings
            // 
            this.pictureBoxSettings.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxSettings.Location = new System.Drawing.Point(100, 1);
            this.pictureBoxSettings.Margin = new System.Windows.Forms.Padding(1, 5, 1, 1);
            this.pictureBoxSettings.Name = "pictureBoxSettings";
            this.pictureBoxSettings.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxSettings.TabIndex = 2;
            this.pictureBoxSettings.TabStop = false;
            this.pictureBoxSettings.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxSettings_Paint);
            this.pictureBoxSettings.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxSettings_MouseClick);
            this.pictureBoxSettings.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxSettings.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            this.pictureBoxSettings.Resize += new System.EventHandler(this.PictureBox_Resize);
            // 
            // pictureBoxMenuAlwaysOpen
            // 
            this.pictureBoxMenuAlwaysOpen.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMenuAlwaysOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxMenuAlwaysOpen.Location = new System.Drawing.Point(78, 1);
            this.pictureBoxMenuAlwaysOpen.Margin = new System.Windows.Forms.Padding(1, 5, 1, 1);
            this.pictureBoxMenuAlwaysOpen.Name = "pictureBoxMenuAlwaysOpen";
            this.pictureBoxMenuAlwaysOpen.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxMenuAlwaysOpen.TabIndex = 1;
            this.pictureBoxMenuAlwaysOpen.TabStop = false;
            this.pictureBoxMenuAlwaysOpen.Click += new System.EventHandler(this.PictureBoxMenuAlwaysOpen_Click);
            this.pictureBoxMenuAlwaysOpen.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxMenuAlwaysOpen_Paint);
            this.pictureBoxMenuAlwaysOpen.DoubleClick += new System.EventHandler(this.PictureBoxMenuAlwaysOpen_Click);
            this.pictureBoxMenuAlwaysOpen.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxMenuAlwaysOpen.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            this.pictureBoxMenuAlwaysOpen.Resize += new System.EventHandler(this.PictureBox_Resize);
            // 
            // pictureBoxOpenFolder
            // 
            this.pictureBoxOpenFolder.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxOpenFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxOpenFolder.Location = new System.Drawing.Point(56, 1);
            this.pictureBoxOpenFolder.Margin = new System.Windows.Forms.Padding(1, 5, 1, 1);
            this.pictureBoxOpenFolder.Name = "pictureBoxOpenFolder";
            this.pictureBoxOpenFolder.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxOpenFolder.TabIndex = 1;
            this.pictureBoxOpenFolder.TabStop = false;
            this.pictureBoxOpenFolder.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxOpenFolder_Paint);
            this.pictureBoxOpenFolder.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxOpenFolder_Click);
            this.pictureBoxOpenFolder.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxOpenFolder.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            this.pictureBoxOpenFolder.Resize += new System.EventHandler(this.PictureBox_Resize);
            //
            // Controls like the scrollbar are removed when open the designer
            // When adding after InitializeComponent(), then e.g. scrollbar on high dpi not more working
            //
            InitializeComponentControlsTheDesignerRemoves();
            // 
            // timerUpdateIcons
            // 
            this.timerUpdateIcons.Tick += new System.EventHandler(this.TimerUpdateIcons_Tick);
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
            this.tableLayoutPanelBottom.ResumeLayout(false);
            this.tableLayoutPanelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRestart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenuAlwaysOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenFolder)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBoxOpenFolder;
        private System.Windows.Forms.PictureBox pictureBoxMenuAlwaysOpen;
        private System.Windows.Forms.Label labelItems;
        private System.Windows.Forms.Timer timerUpdateIcons;
        private System.Windows.Forms.PictureBox pictureBoxSettings;
        private System.Windows.Forms.PictureBox pictureBoxRestart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBottom;
        private System.Windows.Forms.Panel panelLine;
    }
}