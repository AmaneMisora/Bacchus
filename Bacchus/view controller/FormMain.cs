using System;
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
        private int SortedColumn;           // enregistre la dernière colonne triée
        private String NodeSelected = "";   // enregistre sur quel noeud l'utilisateur a cliqué

        /// <summary>
        /// Constructeur de la fenetre FormMain
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Ouvre la fenetre d'import lorsque l'on clique sur "importer" dans le menu
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void ImporterToolStripMenuItem_Click(object Sender, EventArgs Event)
        {
            ImportForm f = new ImportForm();
            f.ShowDialog(this);
        }

        /// <summary>
        /// Ouvre la fenetre d'export lorsque l'on clique sur "exporter" dans le menu
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void ExporterToolStripMenuItem_Click(object Sender, EventArgs Event)
        {
            ExportForm f = new ExportForm();
            f.ShowDialog(this);
        }

        /// <summary>
        /// Actualise le tableau lié au noeud où l'on travaille actuellement lorsque l'on clique sur "Actualiser" dans le menu
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void ActualiserToolStripMenuItem_Click(object Sender, EventArgs Event)
        {
            UpdateListView(NodeSelected);
        }

        private void MainTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void MainListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Créer le tableau lié au noeud de la TreeView sur lequel on clique
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void MainTreeView_NodeMouseClick(object Sender, TreeNodeMouseClickEventArgs Event)
        {
            // affiche le bon tableau en fonction du noeud selectionné sur le treeview
            String NodeCliked = Event.Node.Text;
            int ColumnsWidth = 0;
            switch (NodeCliked)
            {
                case "Articles": // si on clique sur le noeud "Articles"
                    MainListView.ListViewItemSorter = null;
                    NodeSelected = "Articles";
                    MainListView.Groups.Clear();
                    MainListView.Columns.Clear();
                    MainListView.Items.Clear();
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


                    Article[0] = "12";
                    Article[1] = "ZBilles gel G1 Pilot Bleu";
                    Article[2] = "F0010087";
                    Article[3] = "Pilot";
                    Article[4] = "Ecriture & Correction";
                    Article[5] = "Stylos, feutres & rollers";
                    Article[6] = "7,05";
                    ArcticleItem = new ListViewItem(Article);
                    MainListView.Items.Add(ArcticleItem);
                    break;

                case "Marques": // si on clique sur le noeud "Marques"
                    NodeSelected = "Marques";
                    UpdateListView(NodeSelected);
                    break;

                case "Familles": // si on clique sur le noeud "Familles"
                    NodeSelected = "Familles";
                    UpdateListView(NodeSelected);
                    break;

                case "Sous familles": // si on clique sur le noeud "Sous familles"
                    MainListView.ListViewItemSorter = null;
                    NodeSelected = "Sous familles";
                    MainListView.Groups.Clear();
                    MainListView.Columns.Clear();
                    MainListView.Items.Clear();
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

        /// <summary>
        /// Trie en fonction du tableau sur lequel on travaille et la colonne sur laquel on a cliqué
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void MainListView_ColumnClick(object Sender, ColumnClickEventArgs Event)
        {
            // cherche le tableau sur lequel on travaille 
            switch (NodeSelected)
            {
                case "Articles":
                    //trie
                    SortColumn(Event);

                    // creer les groupes en fonction de si il a cliquer sur la bonne colonne 
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
                            SetGroups(3);
                            break;

                        case 4: //Famille
                            MainListView.Groups.Clear();
                            SetGroups(4);
                            break;

                        case 5: //Sous-Famille
                            MainListView.Groups.Clear();
                            SetGroups(5);
                            break;

                        case 6: //Prix H.T.
                            MainListView.Groups.Clear();
                            //faire un group par tranche de prix si j'ai le temps
                            break;

                        default:
                            break;

                    }
                    break;

                case "Marques":
                    MainListView.Groups.Clear();
                    SortColumn(Event);
                    break;

                case "Familles":
                    MainListView.Groups.Clear();
                    SortColumn(Event);
                    break;
                case "Sous familles":
                    MainListView.Groups.Clear();
                    SortColumn(Event);
                    break;

                default:
                    break;

            }
           
            
        }

        /// <summary>
        /// Ouvre la fenetre de modification si on double click sur un element
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void MainListView_MouseDoubleClick(object Sender, MouseEventArgs Event)
        {
            // trouve l'élément selectionné (unique)
            ListViewItem SelectedItem = MainListView.SelectedItems[0];

            // vérifie sur quel tableau on travaille et ouvre la bonne fenetre de modification
            OpenModifyForm(NodeSelected, SelectedItem);
            
        }

        /// <summary>
        /// S'active si on appuie sur la touche entrer ou la touche F5
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void MainListView_KeyDown(object Sender, KeyEventArgs Event)
        {
            // si on appuie sur la touche entrer, ouvre la fenetre de modification de l'élément sélectionné
            if (Event.KeyCode == Keys.Enter)
            {   
                // vérifie si un item est bien sélectionné
                if (MainListView.SelectedItems.Count > 0)
                {
                    ListViewItem SelectedItem = MainListView.SelectedItems[0];

                    // vérifie sur quel tableau on travaille et ouvre la bonne fenetre de modification 
                    OpenModifyForm(NodeSelected, SelectedItem);
                }
            }

            // si on appuie sur la touche F5, recharge la liste des éléments 
            if (Event.KeyCode == Keys.F5)
            {
                UpdateListView(NodeSelected);
            }
        }

        // Sets myListView to the groups created for the specified column.
        /// <summary>
        /// Créer des groups pour chacun des différents objets de la colonne spécifiée
        /// </summary>
        /// <param name="Column"></param>
        private void SetGroups(int Column)
        {
            String LastGroup;
            List<String> ListGroup = new List<String>();
            LastGroup = MainListView.Items[0].SubItems[Column].Text;
            ListGroup.Add(MainListView.Items[0].SubItems[Column].Text);
            MainListView.Groups.Add(new ListViewGroup(LastGroup, HorizontalAlignment.Left));
            foreach (ListViewItem item in MainListView.Items)
            {
                if (LastGroup != item.SubItems[Column].Text)
                {
                    LastGroup = item.SubItems[Column].Text;
                    ListGroup.Add(item.SubItems[Column].Text);
                    MainListView.Groups.Add(new ListViewGroup(LastGroup, HorizontalAlignment.Left));
                    MainListView.Columns.Add(MainListView.Groups[1].Header);
                }
                
                foreach (ListViewGroup GroupCreated in MainListView.Groups)
                {
                    if (GroupCreated.Header == item.SubItems[Column].Text)
                    {
                        item.Group = GroupCreated;
                    }
                }

            }
        }

        /// <summary>
        /// Ouvre la fenetre d'ajout d'un élément à partir de "ajouter élément" du clique droit
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void ajouterÉlémentToolStripMenuItem_Click(object Sender, EventArgs Event)
        {
            // vérifie sur quel tableau on travaille et ouvre la bonne fenetre de création d'un élément
            OpenAddForm(NodeSelected);
        }

        /// <summary>
        /// Ouvre la fenetre de modification d'un élément à partir de "modifier élément" du clique droit
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void modifierÉlémentToolStripMenuItem_Click(object Sender, EventArgs Event)
        {
            // vérifie si un élément est séléctionné 
            if (MainListView.SelectedItems.Count > 0)
            {
                ListViewItem SelectedItem = MainListView.SelectedItems[0];

                // vérifie sur quel tableau on travaille et ouvre la bonne fenetre de modification d'un élément
                OpenModifyForm(NodeSelected, SelectedItem);
            }
        }

        /// <summary>
        /// Ouvre la bonne fenetre de modification en fonction du nom du noeud sur lequel on travaille et un élément à modifier
        /// </summary>
        /// <param name="NodeName">le nom du noeud sur lequel on travaille</param>
        /// <param name="SelectedItem">l'élément à modifier qui est une ligne du tableau</param>
        private void OpenModifyForm(String NodeName, ListViewItem SelectedItem)
        {
            switch (NodeName)
            {
                case "Articles":
                    ModifyArticleForm NewModifyArticleForm = new ModifyArticleForm(SelectedItem);
                    NewModifyArticleForm.ShowDialog(this);
                    UpdateListView("Articles");
                    break;

                case "Marques":
                    ModifyBrandForm NewModifyBrandForm = new ModifyBrandForm(SelectedItem);
                    NewModifyBrandForm.ShowDialog(this);
                    UpdateListView("Marques");
                    break;

                case "Familles":
                    ModifyFamilyForm NewModifyFamilyForm = new ModifyFamilyForm(SelectedItem);
                    NewModifyFamilyForm.ShowDialog(this);
                    UpdateListView("Familles");
                    break;

                case "Sous familles":
                    ModifySubFamilyForm NewModifySubFamilyForm = new ModifySubFamilyForm(SelectedItem);
                    NewModifySubFamilyForm.ShowDialog(this);
                    UpdateListView("Sous familles");
                    break;

                default:
                    break;

            }
        }

        /// <summary>
        /// Ouvre la bonne fenetre d'ajout en fonction du nom du noeud sur lequel on travaille
        /// </summary>
        /// <param name="NodeName">le nom du noeud sur lequel on travaille</param>
        private void OpenAddForm(String NodeName)
        {
            switch (NodeName)
            {
                case "Articles":
                    AddArticleForm NewAddArticleForm = new AddArticleForm();
                    NewAddArticleForm.ShowDialog(this);
                    UpdateListView("Articles");
                    break;

                case "Marques":
                    AddBrandForm NewAddBrandForm = new AddBrandForm();
                    NewAddBrandForm.ShowDialog(this);
                    UpdateListView("Marques");
                    break;

                case "Familles":
                    AddFamilyForm NewAddFamilyForm = new AddFamilyForm();
                    NewAddFamilyForm.ShowDialog(this);
                    UpdateListView("Familles");
                    break;

                case "Sous familles":
                    AddSubFamilyForm NewAddSubFamilyForm = new AddSubFamilyForm();
                    NewAddSubFamilyForm.ShowDialog(this);
                    UpdateListView("Sous familles");
                    break;

                default:
                    break;

            }
        }

        /// <summary>
        /// Trie les colonnes dans l'ordre ascendant au premier clique et descendant au deuxième
        /// </summary>
        /// <param name="Event"></param>
        private void SortColumn(ColumnClickEventArgs Event)
        {

            // Verifie si la colonne cliquée est la meme que la derniere fois 
            if (Event.Column != SortedColumn)
            {
                // mais a jour la derniere colonne cliquee
                SortedColumn = Event.Column;
                // puis mets le tri en ascendant
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
            MainListView.ListViewItemSorter = new ListViewItemComparer(Event.Column, MainListView.Sorting);
        }

        /// <summary>
        /// recréer les tableaux en fonctions des données de la bdd pour le mettre à jour
        /// </summary>
        /// <param name="NodeName"></param>
        private void UpdateListView(String NodeName)
        {
            // reinitialise le trie
            MainListView.ListViewItemSorter = null;

            // choisi quel tableau mettre à jour ou créer
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
