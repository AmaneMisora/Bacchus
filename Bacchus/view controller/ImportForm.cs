using Bacchus.dao;
using Bacchus.model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Bacchus
{
    public partial class ImportForm : Form
    {
        public ImportForm()
        {
            InitializeComponent();
        }

        private void CSVButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.Filter = "Fichiers CSV (*.csv)| *.csv";
            
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string CVSPath = Path.GetFullPath(folderBrowser.FileName);
                CSVNameTextBox.Clear();
                CSVNameTextBox.AppendText(CVSPath);
            }
        }

        private void OverwriteButton_Click(object sender, EventArgs e)
        {
            //clear db
            try
            {
                using (var con = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
                {
                    //delete all statement of table Articles
                    using (var Command = new SQLiteCommand("DELETE FROM Articles;"))
                    {
                        //execute query
                        Command.Connection = con;
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();
                        con.Close();
                    }

                    //delete all statement of table Marques
                    using (var Command = new SQLiteCommand("DELETE FROM Marques;"))
                    {
                        //execute query
                        Command.Connection = con;
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();
                        con.Close();
                    }

                    //delete all statement of table SousFamilles
                    using (var Command = new SQLiteCommand("DELETE FROM SousFamilles;"))
                    {
                        //execute query
                        Command.Connection = con;
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();
                        con.Close();
                    }

                    //delete all statement of table Familles
                    using (var Command = new SQLiteCommand("DELETE FROM Familles;"))
                    {
                        //execute query
                        Command.Connection = con;
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();
                        con.Close();
                    }

                    MessageBox.Show("db Cleared");
                }

            }
            catch (Exception ExceptionCaught)
            {
                MessageBox.Show("Error while clearing db : " + ExceptionCaught);
            }

            //add to db


            //Test SubFamilyDAO
            /*
             */

            //Test FamilyDAO (ok)
            /*
            FamilyDAO.addFamily(new model.Family(0, "test0"));
            MessageBox.Show("Ref : " + FamilyDAO.getFamilyById(0).RefFamily, FamilyDAO.getFamilyById(0).NameFamily);
            MessageBox.Show("Ref : " + FamilyDAO.getFamilyByName("test0").RefFamily, FamilyDAO.getFamilyByName("test0").NameFamily);
            FamilyDAO.addFamily(new model.Family(1, "test1"));
            FamilyDAO.addFamily(new model.Family(2, "test2"));
            FamilyDAO.editFamily(1, "edit");
            model.Family[] Familys = FamilyDAO.getAllFamilys();
            MessageBox.Show("Nombre de lignes à la fin : " + FamilyDAO.nbFamilys());
            MessageBox.Show("Ref : " + Familys[0].RefFamily, Familys[0].NameFamily);
            MessageBox.Show("Ref : " + Familys[1].RefFamily, Familys[1].NameFamily);
            MessageBox.Show("Ref : " + Familys[2].RefFamily, Familys[2].NameFamily);
            */

            //Tests BrandDAO (ok)
            /*
            BrandDAO.addBrand(new model.Brand(0, "test0"));
            MessageBox.Show("Ref : " + BrandDAO.getBrandById(0).RefBrand, BrandDAO.getBrandById(0).NameBrand);
            BrandDAO.addBrand(new model.Brand(1, "test1"));
            BrandDAO.addBrand(new model.Brand(2, "test2"));
            BrandDAO.editBrand(1, "edit");
            model.Brand[] brands = BrandDAO.getAllBrands();
            MessageBox.Show("Nombre de lignes à la fin : " + BrandDAO.nbBrands());
            MessageBox.Show("Ref : " + brands[0].RefBrand, brands[0].NameBrand);
            MessageBox.Show("Ref : " + brands[1].RefBrand, brands[1].NameBrand);
            MessageBox.Show("Ref : " + brands[2].RefBrand, brands[2].NameBrand);
            */

            /*
            //read csv
            model.Brand BrandToAdd = new model.Brand("test", "test");


            using (var con = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("INSERT INTO Marques VALUES ('" + BrandToAdd.NameBrand + "', '" + BrandToAdd.RefBrand + "');"))
                    {
                        // Execute query
                        Command.Connection = con;
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Marque " + BrandToAdd.NameBrand + " créée");

                        MessageBox.Show("nb lines : " + BrandDAO.nbBrands());
                    }
                }
                catch (Exception ExceptionCaught)
                {
                    MessageBox.Show("Marque " + BrandToAdd.NameBrand + " non créée : \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString() );
                    con.Close();
                }


            }
            try
            {
                BrandDAO.addBrand(new model.Brand("test","test"));
                MessageBox.Show("nb marques" + BrandDAO.nbBrands().ToString());
                BrandDAO.editBrand("test", "edit");
                BrandDAO.getAllBrands();
            }
            catch (Exception ExceptionCaught)
            {
                MessageBox.Show(ExceptionCaught.Message.ToString(), ExceptionCaught.GetType().ToString());
            }
            */

            MessageBox.Show("Juste parce que c'est satisfaisant d'afficher une fenêtre quand il n'y a pas d'erreur", "Exécution réussie");

        }

        private void CSVNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            
            using (var reader = new StreamReader(@CSVNameTextBox.Text))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    /*
                    //TODO verifier a chaque fois si les brand et famille n'existe pas 
                    SubFamily SubFamilyToAdd = new SubFamily(values[4]);// TODO peut etre family avant subfamily 
                    Family FamilyToAdd = new Family(values[3], SubFamilyToAdd);
                    Brand BrandToAdd = new Brand(values[2]);
                    //TODO couper values[0] en 2 pour avoir la quantite et la descritption
                    //TODO rajouter un constucteur de article avec quantite
                    Article ArticleToAdd = new Article(values[1] ref, values[0] description, SubFamilyToAdd subfamily, FamilyToAdd family, BrandToAdd brand, values[5] PriceHT, values[0] Quantity);
                    */
                }
            }
        }
    }
}
