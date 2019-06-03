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
        public ExportForm()
        {
            InitializeComponent();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            try
            {
                var csv = new StringBuilder();
                Article[] AllArticle = ArticleDAO.GetAllArticles();
                foreach (Article A in AllArticle)
                {
                    var first = A.ToString();
                    var second = A.RefBrand.ToString();
                    //Suggestion made by KyleMit
                    var newLine = string.Format("{0},{1}", first, second);
                    csv.AppendLine(newLine);
                }
                File.WriteAllText(CSVNameTextBox.Text, csv.ToString());
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
            SaveFile.FileName = dummyFileName;

            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                CSVNameTextBox.Text = Path.GetDirectoryName(SaveFile.FileName);
            }
        }
    }
}
