﻿namespace Bacchus
{
    partial class AddFamilyForm
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
            this.RefTextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.RefLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RefTextBox
            // 
            this.RefTextBox.Location = new System.Drawing.Point(133, 24);
            this.RefTextBox.MaxLength = 35;
            this.RefTextBox.Name = "RefTextBox";
            this.RefTextBox.Size = new System.Drawing.Size(199, 20);
            this.RefTextBox.TabIndex = 22;
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(133, 107);
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
            this.NameLabel.Location = new System.Drawing.Point(25, 60);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(29, 13);
            this.NameLabel.TabIndex = 20;
            this.NameLabel.Text = "Nom";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(133, 57);
            this.NameTextBox.MaxLength = 35;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(199, 20);
            this.NameTextBox.TabIndex = 19;
            // 
            // RefLabel
            // 
            this.RefLabel.AutoSize = true;
            this.RefLabel.Location = new System.Drawing.Point(25, 27);
            this.RefLabel.Name = "RefLabel";
            this.RefLabel.Size = new System.Drawing.Size(57, 13);
            this.RefLabel.TabIndex = 18;
            this.RefLabel.Text = "Référence";
            // 
            // AddFamilyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 149);
            this.Controls.Add(this.RefTextBox);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.RefLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddFamilyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajouter une famille";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RefTextBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label RefLabel;
    }
}