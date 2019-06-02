namespace Bacchus
{
    partial class AddSubFamilyForm
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
            this.FamilyLabel = new System.Windows.Forms.Label();
            this.FamilyComboBox = new System.Windows.Forms.ComboBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.RefLabel = new System.Windows.Forms.Label();
            this.RefTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FamilyLabel
            // 
            this.FamilyLabel.AutoSize = true;
            this.FamilyLabel.Location = new System.Drawing.Point(21, 114);
            this.FamilyLabel.Name = "FamilyLabel";
            this.FamilyLabel.Size = new System.Drawing.Size(36, 13);
            this.FamilyLabel.TabIndex = 30;
            this.FamilyLabel.Text = "Family";
            // 
            // FamilyComboBox
            // 
            this.FamilyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FamilyComboBox.FormattingEnabled = true;
            this.FamilyComboBox.Location = new System.Drawing.Point(129, 106);
            this.FamilyComboBox.Name = "FamilyComboBox";
            this.FamilyComboBox.Size = new System.Drawing.Size(199, 21);
            this.FamilyComboBox.TabIndex = 29;
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(129, 153);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(106, 23);
            this.OkButton.TabIndex = 28;
            this.OkButton.Text = "Valider";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(21, 64);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(29, 13);
            this.NameLabel.TabIndex = 27;
            this.NameLabel.Text = "Nom";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(129, 61);
            this.NameTextBox.MaxLength = 35;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(199, 20);
            this.NameTextBox.TabIndex = 26;
            // 
            // RefLabel
            // 
            this.RefLabel.AutoSize = true;
            this.RefLabel.Location = new System.Drawing.Point(21, 29);
            this.RefLabel.Name = "RefLabel";
            this.RefLabel.Size = new System.Drawing.Size(57, 13);
            this.RefLabel.TabIndex = 24;
            this.RefLabel.Text = "Référence";
            // 
            // RefTextBox
            // 
            this.RefTextBox.Location = new System.Drawing.Point(129, 21);
            this.RefTextBox.MaxLength = 35;
            this.RefTextBox.Name = "RefTextBox";
            this.RefTextBox.Size = new System.Drawing.Size(199, 20);
            this.RefTextBox.TabIndex = 31;
            // 
            // AddSubFamilyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 191);
            this.Controls.Add(this.RefTextBox);
            this.Controls.Add(this.FamilyLabel);
            this.Controls.Add(this.FamilyComboBox);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.RefLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddSubFamilyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajouter une sous famille";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FamilyLabel;
        private System.Windows.Forms.ComboBox FamilyComboBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label RefLabel;
        private System.Windows.Forms.TextBox RefTextBox;
    }
}