using Bacchus.model;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace Bacchus.dao
{
    class SubFamilyDAO
    {
        /// <summary>
        /// Ajoute la sous-famille à la base de donnée
        /// </summary>
        /// <param name="SubFamilyToAdd"></param>
        public static void AddSubFamily(SubFamily SubFamilyToAdd)
        {
            //Verifications
            if(SubFamilyToAdd.NameSubFamily.Equals("") || SubFamilyToAdd.NameSubFamily == null)
            {
                throw new ArgumentNullException("SubFamily Name");
            }
            if(SubFamilyToAdd.RefSubFamily == -1)
            {
                throw new ArgumentException("La référence de la sous-famille ne doit pas être égale à -1");
            }
            if(SubFamilyToAdd.RefFamily == null)
            {
                throw new ArgumentNullException("Family Name");
            }

            //Ajout à la base de donnée
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("INSERT INTO SousFamilles VALUES (" + SubFamilyToAdd.RefSubFamily + ", '" + SubFamilyToAdd.RefFamily.RefFamily + "', '" + SubFamilyToAdd.NameSubFamily + "');"))
                    {
                        //Connection
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        //Execution de la requete
                        Command.ExecuteNonQuery();

                        Connection.Close();
                    }
                }
                catch (Exception ExceptionCaught)
                {
                    MessageBox.Show("Famille " + SubFamilyToAdd.NameSubFamily + " non créée\n" + ExceptionCaught.Message.ToString());

                    Connection.Close();
                }
            }
        }

        /// <summary>
        /// Supprime la sous-famille correspodant à la ref passée en paramètre
        /// </summary>
        /// <param name="SubFamilyRef"></param>
        public static void DeleteSubFamily(int SubFamilyRef)
        {
            //vérifications (la marque ne doit pas avoir d'article)
            DataTable SQLRequestDataTable = new DataTable();
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT COUNT(*) FROM Articles WHERE RefSousFamille = " + SubFamilyRef + ";"))
                {
                    try
                    {
                        //Connection
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        //Execution de la requête
                        SQLiteDataAdapter Adapter = new SQLiteDataAdapter(Command);

                        //Récupération des données
                        Adapter.Fill(SQLRequestDataTable);

                        if (Convert.ToInt32(SQLRequestDataTable.Rows[0][0]) != 0)
                        {
                            MessageBox.Show("Il existe des articles utilisant cette sous-famille. Il n'est pas possible de la supprimer");
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

            // Supression de la sous-famille dans la base de donnée
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("DELETE FROM SousFamilles WHERE RefSousFamille = " + SubFamilyRef + "; "))
                    {
                        //Connection
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        // Execution de la requête
                        Command.ExecuteNonQuery();

                        Connection.Close();
                    }
                }
                catch (Exception ExceptionCaught)
                {
                    MessageBox.Show("Sous-famille " + SubFamilyRef + " non supprimée : \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());

                    Connection.Close();
                }
            }



        }

        /// <summary>
        /// Modifie le nom et la famille de la sous-famille en référencce
        /// </summary>
        /// <param name="SubFamilyRef"> La référence de la sous famille à modifier </param>
        /// <param name="NewSubFamilyName"> Le nouveau nom de la sous famille</param>
        /// <param name="FamilyRef"> La nouvelle famille </param>
        public static void EditSubFamily(int SubFamilyRef, String NewSubFamilyName, Family FamilyRef)
        {
            // Verifications
            if (NewSubFamilyName.Equals("") || NewSubFamilyName == null)
            {
                throw new ArgumentNullException("Famille Name");
            }

            // Ajout à la base de données
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("UPDATE SousFamilles SET RefFamille = " + FamilyRef.RefFamily + ", Nom = '" + NewSubFamilyName + "' WHERE RefSousFamille = " + SubFamilyRef + "; "))
                    {
                        //Connection
                        Command.Connection = Connection;
                        Command.Connection.Open();
                        // Execution de la requete
                        Command.ExecuteNonQuery();

                        Connection.Close();
                    }
                }
                catch (Exception ExceptionCaught)
                {
                    MessageBox.Show("Sous-Famille " + NewSubFamilyName + " non modifièe : \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());

                    Connection.Close();
                }
            }
        }

        /// <summary>
        /// Retourne toutes les sous-familles de la base de donnée
        /// </summary>
        /// <returns></returns>
        public static SubFamily[] GetAllSubFamilies()
        {
            //The number of subFamily
            int nbSubFamily = SubFamilyDAO.NbSubFamilies();

            //The table to return
            SubFamily[] listToReturn = new SubFamily[nbSubFamily];

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT * FROM SousFamilles;"))
                {
                    try
                    {
                        // Connection
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        using (SQLiteDataReader Reader = Command.ExecuteReader())
                        {
                            for(int currentSubFamilyIndex = 0; currentSubFamilyIndex < nbSubFamily; currentSubFamilyIndex++)
                            {
                                // Lecture de la ligne 
                                Reader.Read();

                                // Creation de la famille
                                SubFamily SubFamilyToAdd = new SubFamily();

                                // Ajout des paramètres
                                SubFamilyToAdd.RefSubFamily = (int)Reader[0];
                                SubFamilyToAdd.RefFamily = FamilyDAO.GetFamilyById((int)Reader[1]);
                                SubFamilyToAdd.NameSubFamily = Reader[2].ToString();

                                // Ajout de la sous-famille à la liste à retourner
                                listToReturn.SetValue(SubFamilyToAdd, currentSubFamilyIndex);
                            }
                        }

                        Connection.Close();
                    }
                    catch (Exception ExceptionCaught)
                    {
                        // Rtourne null en cas d'erreur
                        listToReturn = null;

                        MessageBox.Show("Echec de la récupération des données de la table SousFamille  \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());

                        Connection.Close();
                    }
                }

            }

            return listToReturn;
        }

        /// <summary>
        /// Retourne la sous-famille correspondant à l'id passé en paramètre
        /// </summary>
        /// <param name="SubFamilyRef"></param>
        /// <returns></returns>
        public static SubFamily GetSubFamilyById(int SubFamilyRef)
        {
            // Sous famille à retourner
            SubFamily SubFamilyToReturn = null;

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT * FROM SousFamilles WHERE RefSousFamille = " + SubFamilyRef + ";"))
                {
                    try
                    {
                        // Connection
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        using (SQLiteDataReader Reader = Command.ExecuteReader())
                        {
                            // Lecture de la ligne
                            Reader.Read();

                            // Création de la sousfamille
                            SubFamilyToReturn = new SubFamily();

                            // Ajout des paramètres
                            SubFamilyToReturn.RefSubFamily = (int)Reader[0];
                            SubFamilyToReturn.RefFamily = FamilyDAO.GetFamilyById((int)Reader[1]);
                            SubFamilyToReturn.NameSubFamily = Reader[2].ToString();
                        }

                        Connection.Close();

                    }
                    // dans le cas où il n'existe pas de sous familles avec cet id
                    catch (InvalidOperationException)
                    {
                        SubFamilyToReturn = null;

                        Connection.Close();
                    }
                    catch (Exception ExceptionCaught)
                    {
                        // Retourne null en cas d'erreur
                        SubFamilyToReturn = null;
                        MessageBox.Show("Oui comme un con je suis passé là");
                        MessageBox.Show("Echec de la récupération de la SousFamille " + SubFamilyRef + " \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());

                        Connection.Close();
                    }
                }
            }

            return SubFamilyToReturn;
        }

        /// <summary>
        /// Récupère la sous-famille portant le nom en entrèe et appratenant à la famille en entrée
        /// </summary>
        /// <param name="SubFamilyName"> Le nom de la sous-famille à retourner</param>
        /// <param name="RefFamily"> La famille à laquelle appartient la sous-famille </param>
        /// <returns></returns>
        public static SubFamily GetSubFamilyByName(String SubFamilyName, Family RefFamily)
        {
            SubFamily SubFamilyToReturn = new SubFamily();

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT * FROM SousFamilles WHERE Nom = '" + SubFamilyName + "' AND RefFamille = " + RefFamily.RefFamily + ";"))
                {
                    try
                    {
                        // Connection
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        // Execution de la commande
                        using (SQLiteDataReader Reader = Command.ExecuteReader())
                        {
                            // Lecture de la ligne
                            Reader.Read();

                            // Ajout des paramètres
                            SubFamilyToReturn.RefSubFamily = (int)Reader[0];
                            SubFamilyToReturn.RefFamily = FamilyDAO.GetFamilyById((int)Reader[1]);
                            SubFamilyToReturn.NameSubFamily = Reader[2].ToString();
                        }

                        Connection.Close();

                    }
                    // dans le cas où il n'existe pas de sous familles avec cet id
                    catch (InvalidOperationException)
                    {
                        SubFamilyToReturn = null;

                        Connection.Close();
                    }
                    catch (Exception ExceptionCaught)
                    {
                        // Retourne null en cas d'échec
                        SubFamilyToReturn = null;

                        MessageBox.Show("Echec de la récupération de la SousFamille " + SubFamilyName + " \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());

                        Connection.Close();
                    }
                }
            }

            return SubFamilyToReturn;
        }

        /// <summary>
        /// Retourne le nombre de sous familles de la base de donnée
        /// </summary>
        /// <returns></returns>
        public static int NbSubFamilies()
        {
            int Result = -1;

            var DataTableToReturn = new DataTable();

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT COUNT(*) FROM SousFamilles;"))
                {
                    try
                    {
                        // Connection
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        // Execution
                        SQLiteDataAdapter Adapter = new SQLiteDataAdapter(Command);

                        // Récupération
                        Adapter.Fill(DataTableToReturn);
                        Result = Convert.ToInt32(DataTableToReturn.Rows[0][0].ToString());

                        Connection.Close();
                    }
                    catch (Exception ExceptionCaught)
                    {
                        MessageBox.Show("Echec" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());

                        Connection.Close();

                    }
                }
            }

            return Result;

        }
    }
}
