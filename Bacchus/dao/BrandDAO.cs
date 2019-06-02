using Bacchus.model;

using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace Bacchus.dao
{
    static class BrandDAO
    {
        /// <summary>
        /// Add a new brand to the db
        /// </summary>
        /// <param name="BrandToAdd"></param>
        public static void AddBrand(Brand BrandToAdd)
        {
            // Verifications
            if (BrandToAdd.NameBrand.Equals("") || BrandToAdd.NameBrand == null)
            {
                throw new ArgumentNullException("Brand Name");
            }
            if (BrandToAdd.RefBrand == -1)
            {
                throw new ArgumentException("La référence de la Marque ne doit pas être égale à -1");
            }

            // Add to db
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("INSERT INTO Marques VALUES (" + BrandToAdd.RefBrand + ", '" + BrandToAdd.NameBrand + "');"))
                    {
                        // Execute query
                        Command.Connection = Connection;
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();
                        Connection.Close();
                    }
                }
                catch (Exception ExceptionCaught)
                {
                    MessageBox.Show("Marque " + BrandToAdd.NameBrand + " non créée\n" + ExceptionCaught.Message.ToString());
                    Connection.Close();
                }
            }
        }

        /// <summary>
        /// Supprime la marque correspodant à la ref passée en paramètre
        /// </summary>
        /// <param name="BrandRef"></param>
        public static void DeleteBrand(int BrandRef)
        {
            //vérifications (la marque ne doit pas avoir d'article)
            DataTable SQLRequestDataTable = new DataTable();
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT COUNT(*) FROM Articles WHERE RefMarque = " + BrandRef + ";"))
                {
                    try
                    {
                        //Execution de la requête
                        Command.Connection = Connection;
                        Command.Connection.Open();
                        SQLiteDataAdapter adp = new SQLiteDataAdapter(Command);
                        adp.Fill(SQLRequestDataTable);
                        if (Convert.ToInt32(SQLRequestDataTable.Rows[0][0]) != 0)
                        {
                            MessageBox.Show("Il existe des articles utilisant cette marque. Il n'est pas possible de la supprimer");
                            return;
                        }
                        Connection.Close();
                    }
                    catch (Exception)
                    {
                        Connection.Close();
                    }
                }
            }

            // Suppression de la base de donnée
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("DELETE FROM Marques WHERE RefMarque = " + BrandRef + "; "))
                    {
                        //Execution de la requête
                        Command.Connection = Connection;
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();
                        Connection.Close();
                    }
                }
                catch (Exception ExceptionCaught)
                {
                    Connection.Close();
                    MessageBox.Show("Marque " + BrandRef + " non supprimée : \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                }
            }

        }

        /// <summary>
        /// Change the name of a brand
        /// </summary>
        /// <param name="BrandRef"></param>
        /// <param name="NewBrandName"></param>
        public static void EditBrand(int BrandRef, String NewBrandName)
        {
            // Verifications
            if (NewBrandName.Equals("") || NewBrandName == null)
            {
                throw new ArgumentNullException("Brand Ref");
            }

            // Add to db
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("UPDATE Marques SET Nom = '" + NewBrandName + "' WHERE RefMarque = " + BrandRef + "; "))
                    {
                        // Execute query
                        Command.Connection = Connection;
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();
                        Connection.Close();
                    }
                }
                catch (Exception ExceptionCaught)
                {
                    Connection.Close();
                    MessageBox.Show("Marque " + BrandRef + " non modifièe : \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                }
            }
        }

        /// <summary>
        /// Get all brands from db 
        /// </summary>
        /// <returns></returns>
        public static Brand[] GetAllBrands()
        {
            //The number of brands to get
            int NbBrands = BrandDAO.NbBrands();
            //The table to return
            Brand[] listToReturn = new Brand[NbBrands];

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT * FROM Marques;"))
                {
                    try
                    {
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        using (SQLiteDataReader Reader = Command.ExecuteReader())
                        {
                            for (int currentBrandIndex = 0; currentBrandIndex < NbBrands; currentBrandIndex++)
                            {
                                Reader.Read();

                                Brand BrandToAdd = new Brand();

                                BrandToAdd.RefBrand = (int) Reader[0];
                                BrandToAdd.NameBrand = Reader[1].ToString();
                                
                                listToReturn.SetValue(BrandToAdd, currentBrandIndex);
                            }
                        }

                    }
                    catch (Exception ExceptionCaught)
                    {
                        Connection.Close();
                        listToReturn = null;
                        MessageBox.Show("Echec de la récupération des données de la table Marques  \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                    }
                }
            }

            return listToReturn;
        }



        /// <summary>
        /// Get the Brand corresponding to the Ref BrandRef
        /// </summary>
        /// <param name="BrandRef"></param>
        /// <returns></returns>
        public static Brand GetBrandById(int BrandRef)
        {
            Brand BrandToReturn = new Brand();

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT * FROM Marques WHERE RefMarque = " + BrandRef + ";"))
                {
                    try
                    {
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        using (SQLiteDataReader Reader = Command.ExecuteReader())
                        {
                            Reader.Read();

                            BrandToReturn.RefBrand = (int)Reader[0];
                            BrandToReturn.NameBrand = Reader[1].ToString();
                        }

                    }
                    catch (Exception ExceptionCaught)
                    {
                        Connection.Close();
                        BrandToReturn = null;
                       // MessageBox.Show("Echec de la récupération de la Marque " + BrandRef + "\n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                    }
                }
            }

            return BrandToReturn;
        }

        /// <summary>
        /// Count the number of brands in the db
        /// </summary>
        /// <returns></returns>
        public static int NbBrands()
        {
            int Result = -1;

            var DataTableToReturn = new DataTable();

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT COUNT(*) FROM Marques;"))
                {
                    try
                    {
                        //execute query
                        Command.Connection = Connection;
                        Command.Connection.Open();
                        SQLiteDataAdapter adp = new SQLiteDataAdapter(Command);
                        adp.Fill(DataTableToReturn);
                        Result = Convert.ToInt32(DataTableToReturn.Rows[0][0].ToString());
                        Connection.Close();
                    }
                    catch (Exception ExceptionCaught)
                    {
                        Connection.Close();
                        MessageBox.Show("Echec" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());

                    }
                }
            }

            return Result;

        }

    }

}
