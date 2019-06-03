using System;

namespace Bacchus
{
    partial class ModifyArticleForm
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
            this.ArticleLabel = new System.Windows.Forms.Label();
            this.ArticleNameLabel = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.PriceHTTextBox = new System.Windows.Forms.TextBox();
            this.QuantityTextBox = new System.Windows.Forms.TextBox();
            this.FamilyComboBox = new System.Windows.Forms.ComboBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.BrandLabel = new System.Windows.Forms.Label();
            this.SubFamilyLabel = new System.Windows.Forms.Label();
            this.FamilyLabel = new System.Windows.Forms.Label();
            this.SubFamilyComboBox = new System.Windows.Forms.ComboBox();
            this.BrandComboBox = new System.Windows.Forms.ComboBox();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.PriceHTLabel = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ArticleLabel
            // 
            this.ArticleLabel.AutoSize = true;
            this.ArticleLabel.Location = new System.Drawing.Point(116, 9);
            this.ArticleLabel.Name = "ArticleLabel";
            this.ArticleLabel.Size = new System.Drawing.Size(63, 13);
            this.ArticleLabel.TabIndex = 0;
            this.ArticleLabel.Text = "Référence :";
            // 
            // ArticleNameLabel
            // 
            this.ArticleNameLabel.AutoSize = true;
            this.ArticleNameLabel.Location = new System.Drawing.Point(180, 9);
            this.ArticleNameLabel.Name = "ArticleNameLabel";
            this.ArticleNameLabel.Size = new System.Drawing.Size(0, 13);
            this.ArticleNameLabel.TabIndex = 1;
            this.ArticleNameLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(119, 61);
            this.DescriptionTextBox.MaxLength = 35;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(200, 20);
            this.DescriptionTextBox.TabIndex = 2;
            // 
            // PriceHTTextBox
            // 
            this.PriceHTTextBox.Location = new System.Drawing.Point(119, 218);
            this.PriceHTTextBox.MaxLength = 35;
            this.PriceHTTextBox.Name = "PriceHTTextBox";
            this.PriceHTTextBox.Size = new System.Drawing.Size(200, 20);
            this.PriceHTTextBox.TabIndex = 3;
            // 
            // QuantityTextBox
            // 
            this.QuantityTextBox.Location = new System.Drawing.Point(119, 262);
            this.QuantityTextBox.MaxLength = 35;
            this.QuantityTextBox.Name = "QuantityTextBox";
            this.QuantityTextBox.Size = new System.Drawing.Size(200, 20);
            this.QuantityTextBox.TabIndex = 4;
            // 
            // FamilyComboBox
            // 
            this.FamilyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FamilyComboBox.FormattingEnabled = true;
            this.FamilyComboBox.Location = new System.Drawing.Point(119, 96);
            this.FamilyComboBox.Name = "FamilyComboBox";
            this.FamilyComboBox.Size = new System.Drawing.Size(200, 21);
            this.FamilyComboBox.TabIndex = 5;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(12, 64);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionLabel.TabIndex = 6;
            this.DescriptionLabel.Text = "Description";
            // 
            // BrandLabel
            // 
            this.BrandLabel.AutoSize = true;
            this.BrandLabel.Location = new System.Drawing.Point(12, 183);
            this.BrandLabel.Name = "BrandLabel";
            this.BrandLabel.Size = new System.Drawing.Size(43, 13);
            this.BrandLabel.TabIndex = 7;
            this.BrandLabel.Text = "Marque";
            // 
            // SubFamilyLabel
            // 
            this.SubFamilyLabel.AutoSize = true;
            this.SubFamilyLabel.Location = new System.Drawing.Point(12, 142);
            this.SubFamilyLabel.Name = "SubFamilyLabel";
            this.SubFamilyLabel.Size = new System.Drawing.Size(66, 13);
            this.SubFamilyLabel.TabIndex = 8;
            this.SubFamilyLabel.Text = "Sous Famille";
            // 
            // FamilyLabel
            // 
            this.FamilyLabel.AutoSize = true;
            this.FamilyLabel.Location = new System.Drawing.Point(12, 99);
            this.FamilyLabel.Name = "FamilyLabel";
            this.FamilyLabel.Size = new System.Drawing.Size(39, 13);
            this.FamilyLabel.TabIndex = 9;
            this.FamilyLabel.Text = "Famille";
            // 
            // SubFamilyComboBox
            // 
            this.SubFamilyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SubFamilyComboBox.FormattingEnabled = true;
            this.SubFamilyComboBox.Location = new System.Drawing.Point(119, 139);
            this.SubFamilyComboBox.Name = "SubFamilyComboBox";
            this.SubFamilyComboBox.Size = new System.Drawing.Size(200, 21);
            this.SubFamilyComboBox.TabIndex = 10;
            this.SubFamilyComboBox.SelectionChangeCommitted += new System.EventHandler(this.SubFamilyComboBox_SelectionChangeCommitted);
            // 
            // BrandComboBox
            // 
            this.BrandComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BrandComboBox.FormattingEnabled = true;
            this.BrandComboBox.Location = new System.Drawing.Point(119, 180);
            this.BrandComboBox.Name = "BrandComboBox";
            this.BrandComboBox.Size = new System.Drawing.Size(200, 21);
            this.BrandComboBox.TabIndex = 11;
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Location = new System.Drawing.Point(12, 265);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(47, 13);
            this.QuantityLabel.TabIndex = 12;
            this.QuantityLabel.Text = "Quantité";
            // 
            // PriceHTLabel
            // 
            this.PriceHTLabel.AutoSize = true;
            this.PriceHTLabel.Location = new System.Drawing.Point(12, 221);
            this.PriceHTLabel.Name = "PriceHTLabel";
            this.PriceHTLabel.Size = new System.Drawing.Size(42, 13);
            this.PriceHTLabel.TabIndex = 13;
            this.PriceHTLabel.Text = "Prix HT";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(119, 304);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(116, 23);
            this.OkButton.TabIndex = 14;
            this.OkButton.Text = "Valider";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ModifyArticleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 343);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.PriceHTLabel);
            this.Controls.Add(this.QuantityLabel);
            this.Controls.Add(this.BrandComboBox);
            this.Controls.Add(this.SubFamilyComboBox);
            this.Controls.Add(this.FamilyLabel);
            this.Controls.Add(this.SubFamilyLabel);
            this.Controls.Add(this.BrandLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.FamilyComboBox);
            this.Controls.Add(this.QuantityTextBox);
            this.Controls.Add(this.PriceHTTextBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.ArticleNameLabel);
            this.Controls.Add(this.ArticleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ModifyArticleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modifier un article";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private System.Windows.Forms.Label ArticleLabel;
        private System.Windows.Forms.Label ArticleNameLabel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.TextBox PriceHTTextBox;
        private System.Windows.Forms.TextBox QuantityTextBox;
        private System.Windows.Forms.ComboBox FamilyComboBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label BrandLabel;
        private System.Windows.Forms.Label SubFamilyLabel;
        private System.Windows.Forms.Label FamilyLabel;
        private System.Windows.Forms.ComboBox SubFamilyComboBox;
        private System.Windows.Forms.ComboBox BrandComboBox;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.Label PriceHTLabel;
        private System.Windows.Forms.Button OkButton;
    }
}