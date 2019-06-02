using Bacchus.dao;
using Bacchus.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus
{
    public partial class AddFamilyForm : Form
    {
        public AddFamilyForm()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(RefTextBox.Text, out value))
            {
                if (NameTextBox.Text != "")
                {
                    Family NewFamily = new Family(value, NameTextBox.Text);
                    FamilyDAO.addFamily(NewFamily);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Les champs doivent etre remplient", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Référence doit etre un chiffre", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
