using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus
{
    public partial class ImportForm : Form
    {
        private SQLiteConnection SqlConnection;
        private SQLiteCommand SqlCommand;

        public ImportForm()
        {
            InitializeComponent();
        }

        private void CSVButton_Click(object sender, EventArgs e)
        {
            //Ouvre une fenêtre de dialogue pour sélectionner l'emplacement du csv
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.Filter = "Fichiers CSV (*.csv)| *.csv";

            //Si l'utilisateur à sélectionné un fichier
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string CVSPath = Path.GetFullPath(folderBrowser.FileName);
                CSVNameTextBox.Clear();
                CSVNameTextBox.AppendText(CVSPath);
            }
        }

        private void OverwriteButton_Click(object sender, EventArgs e)
        {
            String CSVPath = CSVNameTextBox.Text.ToString();
            SqlConnection = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;");
            SqlConnection.Open();

            SqlCommand = SqlConnection.CreateCommand();
            SqlCommand.CommandText = " SELECT name FROM sqlite_temp_master WHERE type='table'; ";
            int NbLine = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            MessageBox.Show("Importation réussie\nNombre de lignes créées : " + NbLine.ToString(), "Importation réussie",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
