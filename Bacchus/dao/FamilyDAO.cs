using Bacchus.model;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace Bacchus.dao
{
    class FamilyDAO
    {
        /// <summary>
        /// Add a new Family to the db
        /// </summary>
        /// <param name="FamilyToAdd"></param>
        public static void addFamily(Family FamilyToAdd)
        {
            // Verifications
            if (FamilyToAdd.NameFamily.Equals("") || FamilyToAdd.NameFamily == null)
            {
                throw new ArgumentNullException("Famille Name");
            }

            // Add to db
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("INSERT INTO Familles VALUES (" + FamilyToAdd.RefFamily + ", '" + FamilyToAdd.NameFamily + "');"))
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
                    MessageBox.Show("Famille " + FamilyToAdd.NameFamily + " non créée\n" + ExceptionCaught.Message.ToString());
                    Connection.Close();
                }
            }
        }

        /// <summary>
        /// Change de name of a family
        /// </summary>
        /// <param name="RefFamily"></param>
        /// <param name="NewFamilyName"></param>
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
                        Command.ExecuteNonQuery();
                        Connection.Close();
                    }
                }
                catch (Exception ExceptionCaught)
                {
                    MessageBox.Show("Famille " + RefFamily + " non modifièe : \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                    Connection.Close();
                }
            }
        }

        /// <summary>
        /// Get all familys from db 
        /// </summary>
        /// <returns></returns>
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
                        Connection.Close();
                    }
                }
            }

            return listToReturn;
        }

        /// <summary>
        /// Get the Family corresponding to the name FamilyName
        /// </summary>
        /// <param name="FamilyName"></param>
        /// <returns></returns>
        public static Family getFamilyByName(String FamilyName)
        {
            Family FamilyReturn = new Family();

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

                            FamilyReturn.RefFamily = (int)Reader[0];
                            FamilyReturn.NameFamily = Reader[1].ToString();
                        }

                    }
                    catch (Exception ExceptionCaught)
                    {
                        FamilyReturn = null;
                        MessageBox.Show("Echec de la récupération de la Famille " + FamilyName +   "\n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                        Connection.Close();
                    }
                }
            }

            return FamilyReturn;
        }

        /// <summary>
        /// Get the Family corresponding to the Ref FamilyRef
        /// </summary>
        /// <param name="FamilyRef"></param>
        /// <returns></returns>
        public static Family getFamilyById(int FamilyRef)
        {
            Family FamilyToReturn = new Family();

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT * FROM Familles WHERE RefFamille = '" + FamilyRef + "';"))
                {
                    try
                    {
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        using (SQLiteDataReader Reader = Command.ExecuteReader())
                        {
                            Reader.Read();

                            FamilyToReturn.RefFamily = (int)Reader[0];
                            FamilyToReturn.NameFamily = Reader[1].ToString();
                        }

                    }
                    catch (Exception ExceptionCaught)
                    {
                        Connection.Close();
                        FamilyToReturn = null;
                        //MessageBox.Show("Echec de la récupération de la Marque " + FamilyRef + "\n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                    }
                }
            }

            return FamilyToReturn;


        }

        /// <summary>
        /// Count the number of familys in the db
        /// </summary>
        /// <returns></returns>
        public static int nbFamilys()
        {
            int Result = -1;

            var DataTableToReturn = new DataTable();

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT COUNT(*) FROM Familles;"))
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
                    catch (Exception)
                    {
                        Connection.Close();
                    }
                }
            }

            return Result;

        }

    }
}
