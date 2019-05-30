namespace Bacchus
{
    partial class FormMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Articles");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Marques");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Familles");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Sous familles");
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActualiserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.MainTreeView = new System.Windows.Forms.TreeView();
            this.MainSplitter = new System.Windows.Forms.Splitter();
            this.MainListView = new System.Windows.Forms.ListView();
            this.MainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FichierToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // FichierToolStripMenuItem
            // 
            this.FichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActualiserToolStripMenuItem,
            this.ImporterToolStripMenuItem,
            this.ExporterToolStripMenuItem});
            this.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem";
            this.FichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.FichierToolStripMenuItem.Text = "Fichier";
            // 
            // ActualiserToolStripMenuItem
            // 
            this.ActualiserToolStripMenuItem.Name = "ActualiserToolStripMenuItem";
            this.ActualiserToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ActualiserToolStripMenuItem.Text = "Actualiser";
            // 
            // ImporterToolStripMenuItem
            // 
            this.ImporterToolStripMenuItem.Name = "ImporterToolStripMenuItem";
            this.ImporterToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ImporterToolStripMenuItem.Text = "Importer";
            this.ImporterToolStripMenuItem.Click += new System.EventHandler(this.ImporterToolStripMenuItem_Click);
            // 
            // ExporterToolStripMenuItem
            // 
            this.ExporterToolStripMenuItem.Name = "ExporterToolStripMenuItem";
            this.ExporterToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ExporterToolStripMenuItem.Text = "Exporter";
            this.ExporterToolStripMenuItem.Click += new System.EventHandler(this.ExporterToolStripMenuItem_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 428);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(800, 22);
            this.MainStatusStrip.TabIndex = 1;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // MainTreeView
            // 
            this.MainTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainTreeView.Location = new System.Drawing.Point(0, 24);
            this.MainTreeView.MinimumSize = new System.Drawing.Size(200, 4);
            this.MainTreeView.Name = "MainTreeView";
            treeNode1.Name = "ArticlesNode";
            treeNode1.Text = "Articles";
            treeNode2.Name = "MarquesNode";
            treeNode2.Text = "Marques";
            treeNode3.Name = "FamillesNode";
            treeNode3.Text = "Familles";
            treeNode4.Checked = true;
            treeNode4.Name = "SousFamillesNode";
            treeNode4.Text = "Sous familles";
            this.MainTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.MainTreeView.Size = new System.Drawing.Size(200, 404);
            this.MainTreeView.TabIndex = 2;
            this.MainTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MainTreeView_AfterSelect);
            this.MainTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.MainTreeView_NodeMouseClick);
            // 
            // MainSplitter
            // 
            this.MainSplitter.Location = new System.Drawing.Point(200, 24);
            this.MainSplitter.Name = "MainSplitter";
            this.MainSplitter.Size = new System.Drawing.Size(3, 404);
            this.MainSplitter.TabIndex = 3;
            this.MainSplitter.TabStop = false;
            // 
            // MainListView
            // 
            this.MainListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainListView.FullRowSelect = true;
            this.MainListView.Location = new System.Drawing.Point(203, 24);
            this.MainListView.MultiSelect = false;
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(597, 404);
            this.MainListView.TabIndex = 4;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            this.MainListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.MainListView_ColumnClick);
            this.MainListView.SelectedIndexChanged += new System.EventHandler(this.MainListView_SelectedIndexChanged);
            this.MainListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainListView_MouseDoubleClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainListView);
            this.Controls.Add(this.MainSplitter);
            this.Controls.Add(this.MainTreeView);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.MainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.Text = "Fenetre principale";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ActualiserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImporterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExporterToolStripMenuItem;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.TreeView MainTreeView;
        private System.Windows.Forms.Splitter MainSplitter;
        private System.Windows.Forms.ListView MainListView;
    }
}

