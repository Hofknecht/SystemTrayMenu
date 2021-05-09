using SystemTrayMenu.UserInterface.HotkeyTextboxControl;

namespace SystemTrayMenu.UserInterface
{
    partial class SettingsForm
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
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxFolder = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelFolder = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelChangeFolder = new System.Windows.Forms.TableLayoutPanel();
            this.buttonChangeFolder = new System.Windows.Forms.Button();
            this.groupBoxUSB = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelUSB = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelRelativeFolderOpenAssembly = new System.Windows.Forms.TableLayoutPanel();
            this.buttonChangeRelativeFolder = new System.Windows.Forms.Button();
            this.buttonOpenAssemblyLocation = new System.Windows.Forms.Button();
            this.checkBoxStoreConfigAtAssemblyLocation = new System.Windows.Forms.CheckBox();
            this.groupBoxAutostart = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelAutostart = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxAutostart = new System.Windows.Forms.CheckBox();
            this.groupBoxHotkey = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelHotkey = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxHotkeyPlaceholder = new System.Windows.Forms.TextBox();
            this.buttonHotkeyDefault = new System.Windows.Forms.Button();
            this.groupBoxLanguage = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelLanguage = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.tabPageAdvanced = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelAdvanced = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxClick = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelClick = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxOpenItemWithOneClick = new System.Windows.Forms.CheckBox();
            this.groupBoxSizeAndLocation = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelSizeAndLocation = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxAppearAtMouseLocation = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelMaxMenuWidth = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownMenuWidth = new System.Windows.Forms.NumericUpDown();
            this.labelMaxMenuWidth = new System.Windows.Forms.Label();
            this.groupBoxStaysOpen = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelStaysOpen = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxStayOpenWhenItemClicked = new System.Windows.Forms.CheckBox();
            this.checkBoxStayOpenWhenFocusLost = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelTimeUntilCloses = new System.Windows.Forms.TableLayoutPanel();
            this.labelTimeUntilCloses = new System.Windows.Forms.Label();
            this.numericUpDownTimeUntilClose = new System.Windows.Forms.NumericUpDown();
            this.groupBoxOpenSubmenus = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelTimeUntilOpen = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownTimeUntilOpens = new System.Windows.Forms.NumericUpDown();
            this.labelTimeUntilOpen = new System.Windows.Forms.Label();
            this.buttonAdvancedDefault = new System.Windows.Forms.Button();
            this.tabPageCustomize = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelCustomize = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxDarkMode = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxDarkModeAlwaysOn = new System.Windows.Forms.CheckBox();
            this.groupBoxColors = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelColorsAndDefault = new System.Windows.Forms.TableLayoutPanel();
            this.labelPasteHtmlColorCodeOrDoubleClickIntoField = new System.Windows.Forms.Label();
            this.tableLayoutPanelColors = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxColorWarning = new System.Windows.Forms.TextBox();
            this.labelWarning = new System.Windows.Forms.Label();
            this.textBoxColorDarkModeWarning = new System.Windows.Forms.TextBox();
            this.textBoxColorSelectedItemBorder = new System.Windows.Forms.TextBox();
            this.textBoxColorDarkModeSelectedItemBorder = new System.Windows.Forms.TextBox();
            this.textBoxColorDarkModeSelecetedItem = new System.Windows.Forms.TextBox();
            this.textBoxColorSelectedItem = new System.Windows.Forms.TextBox();
            this.textBoxColorOpenFolderBorder = new System.Windows.Forms.TextBox();
            this.textBoxColorDarkModeOpenFolderBorder = new System.Windows.Forms.TextBox();
            this.textBoxColorDarkModeOpenFolder = new System.Windows.Forms.TextBox();
            this.textBoxColorOpenFolder = new System.Windows.Forms.TextBox();
            this.textBoxColorDarkModeTitle = new System.Windows.Forms.TextBox();
            this.textBoxColorTitle = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxColorDarkModeSearchField = new System.Windows.Forms.TextBox();
            this.textBoxColorSearchField = new System.Windows.Forms.TextBox();
            this.textBoxColorDarkModeBackground = new System.Windows.Forms.TextBox();
            this.textBoxColorBackground = new System.Windows.Forms.TextBox();
            this.labelBackground = new System.Windows.Forms.Label();
            this.labelSearchField = new System.Windows.Forms.Label();
            this.labelOpenFolder = new System.Windows.Forms.Label();
            this.labelOpenFolderBorder = new System.Windows.Forms.Label();
            this.labelSelectedItem = new System.Windows.Forms.Label();
            this.labelSelectedItemBorder = new System.Windows.Forms.Label();
            this.tableLayoutPanelColorsDefault = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDefaultColors = new System.Windows.Forms.Button();
            this.buttonDefaultColorsDark = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelBottom.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.tableLayoutPanelGeneral.SuspendLayout();
            this.groupBoxFolder.SuspendLayout();
            this.tableLayoutPanelFolder.SuspendLayout();
            this.tableLayoutPanelChangeFolder.SuspendLayout();
            this.groupBoxUSB.SuspendLayout();
            this.tableLayoutPanelUSB.SuspendLayout();
            this.tableLayoutPanelRelativeFolderOpenAssembly.SuspendLayout();
            this.groupBoxAutostart.SuspendLayout();
            this.tableLayoutPanelAutostart.SuspendLayout();
            this.groupBoxHotkey.SuspendLayout();
            this.tableLayoutPanelHotkey.SuspendLayout();
            this.groupBoxLanguage.SuspendLayout();
            this.tableLayoutPanelLanguage.SuspendLayout();
            this.tabPageAdvanced.SuspendLayout();
            this.tableLayoutPanelAdvanced.SuspendLayout();
            this.groupBoxClick.SuspendLayout();
            this.tableLayoutPanelClick.SuspendLayout();
            this.groupBoxSizeAndLocation.SuspendLayout();
            this.tableLayoutPanelSizeAndLocation.SuspendLayout();
            this.tableLayoutPanelMaxMenuWidth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMenuWidth)).BeginInit();
            this.groupBoxStaysOpen.SuspendLayout();
            this.tableLayoutPanelStaysOpen.SuspendLayout();
            this.tableLayoutPanelTimeUntilCloses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeUntilClose)).BeginInit();
            this.groupBoxOpenSubmenus.SuspendLayout();
            this.tableLayoutPanelTimeUntilOpen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeUntilOpens)).BeginInit();
            this.tabPageCustomize.SuspendLayout();
            this.tableLayoutPanelCustomize.SuspendLayout();
            this.groupBoxDarkMode.SuspendLayout();
            this.tableLayoutPanelDarkMode.SuspendLayout();
            this.groupBoxColors.SuspendLayout();
            this.tableLayoutPanelColorsAndDefault.SuspendLayout();
            this.tableLayoutPanelColors.SuspendLayout();
            this.tableLayoutPanelColorsDefault.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelBottom, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(434, 447);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tableLayoutPanelBottom
            // 
            this.tableLayoutPanelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelBottom.AutoSize = true;
            this.tableLayoutPanelBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelBottom.ColumnCount = 3;
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBottom.Controls.Add(this.buttonOk, 1, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.buttonCancel, 2, 0);
            this.tableLayoutPanelBottom.Location = new System.Drawing.Point(3, 419);
            this.tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            this.tableLayoutPanelBottom.RowCount = 1;
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBottom.Size = new System.Drawing.Size(428, 25);
            this.tableLayoutPanelBottom.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.AutoSize = true;
            this.buttonOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(267, 0);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonOk.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 25);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(348, 0);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.buttonCancel.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 25);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageGeneral);
            this.tabControl.Controls.Add(this.tabPageAdvanced);
            this.tabControl.Controls.Add(this.tabPageCustomize);
            this.tabControl.Location = new System.Drawing.Point(6, 3);
            this.tabControl.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 2;
            this.tabControl.Size = new System.Drawing.Size(422, 410);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.tableLayoutPanelGeneral);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 24);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(414, 382);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "tabPageGeneral";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelGeneral
            // 
            this.tableLayoutPanelGeneral.AutoSize = true;
            this.tableLayoutPanelGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelGeneral.ColumnCount = 1;
            this.tableLayoutPanelGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxFolder, 0, 0);
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxUSB, 0, 1);
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxAutostart, 0, 2);
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxHotkey, 0, 3);
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxLanguage, 0, 4);
            this.tableLayoutPanelGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGeneral.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelGeneral.Name = "tableLayoutPanelGeneral";
            this.tableLayoutPanelGeneral.RowCount = 5;
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.Size = new System.Drawing.Size(408, 376);
            this.tableLayoutPanelGeneral.TabIndex = 0;
            // 
            // groupBoxFolder
            // 
            this.groupBoxFolder.AutoSize = true;
            this.groupBoxFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxFolder.Controls.Add(this.tableLayoutPanelFolder);
            this.groupBoxFolder.Location = new System.Drawing.Point(3, 3);
            this.groupBoxFolder.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxFolder.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxFolder.Name = "groupBoxFolder";
            this.groupBoxFolder.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxFolder.Size = new System.Drawing.Size(400, 81);
            this.groupBoxFolder.TabIndex = 0;
            this.groupBoxFolder.TabStop = false;
            this.groupBoxFolder.Text = "groupBoxFolder";
            // 
            // tableLayoutPanelFolder
            // 
            this.tableLayoutPanelFolder.AutoSize = true;
            this.tableLayoutPanelFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelFolder.ColumnCount = 1;
            this.tableLayoutPanelFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelFolder.Controls.Add(this.textBoxFolder, 0, 0);
            this.tableLayoutPanelFolder.Controls.Add(this.tableLayoutPanelChangeFolder, 0, 1);
            this.tableLayoutPanelFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFolder.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanelFolder.Name = "tableLayoutPanelFolder";
            this.tableLayoutPanelFolder.RowCount = 2;
            this.tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolder.Size = new System.Drawing.Size(394, 53);
            this.tableLayoutPanelFolder.TabIndex = 0;
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFolder.BackColor = System.Drawing.Color.White;
            this.textBoxFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFolder.Location = new System.Drawing.Point(6, 3);
            this.textBoxFolder.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.ReadOnly = true;
            this.textBoxFolder.Size = new System.Drawing.Size(382, 16);
            this.textBoxFolder.TabIndex = 0;
            this.textBoxFolder.TabStop = false;
            // 
            // tableLayoutPanelChangeFolder
            // 
            this.tableLayoutPanelChangeFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelChangeFolder.AutoSize = true;
            this.tableLayoutPanelChangeFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelChangeFolder.ColumnCount = 2;
            this.tableLayoutPanelChangeFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelChangeFolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelChangeFolder.Controls.Add(this.buttonChangeFolder, 0, 0);
            this.tableLayoutPanelChangeFolder.Location = new System.Drawing.Point(0, 22);
            this.tableLayoutPanelChangeFolder.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelChangeFolder.Name = "tableLayoutPanelChangeFolder";
            this.tableLayoutPanelChangeFolder.RowCount = 1;
            this.tableLayoutPanelChangeFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelChangeFolder.Size = new System.Drawing.Size(394, 31);
            this.tableLayoutPanelChangeFolder.TabIndex = 0;
            // 
            // buttonChangeFolder
            // 
            this.buttonChangeFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonChangeFolder.AutoSize = true;
            this.buttonChangeFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonChangeFolder.Location = new System.Drawing.Point(2, 3);
            this.buttonChangeFolder.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.buttonChangeFolder.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonChangeFolder.Name = "buttonChangeFolder";
            this.buttonChangeFolder.Size = new System.Drawing.Size(94, 25);
            this.buttonChangeFolder.TabIndex = 0;
            this.buttonChangeFolder.Text = "Change Folder";
            this.buttonChangeFolder.UseVisualStyleBackColor = true;
            this.buttonChangeFolder.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // groupBoxUSB
            // 
            this.groupBoxUSB.AutoSize = true;
            this.groupBoxUSB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxUSB.Controls.Add(this.tableLayoutPanelUSB);
            this.groupBoxUSB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxUSB.Location = new System.Drawing.Point(3, 90);
            this.groupBoxUSB.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxUSB.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxUSB.Name = "groupBoxUSB";
            this.groupBoxUSB.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxUSB.Size = new System.Drawing.Size(400, 84);
            this.groupBoxUSB.TabIndex = 2;
            this.groupBoxUSB.TabStop = false;
            this.groupBoxUSB.Text = "groupBoxUSB";
            // 
            // tableLayoutPanelUSB
            // 
            this.tableLayoutPanelUSB.AutoSize = true;
            this.tableLayoutPanelUSB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelUSB.ColumnCount = 1;
            this.tableLayoutPanelUSB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelUSB.Controls.Add(this.tableLayoutPanelRelativeFolderOpenAssembly, 0, 0);
            this.tableLayoutPanelUSB.Controls.Add(this.checkBoxStoreConfigAtAssemblyLocation, 0, 1);
            this.tableLayoutPanelUSB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelUSB.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanelUSB.Name = "tableLayoutPanelUSB";
            this.tableLayoutPanelUSB.RowCount = 2;
            this.tableLayoutPanelUSB.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelUSB.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelUSB.Size = new System.Drawing.Size(394, 56);
            this.tableLayoutPanelUSB.TabIndex = 3;
            // 
            // tableLayoutPanelRelativeFolderOpenAssembly
            // 
            this.tableLayoutPanelRelativeFolderOpenAssembly.AutoSize = true;
            this.tableLayoutPanelRelativeFolderOpenAssembly.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelRelativeFolderOpenAssembly.ColumnCount = 3;
            this.tableLayoutPanelRelativeFolderOpenAssembly.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRelativeFolderOpenAssembly.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRelativeFolderOpenAssembly.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRelativeFolderOpenAssembly.Controls.Add(this.buttonChangeRelativeFolder, 0, 0);
            this.tableLayoutPanelRelativeFolderOpenAssembly.Controls.Add(this.buttonOpenAssemblyLocation, 2, 0);
            this.tableLayoutPanelRelativeFolderOpenAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRelativeFolderOpenAssembly.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelRelativeFolderOpenAssembly.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelRelativeFolderOpenAssembly.Name = "tableLayoutPanelRelativeFolderOpenAssembly";
            this.tableLayoutPanelRelativeFolderOpenAssembly.RowCount = 1;
            this.tableLayoutPanelRelativeFolderOpenAssembly.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRelativeFolderOpenAssembly.Size = new System.Drawing.Size(394, 31);
            this.tableLayoutPanelRelativeFolderOpenAssembly.TabIndex = 1;
            // 
            // buttonChangeRelativeFolder
            // 
            this.buttonChangeRelativeFolder.AutoSize = true;
            this.buttonChangeRelativeFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonChangeRelativeFolder.Location = new System.Drawing.Point(2, 3);
            this.buttonChangeRelativeFolder.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.buttonChangeRelativeFolder.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonChangeRelativeFolder.Name = "buttonChangeRelativeFolder";
            this.buttonChangeRelativeFolder.Size = new System.Drawing.Size(132, 25);
            this.buttonChangeRelativeFolder.TabIndex = 0;
            this.buttonChangeRelativeFolder.Text = "ChangeRelativeFolder";
            this.buttonChangeRelativeFolder.UseVisualStyleBackColor = true;
            this.buttonChangeRelativeFolder.Click += new System.EventHandler(this.ButtonChangeRelativeFolder_Click);
            // 
            // buttonOpenAssemblyLocation
            // 
            this.buttonOpenAssemblyLocation.AutoSize = true;
            this.buttonOpenAssemblyLocation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenAssemblyLocation.Location = new System.Drawing.Point(212, 3);
            this.buttonOpenAssemblyLocation.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonOpenAssemblyLocation.Name = "buttonOpenAssemblyLocation";
            this.buttonOpenAssemblyLocation.Size = new System.Drawing.Size(179, 25);
            this.buttonOpenAssemblyLocation.TabIndex = 2;
            this.buttonOpenAssemblyLocation.Text = "buttonOpenAssemblyLocation";
            this.buttonOpenAssemblyLocation.UseVisualStyleBackColor = true;
            this.buttonOpenAssemblyLocation.Click += new System.EventHandler(this.ButtonOpenAssemblyLocation_Click);
            // 
            // checkBoxStoreConfigAtAssemblyLocation
            // 
            this.checkBoxStoreConfigAtAssemblyLocation.AutoSize = true;
            this.checkBoxStoreConfigAtAssemblyLocation.Location = new System.Drawing.Point(3, 34);
            this.checkBoxStoreConfigAtAssemblyLocation.Name = "checkBoxStoreConfigAtAssemblyLocation";
            this.checkBoxStoreConfigAtAssemblyLocation.Size = new System.Drawing.Size(249, 19);
            this.checkBoxStoreConfigAtAssemblyLocation.TabIndex = 1;
            this.checkBoxStoreConfigAtAssemblyLocation.Text = "checkBoxStoreConfigAtAssemblyLocation";
            this.checkBoxStoreConfigAtAssemblyLocation.UseVisualStyleBackColor = true;
            // 
            // groupBoxAutostart
            // 
            this.groupBoxAutostart.AutoSize = true;
            this.groupBoxAutostart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxAutostart.Controls.Add(this.tableLayoutPanelAutostart);
            this.groupBoxAutostart.Location = new System.Drawing.Point(3, 180);
            this.groupBoxAutostart.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxAutostart.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxAutostart.Name = "groupBoxAutostart";
            this.groupBoxAutostart.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxAutostart.Size = new System.Drawing.Size(400, 53);
            this.groupBoxAutostart.TabIndex = 0;
            this.groupBoxAutostart.TabStop = false;
            this.groupBoxAutostart.Text = "groupBoxAutostart";
            // 
            // tableLayoutPanelAutostart
            // 
            this.tableLayoutPanelAutostart.AutoSize = true;
            this.tableLayoutPanelAutostart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelAutostart.ColumnCount = 1;
            this.tableLayoutPanelAutostart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAutostart.Controls.Add(this.checkBoxAutostart, 0, 0);
            this.tableLayoutPanelAutostart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAutostart.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanelAutostart.Name = "tableLayoutPanelAutostart";
            this.tableLayoutPanelAutostart.RowCount = 1;
            this.tableLayoutPanelAutostart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAutostart.Size = new System.Drawing.Size(394, 25);
            this.tableLayoutPanelAutostart.TabIndex = 0;
            // 
            // checkBoxAutostart
            // 
            this.checkBoxAutostart.AutoSize = true;
            this.checkBoxAutostart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxAutostart.Location = new System.Drawing.Point(3, 3);
            this.checkBoxAutostart.Name = "checkBoxAutostart";
            this.checkBoxAutostart.Size = new System.Drawing.Size(388, 19);
            this.checkBoxAutostart.TabIndex = 0;
            this.checkBoxAutostart.Text = "checkBoxAutostart";
            this.checkBoxAutostart.UseVisualStyleBackColor = true;
            // 
            // groupBoxHotkey
            // 
            this.groupBoxHotkey.AutoSize = true;
            this.groupBoxHotkey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxHotkey.Controls.Add(this.tableLayoutPanelHotkey);
            this.groupBoxHotkey.Location = new System.Drawing.Point(3, 239);
            this.groupBoxHotkey.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxHotkey.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxHotkey.Name = "groupBoxHotkey";
            this.groupBoxHotkey.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxHotkey.Size = new System.Drawing.Size(400, 59);
            this.groupBoxHotkey.TabIndex = 0;
            this.groupBoxHotkey.TabStop = false;
            this.groupBoxHotkey.Text = "groupBoxHotkey";
            // 
            // tableLayoutPanelHotkey
            // 
            this.tableLayoutPanelHotkey.AutoSize = true;
            this.tableLayoutPanelHotkey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelHotkey.ColumnCount = 3;
            this.tableLayoutPanelHotkey.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelHotkey.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHotkey.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelHotkey.Controls.Add(this.textBoxHotkeyPlaceholder, 1, 0);
            this.tableLayoutPanelHotkey.Controls.Add(this.buttonHotkeyDefault, 2, 0);
            this.tableLayoutPanelHotkey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelHotkey.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanelHotkey.Name = "tableLayoutPanelHotkey";
            this.tableLayoutPanelHotkey.RowCount = 1;
            this.tableLayoutPanelHotkey.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelHotkey.Size = new System.Drawing.Size(394, 31);
            this.tableLayoutPanelHotkey.TabIndex = 0;
            // 
            // textBoxHotkeyPlaceholder
            // 
            this.textBoxHotkeyPlaceholder.Location = new System.Drawing.Point(3, 3);
            this.textBoxHotkeyPlaceholder.Name = "textBoxHotkeyPlaceholder";
            this.textBoxHotkeyPlaceholder.Size = new System.Drawing.Size(200, 23);
            this.textBoxHotkeyPlaceholder.TabIndex = 0;
            // 
            // buttonHotkeyDefault
            // 
            this.buttonHotkeyDefault.AutoSize = true;
            this.buttonHotkeyDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHotkeyDefault.Location = new System.Drawing.Point(262, 3);
            this.buttonHotkeyDefault.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonHotkeyDefault.Name = "buttonHotkeyDefault";
            this.buttonHotkeyDefault.Size = new System.Drawing.Size(129, 25);
            this.buttonHotkeyDefault.TabIndex = 0;
            this.buttonHotkeyDefault.Text = "buttonHotkeyDefault";
            this.buttonHotkeyDefault.UseVisualStyleBackColor = true;
            this.buttonHotkeyDefault.Click += new System.EventHandler(this.ButtonHotkeyDefault_Click);
            // 
            // groupBoxLanguage
            // 
            this.groupBoxLanguage.AutoSize = true;
            this.groupBoxLanguage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxLanguage.Controls.Add(this.tableLayoutPanelLanguage);
            this.groupBoxLanguage.Location = new System.Drawing.Point(3, 304);
            this.groupBoxLanguage.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxLanguage.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxLanguage.Name = "groupBoxLanguage";
            this.groupBoxLanguage.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxLanguage.Size = new System.Drawing.Size(400, 57);
            this.groupBoxLanguage.TabIndex = 0;
            this.groupBoxLanguage.TabStop = false;
            this.groupBoxLanguage.Text = "groupBoxLanguage";
            // 
            // tableLayoutPanelLanguage
            // 
            this.tableLayoutPanelLanguage.AutoSize = true;
            this.tableLayoutPanelLanguage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelLanguage.ColumnCount = 2;
            this.tableLayoutPanelLanguage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelLanguage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLanguage.Controls.Add(this.comboBoxLanguage, 0, 0);
            this.tableLayoutPanelLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLanguage.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanelLanguage.Name = "tableLayoutPanelLanguage";
            this.tableLayoutPanelLanguage.RowCount = 1;
            this.tableLayoutPanelLanguage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelLanguage.Size = new System.Drawing.Size(394, 29);
            this.tableLayoutPanelLanguage.TabIndex = 0;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(3, 3);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(200, 23);
            this.comboBoxLanguage.TabIndex = 0;
            // 
            // tabPageAdvanced
            // 
            this.tabPageAdvanced.Controls.Add(this.tableLayoutPanelAdvanced);
            this.tabPageAdvanced.Location = new System.Drawing.Point(4, 24);
            this.tabPageAdvanced.Name = "tabPageAdvanced";
            this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdvanced.Size = new System.Drawing.Size(414, 382);
            this.tabPageAdvanced.TabIndex = 0;
            this.tabPageAdvanced.Text = "tabPageAdvanced";
            this.tabPageAdvanced.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelAdvanced
            // 
            this.tableLayoutPanelAdvanced.AutoSize = true;
            this.tableLayoutPanelAdvanced.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelAdvanced.ColumnCount = 1;
            this.tableLayoutPanelAdvanced.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelAdvanced.Controls.Add(this.groupBoxClick, 0, 0);
            this.tableLayoutPanelAdvanced.Controls.Add(this.groupBoxSizeAndLocation, 0, 1);
            this.tableLayoutPanelAdvanced.Controls.Add(this.groupBoxStaysOpen, 0, 2);
            this.tableLayoutPanelAdvanced.Controls.Add(this.groupBoxOpenSubmenus, 0, 3);
            this.tableLayoutPanelAdvanced.Controls.Add(this.buttonAdvancedDefault, 0, 4);
            this.tableLayoutPanelAdvanced.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAdvanced.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelAdvanced.Name = "tableLayoutPanelAdvanced";
            this.tableLayoutPanelAdvanced.RowCount = 5;
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdvanced.Size = new System.Drawing.Size(408, 376);
            this.tableLayoutPanelAdvanced.TabIndex = 0;
            // 
            // groupBoxClick
            // 
            this.groupBoxClick.AutoSize = true;
            this.groupBoxClick.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxClick.Controls.Add(this.tableLayoutPanelClick);
            this.groupBoxClick.Location = new System.Drawing.Point(3, 3);
            this.groupBoxClick.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxClick.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxClick.Name = "groupBoxClick";
            this.groupBoxClick.Size = new System.Drawing.Size(400, 47);
            this.groupBoxClick.TabIndex = 0;
            this.groupBoxClick.TabStop = false;
            this.groupBoxClick.Text = "groupBoxClick";
            // 
            // tableLayoutPanelClick
            // 
            this.tableLayoutPanelClick.AutoSize = true;
            this.tableLayoutPanelClick.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelClick.ColumnCount = 1;
            this.tableLayoutPanelClick.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelClick.Controls.Add(this.checkBoxOpenItemWithOneClick, 0, 0);
            this.tableLayoutPanelClick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelClick.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelClick.Name = "tableLayoutPanelClick";
            this.tableLayoutPanelClick.RowCount = 1;
            this.tableLayoutPanelClick.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelClick.Size = new System.Drawing.Size(394, 25);
            this.tableLayoutPanelClick.TabIndex = 0;
            // 
            // checkBoxOpenItemWithOneClick
            // 
            this.checkBoxOpenItemWithOneClick.AutoSize = true;
            this.checkBoxOpenItemWithOneClick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxOpenItemWithOneClick.Location = new System.Drawing.Point(3, 3);
            this.checkBoxOpenItemWithOneClick.Name = "checkBoxOpenItemWithOneClick";
            this.checkBoxOpenItemWithOneClick.Size = new System.Drawing.Size(388, 19);
            this.checkBoxOpenItemWithOneClick.TabIndex = 0;
            this.checkBoxOpenItemWithOneClick.Text = "checkBoxOpenItemWithOneClick";
            this.checkBoxOpenItemWithOneClick.UseVisualStyleBackColor = true;
            // 
            // groupBoxSizeAndLocation
            // 
            this.groupBoxSizeAndLocation.AutoSize = true;
            this.groupBoxSizeAndLocation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxSizeAndLocation.Controls.Add(this.tableLayoutPanelSizeAndLocation);
            this.groupBoxSizeAndLocation.Location = new System.Drawing.Point(3, 56);
            this.groupBoxSizeAndLocation.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxSizeAndLocation.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxSizeAndLocation.Name = "groupBoxSizeAndLocation";
            this.groupBoxSizeAndLocation.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.groupBoxSizeAndLocation.Size = new System.Drawing.Size(400, 79);
            this.groupBoxSizeAndLocation.TabIndex = 0;
            this.groupBoxSizeAndLocation.TabStop = false;
            this.groupBoxSizeAndLocation.Text = "groupBoxSizeAndLocation";
            // 
            // tableLayoutPanelSizeAndLocation
            // 
            this.tableLayoutPanelSizeAndLocation.AutoSize = true;
            this.tableLayoutPanelSizeAndLocation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSizeAndLocation.ColumnCount = 1;
            this.tableLayoutPanelSizeAndLocation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSizeAndLocation.Controls.Add(this.checkBoxAppearAtMouseLocation, 0, 0);
            this.tableLayoutPanelSizeAndLocation.Controls.Add(this.tableLayoutPanelMaxMenuWidth, 0, 1);
            this.tableLayoutPanelSizeAndLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSizeAndLocation.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelSizeAndLocation.Name = "tableLayoutPanelSizeAndLocation";
            this.tableLayoutPanelSizeAndLocation.RowCount = 2;
            this.tableLayoutPanelSizeAndLocation.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSizeAndLocation.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSizeAndLocation.Size = new System.Drawing.Size(394, 54);
            this.tableLayoutPanelSizeAndLocation.TabIndex = 0;
            // 
            // checkBoxAppearAtMouseLocation
            // 
            this.checkBoxAppearAtMouseLocation.AutoSize = true;
            this.checkBoxAppearAtMouseLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxAppearAtMouseLocation.Location = new System.Drawing.Point(3, 3);
            this.checkBoxAppearAtMouseLocation.Name = "checkBoxAppearAtMouseLocation";
            this.checkBoxAppearAtMouseLocation.Size = new System.Drawing.Size(388, 19);
            this.checkBoxAppearAtMouseLocation.TabIndex = 0;
            this.checkBoxAppearAtMouseLocation.Text = "checkBoxAppearAtMouseLocation";
            this.checkBoxAppearAtMouseLocation.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelMaxMenuWidth
            // 
            this.tableLayoutPanelMaxMenuWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMaxMenuWidth.AutoSize = true;
            this.tableLayoutPanelMaxMenuWidth.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMaxMenuWidth.ColumnCount = 2;
            this.tableLayoutPanelMaxMenuWidth.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMaxMenuWidth.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMaxMenuWidth.Controls.Add(this.numericUpDownMenuWidth, 0, 0);
            this.tableLayoutPanelMaxMenuWidth.Controls.Add(this.labelMaxMenuWidth, 1, 0);
            this.tableLayoutPanelMaxMenuWidth.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanelMaxMenuWidth.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMaxMenuWidth.Name = "tableLayoutPanelMaxMenuWidth";
            this.tableLayoutPanelMaxMenuWidth.RowCount = 1;
            this.tableLayoutPanelMaxMenuWidth.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMaxMenuWidth.Size = new System.Drawing.Size(394, 29);
            this.tableLayoutPanelMaxMenuWidth.TabIndex = 0;
            // 
            // numericUpDownMenuWidth
            // 
            this.numericUpDownMenuWidth.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownMenuWidth.Name = "numericUpDownMenuWidth";
            this.numericUpDownMenuWidth.Size = new System.Drawing.Size(55, 23);
            this.numericUpDownMenuWidth.TabIndex = 1;
            // 
            // labelMaxMenuWidth
            // 
            this.labelMaxMenuWidth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMaxMenuWidth.AutoSize = true;
            this.labelMaxMenuWidth.Location = new System.Drawing.Point(64, 7);
            this.labelMaxMenuWidth.MaximumSize = new System.Drawing.Size(330, 0);
            this.labelMaxMenuWidth.Name = "labelMaxMenuWidth";
            this.labelMaxMenuWidth.Size = new System.Drawing.Size(118, 15);
            this.labelMaxMenuWidth.TabIndex = 0;
            this.labelMaxMenuWidth.Text = "labelMaxMenuWidth";
            // 
            // groupBoxStaysOpen
            // 
            this.groupBoxStaysOpen.AutoSize = true;
            this.groupBoxStaysOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxStaysOpen.Controls.Add(this.tableLayoutPanelStaysOpen);
            this.groupBoxStaysOpen.Location = new System.Drawing.Point(3, 141);
            this.groupBoxStaysOpen.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxStaysOpen.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxStaysOpen.Name = "groupBoxStaysOpen";
            this.groupBoxStaysOpen.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.groupBoxStaysOpen.Size = new System.Drawing.Size(400, 104);
            this.groupBoxStaysOpen.TabIndex = 0;
            this.groupBoxStaysOpen.TabStop = false;
            this.groupBoxStaysOpen.Text = "groupBoxStaysOpen";
            // 
            // tableLayoutPanelStaysOpen
            // 
            this.tableLayoutPanelStaysOpen.AutoSize = true;
            this.tableLayoutPanelStaysOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelStaysOpen.ColumnCount = 1;
            this.tableLayoutPanelStaysOpen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStaysOpen.Controls.Add(this.checkBoxStayOpenWhenItemClicked, 0, 0);
            this.tableLayoutPanelStaysOpen.Controls.Add(this.checkBoxStayOpenWhenFocusLost, 0, 1);
            this.tableLayoutPanelStaysOpen.Controls.Add(this.tableLayoutPanelTimeUntilCloses, 0, 2);
            this.tableLayoutPanelStaysOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelStaysOpen.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelStaysOpen.Name = "tableLayoutPanelStaysOpen";
            this.tableLayoutPanelStaysOpen.RowCount = 3;
            this.tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStaysOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStaysOpen.Size = new System.Drawing.Size(394, 79);
            this.tableLayoutPanelStaysOpen.TabIndex = 0;
            // 
            // checkBoxStayOpenWhenItemClicked
            // 
            this.checkBoxStayOpenWhenItemClicked.AutoSize = true;
            this.checkBoxStayOpenWhenItemClicked.Checked = true;
            this.checkBoxStayOpenWhenItemClicked.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStayOpenWhenItemClicked.Location = new System.Drawing.Point(3, 3);
            this.checkBoxStayOpenWhenItemClicked.Name = "checkBoxStayOpenWhenItemClicked";
            this.checkBoxStayOpenWhenItemClicked.Size = new System.Drawing.Size(222, 19);
            this.checkBoxStayOpenWhenItemClicked.TabIndex = 0;
            this.checkBoxStayOpenWhenItemClicked.Text = "checkBoxStayOpenWhenItemClicked";
            this.checkBoxStayOpenWhenItemClicked.UseVisualStyleBackColor = true;
            // 
            // checkBoxStayOpenWhenFocusLost
            // 
            this.checkBoxStayOpenWhenFocusLost.AutoSize = true;
            this.checkBoxStayOpenWhenFocusLost.Checked = true;
            this.checkBoxStayOpenWhenFocusLost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStayOpenWhenFocusLost.Location = new System.Drawing.Point(3, 28);
            this.checkBoxStayOpenWhenFocusLost.Name = "checkBoxStayOpenWhenFocusLost";
            this.checkBoxStayOpenWhenFocusLost.Size = new System.Drawing.Size(212, 19);
            this.checkBoxStayOpenWhenFocusLost.TabIndex = 0;
            this.checkBoxStayOpenWhenFocusLost.Text = "checkBoxStayOpenWhenFocusLost";
            this.checkBoxStayOpenWhenFocusLost.UseVisualStyleBackColor = true;
            this.checkBoxStayOpenWhenFocusLost.CheckedChanged += new System.EventHandler(this.CheckBoxStayOpenWhenFocusLost_CheckedChanged);
            // 
            // tableLayoutPanelTimeUntilCloses
            // 
            this.tableLayoutPanelTimeUntilCloses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelTimeUntilCloses.AutoSize = true;
            this.tableLayoutPanelTimeUntilCloses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelTimeUntilCloses.ColumnCount = 2;
            this.tableLayoutPanelTimeUntilCloses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTimeUntilCloses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTimeUntilCloses.Controls.Add(this.labelTimeUntilCloses, 1, 0);
            this.tableLayoutPanelTimeUntilCloses.Controls.Add(this.numericUpDownTimeUntilClose, 0, 0);
            this.tableLayoutPanelTimeUntilCloses.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanelTimeUntilCloses.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelTimeUntilCloses.Name = "tableLayoutPanelTimeUntilCloses";
            this.tableLayoutPanelTimeUntilCloses.RowCount = 1;
            this.tableLayoutPanelTimeUntilCloses.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTimeUntilCloses.Size = new System.Drawing.Size(394, 29);
            this.tableLayoutPanelTimeUntilCloses.TabIndex = 0;
            // 
            // labelTimeUntilCloses
            // 
            this.labelTimeUntilCloses.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTimeUntilCloses.AutoSize = true;
            this.labelTimeUntilCloses.Location = new System.Drawing.Point(64, 7);
            this.labelTimeUntilCloses.MaximumSize = new System.Drawing.Size(330, 0);
            this.labelTimeUntilCloses.Name = "labelTimeUntilCloses";
            this.labelTimeUntilCloses.Size = new System.Drawing.Size(117, 15);
            this.labelTimeUntilCloses.TabIndex = 0;
            this.labelTimeUntilCloses.Text = "labelTimeUntilCloses";
            // 
            // numericUpDownTimeUntilClose
            // 
            this.numericUpDownTimeUntilClose.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownTimeUntilClose.Name = "numericUpDownTimeUntilClose";
            this.numericUpDownTimeUntilClose.Size = new System.Drawing.Size(55, 23);
            this.numericUpDownTimeUntilClose.TabIndex = 1;
            // 
            // groupBoxOpenSubmenus
            // 
            this.groupBoxOpenSubmenus.AutoSize = true;
            this.groupBoxOpenSubmenus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxOpenSubmenus.Controls.Add(this.tableLayoutPanelTimeUntilOpen);
            this.groupBoxOpenSubmenus.Location = new System.Drawing.Point(3, 251);
            this.groupBoxOpenSubmenus.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxOpenSubmenus.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxOpenSubmenus.Name = "groupBoxOpenSubmenus";
            this.groupBoxOpenSubmenus.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.groupBoxOpenSubmenus.Size = new System.Drawing.Size(400, 54);
            this.groupBoxOpenSubmenus.TabIndex = 0;
            this.groupBoxOpenSubmenus.TabStop = false;
            this.groupBoxOpenSubmenus.Text = "groupBoxOpenSubmenus";
            // 
            // tableLayoutPanelTimeUntilOpen
            // 
            this.tableLayoutPanelTimeUntilOpen.AutoSize = true;
            this.tableLayoutPanelTimeUntilOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelTimeUntilOpen.ColumnCount = 2;
            this.tableLayoutPanelTimeUntilOpen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTimeUntilOpen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTimeUntilOpen.Controls.Add(this.numericUpDownTimeUntilOpens, 0, 0);
            this.tableLayoutPanelTimeUntilOpen.Controls.Add(this.labelTimeUntilOpen, 1, 0);
            this.tableLayoutPanelTimeUntilOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTimeUntilOpen.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelTimeUntilOpen.Name = "tableLayoutPanelTimeUntilOpen";
            this.tableLayoutPanelTimeUntilOpen.RowCount = 1;
            this.tableLayoutPanelTimeUntilOpen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTimeUntilOpen.Size = new System.Drawing.Size(394, 29);
            this.tableLayoutPanelTimeUntilOpen.TabIndex = 0;
            // 
            // numericUpDownTimeUntilOpens
            // 
            this.numericUpDownTimeUntilOpens.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownTimeUntilOpens.Name = "numericUpDownTimeUntilOpens";
            this.numericUpDownTimeUntilOpens.Size = new System.Drawing.Size(55, 23);
            this.numericUpDownTimeUntilOpens.TabIndex = 2;
            // 
            // labelTimeUntilOpen
            // 
            this.labelTimeUntilOpen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTimeUntilOpen.AutoSize = true;
            this.labelTimeUntilOpen.Location = new System.Drawing.Point(64, 7);
            this.labelTimeUntilOpen.MaximumSize = new System.Drawing.Size(330, 0);
            this.labelTimeUntilOpen.Name = "labelTimeUntilOpen";
            this.labelTimeUntilOpen.Size = new System.Drawing.Size(112, 15);
            this.labelTimeUntilOpen.TabIndex = 0;
            this.labelTimeUntilOpen.Text = "labelTimeUntilOpen";
            // 
            // buttonAdvancedDefault
            // 
            this.buttonAdvancedDefault.AutoSize = true;
            this.buttonAdvancedDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAdvancedDefault.Location = new System.Drawing.Point(9, 317);
            this.buttonAdvancedDefault.Margin = new System.Windows.Forms.Padding(9, 9, 3, 9);
            this.buttonAdvancedDefault.MinimumSize = new System.Drawing.Size(75, 25);
            this.buttonAdvancedDefault.Name = "buttonAdvancedDefault";
            this.buttonAdvancedDefault.Size = new System.Drawing.Size(144, 25);
            this.buttonAdvancedDefault.TabIndex = 0;
            this.buttonAdvancedDefault.Text = "buttonAdvancedDefault";
            this.buttonAdvancedDefault.UseVisualStyleBackColor = true;
            this.buttonAdvancedDefault.Click += new System.EventHandler(this.ButtonAdvancedDefault_Click);
            // 
            // tabPageCustomize
            // 
            this.tabPageCustomize.Controls.Add(this.tableLayoutPanelCustomize);
            this.tabPageCustomize.Location = new System.Drawing.Point(4, 24);
            this.tabPageCustomize.Name = "tabPageCustomize";
            this.tabPageCustomize.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustomize.Size = new System.Drawing.Size(414, 382);
            this.tabPageCustomize.TabIndex = 0;
            this.tabPageCustomize.Text = "tabPageCustomize";
            this.tabPageCustomize.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelCustomize
            // 
            this.tableLayoutPanelCustomize.AutoSize = true;
            this.tableLayoutPanelCustomize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelCustomize.ColumnCount = 1;
            this.tableLayoutPanelCustomize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelCustomize.Controls.Add(this.groupBoxDarkMode, 0, 0);
            this.tableLayoutPanelCustomize.Controls.Add(this.groupBoxColors, 0, 1);
            this.tableLayoutPanelCustomize.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelCustomize.Name = "tableLayoutPanelCustomize";
            this.tableLayoutPanelCustomize.RowCount = 2;
            this.tableLayoutPanelCustomize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCustomize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCustomize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCustomize.Size = new System.Drawing.Size(406, 371);
            this.tableLayoutPanelCustomize.TabIndex = 0;
            // 
            // groupBoxDarkMode
            // 
            this.groupBoxDarkMode.AutoSize = true;
            this.groupBoxDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxDarkMode.Controls.Add(this.tableLayoutPanelDarkMode);
            this.groupBoxDarkMode.Location = new System.Drawing.Point(3, 3);
            this.groupBoxDarkMode.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxDarkMode.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxDarkMode.Name = "groupBoxDarkMode";
            this.groupBoxDarkMode.Size = new System.Drawing.Size(400, 47);
            this.groupBoxDarkMode.TabIndex = 0;
            this.groupBoxDarkMode.TabStop = false;
            this.groupBoxDarkMode.Text = "groupBoxDarkMode";
            // 
            // tableLayoutPanelDarkMode
            // 
            this.tableLayoutPanelDarkMode.AutoSize = true;
            this.tableLayoutPanelDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelDarkMode.ColumnCount = 1;
            this.tableLayoutPanelDarkMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 444F));
            this.tableLayoutPanelDarkMode.Controls.Add(this.checkBoxDarkModeAlwaysOn, 0, 0);
            this.tableLayoutPanelDarkMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDarkMode.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelDarkMode.Name = "tableLayoutPanelDarkMode";
            this.tableLayoutPanelDarkMode.RowCount = 2;
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelDarkMode.Size = new System.Drawing.Size(394, 25);
            this.tableLayoutPanelDarkMode.TabIndex = 0;
            // 
            // checkBoxDarkModeAlwaysOn
            // 
            this.checkBoxDarkModeAlwaysOn.AutoSize = true;
            this.checkBoxDarkModeAlwaysOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxDarkModeAlwaysOn.Location = new System.Drawing.Point(3, 3);
            this.checkBoxDarkModeAlwaysOn.Name = "checkBoxDarkModeAlwaysOn";
            this.checkBoxDarkModeAlwaysOn.Size = new System.Drawing.Size(438, 19);
            this.checkBoxDarkModeAlwaysOn.TabIndex = 0;
            this.checkBoxDarkModeAlwaysOn.Text = "checkBoxDarkModeAlwaysOn";
            this.checkBoxDarkModeAlwaysOn.UseVisualStyleBackColor = true;
            // 
            // groupBoxColors
            // 
            this.groupBoxColors.AutoSize = true;
            this.groupBoxColors.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxColors.Controls.Add(this.tableLayoutPanelColorsAndDefault);
            this.groupBoxColors.Location = new System.Drawing.Point(3, 56);
            this.groupBoxColors.MaximumSize = new System.Drawing.Size(400, 0);
            this.groupBoxColors.MinimumSize = new System.Drawing.Size(400, 0);
            this.groupBoxColors.Name = "groupBoxColors";
            this.groupBoxColors.Size = new System.Drawing.Size(400, 312);
            this.groupBoxColors.TabIndex = 0;
            this.groupBoxColors.TabStop = false;
            this.groupBoxColors.Text = "groupBoxColors";
            // 
            // tableLayoutPanelColorsAndDefault
            // 
            this.tableLayoutPanelColorsAndDefault.AutoSize = true;
            this.tableLayoutPanelColorsAndDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelColorsAndDefault.ColumnCount = 1;
            this.tableLayoutPanelColorsAndDefault.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 444F));
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.labelPasteHtmlColorCodeOrDoubleClickIntoField, 0, 0);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelColors, 0, 1);
            this.tableLayoutPanelColorsAndDefault.Controls.Add(this.tableLayoutPanelColorsDefault, 0, 2);
            this.tableLayoutPanelColorsAndDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelColorsAndDefault.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelColorsAndDefault.Name = "tableLayoutPanelColorsAndDefault";
            this.tableLayoutPanelColorsAndDefault.RowCount = 3;
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsAndDefault.Size = new System.Drawing.Size(394, 290);
            this.tableLayoutPanelColorsAndDefault.TabIndex = 0;
            // 
            // labelPasteHtmlColorCodeOrDoubleClickIntoField
            // 
            this.labelPasteHtmlColorCodeOrDoubleClickIntoField.AutoSize = true;
            this.labelPasteHtmlColorCodeOrDoubleClickIntoField.Location = new System.Drawing.Point(3, 0);
            this.labelPasteHtmlColorCodeOrDoubleClickIntoField.MaximumSize = new System.Drawing.Size(385, 0);
            this.labelPasteHtmlColorCodeOrDoubleClickIntoField.Name = "labelPasteHtmlColorCodeOrDoubleClickIntoField";
            this.labelPasteHtmlColorCodeOrDoubleClickIntoField.Size = new System.Drawing.Size(267, 15);
            this.labelPasteHtmlColorCodeOrDoubleClickIntoField.TabIndex = 1;
            this.labelPasteHtmlColorCodeOrDoubleClickIntoField.Text = "labelPasteHtmlColorCodeOrDoubleClickIntoField";
            // 
            // tableLayoutPanelColors
            // 
            this.tableLayoutPanelColors.AutoSize = true;
            this.tableLayoutPanelColors.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelColors.ColumnCount = 3;
            this.tableLayoutPanelColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelColors.Controls.Add(this.textBoxColorWarning, 0, 7);
            this.tableLayoutPanelColors.Controls.Add(this.labelWarning, 2, 7);
            this.tableLayoutPanelColors.Controls.Add(this.textBoxColorDarkModeWarning, 1, 7);
            this.tableLayoutPanelColors.Controls.Add(this.textBoxColorSelectedItemBorder, 0, 6);
            this.tableLayoutPanelColors.Controls.Add(this.textBoxColorDarkModeSelectedItemBorder, 1, 6);
            this.tableLayoutPanelColors.Controls.Add(this.textBoxColorDarkModeSelecetedItem, 1, 5);
            this.tableLayoutPanelColors.Controls.Add(this.textBoxColorSelectedItem, 0, 5);
            this.tableLayoutPanelColors.Controls.Add(this.textBoxColorOpenFolderBorder, 0, 4);
            this.tableLayoutPanelColors.Controls.Add(this.textBoxColorDarkModeOpenFolderBorder, 1, 4);
            this.tableLayoutPanelColors.Controls.Add(this.textBoxColorDarkModeOpenFolder, 1, 3);
            this.tableLayoutPanelColors.Controls.Add(this.textBoxColorOpenFolder, 0, 3);
            this.tableLayoutPanelColors.Controls.Add(this.textBoxColorDarkModeTitle, 1, 0);
            this.tableLayoutPanelColors.Controls.Add(this.textBoxColorTitle, 0, 0);
            this.tableLayoutPanelColors.Controls.Add(this.labelTitle, 2, 0);
            this.tableLayoutPanelColors.Controls.Add(this.textBoxColorDarkModeSearchField, 1, 2);
            this.tableLayoutPanelColors.Controls.Add(this.textBoxColorSearchField, 0, 2);
            this.tableLayoutPanelColors.Controls.Add(this.textBoxColorDarkModeBackground, 1, 1);
            this.tableLayoutPanelColors.Controls.Add(this.textBoxColorBackground, 0, 1);
            this.tableLayoutPanelColors.Controls.Add(this.labelBackground, 2, 1);
            this.tableLayoutPanelColors.Controls.Add(this.labelSearchField, 2, 2);
            this.tableLayoutPanelColors.Controls.Add(this.labelOpenFolder, 2, 3);
            this.tableLayoutPanelColors.Controls.Add(this.labelOpenFolderBorder, 2, 4);
            this.tableLayoutPanelColors.Controls.Add(this.labelSelectedItem, 2, 5);
            this.tableLayoutPanelColors.Controls.Add(this.labelSelectedItemBorder, 2, 6);
            this.tableLayoutPanelColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelColors.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanelColors.Name = "tableLayoutPanelColors";
            this.tableLayoutPanelColors.RowCount = 8;
            this.tableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColors.Size = new System.Drawing.Size(438, 232);
            this.tableLayoutPanelColors.TabIndex = 1;
            // 
            // textBoxColorWarning
            // 
            this.textBoxColorWarning.Location = new System.Drawing.Point(3, 206);
            this.textBoxColorWarning.MaxLength = 12;
            this.textBoxColorWarning.Name = "textBoxColorWarning";
            this.textBoxColorWarning.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorWarning.TabIndex = 2;
            this.textBoxColorWarning.Text = "#ffffff";
            this.textBoxColorWarning.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorWarning.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // labelWarning
            // 
            this.labelWarning.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelWarning.AutoSize = true;
            this.labelWarning.Location = new System.Drawing.Point(153, 210);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(77, 15);
            this.labelWarning.TabIndex = 0;
            this.labelWarning.Text = "labelWarning";
            // 
            // textBoxColorDarkModeWarning
            // 
            this.textBoxColorDarkModeWarning.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxColorDarkModeWarning.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxColorDarkModeWarning.Location = new System.Drawing.Point(78, 206);
            this.textBoxColorDarkModeWarning.MaxLength = 12;
            this.textBoxColorDarkModeWarning.Name = "textBoxColorDarkModeWarning";
            this.textBoxColorDarkModeWarning.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorDarkModeWarning.TabIndex = 2;
            this.textBoxColorDarkModeWarning.Text = "#ffffff";
            this.textBoxColorDarkModeWarning.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorDarkModeWarning.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorSelectedItemBorder
            // 
            this.textBoxColorSelectedItemBorder.Location = new System.Drawing.Point(3, 177);
            this.textBoxColorSelectedItemBorder.MaxLength = 12;
            this.textBoxColorSelectedItemBorder.Name = "textBoxColorSelectedItemBorder";
            this.textBoxColorSelectedItemBorder.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorSelectedItemBorder.TabIndex = 2;
            this.textBoxColorSelectedItemBorder.Text = "#ffffff";
            this.textBoxColorSelectedItemBorder.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSelectedItemBorder.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorDarkModeSelectedItemBorder
            // 
            this.textBoxColorDarkModeSelectedItemBorder.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxColorDarkModeSelectedItemBorder.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxColorDarkModeSelectedItemBorder.Location = new System.Drawing.Point(78, 177);
            this.textBoxColorDarkModeSelectedItemBorder.MaxLength = 12;
            this.textBoxColorDarkModeSelectedItemBorder.Name = "textBoxColorDarkModeSelectedItemBorder";
            this.textBoxColorDarkModeSelectedItemBorder.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorDarkModeSelectedItemBorder.TabIndex = 2;
            this.textBoxColorDarkModeSelectedItemBorder.Text = "#ffffff";
            this.textBoxColorDarkModeSelectedItemBorder.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorDarkModeSelectedItemBorder.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorDarkModeSelecetedItem
            // 
            this.textBoxColorDarkModeSelecetedItem.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxColorDarkModeSelecetedItem.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxColorDarkModeSelecetedItem.Location = new System.Drawing.Point(78, 148);
            this.textBoxColorDarkModeSelecetedItem.MaxLength = 12;
            this.textBoxColorDarkModeSelecetedItem.Name = "textBoxColorDarkModeSelecetedItem";
            this.textBoxColorDarkModeSelecetedItem.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorDarkModeSelecetedItem.TabIndex = 2;
            this.textBoxColorDarkModeSelecetedItem.Text = "#ffffff";
            this.textBoxColorDarkModeSelecetedItem.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorDarkModeSelecetedItem.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorSelectedItem
            // 
            this.textBoxColorSelectedItem.Location = new System.Drawing.Point(3, 148);
            this.textBoxColorSelectedItem.MaxLength = 12;
            this.textBoxColorSelectedItem.Name = "textBoxColorSelectedItem";
            this.textBoxColorSelectedItem.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorSelectedItem.TabIndex = 2;
            this.textBoxColorSelectedItem.Text = "#ffffff";
            this.textBoxColorSelectedItem.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSelectedItem.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorOpenFolderBorder
            // 
            this.textBoxColorOpenFolderBorder.Location = new System.Drawing.Point(3, 119);
            this.textBoxColorOpenFolderBorder.Name = "textBoxColorOpenFolderBorder";
            this.textBoxColorOpenFolderBorder.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorOpenFolderBorder.TabIndex = 2;
            this.textBoxColorOpenFolderBorder.Text = "#ffffff";
            this.textBoxColorOpenFolderBorder.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorOpenFolderBorder.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorDarkModeOpenFolderBorder
            // 
            this.textBoxColorDarkModeOpenFolderBorder.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxColorDarkModeOpenFolderBorder.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxColorDarkModeOpenFolderBorder.Location = new System.Drawing.Point(78, 119);
            this.textBoxColorDarkModeOpenFolderBorder.Name = "textBoxColorDarkModeOpenFolderBorder";
            this.textBoxColorDarkModeOpenFolderBorder.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorDarkModeOpenFolderBorder.TabIndex = 2;
            this.textBoxColorDarkModeOpenFolderBorder.Text = "#ffffff";
            this.textBoxColorDarkModeOpenFolderBorder.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorDarkModeOpenFolderBorder.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorDarkModeOpenFolder
            // 
            this.textBoxColorDarkModeOpenFolder.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxColorDarkModeOpenFolder.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxColorDarkModeOpenFolder.Location = new System.Drawing.Point(78, 90);
            this.textBoxColorDarkModeOpenFolder.MaxLength = 12;
            this.textBoxColorDarkModeOpenFolder.Name = "textBoxColorDarkModeOpenFolder";
            this.textBoxColorDarkModeOpenFolder.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorDarkModeOpenFolder.TabIndex = 2;
            this.textBoxColorDarkModeOpenFolder.Text = "#ffffff";
            this.textBoxColorDarkModeOpenFolder.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorDarkModeOpenFolder.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorOpenFolder
            // 
            this.textBoxColorOpenFolder.Location = new System.Drawing.Point(3, 90);
            this.textBoxColorOpenFolder.MaxLength = 12;
            this.textBoxColorOpenFolder.Name = "textBoxColorOpenFolder";
            this.textBoxColorOpenFolder.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorOpenFolder.TabIndex = 2;
            this.textBoxColorOpenFolder.Text = "#ffffff";
            this.textBoxColorOpenFolder.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorOpenFolder.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorDarkModeTitle
            // 
            this.textBoxColorDarkModeTitle.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxColorDarkModeTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxColorDarkModeTitle.Location = new System.Drawing.Point(78, 3);
            this.textBoxColorDarkModeTitle.MaxLength = 12;
            this.textBoxColorDarkModeTitle.Name = "textBoxColorDarkModeTitle";
            this.textBoxColorDarkModeTitle.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorDarkModeTitle.TabIndex = 2;
            this.textBoxColorDarkModeTitle.Text = "#ffffff";
            this.textBoxColorDarkModeTitle.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorDarkModeTitle.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorTitle
            // 
            this.textBoxColorTitle.Location = new System.Drawing.Point(3, 3);
            this.textBoxColorTitle.MaxLength = 12;
            this.textBoxColorTitle.Name = "textBoxColorTitle";
            this.textBoxColorTitle.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorTitle.TabIndex = 2;
            this.textBoxColorTitle.Text = "#ffffff";
            this.textBoxColorTitle.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorTitle.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(153, 7);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(54, 15);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "labelTitle";
            // 
            // textBoxColorDarkModeSearchField
            // 
            this.textBoxColorDarkModeSearchField.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxColorDarkModeSearchField.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxColorDarkModeSearchField.Location = new System.Drawing.Point(78, 61);
            this.textBoxColorDarkModeSearchField.MaxLength = 12;
            this.textBoxColorDarkModeSearchField.Name = "textBoxColorDarkModeSearchField";
            this.textBoxColorDarkModeSearchField.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorDarkModeSearchField.TabIndex = 2;
            this.textBoxColorDarkModeSearchField.Text = "#ffffff";
            this.textBoxColorDarkModeSearchField.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorDarkModeSearchField.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorSearchField
            // 
            this.textBoxColorSearchField.Location = new System.Drawing.Point(3, 61);
            this.textBoxColorSearchField.MaxLength = 12;
            this.textBoxColorSearchField.Name = "textBoxColorSearchField";
            this.textBoxColorSearchField.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorSearchField.TabIndex = 2;
            this.textBoxColorSearchField.Text = "#ffffff";
            this.textBoxColorSearchField.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSearchField.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorDarkModeBackground
            // 
            this.textBoxColorDarkModeBackground.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxColorDarkModeBackground.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxColorDarkModeBackground.Location = new System.Drawing.Point(78, 32);
            this.textBoxColorDarkModeBackground.MaxLength = 12;
            this.textBoxColorDarkModeBackground.Name = "textBoxColorDarkModeBackground";
            this.textBoxColorDarkModeBackground.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorDarkModeBackground.TabIndex = 2;
            this.textBoxColorDarkModeBackground.Text = "#ffffff";
            this.textBoxColorDarkModeBackground.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorDarkModeBackground.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorBackground
            // 
            this.textBoxColorBackground.Location = new System.Drawing.Point(3, 32);
            this.textBoxColorBackground.MaxLength = 12;
            this.textBoxColorBackground.Name = "textBoxColorBackground";
            this.textBoxColorBackground.Size = new System.Drawing.Size(69, 23);
            this.textBoxColorBackground.TabIndex = 2;
            this.textBoxColorBackground.Text = "#ffffff";
            this.textBoxColorBackground.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorBackground.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // labelBackground
            // 
            this.labelBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelBackground.AutoSize = true;
            this.labelBackground.Location = new System.Drawing.Point(153, 36);
            this.labelBackground.Name = "labelBackground";
            this.labelBackground.Size = new System.Drawing.Size(96, 15);
            this.labelBackground.TabIndex = 0;
            this.labelBackground.Text = "labelBackground";
            // 
            // labelSearchField
            // 
            this.labelSearchField.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSearchField.AutoSize = true;
            this.labelSearchField.Location = new System.Drawing.Point(153, 65);
            this.labelSearchField.Name = "labelSearchField";
            this.labelSearchField.Size = new System.Drawing.Size(92, 15);
            this.labelSearchField.TabIndex = 0;
            this.labelSearchField.Text = "labelSearchField";
            // 
            // labelOpenFolder
            // 
            this.labelOpenFolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelOpenFolder.AutoSize = true;
            this.labelOpenFolder.Location = new System.Drawing.Point(153, 94);
            this.labelOpenFolder.Name = "labelOpenFolder";
            this.labelOpenFolder.Size = new System.Drawing.Size(94, 15);
            this.labelOpenFolder.TabIndex = 0;
            this.labelOpenFolder.Text = "labelOpenFolder";
            // 
            // labelOpenFolderBorder
            // 
            this.labelOpenFolderBorder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelOpenFolderBorder.AutoSize = true;
            this.labelOpenFolderBorder.Location = new System.Drawing.Point(153, 123);
            this.labelOpenFolderBorder.Name = "labelOpenFolderBorder";
            this.labelOpenFolderBorder.Size = new System.Drawing.Size(129, 15);
            this.labelOpenFolderBorder.TabIndex = 0;
            this.labelOpenFolderBorder.Text = "labelOpenFolderBorder";
            // 
            // labelSelectedItem
            // 
            this.labelSelectedItem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSelectedItem.AutoSize = true;
            this.labelSelectedItem.Location = new System.Drawing.Point(153, 152);
            this.labelSelectedItem.Name = "labelSelectedItem";
            this.labelSelectedItem.Size = new System.Drawing.Size(100, 15);
            this.labelSelectedItem.TabIndex = 0;
            this.labelSelectedItem.Text = "labelSelectedItem";
            // 
            // labelSelectedItemBorder
            // 
            this.labelSelectedItemBorder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSelectedItemBorder.AutoSize = true;
            this.labelSelectedItemBorder.Location = new System.Drawing.Point(153, 181);
            this.labelSelectedItemBorder.Name = "labelSelectedItemBorder";
            this.labelSelectedItemBorder.Size = new System.Drawing.Size(135, 15);
            this.labelSelectedItemBorder.TabIndex = 0;
            this.labelSelectedItemBorder.Text = "labelSelectedItemBorder";
            // 
            // tableLayoutPanelColorsDefault
            // 
            this.tableLayoutPanelColorsDefault.AutoSize = true;
            this.tableLayoutPanelColorsDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelColorsDefault.ColumnCount = 2;
            this.tableLayoutPanelColorsDefault.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelColorsDefault.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelColorsDefault.Controls.Add(this.buttonDefaultColors, 0, 0);
            this.tableLayoutPanelColorsDefault.Controls.Add(this.buttonDefaultColorsDark, 1, 0);
            this.tableLayoutPanelColorsDefault.Location = new System.Drawing.Point(3, 256);
            this.tableLayoutPanelColorsDefault.Name = "tableLayoutPanelColorsDefault";
            this.tableLayoutPanelColorsDefault.RowCount = 1;
            this.tableLayoutPanelColorsDefault.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColorsDefault.Size = new System.Drawing.Size(285, 31);
            this.tableLayoutPanelColorsDefault.TabIndex = 4;
            // 
            // buttonDefaultColors
            // 
            this.buttonDefaultColors.AutoSize = true;
            this.buttonDefaultColors.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDefaultColors.Location = new System.Drawing.Point(2, 3);
            this.buttonDefaultColors.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.buttonDefaultColors.MinimumSize = new System.Drawing.Size(75, 25);
            this.buttonDefaultColors.Name = "buttonDefaultColors";
            this.buttonDefaultColors.Size = new System.Drawing.Size(125, 25);
            this.buttonDefaultColors.TabIndex = 3;
            this.buttonDefaultColors.Text = "buttonDefaultColors";
            this.buttonDefaultColors.UseVisualStyleBackColor = true;
            this.buttonDefaultColors.Click += new System.EventHandler(this.ButtonDefaultColors_Click);
            // 
            // buttonDefaultColorsDark
            // 
            this.buttonDefaultColorsDark.AutoSize = true;
            this.buttonDefaultColorsDark.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDefaultColorsDark.Location = new System.Drawing.Point(133, 3);
            this.buttonDefaultColorsDark.MinimumSize = new System.Drawing.Size(75, 25);
            this.buttonDefaultColorsDark.Name = "buttonDefaultColorsDark";
            this.buttonDefaultColorsDark.Size = new System.Drawing.Size(149, 25);
            this.buttonDefaultColorsDark.TabIndex = 3;
            this.buttonDefaultColorsDark.Text = "buttonDefaultColorsDark";
            this.buttonDefaultColorsDark.UseVisualStyleBackColor = true;
            this.buttonDefaultColorsDark.Click += new System.EventHandler(this.ButtonDefaultColorsDark_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1115, 520);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.tableLayoutPanelBottom.ResumeLayout(false);
            this.tableLayoutPanelBottom.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tableLayoutPanelGeneral.ResumeLayout(false);
            this.tableLayoutPanelGeneral.PerformLayout();
            this.groupBoxFolder.ResumeLayout(false);
            this.groupBoxFolder.PerformLayout();
            this.tableLayoutPanelFolder.ResumeLayout(false);
            this.tableLayoutPanelFolder.PerformLayout();
            this.tableLayoutPanelChangeFolder.ResumeLayout(false);
            this.tableLayoutPanelChangeFolder.PerformLayout();
            this.groupBoxUSB.ResumeLayout(false);
            this.groupBoxUSB.PerformLayout();
            this.tableLayoutPanelUSB.ResumeLayout(false);
            this.tableLayoutPanelUSB.PerformLayout();
            this.tableLayoutPanelRelativeFolderOpenAssembly.ResumeLayout(false);
            this.tableLayoutPanelRelativeFolderOpenAssembly.PerformLayout();
            this.groupBoxAutostart.ResumeLayout(false);
            this.groupBoxAutostart.PerformLayout();
            this.tableLayoutPanelAutostart.ResumeLayout(false);
            this.tableLayoutPanelAutostart.PerformLayout();
            this.groupBoxHotkey.ResumeLayout(false);
            this.groupBoxHotkey.PerformLayout();
            this.tableLayoutPanelHotkey.ResumeLayout(false);
            this.tableLayoutPanelHotkey.PerformLayout();
            this.groupBoxLanguage.ResumeLayout(false);
            this.groupBoxLanguage.PerformLayout();
            this.tableLayoutPanelLanguage.ResumeLayout(false);
            this.tabPageAdvanced.ResumeLayout(false);
            this.tabPageAdvanced.PerformLayout();
            this.tableLayoutPanelAdvanced.ResumeLayout(false);
            this.tableLayoutPanelAdvanced.PerformLayout();
            this.groupBoxClick.ResumeLayout(false);
            this.groupBoxClick.PerformLayout();
            this.tableLayoutPanelClick.ResumeLayout(false);
            this.tableLayoutPanelClick.PerformLayout();
            this.groupBoxSizeAndLocation.ResumeLayout(false);
            this.groupBoxSizeAndLocation.PerformLayout();
            this.tableLayoutPanelSizeAndLocation.ResumeLayout(false);
            this.tableLayoutPanelSizeAndLocation.PerformLayout();
            this.tableLayoutPanelMaxMenuWidth.ResumeLayout(false);
            this.tableLayoutPanelMaxMenuWidth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMenuWidth)).EndInit();
            this.groupBoxStaysOpen.ResumeLayout(false);
            this.groupBoxStaysOpen.PerformLayout();
            this.tableLayoutPanelStaysOpen.ResumeLayout(false);
            this.tableLayoutPanelStaysOpen.PerformLayout();
            this.tableLayoutPanelTimeUntilCloses.ResumeLayout(false);
            this.tableLayoutPanelTimeUntilCloses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeUntilClose)).EndInit();
            this.groupBoxOpenSubmenus.ResumeLayout(false);
            this.groupBoxOpenSubmenus.PerformLayout();
            this.tableLayoutPanelTimeUntilOpen.ResumeLayout(false);
            this.tableLayoutPanelTimeUntilOpen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeUntilOpens)).EndInit();
            this.tabPageCustomize.ResumeLayout(false);
            this.tabPageCustomize.PerformLayout();
            this.tableLayoutPanelCustomize.ResumeLayout(false);
            this.tableLayoutPanelCustomize.PerformLayout();
            this.groupBoxDarkMode.ResumeLayout(false);
            this.groupBoxDarkMode.PerformLayout();
            this.tableLayoutPanelDarkMode.ResumeLayout(false);
            this.tableLayoutPanelDarkMode.PerformLayout();
            this.groupBoxColors.ResumeLayout(false);
            this.groupBoxColors.PerformLayout();
            this.tableLayoutPanelColorsAndDefault.ResumeLayout(false);
            this.tableLayoutPanelColorsAndDefault.PerformLayout();
            this.tableLayoutPanelColors.ResumeLayout(false);
            this.tableLayoutPanelColors.PerformLayout();
            this.tableLayoutPanelColorsDefault.ResumeLayout(false);
            this.tableLayoutPanelColorsDefault.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBottom;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        //private System.Windows.Forms.TextBox textBoxHotkey;
        private HotkeyControl textBoxHotkey; 
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.CheckBox checkBoxAutostart;
        private System.Windows.Forms.Button buttonChangeFolder;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabPage tabPageCustomize;
        private System.Windows.Forms.CheckBox checkBoxOpenItemWithOneClick;
        private System.Windows.Forms.CheckBox checkBoxDarkModeAlwaysOn;
        private System.Windows.Forms.TabPage tabPageAdvanced;
        private System.Windows.Forms.Label labelMaxMenuWidth;
        private System.Windows.Forms.Label labelTimeUntilOpen;
        private System.Windows.Forms.CheckBox checkBoxStayOpenWhenFocusLost;
        private System.Windows.Forms.GroupBox groupBoxFolder;
        private System.Windows.Forms.GroupBox groupBoxAutostart;
        private System.Windows.Forms.GroupBox groupBoxHotkey;
        private System.Windows.Forms.GroupBox groupBoxLanguage;
        private System.Windows.Forms.GroupBox groupBoxStaysOpen;
        private System.Windows.Forms.GroupBox groupBoxClick;
        private System.Windows.Forms.GroupBox groupBoxSizeAndLocation;
        private System.Windows.Forms.GroupBox groupBoxOpenSubmenus;
        private System.Windows.Forms.GroupBox groupBoxDarkMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDarkMode;
        private System.Windows.Forms.GroupBox groupBoxColors;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelClick;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelColorsAndDefault;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCustomize;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStaysOpen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTimeUntilCloses;
        private System.Windows.Forms.Label labelTimeUntilCloses;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAdvanced;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSizeAndLocation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMaxMenuWidth;
        private System.Windows.Forms.CheckBox checkBoxAppearAtMouseLocation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTimeUntilOpen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHotkey;
        private System.Windows.Forms.Button buttonHotkeyDefault;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLanguage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelChangeFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAutostart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGeneral;
        private System.Windows.Forms.TextBox textBoxHotkeyPlaceholder;
        private System.Windows.Forms.Button buttonAdvancedDefault;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeUntilClose;
        private System.Windows.Forms.NumericUpDown numericUpDownMenuWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeUntilOpens;
        private System.Windows.Forms.CheckBox checkBoxStayOpenWhenItemClicked;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button buttonDefaultColorsDark;
        private System.Windows.Forms.TextBox textBoxColorOpenFolder;
        private System.Windows.Forms.TextBox textBoxColorWarning;
        private System.Windows.Forms.TextBox textBoxColorBackground;
        private System.Windows.Forms.TextBox textBoxColorTitle;
        private System.Windows.Forms.TextBox textBoxColorSelectedItem;
        private System.Windows.Forms.TextBox textBoxColorOpenFolderBorder;
        private System.Windows.Forms.TextBox textBoxColorDarkModeWarning;
        private System.Windows.Forms.TextBox textBoxColorDarkModeBackground;
        private System.Windows.Forms.TextBox textBoxColorDarkModeTitle;
        private System.Windows.Forms.TextBox textBoxColorDarkModeSelecetedItem;
        private System.Windows.Forms.TextBox textBoxColorDarkModeOpenFolder;
        private System.Windows.Forms.TextBox textBoxColorDarkModeOpenFolderBorder;
        private System.Windows.Forms.TextBox textBoxColorSelectedItemBorder;
        private System.Windows.Forms.TextBox textBoxColorDarkModeSelectedItemBorder;
        private System.Windows.Forms.TextBox textBoxColorDarkModeSearchField;
        private System.Windows.Forms.Button buttonDefaultColors;
        private System.Windows.Forms.TextBox textBoxColorSearchField;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelColors;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelBackground;
        private System.Windows.Forms.Label labelSearchField;
        private System.Windows.Forms.Label labelOpenFolder;
        private System.Windows.Forms.Label labelOpenFolderBorder;
        private System.Windows.Forms.Label labelSelectedItem;
        private System.Windows.Forms.Label labelSelectedItemBorder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelColorsDefault;
        private System.Windows.Forms.Label labelPasteHtmlColorCodeOrDoubleClickIntoField;
        private System.Windows.Forms.CheckBox checkBoxStoreConfigAtAssemblyLocation;
        private System.Windows.Forms.GroupBox groupBoxUSB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelUSB;
        private System.Windows.Forms.Button buttonChangeRelativeFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRelativeFolderOpenAssembly;
        private System.Windows.Forms.Button buttonOpenAssemblyLocation;
    }
}