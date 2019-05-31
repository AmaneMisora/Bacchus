using Bacchus.dao;

using System;
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
                        SQLiteDataAdapter adp = new SQLiteDataAdapter(Command);
                        con.Close();
                    }

                    //delete all statement of table Marques
                    using (var Command = new SQLiteCommand("DELETE FROM Marques;"))
                    {
                        //execute query
                        Command.Connection = con;
                        Command.Connection.Open();
                        SQLiteDataAdapter adp = new SQLiteDataAdapter(Command);
                        con.Close();
                    }

                    //delete all statement of table SousFamilles
                    using (var Command = new SQLiteCommand("DELETE FROM SousFamilles;"))
                    {
                        //execute query
                        Command.Connection = con;
                        Command.Connection.Open();
                        SQLiteDataAdapter adp = new SQLiteDataAdapter(Command);
                        con.Close();
                    }

                    //delete all statement of table Familles
                    using (var Command = new SQLiteCommand("DELETE FROM Familles;"))
                    {
                        //execute query
                        Command.Connection = con;
                        Command.Connection.Open();
                        SQLiteDataAdapter adp = new SQLiteDataAdapter(Command);
                        con.Close();
                    }

                    MessageBox.Show("db Cleared");
                }
            
            }
            catch(Exception ExceptionCaught)
            {
                MessageBox.Show("Error while clearing db : " + ExceptionCaught);
            }


            /*
            //read csv
            model.Brand BrandToAdd = new model.Brand("test", "test");


            // Add to db
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
            */

            //add to db
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
            MessageBox.Show("Juste parce que c'est satisfaisant d'afficher une fenêtre quand il n'y a pas d'erreur", "Exécution réussie");

        }

    }
}
