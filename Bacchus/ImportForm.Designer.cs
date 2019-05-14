namespace Bacchus
{
    partial class ImportForm
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
            this.CSVButton = new System.Windows.Forms.Button();
            this.CSVNameTextBox = new System.Windows.Forms.TextBox();
            this.OverwriteButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ImportProgressBar = new System.Windows.Forms.ProgressBar();
            this.ImportGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CSVPathLabel = new System.Windows.Forms.Label();
            this.ImportGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CSVButton
            // 
            this.CSVButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CSVButton.Location = new System.Drawing.Point(356, 7);
            this.CSVButton.Margin = new System.Windows.Forms.Padding(0, 7, 8, 8);
            this.CSVButton.Name = "CSVButton";
            this.CSVButton.Size = new System.Drawing.Size(26, 23);
            this.CSVButton.TabIndex = 1;
            this.CSVButton.Text = "...";
            this.CSVButton.UseVisualStyleBackColor = true;
            this.CSVButton.Click += new System.EventHandler(this.CSVButton_Click);
            // 
            // CSVNameTextBox
            // 
            this.CSVNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CSVNameTextBox.Location = new System.Drawing.Point(111, 8);
            this.CSVNameTextBox.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.CSVNameTextBox.Name = "CSVNameTextBox";
            this.CSVNameTextBox.Size = new System.Drawing.Size(245, 20);
            this.CSVNameTextBox.TabIndex = 0;
            // 
            // OverwriteButton
            // 
            this.OverwriteButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.OverwriteButton.Location = new System.Drawing.Point(63, 10);
            this.OverwriteButton.Margin = new System.Windows.Forms.Padding(10);
            this.OverwriteButton.Name = "OverwriteButton";
            this.OverwriteButton.Size = new System.Drawing.Size(120, 23);
            this.OverwriteButton.TabIndex = 2;
            this.OverwriteButton.Text = "Importer et Ecraser";
            this.OverwriteButton.UseVisualStyleBackColor = true;
            this.OverwriteButton.Click += new System.EventHandler(this.OverwriteButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(203, 10);
            this.AddButton.Margin = new System.Windows.Forms.Padding(10);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(120, 23);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Importer et Ajouter";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // ImportProgressBar
            // 
            this.ImportProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ImportProgressBar.Location = new System.Drawing.Point(10, 113);
            this.ImportProgressBar.Margin = new System.Windows.Forms.Padding(3, 30, 3, 30);
            this.ImportProgressBar.Name = "ImportProgressBar";
            this.ImportProgressBar.Size = new System.Drawing.Size(393, 23);
            this.ImportProgressBar.TabIndex = 4;
            this.ImportProgressBar.Tag = "";
            // 
            // ImportGroupBox
            // 
            this.ImportGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.ImportGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.ImportGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ImportGroupBox.Location = new System.Drawing.Point(10, 10);
            this.ImportGroupBox.Name = "ImportGroupBox";
            this.ImportGroupBox.Size = new System.Drawing.Size(393, 95);
            this.ImportGroupBox.TabIndex = 5;
            this.ImportGroupBox.TabStop = false;
            this.ImportGroupBox.Text = "Paramètres d\'importation";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.OverwriteButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.AddButton, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 49);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(387, 43);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.CSVButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.CSVPathLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CSVNameTextBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(387, 38);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // CSVPathLabel
            // 
            this.CSVPathLabel.AutoSize = true;
            this.CSVPathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CSVPathLabel.Location = new System.Drawing.Point(10, 10);
            this.CSVPathLabel.Margin = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.CSVPathLabel.Name = "CSVPathLabel";
            this.CSVPathLabel.Size = new System.Drawing.Size(101, 18);
            this.CSVPathLabel.TabIndex = 2;
            this.CSVPathLabel.Text = "Emplacement CSV :";
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(413, 146);
            this.Controls.Add(this.ImportProgressBar);
            this.Controls.Add(this.ImportGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Importer";
            this.ImportGroupBox.ResumeLayout(false);
            this.ImportGroupBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CSVButton;
        private System.Windows.Forms.TextBox CSVNameTextBox;
        private System.Windows.Forms.Button OverwriteButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ProgressBar ImportProgressBar;
        private System.Windows.Forms.GroupBox ImportGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label CSVPathLabel;
    }
}