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

            // met le maximun de la progress bar au nombre de ligne
            ExportProgressBar.Maximum = ArticleDAO.NbArticles();
           
            
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

                ExportProgressBar.PerformStep();

                // formate cette ligne puis l'ajoute au csv
                var TitleLine = string.Format("{0};{1};{2};{3};{4};{5}", TitleQuantityAndDescriptionRow, TitleRefRow, TitleBrandRow, TitleFamilyRow, TitleSubFamilyRow, TitlePriceRow);
                csv.AppendLine(TitleLine);
                // fait la meme chose pour tout les articles de la bd
                Article[] AllArticle = ArticleDAO.GetAllArticles();
                foreach (Article A in AllArticle)
                {
                    // une ligne est crée, on avance donc d'une étape dans la progress bar
                    ExportProgressBar.PerformStep();
                    var QuantityAndDescriptionRow = A.Quantity + " " + A.Description;
                    var RefRow = A.RefArticle;
                    var BrandRow = A.RefBrand.ToString();
                    var FamilyRow = A.RefSubFamily.RefFamily.ToString();
                    var SubFamilyRow = A.RefSubFamily.ToString();
                    var PriceRow = A.PriceHT.ToString();
                    var NewLine = string.Format("{0};{1};{2};{3};{4};{5}", QuantityAndDescriptionRow, RefRow, BrandRow, FamilyRow, SubFamilyRow, PriceRow);
                    csv.AppendLine(NewLine);
                }

                // ecrit les données dans le fichier au path choisit
                File.WriteAllText(CSVNameTextBox.Text, csv.ToString());

            }
            catch (Exception ExceptionCaught)
            {
                MessageBox.Show("L'export à échoué \n" + ExceptionCaught.Message.ToString(), ExceptionCaught.GetType().ToString());
            }
            this.Close();
        }

        /// <summary>
        /// Choisit ou et comment appeler le fichier csv d'export
        /// ce déclenche à l'appui sur le bouton "..."
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void CSVButton_Click(object Sender, EventArgs Event)
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
