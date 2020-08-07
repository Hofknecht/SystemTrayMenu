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
            this.tabControlExpert = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.textBoxHotkey = new SystemTrayMenu.UserInterface.HotkeyTextboxControl.HotkeyControl();
            this.checkBoxAutostart = new System.Windows.Forms.CheckBox();
            this.labelHotkey = new System.Windows.Forms.Label();
            this.labelAutostart = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonChange = new System.Windows.Forms.Button();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.labelFolder = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabPageExpert = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelExpert = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxOpenItemWithOneClick = new System.Windows.Forms.CheckBox();
            this.checkBoxHideTaskbarForm = new System.Windows.Forms.CheckBox();
            this.checkBoxDarkModeAlwaysOn = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tabControlExpert.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.tableLayoutPanelGeneral.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tabPageExpert.SuspendLayout();
            this.tableLayoutPanelExpert.SuspendLayout();
            this.tableLayoutPanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tabControlExpert, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelBottom, 0, 1);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(401, 275);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tabControlExpert
            // 
            this.tabControlExpert.Controls.Add(this.tabPageGeneral);
            this.tabControlExpert.Controls.Add(this.tabPageExpert);
            this.tabControlExpert.Location = new System.Drawing.Point(3, 3);
            this.tabControlExpert.Name = "tabControlExpert";
            this.tabControlExpert.SelectedIndex = 0;
            this.tabControlExpert.Size = new System.Drawing.Size(395, 240);
            this.tabControlExpert.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.tableLayoutPanelGeneral);
            this.tabPageGeneral.Controls.Add(this.tableLayoutPanel5);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(387, 214);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "tabPageGeneral";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelGeneral
            // 
            this.tableLayoutPanelGeneral.AutoSize = true;
            this.tableLayoutPanelGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelGeneral.ColumnCount = 3;
            this.tableLayoutPanelGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanelGeneral.Controls.Add(this.comboBoxLanguage, 1, 3);
            this.tableLayoutPanelGeneral.Controls.Add(this.labelLanguage, 0, 3);
            this.tableLayoutPanelGeneral.Controls.Add(this.textBoxHotkey, 1, 2);
            this.tableLayoutPanelGeneral.Controls.Add(this.checkBoxAutostart, 1, 1);
            this.tableLayoutPanelGeneral.Controls.Add(this.labelHotkey, 0, 2);
            this.tableLayoutPanelGeneral.Controls.Add(this.labelAutostart, 0, 1);
            this.tableLayoutPanelGeneral.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanelGeneral.Controls.Add(this.labelFolder, 0, 0);
            this.tableLayoutPanelGeneral.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelGeneral.Name = "tableLayoutPanelGeneral";
            this.tableLayoutPanelGeneral.RowCount = 5;
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelGeneral.Size = new System.Drawing.Size(313, 145);
            this.tableLayoutPanelGeneral.TabIndex = 0;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(92, 84);
            this.comboBoxLanguage.Margin = new System.Windows.Forms.Padding(9, 7, 9, 0);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(200, 21);
            this.comboBoxLanguage.TabIndex = 15;
            // 
            // labelLanguage
            // 
            this.labelLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(3, 84);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(77, 13);
            this.labelLanguage.TabIndex = 0;
            this.labelLanguage.Text = "labelLanguage";
            // 
            // textBoxHotkey
            // 
            this.textBoxHotkey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHotkey.Hotkey = System.Windows.Forms.Keys.None;
            this.textBoxHotkey.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.textBoxHotkey.Location = new System.Drawing.Point(92, 57);
            this.textBoxHotkey.Margin = new System.Windows.Forms.Padding(9, 7, 9, 0);
            this.textBoxHotkey.Name = "textBoxHotkey";
            this.textBoxHotkey.Size = new System.Drawing.Size(200, 20);
            this.textBoxHotkey.TabIndex = 99;
            this.textBoxHotkey.TabStop = false;
            this.textBoxHotkey.Text = "None";
            this.textBoxHotkey.Enter += new System.EventHandler(this.TextBoxHotkeyEnter);
            this.textBoxHotkey.Leave += new System.EventHandler(this.TextBoxHotkey_Leave);
            // 
            // checkBoxAutostart
            // 
            this.checkBoxAutostart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAutostart.AutoSize = true;
            this.checkBoxAutostart.Location = new System.Drawing.Point(92, 33);
            this.checkBoxAutostart.Margin = new System.Windows.Forms.Padding(9, 7, 9, 0);
            this.checkBoxAutostart.Name = "checkBoxAutostart";
            this.checkBoxAutostart.Size = new System.Drawing.Size(200, 17);
            this.checkBoxAutostart.TabIndex = 10;
            this.checkBoxAutostart.Text = "checkBoxAutostart";
            this.checkBoxAutostart.UseVisualStyleBackColor = true;
            // 
            // labelHotkey
            // 
            this.labelHotkey.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelHotkey.AutoSize = true;
            this.labelHotkey.Location = new System.Drawing.Point(3, 57);
            this.labelHotkey.Name = "labelHotkey";
            this.labelHotkey.Size = new System.Drawing.Size(63, 13);
            this.labelHotkey.TabIndex = 0;
            this.labelHotkey.Text = "labelHotkey";
            // 
            // labelAutostart
            // 
            this.labelAutostart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelAutostart.AutoSize = true;
            this.labelAutostart.Location = new System.Drawing.Point(3, 31);
            this.labelAutostart.Name = "labelAutostart";
            this.labelAutostart.Size = new System.Drawing.Size(71, 13);
            this.labelAutostart.TabIndex = 0;
            this.labelAutostart.Text = "labelAutostart";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.buttonChange, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxFolder, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(83, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(218, 26);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonChange
            // 
            this.buttonChange.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonChange.AutoSize = true;
            this.buttonChange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChange.Location = new System.Drawing.Point(180, 3);
            this.buttonChange.Margin = new System.Windows.Forms.Padding(3, 3, 9, 0);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(29, 23);
            this.buttonChange.TabIndex = 5;
            this.buttonChange.Text = "...";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFolder.BackColor = System.Drawing.Color.White;
            this.textBoxFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFolder.Location = new System.Drawing.Point(9, 8);
            this.textBoxFolder.Margin = new System.Windows.Forms.Padding(9, 3, 9, 0);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.ReadOnly = true;
            this.textBoxFolder.Size = new System.Drawing.Size(155, 13);
            this.textBoxFolder.TabIndex = 0;
            this.textBoxFolder.TabStop = false;
            // 
            // labelFolder
            // 
            this.labelFolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelFolder.AutoSize = true;
            this.labelFolder.Location = new System.Drawing.Point(3, 6);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(58, 13);
            this.labelFolder.TabIndex = 0;
            this.labelFolder.Text = "labelFolder";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(100, 0);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(100, 0);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(100, 0);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(100, 0);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tabPageExpert
            // 
            this.tabPageExpert.Controls.Add(this.tableLayoutPanelExpert);
            this.tabPageExpert.Location = new System.Drawing.Point(4, 22);
            this.tabPageExpert.Name = "tabPageExpert";
            this.tabPageExpert.Size = new System.Drawing.Size(387, 214);
            this.tabPageExpert.TabIndex = 1;
            this.tabPageExpert.Text = "tabPageExpert";
            this.tabPageExpert.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelExpert
            // 
            this.tableLayoutPanelExpert.AutoSize = true;
            this.tableLayoutPanelExpert.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelExpert.ColumnCount = 3;
            this.tableLayoutPanelExpert.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelExpert.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelExpert.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanelExpert.Controls.Add(this.checkBoxDarkModeAlwaysOn, 0, 2);
            this.tableLayoutPanelExpert.Controls.Add(this.checkBoxOpenItemWithOneClick, 0, 1);
            this.tableLayoutPanelExpert.Controls.Add(this.checkBoxHideTaskbarForm, 0, 0);
            this.tableLayoutPanelExpert.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelExpert.Name = "tableLayoutPanelExpert";
            this.tableLayoutPanelExpert.RowCount = 4;
            this.tableLayoutPanelExpert.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelExpert.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelExpert.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelExpert.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelExpert.Size = new System.Drawing.Size(215, 112);
            this.tableLayoutPanelExpert.TabIndex = 1;
            // 
            // checkBoxOpenItemWithOneClick
            // 
            this.checkBoxOpenItemWithOneClick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxOpenItemWithOneClick.AutoSize = true;
            this.checkBoxOpenItemWithOneClick.Location = new System.Drawing.Point(9, 31);
            this.checkBoxOpenItemWithOneClick.Margin = new System.Windows.Forms.Padding(9, 7, 9, 0);
            this.checkBoxOpenItemWithOneClick.Name = "checkBoxOpenItemWithOneClick";
            this.checkBoxOpenItemWithOneClick.Size = new System.Drawing.Size(185, 17);
            this.checkBoxOpenItemWithOneClick.TabIndex = 106;
            this.checkBoxOpenItemWithOneClick.Text = "checkBoxOpenItemWithOneClick";
            this.checkBoxOpenItemWithOneClick.UseVisualStyleBackColor = true;
            // 
            // checkBoxHideTaskbarForm
            // 
            this.checkBoxHideTaskbarForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHideTaskbarForm.AutoSize = true;
            this.checkBoxHideTaskbarForm.Location = new System.Drawing.Point(9, 7);
            this.checkBoxHideTaskbarForm.Margin = new System.Windows.Forms.Padding(9, 7, 9, 0);
            this.checkBoxHideTaskbarForm.Name = "checkBoxHideTaskbarForm";
            this.checkBoxHideTaskbarForm.Size = new System.Drawing.Size(185, 17);
            this.checkBoxHideTaskbarForm.TabIndex = 107;
            this.checkBoxHideTaskbarForm.Text = "checkBoxShowTaskbarForm";
            this.checkBoxHideTaskbarForm.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanelBottom.Location = new System.Drawing.Point(3, 249);
            this.tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            this.tableLayoutPanelBottom.RowCount = 1;
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBottom.Size = new System.Drawing.Size(395, 23);
            this.tableLayoutPanelBottom.TabIndex = 1;
            // 
            // buttonOk
            // 
            this.buttonOk.AutoSize = true;
            this.buttonOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(236, 0);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonOk.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(317, 0);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonCancel.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // checkBoxDarkModeAlwaysOn
            // 
            this.checkBoxDarkModeAlwaysOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDarkModeAlwaysOn.AutoSize = true;
            this.checkBoxDarkModeAlwaysOn.Location = new System.Drawing.Point(9, 55);
            this.checkBoxDarkModeAlwaysOn.Margin = new System.Windows.Forms.Padding(9, 7, 9, 0);
            this.checkBoxDarkModeAlwaysOn.Name = "checkBoxDarkModeAlwaysOn";
            this.checkBoxDarkModeAlwaysOn.Size = new System.Drawing.Size(185, 17);
            this.checkBoxDarkModeAlwaysOn.TabIndex = 108;
            this.checkBoxDarkModeAlwaysOn.Text = "checkBoxDarkModeAlwaysOn";
            this.checkBoxDarkModeAlwaysOn.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(795, 460);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.tabControlExpert.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tableLayoutPanelGeneral.ResumeLayout(false);
            this.tableLayoutPanelGeneral.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tabPageExpert.ResumeLayout(false);
            this.tabPageExpert.PerformLayout();
            this.tableLayoutPanelExpert.ResumeLayout(false);
            this.tableLayoutPanelExpert.PerformLayout();
            this.tableLayoutPanelBottom.ResumeLayout(false);
            this.tableLayoutPanelBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBottom;
        private System.Windows.Forms.TabControl tabControlExpert;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        //private System.Windows.Forms.TextBox textBoxHotkey;
        private HotkeyControl textBoxHotkey; 
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox checkBoxAutostart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label labelFolder;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.Label labelAutostart;
        private System.Windows.Forms.Label labelHotkey;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGeneral;
        private System.Windows.Forms.TabPage tabPageExpert;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelExpert;
        private System.Windows.Forms.CheckBox checkBoxOpenItemWithOneClick;
        private System.Windows.Forms.CheckBox checkBoxHideTaskbarForm;
        private System.Windows.Forms.CheckBox checkBoxDarkModeAlwaysOn;
    }
}