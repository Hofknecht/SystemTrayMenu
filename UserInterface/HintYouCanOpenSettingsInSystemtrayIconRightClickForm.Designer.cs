namespace SystemTrayMenu.UserInterface
{
    partial class HintYouCanOpenSettingsInSystemtrayIconRightClickForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HintYouCanOpenSettingsInSystemtrayIconRightClickForm));
            labelHintYouCanOpenSettingsInSystemtrayIconRightClickForm = new System.Windows.Forms.Label();
            checkBoxDontShowThisHintAgain = new System.Windows.Forms.CheckBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            buttonOK = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelHintYouCanOpenSettingsInSystemtrayIconRightClickForm
            // 
            labelHintYouCanOpenSettingsInSystemtrayIconRightClickForm.AutoSize = true;
            labelHintYouCanOpenSettingsInSystemtrayIconRightClickForm.Location = new System.Drawing.Point(3, 0);
            labelHintYouCanOpenSettingsInSystemtrayIconRightClickForm.Name = "labelHintYouCanOpenSettingsInSystemtrayIconRightClickForm";
            labelHintYouCanOpenSettingsInSystemtrayIconRightClickForm.Size = new System.Drawing.Size(302, 45);
            labelHintYouCanOpenSettingsInSystemtrayIconRightClickForm.TabIndex = 1;
            labelHintYouCanOpenSettingsInSystemtrayIconRightClickForm.Text = "The settings menu can also be opened by right-clicking the icon in the system tray at the bottom right, in case you can no longer open it via the menu.";
            // 
            // checkBoxDontShowThisHintAgain
            // 
            checkBoxDontShowThisHintAgain.AutoSize = true;
            checkBoxDontShowThisHintAgain.Location = new System.Drawing.Point(3, 364);
            checkBoxDontShowThisHintAgain.Name = "checkBoxDontShowThisHintAgain";
            checkBoxDontShowThisHintAgain.Size = new System.Drawing.Size(167, 19);
            checkBoxDontShowThisHintAgain.TabIndex = 2;
            checkBoxDontShowThisHintAgain.Text = "Don't show this hint again.";
            checkBoxDontShowThisHintAgain.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayoutPanel1.Controls.Add(labelHintYouCanOpenSettingsInSystemtrayIconRightClickForm, 0, 0);
            tableLayoutPanel1.Controls.Add(checkBoxDontShowThisHintAgain, 0, 2);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 3);
            tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 9, 9);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.Size = new System.Drawing.Size(313, 421);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(buttonOK, 1, 0);
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 389);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.Size = new System.Drawing.Size(307, 29);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // buttonOK
            // 
            buttonOK.AutoSize = true;
            buttonOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonOK.Location = new System.Drawing.Point(209, 3);
            buttonOK.MinimumSize = new System.Drawing.Size(75, 23);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new System.Drawing.Size(75, 25);
            buttonOK.TabIndex = 0;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += ButtonOK_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(3, 48);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(305, 310);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // HintYouCanOpenSettingsInSystemtrayIconRightClickForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(348, 450);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HintYouCanOpenSettingsInSystemtrayIconRightClickForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Hint";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label labelHintYouCanOpenSettingsInSystemtrayIconRightClickForm;
        private System.Windows.Forms.CheckBox checkBoxDontShowThisHintAgain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}