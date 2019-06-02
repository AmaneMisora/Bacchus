namespace Bacchus
{
    partial class ModifySubFamilyForm
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
            this.OkButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SubFamilyNameLabel = new System.Windows.Forms.Label();
            this.SubFamilyLabel = new System.Windows.Forms.Label();
            this.FamilyComboBox = new System.Windows.Forms.ComboBox();
            this.FamilyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(125, 153);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(106, 23);
            this.OkButton.TabIndex = 21;
            this.OkButton.Text = "Valider";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(17, 64);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(29, 13);
            this.NameLabel.TabIndex = 20;
            this.NameLabel.Text = "Nom";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(125, 61);
            this.NameTextBox.MaxLength = 35;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(199, 20);
            this.NameTextBox.TabIndex = 19;
            // 
            // SubFamilyNameLabel
            // 
            this.SubFamilyNameLabel.AutoSize = true;
            this.SubFamilyNameLabel.Location = new System.Drawing.Point(185, 9);
            this.SubFamilyNameLabel.Name = "SubFamilyNameLabel";
            this.SubFamilyNameLabel.Size = new System.Drawing.Size(0, 13);
            this.SubFamilyNameLabel.TabIndex = 18;
            // 
            // SubFamilyLabel
            // 
            this.SubFamilyLabel.AutoSize = true;
            this.SubFamilyLabel.Location = new System.Drawing.Point(122, 9);
            this.SubFamilyLabel.Name = "SubFamilyLabel";
            this.SubFamilyLabel.Size = new System.Drawing.Size(63, 13);
            this.SubFamilyLabel.TabIndex = 17;
            this.SubFamilyLabel.Text = "Référence :";
            // 
            // FamilyComboBox
            // 
            this.FamilyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FamilyComboBox.FormattingEnabled = true;
            this.FamilyComboBox.Location = new System.Drawing.Point(125, 106);
            this.FamilyComboBox.Name = "FamilyComboBox";
            this.FamilyComboBox.Size = new System.Drawing.Size(199, 21);
            this.FamilyComboBox.TabIndex = 22;
            // 
            // FamilyLabel
            // 
            this.FamilyLabel.AutoSize = true;
            this.FamilyLabel.Location = new System.Drawing.Point(17, 114);
            this.FamilyLabel.Name = "FamilyLabel";
            this.FamilyLabel.Size = new System.Drawing.Size(36, 13);
            this.FamilyLabel.TabIndex = 23;
            this.FamilyLabel.Text = "Family";
            // 
            // ModifySubFamilyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 211);
            this.Controls.Add(this.FamilyLabel);
            this.Controls.Add(this.FamilyComboBox);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.SubFamilyNameLabel);
            this.Controls.Add(this.SubFamilyLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ModifySubFamilyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modifier une sous famille";
            this.Load += new System.EventHandler(this.SubFamilyModifyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label SubFamilyNameLabel;
        private System.Windows.Forms.Label SubFamilyLabel;
        private System.Windows.Forms.ComboBox FamilyComboBox;
        private System.Windows.Forms.Label FamilyLabel;
    }
}