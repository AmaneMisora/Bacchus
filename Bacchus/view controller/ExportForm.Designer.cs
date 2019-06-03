namespace Bacchus
{
    partial class ExportForm
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
            this.ExportProgressBar = new System.Windows.Forms.ProgressBar();
            this.ExportGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ExportButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CSVButton = new System.Windows.Forms.Button();
            this.CSVPathLabel = new System.Windows.Forms.Label();
            this.CSVNameTextBox = new System.Windows.Forms.TextBox();
            this.ExportGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExportProgressBar
            // 
            this.ExportProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ExportProgressBar.Location = new System.Drawing.Point(10, 115);
            this.ExportProgressBar.Margin = new System.Windows.Forms.Padding(3, 30, 3, 30);
            this.ExportProgressBar.Name = "ExportProgressBar";
            this.ExportProgressBar.Size = new System.Drawing.Size(415, 23);
            this.ExportProgressBar.Step = 1;
            this.ExportProgressBar.TabIndex = 6;
            this.ExportProgressBar.Tag = "";
            // 
            // ExportGroupBox
            // 
            this.ExportGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.ExportGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.ExportGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExportGroupBox.Location = new System.Drawing.Point(10, 10);
            this.ExportGroupBox.Name = "ExportGroupBox";
            this.ExportGroupBox.Size = new System.Drawing.Size(415, 95);
            this.ExportGroupBox.TabIndex = 7;
            this.ExportGroupBox.TabStop = false;
            this.ExportGroupBox.Text = "Paramètres d\'exportation";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.ExportButton, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 49);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(409, 43);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // ExportButton
            // 
            this.ExportButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExportButton.Location = new System.Drawing.Point(10, 10);
            this.ExportButton.Margin = new System.Windows.Forms.Padding(10);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(389, 23);
            this.ExportButton.TabIndex = 2;
            this.ExportButton.Text = "Exporter";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(409, 38);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // CSVButton
            // 
            this.CSVButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CSVButton.Location = new System.Drawing.Point(356, 7);
            this.CSVButton.Margin = new System.Windows.Forms.Padding(0, 7, 8, 8);
            this.CSVButton.Name = "CSVButton";
            this.CSVButton.Size = new System.Drawing.Size(45, 23);
            this.CSVButton.TabIndex = 1;
            this.CSVButton.Text = "...";
            this.CSVButton.UseVisualStyleBackColor = true;
            this.CSVButton.Click += new System.EventHandler(this.CSVButton_Click);
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
            // CSVNameTextBox
            // 
            this.CSVNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CSVNameTextBox.Location = new System.Drawing.Point(111, 8);
            this.CSVNameTextBox.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.CSVNameTextBox.Name = "CSVNameTextBox";
            this.CSVNameTextBox.Size = new System.Drawing.Size(245, 20);
            this.CSVNameTextBox.TabIndex = 0;
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 148);
            this.Controls.Add(this.ExportProgressBar);
            this.Controls.Add(this.ExportGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ExportForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export";
            this.ExportGroupBox.ResumeLayout(false);
            this.ExportGroupBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar ExportProgressBar;
        private System.Windows.Forms.GroupBox ExportGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button CSVButton;
        private System.Windows.Forms.Label CSVPathLabel;
        private System.Windows.Forms.TextBox CSVNameTextBox;
    }
}