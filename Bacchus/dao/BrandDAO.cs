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
        /// Ajoute la marque en entrée à la base de donnée
        /// </summary>
        /// <param name="BrandToAdd"></param>
        public static void AddBrand(Brand BrandToAdd)
        {
            // Vérifications
            if (BrandToAdd.NameBrand.Equals("") || BrandToAdd.NameBrand == null)
            {
                throw new ArgumentNullException("Brand Name");
            }
            if (BrandToAdd.RefBrand == -1)
            {
                throw new ArgumentException("La référence de la Marque ne doit pas être égale à -1");
            }

            // Ajout à la base de donnée
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("INSERT INTO Marques VALUES (" + BrandToAdd.RefBrand + ", '" + BrandToAdd.NameBrand + "');"))
                    {
                        // Execution de la requete
                        Command.Connection = Connection;
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();

                        Connection.Close();
                    }
                }
                catch (Exception ExceptionCaught)
                {
                    MessageBox.Show("Marque " + BrandToAdd.NameBrand + " non créée\n" + ExceptionCaught.Message.ToString(), ExceptionCaught.GetType().ToString());

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
                    catch
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
                    MessageBox.Show("La suppression de la marque " + BrandRef + " à échoué\n" + ExceptionCaught.Message.ToString(), ExceptionCaught.GetType().ToString());

                    Connection.Close();
                }
            }

        }

        /// <summary>
        /// Change le nom de la marque en paramètre
        /// </summary>
        /// <param name="BrandRef"> La marque à modifier </param>
        /// <param name="NewBrandName"> Le nouveau nom </param>
        public static void EditBrand(int BrandRef, String NewBrandName)
        {
            // Vérifications
            if (NewBrandName.Equals("") || NewBrandName == null)
            {
                throw new ArgumentNullException("Brand Ref");
            }

            // Ajout à la base de données
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("UPDATE Marques SET Nom = '" + NewBrandName + "' WHERE RefMarque = " + BrandRef + "; "))
                    {
                        // Execution de la requete
                        Command.Connection = Connection;
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();

                        Connection.Close();
                    }
                }
                catch (Exception ExceptionCaught)
                {
                    MessageBox.Show("Echec de la modification de la marque " + BrandRef + " : \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());

                    Connection.Close();
                }
            }
        }

        /// <summary>
        /// Retourne toutes les marques de la base de données
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

                        Connection.Close();

                    }
                    catch (Exception ExceptionCaught)
                    {
                        // Retourne null en cas d'erreur
                        listToReturn = null;

                        MessageBox.Show("Echec de la récupération des données de la table Marques  \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());

                        Connection.Close();
                    }
                }
            }

            return listToReturn;
        }

        /// <summary>
        /// Retourne la marque correspondante au nom en paramètre
        /// </summary>
        /// <param name="BrandName"> Le nom de la marque à retourner </param>
        /// <returns></returns>
        public static Brand GetBrandByName(String BrandName)
        {
            Brand BrandToReturn = new Brand();

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT * FROM Marques WHERE Nom = '" + BrandName + "';"))
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

                            // Ajout des paramètres
                            BrandToReturn.RefBrand = (int)Reader[0];
                            BrandToReturn.NameBrand = Reader[1].ToString();
                        }

                        Connection.Close();

                    }
                    // Dans le cas où la marque n'existe pas
                    catch (InvalidOperationException)
                    {
                        BrandToReturn = null;

                        Connection.Close();

                    }
                    catch (Exception ExceptionCaught)
                    {
                        // Retourne null en cas d'erreur
                        BrandToReturn = null;

                        MessageBox.Show("Echec de la récupération de la marque " + BrandName + "  \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                        
                        Connection.Close();
                    }
                }
            }

            return BrandToReturn;

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
                    // Dans le cas où la marque n'existe pas
                    catch(InvalidOperationException)
                    {
                        BrandToReturn = null;

                        Connection.Close();

                    }
                    catch(Exception ExceptionCaught)
                    {
                        MessageBox.Show("Echec de la récupération de la marque " + BrandRef + " \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());

                        BrandToReturn = null;

                        Connection.Close();
                    }
                }
            }

            return BrandToReturn;
        }

        /// <summary>
        /// Compte le nombre de marques dans la base de données
        /// </summary>
        /// <returns></returns>
        public static int NbBrands()
        {
            // Initialisation du résultat à retourner
            int Result = -1;

            // DataTable récupèrant les résultats de la requete
            var DataTableToFill = new DataTable();

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT COUNT(*) FROM Marques;"))
                {
                    try
                    {
                        // Connection
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        // Execution de la commande
                        SQLiteDataAdapter adp = new SQLiteDataAdapter(Command);

                        // Récupération des données 
                        adp.Fill(DataTableToFill);
                        Result = Convert.ToInt32(DataTableToFill.Rows[0][0].ToString());

                        Connection.Close();
                    }
                    catch (Exception ExceptionCaught)
                    {
                        MessageBox.Show("Echec dans le comptage des marques \n " + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());

                        Connection.Close();
                    }
                }
            }

            return Result;

        }

    }

}
