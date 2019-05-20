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

namespace Bacchus
{
    public partial class FormMain : Form
    {
        private int SortedColumn;

        // Declare a Hashtable array in which to store the groups.
        private Hashtable[] groupTables;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void ImporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportForm f = new ImportForm();
            f.ShowDialog(this);
        }

        private void ExporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ExportForm f = new ExportForm();
            //f.ShowDialog(this);
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


            String nodeCliked = Event.Node.Text;
            switch (nodeCliked)
            {
                case "Articles":
                    int ColumnsWidth = MainListView.Width / 6; //faire en sorte que cela sadapte a chaque changment de taille de la fenetre (optionnel)
                    MainListView.Columns.Add("Description", ColumnsWidth);
                    MainListView.Columns.Add("Ref", ColumnsWidth);
                    MainListView.Columns.Add("Marque", ColumnsWidth);
                    MainListView.Columns.Add("Famille", ColumnsWidth);
                    MainListView.Columns.Add("Sous-Famille", ColumnsWidth);
                    MainListView.Columns.Add("Prix H.T.", ColumnsWidth);
                    string[] arr = new string[6];
                    ListViewItem itm;
                    //add items to ListView
                    arr[0] = "12 Billes gel G1 Pilot Bleu";
                    arr[1] = "F0010087";
                    arr[2] = "Pilot";
                    arr[3] = "Ecriture & Correction";
                    arr[4] = "Stylos, feutres & rollers";
                    arr[5] = "7,05";
                    itm = new ListViewItem(arr);
                    MainListView.Items.Add(itm);

                    arr[0] = "12 Crayons à papier Tradition HB";
                    arr[1] = "F0000019";
                    arr[2] = "Conté";
                    arr[3] = "Ecriture & Correction";
                    arr[4] = "Crayons & Porte-mines";
                    arr[5] = "5,09";
                    itm = new ListViewItem(arr);
                    MainListView.Items.Add(itm);

                    arr[0] = "12 Crayons graphite Foray HB";
                    arr[1] = "F1646150";
                    arr[2] = "Foray";
                    arr[3] = "Ecriture & Correction";
                    arr[4] = "Crayons & Porte-mines";
                    arr[5] = "2,69";
                    itm = new ListViewItem(arr);
                    MainListView.Items.Add(itm);

                    //ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);



                    break;
                case "Marques":
                    //faire un clear column avant
                    MainListView.Columns.Add("Marques");
                    break;
                case "Familles":
                    MainListView.Columns.Add("Familles");
                    break;
                case "Sous familles":
                    MainListView.Columns.Add("Sous familles");
                    break;
                default:
                    break;
            }

        }

        private void MainListView_ColumnClick(object sender, ColumnClickEventArgs Event)
        {

            SortColumn(Event);

            //creer les groupes en fonction de si il a cliquer sur la bonne colonne 
            //factoriser le code plus bas car il se repete
            switch (Event.Column)
            {
                case 0: //Description
                    MainListView.Groups.Clear();
                    break;
                case 1: //Ref
                    MainListView.Groups.Clear();
                    break;
                case 2: //Marques
                    MainListView.Groups.Clear();
                    SetGroups(2);
                    break;
                case 3: //Famille
                    MainListView.Groups.Clear();
                    SetGroups(3);
                    break;
                case 4: //Sous-Famille
                    MainListView.Groups.Clear();
                    SetGroups(4);
                    break;
                case 5: //Prix H.T.
                    MainListView.Groups.Clear();
                    //faire un group par tranche de prix si j'ai le temps
                    break;
                default:
                    break;
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
    }
}
