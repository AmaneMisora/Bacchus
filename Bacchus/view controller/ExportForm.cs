using Bacchus.dao;
using Bacchus.model;
using System;
using System.IO;
using System.Text;
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

                MessageBox.Show("Export réussi");
            }
            catch (Exception ExceptionCaught)
            {
                MessageBox.Show("L'export à échoué \n" + ExceptionCaught.Message.ToString(), ExceptionCaught.GetType().ToString());
            }
        }

        /// <summary>
        /// Ouvre le gestionnaire de fichier à l'appui sur le bouton "..."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CSVButton_Click(object sender, EventArgs e)
        {
            // Nom de fichier par défault dans l'explorateur de fichier
            string FileName = "BacchusExport.csv";

            // Création de la fenetre de dialogue pour entrer le path
            SaveFileDialog SaveFile = new SaveFileDialog();

            // Affiche uniquement les csv
            SaveFile.Filter = "Fichiers CSV (*.csv)| *.csv";

            // Nom du fichier par défaut à l'ouverture de la SaveFileDialog
            SaveFile.FileName = FileName;

            // Répertoire ouvert par défaut à l'ouverture de la SaveFileDialog
            SaveFile.InitialDirectory = CSVNameTextBox.Text;

            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                // Récupère le path dans la OpenFileDialog
                string CVSPath = Path.GetFullPath(SaveFile.FileName);

                // Efface la textBox si elle était pleine
                CSVNameTextBox.Clear();

                // Ajoute le path du fichier CSV dans la textBox
                CSVNameTextBox.AppendText(CVSPath);
            }
        }
    }
}
