namespace SystemTrayMenu.Controls
{
    partial class AboutBox
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.buttonDetails = new System.Windows.Forms.Button();
            this.ImagePictureBox = new System.Windows.Forms.PictureBox();
            this.AppDateLabel = new System.Windows.Forms.Label();
            this.buttonSystemInfo = new System.Windows.Forms.Button();
            this.AppCopyrightLabel = new System.Windows.Forms.Label();
            this.AppVersionLabel = new System.Windows.Forms.Label();
            this.AppDescriptionLabel = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.AppTitleLabel = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.MoreRichTextBox = new System.Windows.Forms.RichTextBox();
            this.TabPanelDetails = new System.Windows.Forms.TabControl();
            this.TabPageApplication = new System.Windows.Forms.TabPage();
            this.AppInfoListView = new System.Windows.Forms.ListView();
            this.colKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TabPageAssemblies = new System.Windows.Forms.TabPage();
            this.AssemblyInfoListView = new System.Windows.Forms.ListView();
            this.colAssemblyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssemblyVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssemblyBuilt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssemblyCodeBase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TabPageAssemblyDetails = new System.Windows.Forms.TabPage();
            this.AssemblyDetailsListView = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AssemblyNamesComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            this.TabPanelDetails.SuspendLayout();
            this.TabPageApplication.SuspendLayout();
            this.TabPageAssemblies.SuspendLayout();
            this.TabPageAssemblyDetails.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDetails
            // 
            this.buttonDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDetails.AutoSize = true;
            this.buttonDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDetails.Location = new System.Drawing.Point(148, 5);
            this.buttonDetails.Margin = new System.Windows.Forms.Padding(5);
            this.buttonDetails.MinimumSize = new System.Drawing.Size(133, 40);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(133, 40);
            this.buttonDetails.TabIndex = 25;
            this.buttonDetails.Text = "Details";
            this.buttonDetails.Click += new System.EventHandler(this.DetailsButton_Click);
            // 
            // ImagePictureBox
            // 
            this.ImagePictureBox.BackgroundImage = global::SystemTrayMenu.Properties.Resources.STM;
            this.ImagePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImagePictureBox.Location = new System.Drawing.Point(5, 5);
            this.ImagePictureBox.Margin = new System.Windows.Forms.Padding(5);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(68, 63);
            this.ImagePictureBox.TabIndex = 24;
            this.ImagePictureBox.TabStop = false;
            // 
            // AppDateLabel
            // 
            this.AppDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppDateLabel.AutoSize = true;
            this.AppDateLabel.Location = new System.Drawing.Point(5, 140);
            this.AppDateLabel.Margin = new System.Windows.Forms.Padding(5);
            this.AppDateLabel.Name = "AppDateLabel";
            this.AppDateLabel.Size = new System.Drawing.Size(668, 25);
            this.AppDateLabel.TabIndex = 23;
            this.AppDateLabel.Text = "Built on %builddate%";
            // 
            // buttonSystemInfo
            // 
            this.buttonSystemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSystemInfo.AutoSize = true;
            this.buttonSystemInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSystemInfo.Location = new System.Drawing.Point(5, 5);
            this.buttonSystemInfo.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSystemInfo.MinimumSize = new System.Drawing.Size(133, 40);
            this.buttonSystemInfo.Name = "buttonSystemInfo";
            this.buttonSystemInfo.Size = new System.Drawing.Size(133, 40);
            this.buttonSystemInfo.TabIndex = 22;
            this.buttonSystemInfo.Text = "System Info";
            this.buttonSystemInfo.Visible = false;
            this.buttonSystemInfo.Click += new System.EventHandler(this.SysInfoButton_Click);
            // 
            // AppCopyrightLabel
            // 
            this.AppCopyrightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppCopyrightLabel.AutoSize = true;
            this.AppCopyrightLabel.Location = new System.Drawing.Point(5, 175);
            this.AppCopyrightLabel.Margin = new System.Windows.Forms.Padding(5);
            this.AppCopyrightLabel.Name = "AppCopyrightLabel";
            this.AppCopyrightLabel.Size = new System.Drawing.Size(668, 25);
            this.AppCopyrightLabel.TabIndex = 21;
            this.AppCopyrightLabel.Text = "Copyright © %year%, %company%";
            // 
            // AppVersionLabel
            // 
            this.AppVersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppVersionLabel.AutoSize = true;
            this.AppVersionLabel.Location = new System.Drawing.Point(5, 105);
            this.AppVersionLabel.Margin = new System.Windows.Forms.Padding(5);
            this.AppVersionLabel.Name = "AppVersionLabel";
            this.AppVersionLabel.Size = new System.Drawing.Size(668, 25);
            this.AppVersionLabel.TabIndex = 20;
            this.AppVersionLabel.Text = "Version %version%";
            // 
            // AppDescriptionLabel
            // 
            this.AppDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppDescriptionLabel.AutoSize = true;
            this.AppDescriptionLabel.Location = new System.Drawing.Point(5, 40);
            this.AppDescriptionLabel.Margin = new System.Windows.Forms.Padding(5);
            this.AppDescriptionLabel.Name = "AppDescriptionLabel";
            this.AppDescriptionLabel.Size = new System.Drawing.Size(142, 25);
            this.AppDescriptionLabel.TabIndex = 19;
            this.AppDescriptionLabel.Text = "%description%";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Location = new System.Drawing.Point(5, 91);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.GroupBox1.Size = new System.Drawing.Size(668, 4);
            this.GroupBox1.TabIndex = 18;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "GroupBox1";
            // 
            // AppTitleLabel
            // 
            this.AppTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppTitleLabel.AutoSize = true;
            this.AppTitleLabel.Location = new System.Drawing.Point(5, 5);
            this.AppTitleLabel.Margin = new System.Windows.Forms.Padding(5);
            this.AppTitleLabel.Name = "AppTitleLabel";
            this.AppTitleLabel.Size = new System.Drawing.Size(142, 25);
            this.AppTitleLabel.TabIndex = 17;
            this.AppTitleLabel.Text = "%title%";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.AutoSize = true;
            this.buttonOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOk.Location = new System.Drawing.Point(291, 5);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(5);
            this.buttonOk.MinimumSize = new System.Drawing.Size(133, 40);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(133, 40);
            this.buttonOk.TabIndex = 16;
            this.buttonOk.Text = "OK";
            // 
            // MoreRichTextBox
            // 
            this.MoreRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MoreRichTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MoreRichTextBox.Location = new System.Drawing.Point(5, 210);
            this.MoreRichTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.MoreRichTextBox.Name = "MoreRichTextBox";
            this.MoreRichTextBox.ReadOnly = true;
            this.MoreRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.MoreRichTextBox.Size = new System.Drawing.Size(668, 210);
            this.MoreRichTextBox.TabIndex = 26;
            this.MoreRichTextBox.Text = "%product% is %copyright%, %trademark%";
            this.MoreRichTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.MoreRichTextBox_LinkClicked);
            // 
            // TabPanelDetails
            // 
            this.TabPanelDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabPanelDetails.Controls.Add(this.TabPageApplication);
            this.TabPanelDetails.Controls.Add(this.TabPageAssemblies);
            this.TabPanelDetails.Controls.Add(this.TabPageAssemblyDetails);
            this.TabPanelDetails.Location = new System.Drawing.Point(5, 430);
            this.TabPanelDetails.Margin = new System.Windows.Forms.Padding(5);
            this.TabPanelDetails.Name = "TabPanelDetails";
            this.TabPanelDetails.SelectedIndex = 0;
            this.TabPanelDetails.Size = new System.Drawing.Size(668, 219);
            this.TabPanelDetails.TabIndex = 27;
            this.TabPanelDetails.Visible = false;
            this.TabPanelDetails.SelectedIndexChanged += new System.EventHandler(this.TabPanelDetails_SelectedIndexChanged);
            // 
            // TabPageApplication
            // 
            this.TabPageApplication.Controls.Add(this.AppInfoListView);
            this.TabPageApplication.Location = new System.Drawing.Point(4, 33);
            this.TabPageApplication.Margin = new System.Windows.Forms.Padding(5);
            this.TabPageApplication.Name = "TabPageApplication";
            this.TabPageApplication.Size = new System.Drawing.Size(660, 182);
            this.TabPageApplication.TabIndex = 0;
            this.TabPageApplication.Text = "Application";
            // 
            // AppInfoListView
            // 
            this.AppInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colKey,
            this.colValue});
            this.AppInfoListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppInfoListView.FullRowSelect = true;
            this.AppInfoListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.AppInfoListView.Location = new System.Drawing.Point(0, 0);
            this.AppInfoListView.Margin = new System.Windows.Forms.Padding(5);
            this.AppInfoListView.Name = "AppInfoListView";
            this.AppInfoListView.Size = new System.Drawing.Size(660, 182);
            this.AppInfoListView.TabIndex = 16;
            this.AppInfoListView.UseCompatibleStateImageBehavior = false;
            this.AppInfoListView.View = System.Windows.Forms.View.Details;
            // 
            // colKey
            // 
            this.colKey.Text = "Application Key";
            this.colKey.Width = 120;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            this.colValue.Width = 700;
            // 
            // TabPageAssemblies
            // 
            this.TabPageAssemblies.Controls.Add(this.AssemblyInfoListView);
            this.TabPageAssemblies.Location = new System.Drawing.Point(4, 33);
            this.TabPageAssemblies.Margin = new System.Windows.Forms.Padding(5);
            this.TabPageAssemblies.Name = "TabPageAssemblies";
            this.TabPageAssemblies.Size = new System.Drawing.Size(660, 182);
            this.TabPageAssemblies.TabIndex = 1;
            this.TabPageAssemblies.Text = "Assemblies";
            // 
            // AssemblyInfoListView
            // 
            this.AssemblyInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAssemblyName,
            this.colAssemblyVersion,
            this.colAssemblyBuilt,
            this.colAssemblyCodeBase});
            this.AssemblyInfoListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssemblyInfoListView.FullRowSelect = true;
            this.AssemblyInfoListView.Location = new System.Drawing.Point(0, 0);
            this.AssemblyInfoListView.Margin = new System.Windows.Forms.Padding(5);
            this.AssemblyInfoListView.MultiSelect = false;
            this.AssemblyInfoListView.Name = "AssemblyInfoListView";
            this.AssemblyInfoListView.Size = new System.Drawing.Size(660, 182);
            this.AssemblyInfoListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.AssemblyInfoListView.TabIndex = 13;
            this.AssemblyInfoListView.UseCompatibleStateImageBehavior = false;
            this.AssemblyInfoListView.View = System.Windows.Forms.View.Details;
            this.AssemblyInfoListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.AssemblyInfoListView_ColumnClick);
            this.AssemblyInfoListView.DoubleClick += new System.EventHandler(this.AssemblyInfoListView_DoubleClick);
            // 
            // colAssemblyName
            // 
            this.colAssemblyName.Text = "Assembly";
            this.colAssemblyName.Width = 123;
            // 
            // colAssemblyVersion
            // 
            this.colAssemblyVersion.Text = "Version";
            this.colAssemblyVersion.Width = 100;
            // 
            // colAssemblyBuilt
            // 
            this.colAssemblyBuilt.Text = "Built";
            this.colAssemblyBuilt.Width = 130;
            // 
            // colAssemblyCodeBase
            // 
            this.colAssemblyCodeBase.Text = "CodeBase";
            this.colAssemblyCodeBase.Width = 750;
            // 
            // TabPageAssemblyDetails
            // 
            this.TabPageAssemblyDetails.Controls.Add(this.AssemblyDetailsListView);
            this.TabPageAssemblyDetails.Controls.Add(this.AssemblyNamesComboBox);
            this.TabPageAssemblyDetails.Location = new System.Drawing.Point(4, 33);
            this.TabPageAssemblyDetails.Margin = new System.Windows.Forms.Padding(5);
            this.TabPageAssemblyDetails.Name = "TabPageAssemblyDetails";
            this.TabPageAssemblyDetails.Size = new System.Drawing.Size(660, 182);
            this.TabPageAssemblyDetails.TabIndex = 2;
            this.TabPageAssemblyDetails.Text = "Assembly Details";
            // 
            // AssemblyDetailsListView
            // 
            this.AssemblyDetailsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.AssemblyDetailsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssemblyDetailsListView.FullRowSelect = true;
            this.AssemblyDetailsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.AssemblyDetailsListView.Location = new System.Drawing.Point(0, 32);
            this.AssemblyDetailsListView.Margin = new System.Windows.Forms.Padding(5);
            this.AssemblyDetailsListView.Name = "AssemblyDetailsListView";
            this.AssemblyDetailsListView.Size = new System.Drawing.Size(660, 150);
            this.AssemblyDetailsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.AssemblyDetailsListView.TabIndex = 19;
            this.AssemblyDetailsListView.UseCompatibleStateImageBehavior = false;
            this.AssemblyDetailsListView.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Assembly Key";
            this.ColumnHeader1.Width = 120;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Value";
            this.ColumnHeader2.Width = 700;
            // 
            // AssemblyNamesComboBox
            // 
            this.AssemblyNamesComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.AssemblyNamesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AssemblyNamesComboBox.Location = new System.Drawing.Point(0, 0);
            this.AssemblyNamesComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.AssemblyNamesComboBox.Name = "AssemblyNamesComboBox";
            this.AssemblyNamesComboBox.Size = new System.Drawing.Size(660, 32);
            this.AssemblyNamesComboBox.Sorted = true;
            this.AssemblyNamesComboBox.TabIndex = 18;
            this.AssemblyNamesComboBox.SelectedIndexChanged += new System.EventHandler(this.AssemblyNamesComboBox_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AppCopyrightLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.AppDateLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.GroupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TabPanelDetails, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.MoreRichTextBox, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.AppVersionLabel, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 12);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(678, 712);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.buttonSystemInfo, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonDetails, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonOk, 2, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 658);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(429, 50);
            this.tableLayoutPanel4.TabIndex = 29;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 548F));
            this.tableLayoutPanel2.Controls.Add(this.ImagePictureBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(626, 78);
            this.tableLayoutPanel2.TabIndex = 29;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.AppTitleLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.AppDescriptionLabel, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(82, 4);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(152, 70);
            this.tableLayoutPanel3.TabIndex = 25;
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.buttonOk;
            this.ClientSize = new System.Drawing.Size(704, 861);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About %title%";
            this.Load += new System.EventHandler(this.AboutBox_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AboutBox_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            this.TabPanelDetails.ResumeLayout(false);
            this.TabPageApplication.ResumeLayout(false);
            this.TabPageAssemblies.ResumeLayout(false);
            this.TabPageAssemblyDetails.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.PictureBox ImagePictureBox;
        private System.Windows.Forms.Label AppDateLabel;
        private System.Windows.Forms.Button buttonSystemInfo;
        private System.Windows.Forms.Label AppCopyrightLabel;
        private System.Windows.Forms.Label AppVersionLabel;
        private System.Windows.Forms.Label AppDescriptionLabel;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Label AppTitleLabel;
        private System.Windows.Forms.Button buttonOk;
        internal System.Windows.Forms.RichTextBox MoreRichTextBox;
        internal System.Windows.Forms.TabControl TabPanelDetails;
        internal System.Windows.Forms.TabPage TabPageApplication;
        internal System.Windows.Forms.ListView AppInfoListView;
        internal System.Windows.Forms.ColumnHeader colKey;
        internal System.Windows.Forms.ColumnHeader colValue;
        internal System.Windows.Forms.TabPage TabPageAssemblies;
        internal System.Windows.Forms.ListView AssemblyInfoListView;
        internal System.Windows.Forms.ColumnHeader colAssemblyName;
        internal System.Windows.Forms.ColumnHeader colAssemblyVersion;
        internal System.Windows.Forms.ColumnHeader colAssemblyBuilt;
        internal System.Windows.Forms.ColumnHeader colAssemblyCodeBase;
        internal System.Windows.Forms.TabPage TabPageAssemblyDetails;
        internal System.Windows.Forms.ListView AssemblyDetailsListView;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.ComboBox AssemblyNamesComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    }
}