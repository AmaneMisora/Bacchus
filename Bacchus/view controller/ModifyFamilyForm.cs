using Bacchus.dao;
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
    public partial class ModifyFamilyForm : Form
    {

        /// <summary>
        /// Constructeur de la fenetre qui initialise tout les champs à partir des données de la famille modifiée
        /// </summary>
        /// <param name="SelectedItem"></param>
        public ModifyFamilyForm(ListViewItem SelectedItem)
        {
            InitializeComponent();
            FamilyNameLabel.Text = SelectedItem.SubItems[1].Text;
            NameTextBox.Text = SelectedItem.SubItems[0].Text;
        }

        private void ModifyFamilyForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Si les modifications sont valides change la famille concernée à l'appuie sur le bouton valider
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void OkButton_Click(object Sender, EventArgs Event)
        {
            if (NameTextBox.Text != "")
            {
                FamilyDAO.editFamily(int.Parse(FamilyNameLabel.Text), NameTextBox.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Les champs doivent etre remplient", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
