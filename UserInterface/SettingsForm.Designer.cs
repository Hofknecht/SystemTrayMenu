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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxFolder = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelFolder = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelChangeFolder = new System.Windows.Forms.TableLayoutPanel();
            this.buttonChangeFolder = new System.Windows.Forms.Button();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
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
            this.groupBoxColors = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelColors = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelMenuMenu = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxColorTitle = new System.Windows.Forms.TextBox();
            this.textBoxColorWarning = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelMenuSelectedMenu = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxColorSelected = new System.Windows.Forms.TextBox();
            this.textBoxColorSelectedBorder = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelMenuOpenMenu = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxColorOpenMenu = new System.Windows.Forms.TextBox();
            this.textBoxColorOpenMenuBorder = new System.Windows.Forms.TextBox();
            this.textBoxColorMain = new System.Windows.Forms.TextBox();
            this.textBoxColorSearch = new System.Windows.Forms.TextBox();
            this.buttonDefaultColors = new System.Windows.Forms.Button();
            this.groupBoxDarkMode = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelDarkMode = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxDarkModeAlwaysOn = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelMenuDarkMenu = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxColorDarkModeTitle = new System.Windows.Forms.TextBox();
            this.textBoxColorDarkModeWarning = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelMenuDarkSelectedMenu = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxColorDarkModeSeleceted = new System.Windows.Forms.TextBox();
            this.textBoxColorDarkModeSelectedBorder = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelMenuDarkOpenMenu = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxColorDarkModeOpenMenu = new System.Windows.Forms.TextBox();
            this.textBoxColorDarkModeModeOpenMenuBorder = new System.Windows.Forms.TextBox();
            this.textBoxColorDarkModeMain = new System.Windows.Forms.TextBox();
            this.textBoxColorDarkModeSearch = new System.Windows.Forms.TextBox();
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
            this.groupBoxColors.SuspendLayout();
            this.tableLayoutPanelColors.SuspendLayout();
            this.tableLayoutPanelMenuMenu.SuspendLayout();
            this.tableLayoutPanelMenuSelectedMenu.SuspendLayout();
            this.tableLayoutPanelMenuOpenMenu.SuspendLayout();
            this.groupBoxDarkMode.SuspendLayout();
            this.tableLayoutPanelDarkMode.SuspendLayout();
            this.tableLayoutPanelMenuDarkMenu.SuspendLayout();
            this.tableLayoutPanelMenuDarkSelectedMenu.SuspendLayout();
            this.tableLayoutPanelMenuDarkOpenMenu.SuspendLayout();
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
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(476, 467);
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
            this.tableLayoutPanelBottom.Location = new System.Drawing.Point(3, 439);
            this.tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            this.tableLayoutPanelBottom.RowCount = 1;
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBottom.Size = new System.Drawing.Size(470, 25);
            this.tableLayoutPanelBottom.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.AutoSize = true;
            this.buttonOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(311, 0);
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
            this.buttonCancel.Location = new System.Drawing.Point(392, 0);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
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
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 2;
            this.tabControl.Size = new System.Drawing.Size(470, 430);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.tableLayoutPanelGeneral);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 24);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(462, 402);
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
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxAutostart, 0, 1);
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxHotkey, 0, 2);
            this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxLanguage, 0, 3);
            this.tableLayoutPanelGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGeneral.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelGeneral.Name = "tableLayoutPanelGeneral";
            this.tableLayoutPanelGeneral.RowCount = 4;
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.Size = new System.Drawing.Size(456, 396);
            this.tableLayoutPanelGeneral.TabIndex = 0;
            // 
            // groupBoxFolder
            // 
            this.groupBoxFolder.AutoSize = true;
            this.groupBoxFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxFolder.Controls.Add(this.tableLayoutPanelFolder);
            this.groupBoxFolder.Location = new System.Drawing.Point(3, 3);
            this.groupBoxFolder.MaximumSize = new System.Drawing.Size(450, 0);
            this.groupBoxFolder.MinimumSize = new System.Drawing.Size(450, 0);
            this.groupBoxFolder.Name = "groupBoxFolder";
            this.groupBoxFolder.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.groupBoxFolder.Size = new System.Drawing.Size(450, 78);
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
            this.tableLayoutPanelFolder.Controls.Add(this.tableLayoutPanelChangeFolder, 0, 1);
            this.tableLayoutPanelFolder.Controls.Add(this.textBoxFolder, 0, 0);
            this.tableLayoutPanelFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFolder.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelFolder.Name = "tableLayoutPanelFolder";
            this.tableLayoutPanelFolder.RowCount = 2;
            this.tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFolder.Size = new System.Drawing.Size(444, 53);
            this.tableLayoutPanelFolder.TabIndex = 0;
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
            this.tableLayoutPanelChangeFolder.Size = new System.Drawing.Size(450, 31);
            this.tableLayoutPanelChangeFolder.TabIndex = 0;
            // 
            // buttonChangeFolder
            // 
            this.buttonChangeFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonChangeFolder.AutoSize = true;
            this.buttonChangeFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonChangeFolder.Location = new System.Drawing.Point(3, 3);
            this.buttonChangeFolder.Name = "buttonChangeFolder";
            this.buttonChangeFolder.Size = new System.Drawing.Size(94, 25);
            this.buttonChangeFolder.TabIndex = 0;
            this.buttonChangeFolder.Text = "Change Folder";
            this.buttonChangeFolder.UseVisualStyleBackColor = true;
            this.buttonChangeFolder.Click += new System.EventHandler(this.ButtonChange_Click);
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
            this.textBoxFolder.Size = new System.Drawing.Size(438, 16);
            this.textBoxFolder.TabIndex = 0;
            this.textBoxFolder.TabStop = false;
            // 
            // groupBoxAutostart
            // 
            this.groupBoxAutostart.AutoSize = true;
            this.groupBoxAutostart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxAutostart.Controls.Add(this.tableLayoutPanelAutostart);
            this.groupBoxAutostart.Location = new System.Drawing.Point(3, 87);
            this.groupBoxAutostart.MaximumSize = new System.Drawing.Size(450, 0);
            this.groupBoxAutostart.MinimumSize = new System.Drawing.Size(450, 0);
            this.groupBoxAutostart.Name = "groupBoxAutostart";
            this.groupBoxAutostart.Size = new System.Drawing.Size(450, 47);
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
            this.tableLayoutPanelAutostart.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelAutostart.Name = "tableLayoutPanelAutostart";
            this.tableLayoutPanelAutostart.RowCount = 1;
            this.tableLayoutPanelAutostart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAutostart.Size = new System.Drawing.Size(444, 25);
            this.tableLayoutPanelAutostart.TabIndex = 0;
            // 
            // checkBoxAutostart
            // 
            this.checkBoxAutostart.AutoSize = true;
            this.checkBoxAutostart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxAutostart.Location = new System.Drawing.Point(3, 3);
            this.checkBoxAutostart.Name = "checkBoxAutostart";
            this.checkBoxAutostart.Size = new System.Drawing.Size(438, 19);
            this.checkBoxAutostart.TabIndex = 0;
            this.checkBoxAutostart.Text = "checkBoxAutostart";
            this.checkBoxAutostart.UseVisualStyleBackColor = true;
            // 
            // groupBoxHotkey
            // 
            this.groupBoxHotkey.AutoSize = true;
            this.groupBoxHotkey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxHotkey.Controls.Add(this.tableLayoutPanelHotkey);
            this.groupBoxHotkey.Location = new System.Drawing.Point(3, 140);
            this.groupBoxHotkey.MaximumSize = new System.Drawing.Size(450, 0);
            this.groupBoxHotkey.MinimumSize = new System.Drawing.Size(450, 0);
            this.groupBoxHotkey.Name = "groupBoxHotkey";
            this.groupBoxHotkey.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxHotkey.Size = new System.Drawing.Size(450, 59);
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
            this.tableLayoutPanelHotkey.Controls.Add(this.textBoxHotkeyPlaceholder, 0, 0);
            this.tableLayoutPanelHotkey.Controls.Add(this.buttonHotkeyDefault, 2, 0);
            this.tableLayoutPanelHotkey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelHotkey.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanelHotkey.Name = "tableLayoutPanelHotkey";
            this.tableLayoutPanelHotkey.RowCount = 1;
            this.tableLayoutPanelHotkey.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelHotkey.Size = new System.Drawing.Size(444, 31);
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
            this.buttonHotkeyDefault.Location = new System.Drawing.Point(312, 3);
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
            this.groupBoxLanguage.Location = new System.Drawing.Point(3, 205);
            this.groupBoxLanguage.MaximumSize = new System.Drawing.Size(450, 0);
            this.groupBoxLanguage.MinimumSize = new System.Drawing.Size(450, 0);
            this.groupBoxLanguage.Name = "groupBoxLanguage";
            this.groupBoxLanguage.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxLanguage.Size = new System.Drawing.Size(450, 57);
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
            this.tableLayoutPanelLanguage.Size = new System.Drawing.Size(444, 29);
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
            this.tabPageAdvanced.Size = new System.Drawing.Size(462, 402);
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
            this.tableLayoutPanelAdvanced.Size = new System.Drawing.Size(456, 396);
            this.tableLayoutPanelAdvanced.TabIndex = 0;
            // 
            // groupBoxClick
            // 
            this.groupBoxClick.AutoSize = true;
            this.groupBoxClick.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxClick.Controls.Add(this.tableLayoutPanelClick);
            this.groupBoxClick.Location = new System.Drawing.Point(3, 3);
            this.groupBoxClick.MaximumSize = new System.Drawing.Size(450, 0);
            this.groupBoxClick.MinimumSize = new System.Drawing.Size(450, 0);
            this.groupBoxClick.Name = "groupBoxClick";
            this.groupBoxClick.Size = new System.Drawing.Size(450, 47);
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
            this.tableLayoutPanelClick.Size = new System.Drawing.Size(444, 25);
            this.tableLayoutPanelClick.TabIndex = 0;
            // 
            // checkBoxOpenItemWithOneClick
            // 
            this.checkBoxOpenItemWithOneClick.AutoSize = true;
            this.checkBoxOpenItemWithOneClick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxOpenItemWithOneClick.Location = new System.Drawing.Point(3, 3);
            this.checkBoxOpenItemWithOneClick.Name = "checkBoxOpenItemWithOneClick";
            this.checkBoxOpenItemWithOneClick.Size = new System.Drawing.Size(438, 19);
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
            this.groupBoxSizeAndLocation.MaximumSize = new System.Drawing.Size(450, 0);
            this.groupBoxSizeAndLocation.MinimumSize = new System.Drawing.Size(450, 0);
            this.groupBoxSizeAndLocation.Name = "groupBoxSizeAndLocation";
            this.groupBoxSizeAndLocation.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.groupBoxSizeAndLocation.Size = new System.Drawing.Size(450, 79);
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
            this.tableLayoutPanelSizeAndLocation.Size = new System.Drawing.Size(444, 54);
            this.tableLayoutPanelSizeAndLocation.TabIndex = 0;
            // 
            // checkBoxAppearAtMouseLocation
            // 
            this.checkBoxAppearAtMouseLocation.AutoSize = true;
            this.checkBoxAppearAtMouseLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxAppearAtMouseLocation.Location = new System.Drawing.Point(3, 3);
            this.checkBoxAppearAtMouseLocation.Name = "checkBoxAppearAtMouseLocation";
            this.checkBoxAppearAtMouseLocation.Size = new System.Drawing.Size(438, 19);
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
            this.tableLayoutPanelMaxMenuWidth.Size = new System.Drawing.Size(444, 29);
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
            this.labelMaxMenuWidth.MaximumSize = new System.Drawing.Size(380, 0);
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
            this.groupBoxStaysOpen.MaximumSize = new System.Drawing.Size(450, 0);
            this.groupBoxStaysOpen.MinimumSize = new System.Drawing.Size(450, 0);
            this.groupBoxStaysOpen.Name = "groupBoxStaysOpen";
            this.groupBoxStaysOpen.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.groupBoxStaysOpen.Size = new System.Drawing.Size(450, 104);
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
            this.tableLayoutPanelStaysOpen.Size = new System.Drawing.Size(444, 79);
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
            this.tableLayoutPanelTimeUntilCloses.Size = new System.Drawing.Size(444, 29);
            this.tableLayoutPanelTimeUntilCloses.TabIndex = 0;
            // 
            // labelTimeUntilCloses
            // 
            this.labelTimeUntilCloses.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTimeUntilCloses.AutoSize = true;
            this.labelTimeUntilCloses.Location = new System.Drawing.Point(64, 7);
            this.labelTimeUntilCloses.MaximumSize = new System.Drawing.Size(380, 0);
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
            this.groupBoxOpenSubmenus.MaximumSize = new System.Drawing.Size(450, 0);
            this.groupBoxOpenSubmenus.MinimumSize = new System.Drawing.Size(450, 0);
            this.groupBoxOpenSubmenus.Name = "groupBoxOpenSubmenus";
            this.groupBoxOpenSubmenus.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.groupBoxOpenSubmenus.Size = new System.Drawing.Size(450, 54);
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
            this.tableLayoutPanelTimeUntilOpen.Size = new System.Drawing.Size(444, 29);
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
            this.labelTimeUntilOpen.MaximumSize = new System.Drawing.Size(380, 0);
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
            this.tabPageCustomize.Size = new System.Drawing.Size(462, 402);
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
            this.tableLayoutPanelCustomize.Controls.Add(this.groupBoxColors, 0, 0);
            this.tableLayoutPanelCustomize.Controls.Add(this.groupBoxDarkMode, 0, 1);
            this.tableLayoutPanelCustomize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCustomize.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelCustomize.Name = "tableLayoutPanelCustomize";
            this.tableLayoutPanelCustomize.RowCount = 2;
            this.tableLayoutPanelCustomize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCustomize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCustomize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCustomize.Size = new System.Drawing.Size(456, 396);
            this.tableLayoutPanelCustomize.TabIndex = 0;
            // 
            // groupBoxColors
            // 
            this.groupBoxColors.AutoSize = true;
            this.groupBoxColors.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxColors.Controls.Add(this.tableLayoutPanelColors);
            this.groupBoxColors.Location = new System.Drawing.Point(3, 3);
            this.groupBoxColors.MaximumSize = new System.Drawing.Size(450, 0);
            this.groupBoxColors.MinimumSize = new System.Drawing.Size(450, 0);
            this.groupBoxColors.Name = "groupBoxColors";
            this.groupBoxColors.Size = new System.Drawing.Size(450, 180);
            this.groupBoxColors.TabIndex = 0;
            this.groupBoxColors.TabStop = false;
            this.groupBoxColors.Text = "groupBoxColors";
            // 
            // tableLayoutPanelColors
            // 
            this.tableLayoutPanelColors.AutoSize = true;
            this.tableLayoutPanelColors.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelColors.ColumnCount = 1;
            this.tableLayoutPanelColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 444F));
            this.tableLayoutPanelColors.Controls.Add(this.tableLayoutPanelMenuMenu, 0, 0);
            this.tableLayoutPanelColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelColors.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelColors.Name = "tableLayoutPanelColors";
            this.tableLayoutPanelColors.RowCount = 1;
            this.tableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tableLayoutPanelColors.Size = new System.Drawing.Size(444, 158);
            this.tableLayoutPanelColors.TabIndex = 0;
            // 
            // tableLayoutPanelMenuMenu
            // 
            this.tableLayoutPanelMenuMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanelMenuMenu.BackgroundImage")));
            this.tableLayoutPanelMenuMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tableLayoutPanelMenuMenu.ColumnCount = 3;
            this.tableLayoutPanelMenuMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.31818F));
            this.tableLayoutPanelMenuMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.95454F));
            this.tableLayoutPanelMenuMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.5F));
            this.tableLayoutPanelMenuMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMenuMenu.Controls.Add(this.textBoxColorTitle, 2, 1);
            this.tableLayoutPanelMenuMenu.Controls.Add(this.textBoxColorWarning, 0, 2);
            this.tableLayoutPanelMenuMenu.Controls.Add(this.tableLayoutPanelMenuSelectedMenu, 1, 2);
            this.tableLayoutPanelMenuMenu.Controls.Add(this.tableLayoutPanelMenuOpenMenu, 2, 2);
            this.tableLayoutPanelMenuMenu.Controls.Add(this.textBoxColorMain, 2, 3);
            this.tableLayoutPanelMenuMenu.Controls.Add(this.textBoxColorSearch, 2, 4);
            this.tableLayoutPanelMenuMenu.Controls.Add(this.buttonDefaultColors, 0, 4);
            this.tableLayoutPanelMenuMenu.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelMenuMenu.MaximumSize = new System.Drawing.Size(440, 152);
            this.tableLayoutPanelMenuMenu.MinimumSize = new System.Drawing.Size(440, 152);
            this.tableLayoutPanelMenuMenu.Name = "tableLayoutPanelMenuMenu";
            this.tableLayoutPanelMenuMenu.RowCount = 6;
            this.tableLayoutPanelMenuMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanelMenuMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.76423F));
            this.tableLayoutPanelMenuMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.01626F));
            this.tableLayoutPanelMenuMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.01626F));
            this.tableLayoutPanelMenuMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.20325F));
            this.tableLayoutPanelMenuMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelMenuMenu.Size = new System.Drawing.Size(440, 152);
            this.tableLayoutPanelMenuMenu.TabIndex = 1;
            // 
            // textBoxColorTitle
            // 
            this.textBoxColorTitle.Location = new System.Drawing.Point(299, 15);
            this.textBoxColorTitle.MaxLength = 12;
            this.textBoxColorTitle.Name = "textBoxColorTitle";
            this.textBoxColorTitle.Size = new System.Drawing.Size(84, 23);
            this.textBoxColorTitle.TabIndex = 2;
            this.textBoxColorTitle.Text = "#ffffff";
            this.textBoxColorTitle.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorTitle.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorWarning
            // 
            this.textBoxColorWarning.Location = new System.Drawing.Point(7, 43);
            this.textBoxColorWarning.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.textBoxColorWarning.MaxLength = 12;
            this.textBoxColorWarning.Name = "textBoxColorWarning";
            this.textBoxColorWarning.Size = new System.Drawing.Size(137, 23);
            this.textBoxColorWarning.TabIndex = 2;
            this.textBoxColorWarning.Text = "#ffffff";
            this.textBoxColorWarning.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorWarning.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // tableLayoutPanelMenuSelectedMenu
            // 
            this.tableLayoutPanelMenuSelectedMenu.AutoSize = true;
            this.tableLayoutPanelMenuSelectedMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMenuSelectedMenu.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelMenuSelectedMenu.ColumnCount = 2;
            this.tableLayoutPanelMenuSelectedMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMenuSelectedMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMenuSelectedMenu.Controls.Add(this.textBoxColorSelected, 0, 0);
            this.tableLayoutPanelMenuSelectedMenu.Controls.Add(this.textBoxColorSelectedBorder, 1, 0);
            this.tableLayoutPanelMenuSelectedMenu.Location = new System.Drawing.Point(151, 40);
            this.tableLayoutPanelMenuSelectedMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMenuSelectedMenu.Name = "tableLayoutPanelMenuSelectedMenu";
            this.tableLayoutPanelMenuSelectedMenu.RowCount = 1;
            this.tableLayoutPanelMenuSelectedMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenuSelectedMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanelMenuSelectedMenu.Size = new System.Drawing.Size(137, 29);
            this.tableLayoutPanelMenuSelectedMenu.TabIndex = 3;
            // 
            // textBoxColorSelected
            // 
            this.textBoxColorSelected.Location = new System.Drawing.Point(3, 3);
            this.textBoxColorSelected.MaxLength = 12;
            this.textBoxColorSelected.Name = "textBoxColorSelected";
            this.textBoxColorSelected.Size = new System.Drawing.Size(65, 23);
            this.textBoxColorSelected.TabIndex = 2;
            this.textBoxColorSelected.Text = "#ffffff";
            this.textBoxColorSelected.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSelected.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorSelectedBorder
            // 
            this.textBoxColorSelectedBorder.Location = new System.Drawing.Point(74, 3);
            this.textBoxColorSelectedBorder.MaxLength = 12;
            this.textBoxColorSelectedBorder.Name = "textBoxColorSelectedBorder";
            this.textBoxColorSelectedBorder.Size = new System.Drawing.Size(60, 23);
            this.textBoxColorSelectedBorder.TabIndex = 2;
            this.textBoxColorSelectedBorder.Text = "#ffffff";
            this.textBoxColorSelectedBorder.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSelectedBorder.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // tableLayoutPanelMenuOpenMenu
            // 
            this.tableLayoutPanelMenuOpenMenu.AutoSize = true;
            this.tableLayoutPanelMenuOpenMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMenuOpenMenu.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelMenuOpenMenu.ColumnCount = 2;
            this.tableLayoutPanelMenuOpenMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMenuOpenMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMenuOpenMenu.Controls.Add(this.textBoxColorOpenMenu, 0, 0);
            this.tableLayoutPanelMenuOpenMenu.Controls.Add(this.textBoxColorOpenMenuBorder, 1, 0);
            this.tableLayoutPanelMenuOpenMenu.Location = new System.Drawing.Point(296, 40);
            this.tableLayoutPanelMenuOpenMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMenuOpenMenu.Name = "tableLayoutPanelMenuOpenMenu";
            this.tableLayoutPanelMenuOpenMenu.RowCount = 1;
            this.tableLayoutPanelMenuOpenMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenuOpenMenu.Size = new System.Drawing.Size(137, 29);
            this.tableLayoutPanelMenuOpenMenu.TabIndex = 3;
            // 
            // textBoxColorOpenMenu
            // 
            this.textBoxColorOpenMenu.Location = new System.Drawing.Point(3, 3);
            this.textBoxColorOpenMenu.MaxLength = 12;
            this.textBoxColorOpenMenu.Name = "textBoxColorOpenMenu";
            this.textBoxColorOpenMenu.Size = new System.Drawing.Size(65, 23);
            this.textBoxColorOpenMenu.TabIndex = 2;
            this.textBoxColorOpenMenu.Text = "#ffffff";
            this.textBoxColorOpenMenu.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorOpenMenu.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorOpenMenuBorder
            // 
            this.textBoxColorOpenMenuBorder.Location = new System.Drawing.Point(74, 3);
            this.textBoxColorOpenMenuBorder.Name = "textBoxColorOpenMenuBorder";
            this.textBoxColorOpenMenuBorder.Size = new System.Drawing.Size(60, 23);
            this.textBoxColorOpenMenuBorder.TabIndex = 2;
            this.textBoxColorOpenMenuBorder.Text = "#ffffff";
            this.textBoxColorOpenMenuBorder.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorOpenMenuBorder.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorMain
            // 
            this.textBoxColorMain.Location = new System.Drawing.Point(299, 75);
            this.textBoxColorMain.MaxLength = 12;
            this.textBoxColorMain.Name = "textBoxColorMain";
            this.textBoxColorMain.Size = new System.Drawing.Size(132, 23);
            this.textBoxColorMain.TabIndex = 2;
            this.textBoxColorMain.Text = "#ffffff";
            this.textBoxColorMain.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorMain.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorSearch
            // 
            this.textBoxColorSearch.Location = new System.Drawing.Point(329, 109);
            this.textBoxColorSearch.Margin = new System.Windows.Forms.Padding(33, 5, 3, 3);
            this.textBoxColorSearch.MaxLength = 12;
            this.textBoxColorSearch.Name = "textBoxColorSearch";
            this.textBoxColorSearch.Size = new System.Drawing.Size(100, 23);
            this.textBoxColorSearch.TabIndex = 2;
            this.textBoxColorSearch.Text = "#ffffff";
            this.textBoxColorSearch.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorSearch.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // buttonDefaultColors
            // 
            this.buttonDefaultColors.Location = new System.Drawing.Point(3, 107);
            this.buttonDefaultColors.MinimumSize = new System.Drawing.Size(75, 25);
            this.buttonDefaultColors.Name = "buttonDefaultColors";
            this.buttonDefaultColors.Size = new System.Drawing.Size(75, 25);
            this.buttonDefaultColors.TabIndex = 3;
            this.buttonDefaultColors.Text = "Default";
            this.buttonDefaultColors.UseVisualStyleBackColor = true;
            this.buttonDefaultColors.Click += new System.EventHandler(this.ButtonDefaultColors_Click);
            // 
            // groupBoxDarkMode
            // 
            this.groupBoxDarkMode.AutoSize = true;
            this.groupBoxDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxDarkMode.Controls.Add(this.tableLayoutPanelDarkMode);
            this.groupBoxDarkMode.Location = new System.Drawing.Point(3, 189);
            this.groupBoxDarkMode.MaximumSize = new System.Drawing.Size(450, 0);
            this.groupBoxDarkMode.MinimumSize = new System.Drawing.Size(450, 0);
            this.groupBoxDarkMode.Name = "groupBoxDarkMode";
            this.groupBoxDarkMode.Size = new System.Drawing.Size(450, 205);
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
            this.tableLayoutPanelDarkMode.Controls.Add(this.tableLayoutPanelMenuDarkMenu, 0, 1);
            this.tableLayoutPanelDarkMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDarkMode.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelDarkMode.Name = "tableLayoutPanelDarkMode";
            this.tableLayoutPanelDarkMode.RowCount = 2;
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDarkMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelDarkMode.Size = new System.Drawing.Size(444, 183);
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
            // tableLayoutPanelMenuDarkMenu
            // 
            this.tableLayoutPanelMenuDarkMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanelMenuDarkMenu.BackgroundImage")));
            this.tableLayoutPanelMenuDarkMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tableLayoutPanelMenuDarkMenu.ColumnCount = 3;
            this.tableLayoutPanelMenuDarkMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.31818F));
            this.tableLayoutPanelMenuDarkMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.95454F));
            this.tableLayoutPanelMenuDarkMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.5F));
            this.tableLayoutPanelMenuDarkMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMenuDarkMenu.Controls.Add(this.textBoxColorDarkModeTitle, 2, 1);
            this.tableLayoutPanelMenuDarkMenu.Controls.Add(this.textBoxColorDarkModeWarning, 0, 2);
            this.tableLayoutPanelMenuDarkMenu.Controls.Add(this.tableLayoutPanelMenuDarkSelectedMenu, 1, 2);
            this.tableLayoutPanelMenuDarkMenu.Controls.Add(this.tableLayoutPanelMenuDarkOpenMenu, 2, 2);
            this.tableLayoutPanelMenuDarkMenu.Controls.Add(this.textBoxColorDarkModeMain, 2, 3);
            this.tableLayoutPanelMenuDarkMenu.Controls.Add(this.textBoxColorDarkModeSearch, 2, 4);
            this.tableLayoutPanelMenuDarkMenu.Controls.Add(this.buttonDefaultColorsDark, 0, 4);
            this.tableLayoutPanelMenuDarkMenu.Location = new System.Drawing.Point(3, 28);
            this.tableLayoutPanelMenuDarkMenu.MaximumSize = new System.Drawing.Size(440, 152);
            this.tableLayoutPanelMenuDarkMenu.MinimumSize = new System.Drawing.Size(440, 152);
            this.tableLayoutPanelMenuDarkMenu.Name = "tableLayoutPanelMenuDarkMenu";
            this.tableLayoutPanelMenuDarkMenu.RowCount = 6;
            this.tableLayoutPanelMenuDarkMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanelMenuDarkMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.76423F));
            this.tableLayoutPanelMenuDarkMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.01626F));
            this.tableLayoutPanelMenuDarkMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.01626F));
            this.tableLayoutPanelMenuDarkMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.20325F));
            this.tableLayoutPanelMenuDarkMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelMenuDarkMenu.Size = new System.Drawing.Size(440, 152);
            this.tableLayoutPanelMenuDarkMenu.TabIndex = 1;
            // 
            // textBoxColorDarkModeTitle
            // 
            this.textBoxColorDarkModeTitle.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxColorDarkModeTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxColorDarkModeTitle.Location = new System.Drawing.Point(299, 15);
            this.textBoxColorDarkModeTitle.MaxLength = 12;
            this.textBoxColorDarkModeTitle.Name = "textBoxColorDarkModeTitle";
            this.textBoxColorDarkModeTitle.Size = new System.Drawing.Size(84, 23);
            this.textBoxColorDarkModeTitle.TabIndex = 2;
            this.textBoxColorDarkModeTitle.Text = "#ffffff";
            this.textBoxColorDarkModeTitle.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorDarkModeTitle.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorDarkModeWarning
            // 
            this.textBoxColorDarkModeWarning.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxColorDarkModeWarning.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxColorDarkModeWarning.Location = new System.Drawing.Point(7, 43);
            this.textBoxColorDarkModeWarning.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.textBoxColorDarkModeWarning.MaxLength = 12;
            this.textBoxColorDarkModeWarning.Name = "textBoxColorDarkModeWarning";
            this.textBoxColorDarkModeWarning.Size = new System.Drawing.Size(137, 23);
            this.textBoxColorDarkModeWarning.TabIndex = 2;
            this.textBoxColorDarkModeWarning.Text = "#ffffff";
            this.textBoxColorDarkModeWarning.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorDarkModeWarning.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // tableLayoutPanelMenuDarkSelectedMenu
            // 
            this.tableLayoutPanelMenuDarkSelectedMenu.AutoSize = true;
            this.tableLayoutPanelMenuDarkSelectedMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMenuDarkSelectedMenu.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelMenuDarkSelectedMenu.ColumnCount = 2;
            this.tableLayoutPanelMenuDarkSelectedMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMenuDarkSelectedMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMenuDarkSelectedMenu.Controls.Add(this.textBoxColorDarkModeSeleceted, 0, 0);
            this.tableLayoutPanelMenuDarkSelectedMenu.Controls.Add(this.textBoxColorDarkModeSelectedBorder, 1, 0);
            this.tableLayoutPanelMenuDarkSelectedMenu.Location = new System.Drawing.Point(151, 40);
            this.tableLayoutPanelMenuDarkSelectedMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMenuDarkSelectedMenu.Name = "tableLayoutPanelMenuDarkSelectedMenu";
            this.tableLayoutPanelMenuDarkSelectedMenu.RowCount = 1;
            this.tableLayoutPanelMenuDarkSelectedMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenuDarkSelectedMenu.Size = new System.Drawing.Size(137, 29);
            this.tableLayoutPanelMenuDarkSelectedMenu.TabIndex = 3;
            // 
            // textBoxColorDarkModeSeleceted
            // 
            this.textBoxColorDarkModeSeleceted.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxColorDarkModeSeleceted.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxColorDarkModeSeleceted.Location = new System.Drawing.Point(3, 3);
            this.textBoxColorDarkModeSeleceted.MaxLength = 12;
            this.textBoxColorDarkModeSeleceted.Name = "textBoxColorDarkModeSeleceted";
            this.textBoxColorDarkModeSeleceted.Size = new System.Drawing.Size(65, 23);
            this.textBoxColorDarkModeSeleceted.TabIndex = 2;
            this.textBoxColorDarkModeSeleceted.Text = "#ffffff";
            this.textBoxColorDarkModeSeleceted.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorDarkModeSeleceted.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorDarkModeSelectedBorder
            // 
            this.textBoxColorDarkModeSelectedBorder.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxColorDarkModeSelectedBorder.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxColorDarkModeSelectedBorder.Location = new System.Drawing.Point(74, 3);
            this.textBoxColorDarkModeSelectedBorder.MaxLength = 12;
            this.textBoxColorDarkModeSelectedBorder.Name = "textBoxColorDarkModeSelectedBorder";
            this.textBoxColorDarkModeSelectedBorder.Size = new System.Drawing.Size(60, 23);
            this.textBoxColorDarkModeSelectedBorder.TabIndex = 2;
            this.textBoxColorDarkModeSelectedBorder.Text = "#ffffff";
            this.textBoxColorDarkModeSelectedBorder.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorDarkModeSelectedBorder.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // tableLayoutPanelMenuDarkOpenMenu
            // 
            this.tableLayoutPanelMenuDarkOpenMenu.AutoSize = true;
            this.tableLayoutPanelMenuDarkOpenMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMenuDarkOpenMenu.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelMenuDarkOpenMenu.ColumnCount = 2;
            this.tableLayoutPanelMenuDarkOpenMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMenuDarkOpenMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMenuDarkOpenMenu.Controls.Add(this.textBoxColorDarkModeOpenMenu, 0, 0);
            this.tableLayoutPanelMenuDarkOpenMenu.Controls.Add(this.textBoxColorDarkModeModeOpenMenuBorder, 1, 0);
            this.tableLayoutPanelMenuDarkOpenMenu.Location = new System.Drawing.Point(296, 40);
            this.tableLayoutPanelMenuDarkOpenMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMenuDarkOpenMenu.Name = "tableLayoutPanelMenuDarkOpenMenu";
            this.tableLayoutPanelMenuDarkOpenMenu.RowCount = 1;
            this.tableLayoutPanelMenuDarkOpenMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMenuDarkOpenMenu.Size = new System.Drawing.Size(137, 29);
            this.tableLayoutPanelMenuDarkOpenMenu.TabIndex = 3;
            // 
            // textBoxColorDarkModeOpenMenu
            // 
            this.textBoxColorDarkModeOpenMenu.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxColorDarkModeOpenMenu.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxColorDarkModeOpenMenu.Location = new System.Drawing.Point(3, 3);
            this.textBoxColorDarkModeOpenMenu.MaxLength = 12;
            this.textBoxColorDarkModeOpenMenu.Name = "textBoxColorDarkModeOpenMenu";
            this.textBoxColorDarkModeOpenMenu.Size = new System.Drawing.Size(65, 23);
            this.textBoxColorDarkModeOpenMenu.TabIndex = 2;
            this.textBoxColorDarkModeOpenMenu.Text = "#ffffff";
            this.textBoxColorDarkModeOpenMenu.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorDarkModeOpenMenu.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorDarkModeModeOpenMenuBorder
            // 
            this.textBoxColorDarkModeModeOpenMenuBorder.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxColorDarkModeModeOpenMenuBorder.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxColorDarkModeModeOpenMenuBorder.Location = new System.Drawing.Point(74, 3);
            this.textBoxColorDarkModeModeOpenMenuBorder.Name = "textBoxColorDarkModeModeOpenMenuBorder";
            this.textBoxColorDarkModeModeOpenMenuBorder.Size = new System.Drawing.Size(60, 23);
            this.textBoxColorDarkModeModeOpenMenuBorder.TabIndex = 2;
            this.textBoxColorDarkModeModeOpenMenuBorder.Text = "#ffffff";
            this.textBoxColorDarkModeModeOpenMenuBorder.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorDarkModeModeOpenMenuBorder.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorDarkModeMain
            // 
            this.textBoxColorDarkModeMain.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxColorDarkModeMain.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxColorDarkModeMain.Location = new System.Drawing.Point(299, 75);
            this.textBoxColorDarkModeMain.MaxLength = 12;
            this.textBoxColorDarkModeMain.Name = "textBoxColorDarkModeMain";
            this.textBoxColorDarkModeMain.Size = new System.Drawing.Size(132, 23);
            this.textBoxColorDarkModeMain.TabIndex = 2;
            this.textBoxColorDarkModeMain.Text = "#ffffff";
            this.textBoxColorDarkModeMain.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorDarkModeMain.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // textBoxColorDarkModeSearch
            // 
            this.textBoxColorDarkModeSearch.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxColorDarkModeSearch.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxColorDarkModeSearch.Location = new System.Drawing.Point(329, 109);
            this.textBoxColorDarkModeSearch.Margin = new System.Windows.Forms.Padding(33, 5, 3, 3);
            this.textBoxColorDarkModeSearch.MaxLength = 12;
            this.textBoxColorDarkModeSearch.Name = "textBoxColorDarkModeSearch";
            this.textBoxColorDarkModeSearch.Size = new System.Drawing.Size(100, 23);
            this.textBoxColorDarkModeSearch.TabIndex = 2;
            this.textBoxColorDarkModeSearch.Text = "#ffffff";
            this.textBoxColorDarkModeSearch.TextChanged += new System.EventHandler(this.TextBoxColorsChanged);
            this.textBoxColorDarkModeSearch.DoubleClick += new System.EventHandler(this.TextBoxColorsDoubleClick);
            // 
            // buttonDefaultColorsDark
            // 
            this.buttonDefaultColorsDark.Location = new System.Drawing.Point(3, 107);
            this.buttonDefaultColorsDark.MinimumSize = new System.Drawing.Size(75, 25);
            this.buttonDefaultColorsDark.Name = "buttonDefaultColorsDark";
            this.buttonDefaultColorsDark.Size = new System.Drawing.Size(75, 25);
            this.buttonDefaultColorsDark.TabIndex = 3;
            this.buttonDefaultColorsDark.Text = "Default";
            this.buttonDefaultColorsDark.UseVisualStyleBackColor = true;
            this.buttonDefaultColorsDark.Click += new System.EventHandler(this.ButtonDefaultColorsDark_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1429, 520);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
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
            this.groupBoxColors.ResumeLayout(false);
            this.groupBoxColors.PerformLayout();
            this.tableLayoutPanelColors.ResumeLayout(false);
            this.tableLayoutPanelMenuMenu.ResumeLayout(false);
            this.tableLayoutPanelMenuMenu.PerformLayout();
            this.tableLayoutPanelMenuSelectedMenu.ResumeLayout(false);
            this.tableLayoutPanelMenuSelectedMenu.PerformLayout();
            this.tableLayoutPanelMenuOpenMenu.ResumeLayout(false);
            this.tableLayoutPanelMenuOpenMenu.PerformLayout();
            this.groupBoxDarkMode.ResumeLayout(false);
            this.groupBoxDarkMode.PerformLayout();
            this.tableLayoutPanelDarkMode.ResumeLayout(false);
            this.tableLayoutPanelDarkMode.PerformLayout();
            this.tableLayoutPanelMenuDarkMenu.ResumeLayout(false);
            this.tableLayoutPanelMenuDarkMenu.PerformLayout();
            this.tableLayoutPanelMenuDarkSelectedMenu.ResumeLayout(false);
            this.tableLayoutPanelMenuDarkSelectedMenu.PerformLayout();
            this.tableLayoutPanelMenuDarkOpenMenu.ResumeLayout(false);
            this.tableLayoutPanelMenuDarkOpenMenu.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelColors;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMenuMenu;
        private System.Windows.Forms.TextBox textBoxColorOpenMenu;
        private System.Windows.Forms.TextBox textBoxColorWarning;
        private System.Windows.Forms.TextBox textBoxColorMain;
        private System.Windows.Forms.TextBox textBoxColorTitle;
        private System.Windows.Forms.TextBox textBoxColorSelected;
        private System.Windows.Forms.TextBox textBoxColorOpenMenuBorder;
        private System.Windows.Forms.TextBox textBoxColorDarkModeWarning;
        private System.Windows.Forms.TextBox textBoxColorDarkModeMain;
        private System.Windows.Forms.TextBox textBoxColorDarkModeTitle;
        private System.Windows.Forms.TextBox textBoxColorDarkModeSeleceted;
        private System.Windows.Forms.TextBox textBoxColorDarkModeOpenMenu;
        private System.Windows.Forms.TextBox textBoxColorDarkModeModeOpenMenuBorder;
        private System.Windows.Forms.TextBox textBoxColorSelectedBorder;
        private System.Windows.Forms.TextBox textBoxColorDarkModeSelectedBorder;
        private System.Windows.Forms.TextBox textBoxColorDarkModeSearch;
        private System.Windows.Forms.Button buttonDefaultColors;
        private System.Windows.Forms.TextBox textBoxColorSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMenuSelectedMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMenuOpenMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMenuDarkSelectedMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMenuDarkOpenMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMenuDarkMenu;
    }
}