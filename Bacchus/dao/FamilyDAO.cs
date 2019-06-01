using Bacchus.model;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace Bacchus.dao
{
    class FamilyDAO
    {

        /**
         * Add a new Family to the db
         * param name="NewFamilyRef" : the family's ref
         * param name="NewFamilyName" : the family's name
         */
        public static void addFamily(Family FamilyToAdd)
        {
            // Verifications
            if (FamilyToAdd.NameFamily.Equals("") || FamilyToAdd.NameFamily == null)
            {
                throw new ArgumentNullException("Famille Name");
            }

            // Add to db
            using (var con = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("INSERT INTO Familles VALUES (" + FamilyToAdd.RefFamily + ", '" + FamilyToAdd.NameFamily + "');"))
                    {
                        // Execute query
                        Command.Connection = con;
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Famille " + FamilyToAdd.NameFamily + " créée");

                        MessageBox.Show("nb lines : " + nbFamilys());
                    }
                }
                catch (Exception ExceptionCaught)
                {
                    MessageBox.Show("Famille " + FamilyToAdd.NameFamily + " non créée\n" + ExceptionCaught.Message.ToString());
                    con.Close();
                }
                
            }
        }

        /**
         * Change de name of a family
         * param name="RefFamily" : The reference of the Family to modify
         * param name="NewFamilyName" : The new name of the family
         */
        public static void editFamily(int RefFamily, String NewFamilyName)
        {
            // Verifications
            if (NewFamilyName.Equals("") || NewFamilyName == null)
            {
                throw new ArgumentNullException("Famille Ref");
            }

            // Add to db
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("UPDATE Familles SET Nom = " + NewFamilyName + " WHERE RefMarque = " + RefFamily + "; "))
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
                    MessageBox.Show("Famille " + RefFamily + " non modifièe : \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                    Connection.Close();
                    throw;
                }
            }
        }

        /**
         * Get all familys from db 
         * returns a table of familys
         */
        public static Family[] getAllFamilys()
        {
            //The table to return
            Family[] listToReturn = new Family[FamilyDAO.nbFamilys()];
            //The number of familys to get
            int NbFamilys = FamilyDAO.nbFamilys();

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT * FROM Familles;"))
                {
                    try
                    {
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        using (SQLiteDataReader Reader = Command.ExecuteReader())
                        {
                            for (int currentFamilyIndex = 0; currentFamilyIndex < NbFamilys; currentFamilyIndex++)
                            {
                                Reader.Read();

                                Family FamilyToAdd = new Family();

                                FamilyToAdd.RefFamily = (int)Reader[0];
                                FamilyToAdd.NameFamily = Reader[1].ToString();

                                listToReturn.SetValue(FamilyToAdd, currentFamilyIndex);
                            }
                        }

                    }
                    catch (Exception ExceptionCaught)
                    {
                        listToReturn = null;
                        MessageBox.Show("Echec de la récupération des données de la table Familles  \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                    }
                }
            }

            return listToReturn;
        }
        /**
         * Get the Family corresponding to the name FamilyName
         */
        public static Family getFamilyByName(String FamilyName)
        {
            Family FamilyToAdd = new Family();

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT * FROM Familles WHERE Nom = '"+ FamilyName + "';"))
                {
                    try
                    {
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        using (SQLiteDataReader Reader = Command.ExecuteReader())
                        {
                            Reader.Read();

                            FamilyToAdd.RefFamily = (int)Reader[0];
                            FamilyToAdd.NameFamily = Reader[1].ToString();
                        }

                    }
                    catch (Exception ExceptionCaught)
                    {
                        FamilyToAdd = null;
                        MessageBox.Show("Echec de la récupération de la Famille " + FamilyName +   "\n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                    }
                }
            }

            return FamilyToAdd;
        }

        /**
         * Count the number of familys in the db
         * Return -1 if failed
         */
        public static int nbFamilys()
        {
            int Result = -1;

            var DataTableToReturn = new DataTable();

            using (var con = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT COUNT(*) FROM Familles;"))
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
