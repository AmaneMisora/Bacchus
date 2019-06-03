using Bacchus.dao;
using Bacchus.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus
{
    public partial class ExportForm : Form
    {
        /// <summary>
        /// Constructeur de la fenetre
        /// </summary>
        public ExportForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lance l'exportation des données vers le path choisit, à l'appuie sur le bouton "Exporter"
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void ExportButton_Click(object Sender, EventArgs Event)
        {
            try
            {
                // écrit les titres des colonnes en première ligne
                var csv = new StringBuilder();
                var TitleQuantityAndDescriptionRow = "Description";
                var TitleRefRow = "Ref";
                var TitleBrandRow = "Marque";
                var TitleFamilyRow = "Famille";
                var TitleSubFamilyRow = "Sous-Famille";
                var TitlePriceRow = "Prix H.T.";

                // formate cette ligne puis l'ajoute au csv
                var TitleLine = string.Format("{0};{1};{2};{3};{4};{5}", TitleQuantityAndDescriptionRow, TitleRefRow, TitleBrandRow, TitleFamilyRow, TitleSubFamilyRow, TitlePriceRow);
                csv.AppendLine(TitleLine);

                // fait la meme chose pour tout les articles de la bd
                Article[] AllArticle = ArticleDAO.GetAllArticles();
                foreach (Article A in AllArticle)
                {
                    var QuantityAndDescriptionRow = A.Quantity + " " + A.Description;
                    var RefRow = A.RefArticle;
                    var BrandRow = A.RefBrand.ToString();
                    var FamilyRow = A.RefSubFamily.RefFamily.ToString();
                    var SubFamilyRow = A.RefSubFamily.ToString();
                    var PriceRow = A.PriceHT.ToString();
                    //Suggestion made by KyleMit
                    var NewLine = string.Format("{0};{1};{2};{3};{4};{5}", QuantityAndDescriptionRow, RefRow, BrandRow, FamilyRow, SubFamilyRow, PriceRow);
                    csv.AppendLine(NewLine);
                }

                // ecrit les données dans le fichier au path choisit
                File.WriteAllText(CSVNameTextBox.Text, csv.ToString()); //"E:\\Travail\\test.csv"
            }
            catch (Exception Excep)
            {
                MessageBox.Show(Excep.Message);
            }
        }

        private void CSVButton_Click(object sender, EventArgs e)
        {
            // String qui vont apparaitre dans le nom de fichier dans l'explorateur de fichier
            string dummyFileName = "Enregistrer ici";

            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Filter = "Fichiers CSV (*.csv)| *.csv";

            SaveFile.ShowDialog();

            CSVNameTextBox.Text = Path.GetDirectoryName(SaveFile.FileName);
        }
    }
}
