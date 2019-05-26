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
         * Create a new brand and add it to the db
         * param name="NewBrandRef" : the band's ref
         * param name="NewBrandName" : the brand's name
         */
        public static void creatBrand(Brand BrandToAdd)
        {
            // Verifications
            if (BrandToAdd.NameBrand.Equals("") || BrandToAdd.NameBrand == null)
            {
                throw new ArgumentNullException("Brand Name");
            }
            if (BrandToAdd.RefBrand.Equals("") || BrandToAdd.RefBrand == null)
            {
                throw new ArgumentNullException("Brand Ref");
            }

            // Add to db
            using (var con = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("INSERT INTO Marques VALUES ('" + BrandToAdd.NameBrand + "'), ('" + BrandToAdd.RefBrand + "');"))
                    {
                        // Execute query
                        Command.Connection = con;
                        Command.Connection.Open();
                        SQLiteDataAdapter adp = new SQLiteDataAdapter(Command);
                        con.Close();
                        MessageBox.Show("Marque " + BrandToAdd.NameBrand + " créée");

                        MessageBox.Show("nb lines : " + nbBrands());
                    }
                }
                catch (Exception ExceptionCaught)
                {
                    MessageBox.Show("Marque " + BrandToAdd.NameBrand + " non créée");
                    con.Close();
                    throw;
                }


            }
        }

        /**
         * Get all brands from db
         */
        public static DataTable getBrands()
        {

            var DataTableToReturn = new DataTable();

            using (var con = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT * FROM Marques;"))
                {
                    try
                    {
                        //execute query
                        Command.Connection = con;
                        Command.Connection.Open();
                        SQLiteDataAdapter adp = new SQLiteDataAdapter(Command);
                        con.Close();

                        adp.Fill(DataTableToReturn);

                        MessageBox.Show("Nb lines : " + DataTableToReturn.Rows.Count);
                    }
                    catch (Exception ExceptionCaught)
                    {
                        con.Close();
                        throw;
                    }
                }


            }

            return DataTableToReturn;
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
