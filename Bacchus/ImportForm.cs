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

            using (var con = new SQLiteConnection("Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;"))
            {
                using (var Command = new SQLiteCommand("PRAGMA table_info( Articles );"))
                {
                    var table = new DataTable();

                    Command.Connection = con;
                    Command.Connection.Open();

                    SQLiteDataAdapter adp = null;
                    try
                    {
                        adp = new SQLiteDataAdapter(Command);
                        adp.Fill(table);
                        con.Close();
                    }
                    catch (Exception ex)
                    { }
                    
                }
            }
            
            /*
            string Cs = "Data Source = Bacchus.SQLite ;Version=3;New=False;Compress=True;";
            
            using (SQLiteConnection Connection = new SQLiteConnection(Cs))
            {
                Connection.Open();

                string stm = " SELECT name FROM sqlite_master WHERE type='table'; ";

                using (SQLiteCommand Command = new SQLiteCommand(stm, Connection))
                {

                    using (SQLiteDataReader Reader = Command.ExecuteReader())
                    {
                        while(Reader.Read())
                        {
                            //MessageBox.Show(Reader.GetString(0), Reader.GetString(0), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }
                    }
                }

                stm = "SELECT * FROM table_info(Marques); ";
                using (SQLiteCommand Command = new SQLiteCommand(stm, Connection))
                {
                    using (SQLiteDataReader Reader = Command.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            MessageBox.Show(Reader.GetString(0), Reader.GetString(0), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                }
            }
            */
        }
    }
}
