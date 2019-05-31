using Bacchus.model;

using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace Bacchus.dao
{
    static class BrandDAO
    {

        /**
         * Add a new brand to the db
         * param name="NewBrandRef" : the band's ref
         * param name="NewBrandName" : the brand's name
         */
        public static void addBrand(Brand BrandToAdd)
        {
            // Verifications
            if (BrandToAdd.NameBrand.Equals("") || BrandToAdd.NameBrand == null)
            {
                throw new ArgumentNullException("Brand Name");
            }

            // Add to db
            using (var con = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("INSERT INTO Marques VALUES (" + BrandToAdd.RefBrand + ", '" + BrandToAdd.NameBrand + "');"))
                    {
                        MessageBox.Show("INSERT INTO Marques VALUES (" + BrandToAdd.RefBrand + ", '" + BrandToAdd.NameBrand + "');");
                        // Execute query
                        Command.Connection = con;
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Marque " + BrandToAdd.NameBrand + " créée");

                        MessageBox.Show("nb lines : " + nbBrands());
                    }
                }
                catch (Exception ExceptionCaught)
                {
                    MessageBox.Show("Marque " + BrandToAdd.NameBrand + " non créée\n" + ExceptionCaught.Message.ToString());
                    con.Close();
                }


            }
        }

        /**
         * Change the name of a brand
         * param name="BrandRef" : The reference of the Brand to modify
         * param name="NewBrandName" : The new name of the brand
         */
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
                    MessageBox.Show("Marque " + BrandRef + " non modifièe : \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                    Connection.Close();
                    throw;
                }


            }



        }
        
        /**
         * Get all brands from db 
         * returns a table of brands
         */
        public static Brand[] getAllBrands()
        {
            //The table to return
            Brand[] listToReturn = new Brand[BrandDAO.nbBrands()];
            //The number of brands to get
            int NbBrands = BrandDAO.nbBrands();

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
                        MessageBox.Show("Echec de la récupération des données de la table Marques  \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                    }
                }


            }
            
            
            return listToReturn;
        }

        /**
         * Count the number of brands in the db
         * Return -1 if failed
         */
        public static int nbBrands()
        {
            int Result = -1;

            var DataTableToReturn = new DataTable();

            using (var con = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT COUNT(*) FROM Marques;"))
                {
                    try
                    {
                        //execute query
                        Command.Connection = con;
                        Command.Connection.Open();
                        SQLiteDataAdapter adp = new SQLiteDataAdapter(Command);
                        adp.Fill(DataTableToReturn);
                        Result = Convert.ToInt32(DataTableToReturn.Rows[0][0].ToString());
                        con.Close();
                    }
                    catch (Exception)
                    {
                        con.Close();
                        throw;
                    }
                }
            }

            return Result;

        }

    }

}
