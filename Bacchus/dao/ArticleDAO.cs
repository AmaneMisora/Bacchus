using Bacchus.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bacchus.dao
{
    class ArticleDAO
    {

        /// <summary>
        /// Ajoute l'article à la base de données
        /// </summary>
        /// <param name="ArticleToAdd"></param>
        public static void AddArticle(Article ArticleToAdd)
        {
            // Vérification
            if(VerifArticleRef(ArticleToAdd.RefArticle) == false)
            {
                throw new ArgumentException("La référence de l'article est invalide");
            }
            if(ArticleToAdd.Description.Equals("") || ArticleToAdd.Description == null)
            {
                throw new ArgumentNullException("Description");
            }

            // Ajout à la base de données
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("INSERT INTO Articles VALUES ('" + ArticleToAdd.Description + "', " + ArticleToAdd.RefSubFamily + " , " + ArticleToAdd.RefBrand + " , " + ArticleToAdd.PriceHT + " , " + ArticleToAdd.Quantity + ") ;"))
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
                    MessageBox.Show("Article " + ArticleToAdd.RefArticle + " non créé\n" + ExceptionCaught.Message.ToString());
                    Connection.Close();
                }
            }
            
        }

        /// <summary>
        /// Supprime l'article correspondant à la ref en entrée
        /// </summary>
        /// <param name="RefArticleToDelete"></param>
        public static void DeleteArticle(String RefArticleToDelete)
        {
            // Supression de l'article dans la base de donnée
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("DELETE FROM Articles WHERE RefArticle = '" + RefArticleToDelete + "'; "))
                    {
                        // Execution de la requête
                        Command.Connection = Connection;
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();
                        Connection.Close();
                    }
                }
                catch (Exception ExceptionCaught)
                {
                    MessageBox.Show("Article " + RefArticleToDelete + " non supprimée : \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                    Connection.Close();
                }
            }

        }

        public static void EditArticle(String RefArticle, String NewDescription, SubFamily NewRefSubFamily, Brand NewRefBrand, float NewPrice, int NewQuantity)
        {
            // Vérification
            if (VerifArticleRef(RefArticle) == false)
            {
                throw new ArgumentException("La référence de l'article est invalide");
            }
            if (NewDescription.Equals("") || NewDescription == null)
            {
                throw new ArgumentNullException("Description");
            }

            // Modification de la base de données
            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                try
                {
                    using (var Command = new SQLiteCommand("UPDATE Familles SET Description = '" + NewDescription + "', RefSousFamille = " + NewRefSubFamily.RefSubFamily + ", RefMarque = " + NewRefBrand.RefBrand + ", PrisHT = " + NewPrice + ", Quantité = " + NewQuantity + " WHERE RefArticle = " + RefArticle + "; "))
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
                    MessageBox.Show("Article " + RefArticle + " non modifièe : \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                    Connection.Close();
                }
            }
            
        }

        /// <summary>
        /// Retourne tous les articles de la base de données
        /// </summary>
        /// <returns></returns>
        public static Article[] GetAllArticles()
        {
            //Nombre d'articles dans la base de donnée
            int nbArticle = ArticleDAO.NbArticles();
            //Tableau d'artiles à retourner
            Article[] listToReturn = new Article[nbArticle];

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT * FROM Articles;"))
                {
                    try
                    {
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        using (SQLiteDataReader Reader = Command.ExecuteReader())
                        {
                            for (int currentArticleIndex = 0; currentArticleIndex < nbArticle; currentArticleIndex++)
                            {
                                Reader.Read();

                                Article ArticleToAdd = new Article();

                                ArticleToAdd.RefArticle = Reader[0].ToString();
                                ArticleToAdd.Description = Reader[1].ToString();
                                ArticleToAdd.RefSubFamily = SubFamilyDAO.GetSubFamilyById((int)Reader[2]);
                                ArticleToAdd.RefBrand = BrandDAO.GetBrandById((int)Reader[3]);
                                ArticleToAdd.PriceHT = (float)Reader[4];
                                ArticleToAdd.Quantity = (int)Reader[5];

                                listToReturn.SetValue(ArticleToAdd, currentArticleIndex);
                            }
                        }

                        Connection.Close();
                    }
                    catch (Exception ExceptionCaught)
                    {
                        Connection.Close();
                        listToReturn = null;
                        MessageBox.Show("Echec de la récupération des données de la table SousFamille  \n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                    }

                }

            }
                return listToReturn;

        }

        /// <summary>
        /// Retourne l'article correspondant à la référence passée en paramètre
        /// </summary>
        /// <param name="ArticleRef"></param>
        /// <returns></returns>
        public static Article GetArticleById(String ArticleRef)
        {
            Article ArticleToReturn = new Article();

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT * FROM Articles WHERE RefArticle = '" + ArticleRef + "';"))
                {
                    try
                    {
                        Command.Connection = Connection;
                        Command.Connection.Open();

                        using (SQLiteDataReader Reader = Command.ExecuteReader())
                        {
                            Reader.Read();
                            ArticleToReturn.RefArticle = Reader[0].ToString();
                            ArticleToReturn.Description = Reader[1].ToString();
                            ArticleToReturn.RefSubFamily = SubFamilyDAO.GetSubFamilyById((int)Reader[2]);
                            ArticleToReturn.RefBrand = BrandDAO.GetBrandById((int)Reader[3]);
                            ArticleToReturn.PriceHT = (float)Reader[4];
                            ArticleToReturn.Quantity = (int)Reader[5];
                        }

                    }
                    catch (Exception ExceptionCaught)
                    {
                        Connection.Close();
                        ArticleToReturn = null;
                        // MessageBox.Show("Echec de la récupération de la Marque " + BrandRef + "\n" + ExceptionCaught.Message, ExceptionCaught.GetType().ToString());
                    }
                }
            }

            return ArticleToReturn;
        }

        /// <summary>
        /// Compte le nombre d'articles dans la base de donéee
        /// </summary>
        /// <returns></returns>
        public static int NbArticles()
        {
            int Result = -1;

            var DataTableToReturn = new DataTable();

            using (var Connection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("SELECT COUNT(*) FROM Articles;"))
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

        /// <summary>
        /// Vérifie si la référence passée en paramètre est conventionnelle pour un artice
        /// </summary>
        /// <param name="ArticleRef"></param>
        /// <returns></returns>
        public static Boolean VerifArticleRef(String ArticleRef)
        {
            if(ArticleRef.Length == 8)
            {
                if (ArticleRef.ElementAt(0).Equals('F'))
                {
                    if (int.TryParse(ArticleRef.Substring(1),out int value))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
