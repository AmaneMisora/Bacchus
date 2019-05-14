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

namespace Bacchus
{
    public partial class FormMain : Form
    {
        private int SortedColumn;

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

        private void MainTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            MainListView.Columns.Clear();
            MainListView.Items.Clear();


            String nodeCliked = e.Node.Text;
            switch (nodeCliked)
            {
                case "Articles":    
                    int ColumnsWidth = MainListView.Width / 6; //faire en sorte que cela sadapte a chaque changment de taille de la fenetre
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

        private void MainListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
          
            int NumColumn = e.Column;
            if (NumColumn == SortedColumn)
            {
                //trier pas ordre ascendant 
                //trier utiliser icompare
                //creer les groupes en fonction de si il a cliquer sur la bonne colonne 
                //factoriser le code plus bas car il se repete
                SortedColumn = NumColumn;
                switch (NumColumn)
                {
                    case 0:
                        MainListView.Columns.Clear();
                        MainListView.Items.Clear();
                        MainListView.Columns.Add("Marques");
                        break;
                    case 1:
                        MainListView.Columns.Clear();
                        MainListView.Columns.Add("Familles");
                        break;
                    case 2:
                        MainListView.Columns.Clear();
                        MainListView.Columns.Add("Familles");
                        break;
                    case 3:
                        MainListView.Columns.Clear();
                        MainListView.Columns.Add("Familles");
                        break;
                    case 4:
                        MainListView.Columns.Clear();
                        MainListView.Columns.Add("Familles");
                        break;
                    case 5:
                        MainListView.Columns.Clear();
                        MainListView.Columns.Add("Familles");
                        break;
                    default:
                        break;
                }

            }
            else
            {
                //trier pas ordre descendant 
            }

        }   
    }
}
