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
        /// Ajoute la famille à la base de donnée
        /// </summary>
        /// <param name="FamilyToAdd"></param>
        public static void AddFamily(Family FamilyToAdd)
        {
            // Vérifications
            if (FamilyToAdd.NameFamily.Equals("") || FamilyToAdd.NameFamily == null)
            {
                throw new ArgumentNullException("Famille Name");
            }

            // Ajout à la base de données
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("INSERT INTO Familles VALUES (" + FamilyToAdd.RefFamily + ", '" + FamilyToAdd.NameFamily + "');"))
                    {
                        // Connection 
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        // Execution de la requete
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
        /// Supprime la famille correspondant à la ref en entrée
        /// </summary>
        /// <param name="RefFamily"></param>
        public static void DeleteFamily(int RefFamily)
        {
            //vérifications (la famille ne doit pas avoir de sous famille)
            DataTable SQLRequestDataTable = new DataTable();
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT COUNT(*) FROM SousFamilles WHERE RefFamille = " + RefFamily + ";"))
                {
                    try
                    {
                        // Connection
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        // Execution de la requête
                        SQLiteDataAdapter Adapter = new SQLiteDataAdapter(Command);

                        // Récupération des données
                        Adapter.Fill(SQLRequestDataTable);
                        if( Convert.ToInt32(SQLRequestDataTable.Rows[0][0]) != 0 )
                        {
                            MessageBox.Show("Il existe des sous familles utilisant cette famille. Il n'est pas possible de la supprimer");
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
            
            // Supression de la famille dans la base de donnée
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("DELETE FROM Familles WHERE RefFamille = " + RefFamily + "; "))
                    {
                        // Connection
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        // Execution de la requête
                        Command.ExecuteNonQuery();

                        Connection.Close();
                    }
                }
                catch (Exception ExceptionCaught)
                {
                    MessageBox.Show("Famille " + RefFamily + " non supprimée : \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());

                    Connection.Close();
                }
            }

        }

        /// <summary>
        /// Change le nom de la famille
        /// </summary>
        /// <param name="RefFamily"></param>
        /// <param name="NewFamilyName"></param>
        public static void EditFamily(int RefFamily, String NewFamilyName)
        {
            // Verifications
            if (NewFamilyName.Equals("") || NewFamilyName == null)
            {
                throw new ArgumentNullException("Famille Ref");
            }

            // Modification de la base de données
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("UPDATE Familles SET Nom = '" + NewFamilyName + "' WHERE RefFamille = " + RefFamily + "; "))
                    {
                        // Connection
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        // Execution de la requete
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
        /// Retourne toutes les familles de la base de données
        /// </summary>
        /// <returns></returns>
        public static Family[] GetAllFamilies()
        {
            // Nombre de familles dans la base de données
            int NbFamilies = FamilyDAO.NbFamilies();

            // Tableau de familles à retourner
            Family[] listToReturn = new Family[NbFamilies];

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT * FROM Familles;"))
                {
                    try
                    {
                        // Connection
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        using (SQLiteDataReader Reader = Command.ExecuteReader())
                        {
                            for (int CurrentFamilyIndex = 0; CurrentFamilyIndex < NbFamilies; CurrentFamilyIndex++)
                            {
                                // Lecture de la ligne
                                Reader.Read();

                                // Création d'une nouvelle famille
                                Family FamilyToAdd = new Family();

                                // Ajout des paramètres
                                FamilyToAdd.RefFamily = (int)Reader[0];
                                FamilyToAdd.NameFamily = Reader[1].ToString();

                                // Ajout de la famille au tableau
                                listToReturn.SetValue(FamilyToAdd, CurrentFamilyIndex);
                            }
                        }

                        Connection.Close();

                    }
                    catch (Exception ExceptionCaught)
                    {
                        // Retourne null en cas d'erreur 
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
        public static Family GetFamilyByName(String FamilyName)
        {
            Family FamilyReturn = null;

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
                            // Lecture de la ligne
                            Reader.Read();

                            // Crée une nouvelle famille
                            FamilyReturn = new Family();

                            //Ajout des paramètres
                            FamilyReturn.RefFamily = (int)Reader[0];
                            FamilyReturn.NameFamily = Reader[1].ToString();
                        }

                        Connection.Close();

                    }
                    // Dans le cas où il n'y a pas de famille avec cet id
                    catch (InvalidOperationException)
                    {
                        FamilyReturn = null;

                        Connection.Close();
                    }
                    catch (Exception ExceptionCaught)
                    {
                        // Retourne null en cas d'erreur 
                        FamilyReturn = null;

                        MessageBox.Show("Echec de la récupération de la famille" + FamilyName + "  \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());

                        Connection.Close();
                    }
                }
            }

            return FamilyReturn;
        }

        /// <summary>
        /// Retourne la famille correspondant à la ref en entrée
        /// </summary>
        /// <param name="FamilyRef"></param>
        /// <returns></returns>
        public static Family GetFamilyById(int FamilyRef)
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
                            // Lecture de la ligne
                            Reader.Read();

                            // Création d'une famille
                            FamilyToReturn = new Family();

                            // Ajout des paramètres
                            FamilyToReturn.RefFamily = (int)Reader[0];
                            FamilyToReturn.NameFamily = Reader[1].ToString();
                        }

                        Connection.Close();

                    }
                    // Dans le cas où il n'y a pas de famille avec cet id
                    catch(InvalidOperationException)
                    {
                        FamilyToReturn = null;

                        Connection.Close();
                    }
                    catch(Exception ExceptionCaught)
                    {
                        // Retourne null en cas d'erreur 
                        FamilyToReturn = null;

                        MessageBox.Show("Echec de la récupération de la Familles " + FamilyRef + "  \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());

                        Connection.Close();
                    }
                }
            }

            return FamilyToReturn;
            
        }

        /// <summary>
        /// Retourne toutes les sous-familles de la famille en entrée
        /// </summary>
        /// <param name="Family"></param>
        /// <returns></returns>
        public static SubFamily[] GetAllSubFamilies(Family Family)
        {
            // DataTable récupérant les données de la requete
            DataTable DataTableToFill = new DataTable();

            // Récupération des données
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT * FROM SousFamilles WHERE RefFamille = " + Family.RefFamily + ";"))
                {
                    try
                    {
                        // Execution de la requete
                        Command.Connection = Connection;
                        Command.Connection.Open();
                        SQLiteDataAdapter adp = new SQLiteDataAdapter(Command);
                        adp.Fill(DataTableToFill);
                        Connection.Close();
                    }
                    catch
                    {
                        Connection.Close();
                    }
                }
            }

            // Création de la liste à retourner (de la taille du résultat de la requete)
            SubFamily[] SubFamilyTableToReturn = new SubFamily[DataTableToFill.Rows.Count];
            
            // Création des SubFamilies à partir de la DataTable et ajout à la liste
            for (int currentSubFamilyIndex = 0; currentSubFamilyIndex < DataTableToFill.Rows.Count; currentSubFamilyIndex++)
            {
                // Création d'une SousFamille vide
                SubFamily TmpSubFamilyToAdd = new SubFamily();

                // Ajout des paramètres de la SousFamille
                TmpSubFamilyToAdd.RefSubFamily = (int)DataTableToFill.Rows[currentSubFamilyIndex][1];
                TmpSubFamilyToAdd.RefFamily = FamilyDAO.GetFamilyById((int)DataTableToFill.Rows[currentSubFamilyIndex][0]);
                TmpSubFamilyToAdd.NameSubFamily = DataTableToFill.Rows[currentSubFamilyIndex][2].ToString();

                // Ajout de la famille à la liste à retourner
                SubFamilyTableToReturn.SetValue(TmpSubFamilyToAdd, currentSubFamilyIndex);
            }

            return SubFamilyTableToReturn;
        }

        /// <summary>
        /// Compte le nombre de familles dans le base de données
        /// </summary>
        /// <returns></returns>
        public static int NbFamilies()
        {
            // Le résultat du compte à retourner
            int Result = -1;

            // DataTable contenant le résultat de la requete sql
            DataTable DataTableToFill = new DataTable();

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT COUNT(*) FROM Familles;"))
                {
                    try
                    {
                        // Connection
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        // Execution de la requete
                        SQLiteDataAdapter Adapter = new SQLiteDataAdapter(Command);

                        // Récupération des données
                        Adapter.Fill(DataTableToFill);
                        Result = Convert.ToInt32(DataTableToFill.Rows[0][0].ToString());

                        Connection.Close();
                    }
                    catch
                    {
                        Connection.Close();
                    }
                }
            }

            return Result;

        }

    }
}
