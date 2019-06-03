using Bacchus.dao;
using Bacchus.model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Bacchus
{
    public partial class ImportForm : Form
    {

        /// <summary>
        /// Constructeur de la fenetre
        /// </summary>
        public ImportForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ouvre le gestionnaire de fichier à l'appui sur le bouton "..."
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void CSVButton_Click(object Sender, EventArgs Event)
        {

            // Ouvre le gestionnaire de fichier seulement pour les fichiers CSV
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.Filter = "Fichiers CSV (*.csv)| *.csv";
            
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                // Puis ajoute le path du fichier CSV dans la textBox
                string CVSPath = Path.GetFullPath(folderBrowser.FileName);
                CSVNameTextBox.Clear();
                CSVNameTextBox.AppendText(CVSPath);
            }
        }

        private void OverwriteButton_Click(object sender, EventArgs e)
        {

            // test les erreurs avec le fichier CSV
            try
            {
                using (var reader = new StreamReader(@CSVNameTextBox.Text))
                {
                    // nettoie la bd
                    try
                    {
                        using (var con = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
                        {
                            // supprime le contenu de la table articles
                            using (var Command = new SQLiteCommand("DELETE FROM Articles;"))
                            {
                                //execute query
                                Command.Connection = con;
                                Command.Connection.Open();
                                Command.ExecuteNonQuery();
                                con.Close();
                            }

                            // supprime le contenu de la table marques
                            using (var Command = new SQLiteCommand("DELETE FROM Marques;"))
                            {
                                //execute query
                                Command.Connection = con;
                                Command.Connection.Open();
                                Command.ExecuteNonQuery();
                                con.Close();
                            }

                            // supprime le contenu de la table sousfamilles
                            using (var Command = new SQLiteCommand("DELETE FROM SousFamilles;"))
                            {
                                //execute query
                                Command.Connection = con;
                                Command.Connection.Open();
                                Command.ExecuteNonQuery();
                                con.Close();
                            }

                            // supprime le contenu de la table familles
                            using (var Command = new SQLiteCommand("DELETE FROM Familles;"))
                            {
                                //execute query
                                Command.Connection = con;
                                Command.Connection.Open();
                                Command.ExecuteNonQuery();
                                con.Close();
                            }
                        }

                    }
                    catch (Exception ExceptionCaught)
                    {
                        MessageBox.Show("Error while clearing db : " + ExceptionCaught);
                    }

                
                    bool TitleLine = true;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        // verification qui permet d'éviter la ligne titre
                        if (TitleLine == false)
                        {
                            // verifie si la reference est valide 
                            if (ArticleDAO.VerifArticleRef(values[1]) == true)
                            {

                                // cherche la quantité, si elle existe, dans la premiere colonne
                                var firstSpaceIndex = values[0].IndexOf(" ");
                                var Quantity = values[0].Substring(0, firstSpaceIndex); // la quantite si elle existe
                                var Description = values[0].Substring(firstSpaceIndex + 1); // la description si il y a un quantite
                                int IntQuantity;
                                if (int.TryParse(Quantity, out IntQuantity) == false)
                                {
                                    Description = values[0];
                                    IntQuantity = 1;
                                }


                                // si la famille existe la trouve sinon la creer 
                                Family FamilyToAdd = FamilyDAO.GetFamilyByName(values[3]);
                                if (FamilyToAdd == null)
                                {
                                    FamilyToAdd = new Family(values[3]);
                                    FamilyDAO.AddFamily(FamilyToAdd);
                                }

                                // si la sous famille existe la trouve sinon la creer
                                SubFamily SubFamilyToAdd = SubFamilyDAO.GetSubFamilyByName(values[4], FamilyToAdd);
                                if (SubFamilyToAdd == null)
                                {
                                    SubFamilyToAdd = new SubFamily(values[4], FamilyToAdd);
                                    SubFamilyDAO.AddSubFamily(SubFamilyToAdd);
                                }

                                // si la marque existe la trouve sinon la creer
                                Brand BrandToAdd = BrandDAO.GetBrandByName(values[2]);
                                if (BrandToAdd == null)
                                {
                                    BrandToAdd = new Brand(values[2]);
                                    BrandDAO.AddBrand(BrandToAdd);
                                }

                                // vérifie si le prix est bien un double
                                float FloatPrice;
                                if (float.TryParse(values[5], out FloatPrice))
                                {
                                    // si la reference de l'article existe la trouve sinon creer l'article
                                    Article ArticleToAdd = ArticleDAO.GetArticleById(values[1]);
                                    if (ArticleToAdd == null)
                                    {
                                        //créer l'article et le rajoute à la bd
                                        ArticleToAdd = new Article(values[1], Description, SubFamilyToAdd, BrandToAdd, FloatPrice, IntQuantity);
                                        ArticleDAO.AddArticle(ArticleToAdd);
                                    }

                                }

                            }
                        }
                        else
                        {
                            TitleLine = false;
                        }
                    }
                    this.Close();
                }
            }
            catch (System.Exception Excep)
            {
                MessageBox.Show(Excep.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Déclenche l'import du fichier précédement séléctionné à l'appui sur le bouton "Importer et Ajouter"
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void AddButton_Click(object Sender, EventArgs Event)
        {
            // test les erreurs avec le fichier CSV
            try
            {
                using (var reader = new StreamReader(@CSVNameTextBox.Text))
                {
                    bool TitleLine = true;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        // verification qui permet d'éviter la ligne titre
                        if (TitleLine == false)
                        {
                            // verifie si la reference est valide 
                            if (ArticleDAO.VerifArticleRef(values[1]) == true)
                            {

                                // cherche la quantité, si elle existe, dans la premiere colonne
                                var firstSpaceIndex = values[0].IndexOf(" ");
                                var Quantity = values[0].Substring(0, firstSpaceIndex); // la quantite si elle existe
                                var Description = values[0].Substring(firstSpaceIndex + 1); // la description si il y a un quantite
                                int IntQuantity;
                                if (int.TryParse(Quantity, out IntQuantity) == false)
                                {
                                    Description = values[0];
                                    IntQuantity = 1;
                                }


                                // si la famille existe la trouve sinon la creer 
                                Family FamilyToAdd = FamilyDAO.GetFamilyByName(values[3]);
                                if (FamilyToAdd == null)
                                {
                                    FamilyToAdd = new Family(values[3]);
                                    FamilyDAO.AddFamily(FamilyToAdd);
                                }

                                // si la sous famille existe la trouve sinon la creer
                                SubFamily SubFamilyToAdd = SubFamilyDAO.GetSubFamilyByName(values[4], FamilyToAdd);
                                if (SubFamilyToAdd == null)
                                {
                                    SubFamilyToAdd = new SubFamily(values[4], FamilyToAdd);
                                    SubFamilyDAO.AddSubFamily(SubFamilyToAdd);
                                }

                                // si la marque existe la trouve sinon la creer
                                Brand BrandToAdd = BrandDAO.GetBrandByName(values[2]);
                                if (BrandToAdd == null)
                                {
                                    BrandToAdd = new Brand(values[2]);
                                    BrandDAO.AddBrand(BrandToAdd);
                                }

                                // vérifie si le prix est bien un double
                                float FloatPrice;
                                if (float.TryParse(values[5], out FloatPrice))
                                {
                                    // si la reference de l'article existe la trouve sinon creer l'article
                                    Article ArticleToAdd = ArticleDAO.GetArticleById(values[1]);
                                    if(ArticleToAdd == null)
                                    {
                                        //créer l'article et le rajoute à la bd
                                        ArticleToAdd = new Article(values[1], Description, SubFamilyToAdd, BrandToAdd, FloatPrice, IntQuantity);
                                        ArticleDAO.AddArticle(ArticleToAdd);
                                    }
                                    
                                }

                            }
                        }
                        else
                        {
                            TitleLine = false;
                        }
                    }
                    this.Close();
                }
            } catch (System.Exception Excep)
            {
                MessageBox.Show(Excep.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
