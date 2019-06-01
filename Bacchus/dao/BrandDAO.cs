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
        public static void addBrand(Brand BrandToAdd)
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
        /// Change the name of a brand
        /// </summary>
        /// <param name="BrandRef"></param>
        /// <param name="NewBrandName"></param>
        public static void editBrand(int BrandRef, String NewBrandName)
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
                    using (var Command = new SQLiteCommand("UPDATE Marques SET Nom = " + NewBrandName + " WHERE RefMarque = " + BrandRef + "; "))
                    {
                        // Execute query
                        Command.Connection = Connection;
                        Command.Connection.Open();
                        SQLiteDataAdapter adp = new SQLiteDataAdapter(Command);
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
        public static Brand[] getAllBrands()
        {
            //The number of brands to get
            int NbBrands = BrandDAO.nbBrands();
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
        public static Brand getBrandById(int BrandRef)
        {
            Brand BrandToReturn = new Brand();

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT * FROM Marques WHERE RefMarque = '" + BrandRef + "';"))
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
                        MessageBox.Show("Echec de la récupération de la Marque " + BrandRef + "\n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                    }
                }
            }

            return BrandToReturn;


        }

        /// <summary>
        /// Count the number of brands in the db
        /// </summary>
        /// <returns></returns>
        public static int nbBrands()
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
