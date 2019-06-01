﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections;
using Bacchus.dao;
using Bacchus.model;

namespace Bacchus
{
    public partial class FormMain : Form
    {
        private int SortedColumn;
        private String NodeSelected = ""; // enregistre sur quel noeud l'utilisateur à cliqué

        // Declare a Hashtable array in which to store the groups.
        private Hashtable[] groupTables;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void ImporterToolStripMenuItem_Click(object sender, EventArgs Event)
        {
            ImportForm f = new ImportForm();
            f.ShowDialog(this);
        }

        private void ExporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportForm f = new ExportForm();
            f.ShowDialog(this);
        }

        private void MainTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void MainListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs Event)
        {

            MainListView.Columns.Clear();
            MainListView.Items.Clear();

            // affiche le bon tableau en fonction du noeud selectionné sur le treeview
            String NodeCliked = Event.Node.Text;
            int ColumnsWidth = 0;
            switch (NodeCliked)
            {
                case "Articles": // si on clique sur le noeud "Articles"
                    NodeSelected = "Articles";
                    ColumnsWidth = MainListView.Width / 7;
                    MainListView.Columns.Add("Quantité", ColumnsWidth);
                    MainListView.Columns.Add("Description", ColumnsWidth);
                    MainListView.Columns.Add("Référence", ColumnsWidth);
                    MainListView.Columns.Add("Marque", ColumnsWidth);
                    MainListView.Columns.Add("Famille", ColumnsWidth);
                    MainListView.Columns.Add("Sous-Famille", ColumnsWidth);
                    MainListView.Columns.Add("Prix H.T.", ColumnsWidth);
                    string[] Article = new string[7];
                    //dao.ArticleDAO.getArticle();
                    // faire une boucle ou on ajoute chaque article de la list plus haut dans la listview
                    ListViewItem ArcticleItem;
                    // ajoute les items a la ListView
                    Article[0] = "12";
                    Article[1] = "Billes gel G1 Pilot Bleu";
                    Article[2] = "F0010087";
                    Article[3] = "Pilot";
                    Article[4] = "Ecriture & Correction";
                    Article[5] = "Stylos, feutres & rollers";
                    Article[6] = "7,05";
                    ArcticleItem = new ListViewItem(Article);
                    MainListView.Items.Add(ArcticleItem);

                    Article[0] = "12";
                    Article[1] = "Crayons à papier Tradition HB";
                    Article[2] = "F0000019";
                    Article[3] = "Conté";
                    Article[4] = "Ecriture & Correction";
                    Article[5] = "Crayons & Porte-mines";
                    Article[6] = "5,09";
                    ArcticleItem = new ListViewItem(Article);
                    MainListView.Items.Add(ArcticleItem);

                    Article[0] = "12";
                    Article[1] = "Crayons graphite Foray HB";
                    Article[2] = "F1646150";
                    Article[3] = "Foray";
                    Article[4] = "Ecriture & Correction";
                    Article[5] = "Crayons & Porte-mines";
                    Article[6] = "2,69";
                    ArcticleItem = new ListViewItem(Article);
                    MainListView.Items.Add(ArcticleItem);


                    break;
                case "Marques": // si on clique sur le noeud "Marques"
                    NodeSelected = "Marques";
                    UpdateListViewBrand(NodeSelected);
                    break;
                case "Familles": // si on clique sur le noeud "Familles"
                    NodeSelected = "Familles";
                    UpdateListViewBrand(NodeSelected);
                    break;
                case "Sous familles": // si on clique sur le noeud "Sous familles"
                    MainListView.Groups.Clear();
                    NodeSelected = "Sous familles";
                    ColumnsWidth = MainListView.Width / 3;
                    MainListView.Columns.Add("Nom", ColumnsWidth);
                    MainListView.Columns.Add("Référence", ColumnsWidth);
                    MainListView.Columns.Add("Famille", ColumnsWidth);

                    string[] SubFamily = new string[3];

                    ListViewItem SubFamilyItem;
                    // ajoute les items a la ListView
                    SubFamily[0] = "sousRetail";
                    SubFamily[1] = "beaucoup";
                    SubFamily[2] = "Retail";
                    SubFamilyItem = new ListViewItem(SubFamily);
                    MainListView.Items.Add(SubFamilyItem);

                    SubFamily[0] = "sousvallllaude";
                    SubFamily[1] = "moins";
                    SubFamily[2] = "vallllaude";
                    SubFamilyItem = new ListViewItem(SubFamily);
                    MainListView.Items.Add(SubFamilyItem);
                    break;
                default:
                    break;
            }

        }

        private void MainListView_ColumnClick(object sender, ColumnClickEventArgs Event)
        {

            SortColumn(Event);

            //creer les groupes en fonction de si il a cliquer sur la bonne colonne 
            switch (Event.Column)
            {
                case 0: //Quantity
                    MainListView.Groups.Clear();
                    break;
                case 1: //Description
                    MainListView.Groups.Clear();
                    break;
                case 2: //Ref
                    MainListView.Groups.Clear();
                    break;
                case 3: //Marques
                    MainListView.Groups.Clear();
                    SetGroups(2);
                    break;
                case 4: //Famille
                    MainListView.Groups.Clear();
                    SetGroups(3);
                    break;
                case 5: //Sous-Famille
                    MainListView.Groups.Clear();
                    SetGroups(4);
                    break;
                case 6: //Prix H.T.
                    MainListView.Groups.Clear();
                    //faire un group par tranche de prix si j'ai le temps
                    break;
                default:
                    break;
            }
            
        }

        private void MainListView_MouseDoubleClick(object sender, MouseEventArgs Event)
        {
            ListViewItem SelectedItem = MainListView.SelectedItems[0];
            // vérifie sur quel tableau on travaille
            OpenModifyForm(NodeSelected, SelectedItem);
            
        }

        private void MainListView_KeyDown(object sender, KeyEventArgs e)
        {
            // si on appuie sur la touche entrer, ouvre la fenetre de modification de l'élément séléctionné
            if (e.KeyCode == Keys.Enter)
            {   
                // vérifie si un item est bien séléctionné
                if (MainListView.SelectedItems.Count > 0)
                {
                    ListViewItem SelectedItem = MainListView.SelectedItems[0];
                    // vérifie sur quel tableau on travaille
                    OpenModifyForm(NodeSelected, SelectedItem);
                    
                }
            }
            // si on appuie sur la touche F5, recharge la liste des éléments 
            if (e.KeyCode == Keys.F5)
            {
                //TODO La touche F5 rechargera la liste des éléments tout comme le sous-menu « Actualiser ».
                //faire un getall en fonction du noeud selectionné (factorise le code dans MainTreeView_NodeMouseClick dans une fonction a part)
                UpdateListViewBrand(NodeSelected);
            }
        }

        // Sets myListView to the groups created for the specified column.
        private void SetGroups(int column)
        {
            String LastGroup;
            List<String> ListGroup = new List<String>();
            LastGroup = MainListView.Items[0].SubItems[column].Text;
            ListGroup.Add(MainListView.Items[0].SubItems[column].Text);
            MainListView.Groups.Add(new ListViewGroup(LastGroup, HorizontalAlignment.Left));
            foreach (ListViewItem item in MainListView.Items)
            {
                if (LastGroup != item.SubItems[column].Text)
                {
                    LastGroup = item.SubItems[column].Text;
                    ListGroup.Add(item.SubItems[column].Text);
                    MainListView.Groups.Add(new ListViewGroup(LastGroup, HorizontalAlignment.Left));
                    MainListView.Columns.Add(MainListView.Groups[1].Header);
                }
                
                foreach (ListViewGroup GroupCreated in MainListView.Groups)
                {

                    if (GroupCreated.Header == item.SubItems[column].Text)
                    {
                        item.Group = GroupCreated;
                    }
                }

            }

        }

        private void ajouterÉlémentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAddForm(NodeSelected);
        }

        private void modifierÉlémentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainListView.SelectedItems.Count > 0)
            {
                ListViewItem SelectedItem = MainListView.SelectedItems[0];
                // vérifie sur quel tableau on travaille
                OpenModifyForm(NodeSelected, SelectedItem);
            }
        }


        private void OpenModifyForm(String NodeName, ListViewItem SelectedItem)
        {
            switch (NodeName)
            {
                case "Articles":
                    ModifyArticleForm NewModifyArticleForm = new ModifyArticleForm(SelectedItem);
                    NewModifyArticleForm.ShowDialog(this);
                    break;
                case "Marques":
                    ModifyBrandForm NewModifyBrandForm = new ModifyBrandForm(SelectedItem);
                    NewModifyBrandForm.ShowDialog(this);
                    break;
                case "Familles":
                    ModifyFamilyForm NewModifyFamilyForm = new ModifyFamilyForm(SelectedItem);
                    NewModifyFamilyForm.ShowDialog(this);
                    break;
                case "Sous familles":
                    ModifySubFamilyForm NewModifySubFamilyForm = new ModifySubFamilyForm(SelectedItem);
                    NewModifySubFamilyForm.ShowDialog(this);
                    break;
                default:
                    break;
            }
        }

        private void OpenAddForm(String NodeName)
        {
            switch (NodeName)
            {
                case "Articles":
                    AddArticleForm NewAddArticleForm = new AddArticleForm();
                    NewAddArticleForm.ShowDialog(this);
                    break;
                case "Marques":
                    AddBrandForm NewAddBrandForm = new AddBrandForm();
                    NewAddBrandForm.ShowDialog(this);
                    UpdateListViewBrand("Marques");
                    break;
                case "Familles":
                    AddFamilyForm NewAddFamilyForm = new AddFamilyForm();
                    NewAddFamilyForm.ShowDialog(this);
                    break;
                case "Sous familles":
                    AddSubFamilyForm NewAddSubFamilyForm = new AddSubFamilyForm();
                    NewAddSubFamilyForm.ShowDialog(this);
                    break;
                default:
                    break;
            }
        }


        private void SortColumn(ColumnClickEventArgs Event)
        {

            // Verifie si la colonne cliquée est la meme que la derniere fois 
            if (Event.Column != SortedColumn)
            {
                // mais a jour la derniere colonne cliquee
                SortedColumn = Event.Column;
                // puis mais le tri en ascendant
                MainListView.Sorting = SortOrder.Ascending;
            }
            else
            {
                // inverse le tri (ascendant si descendant et vice versa)
                if (MainListView.Sorting == SortOrder.Ascending)
                    MainListView.Sorting = SortOrder.Descending;
                else
                    MainListView.Sorting = SortOrder.Ascending;
            }

            MainListView.Sort();
            // utilise ListViewItemComparer qui implemente ICompare pour trier
            this.MainListView.ListViewItemSorter = new ListViewItemComparer(Event.Column, MainListView.Sorting);
        }

        private void UpdateListViewBrand(String NodeName)
        {
            switch (NodeName)
            {
                case "Articles":
                    break;
                case "Marques":
                    Brand[] Brands = BrandDAO.getAllBrands();

                    MainListView.Columns.Clear();
                    MainListView.Items.Clear();
                    MainListView.Groups.Clear();
                    MainListView.Columns.Add("Nom");
                    MainListView.Columns.Add("Référence");
                    foreach (Brand B in Brands)
                    {

                        string[] BrandToAdd = new string[2];

                        ListViewItem BrandItem;
                        // ajoute les items a la ListView
                        BrandToAdd[0] = B.NameBrand;
                        BrandToAdd[1] = B.RefBrand.ToString();
                        BrandItem = new ListViewItem(BrandToAdd);
                        MainListView.Items.Add(BrandItem);
                    }
                    break;
                case "Familles":
                    Family[] Families = FamilyDAO.getAllFamilys();

                    MainListView.Columns.Clear();
                    MainListView.Items.Clear();
                    MainListView.Groups.Clear();
                    MainListView.Columns.Add("Nom");
                    MainListView.Columns.Add("Référence");
                    foreach (Family F in Families)
                    {

                        string[] FamilyToAdd = new string[2];

                        ListViewItem FamilyItem;
                        // ajoute les items a la ListView
                        FamilyToAdd[0] = F.NameFamily;
                        FamilyToAdd[1] = F.RefFamily.ToString();
                        FamilyItem = new ListViewItem(FamilyToAdd);
                        MainListView.Items.Add(FamilyItem);
                    }
                    break;
                case "Sous familles":
                    break;
                default:
                    break;
            }
            
        }
    }
}
