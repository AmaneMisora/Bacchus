﻿using Bacchus.model;
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
                            ArticleToReturn.RefSubFamily = SubFamilyDAO.getFamilyById((int)Reader[2]);
                            ArticleToReturn.RefBrand = BrandDAO.getBrandById((int)Reader[3]);
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
                if(ArticleRef.ElementAt(0).Equals("F"))
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