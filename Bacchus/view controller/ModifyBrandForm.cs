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
    public partial class ModifyBrandForm : Form
    {

        /// <summary>
        /// Constructeur de la fenetre qui initialise tout les champs à partir des données de la marque modifiée
        /// </summary>
        /// <param name="SelectedItem"></param>
        public ModifyBrandForm(ListViewItem SelectedItem)
        {
            InitializeComponent();
            BrandNameLabel.Text = SelectedItem.SubItems[1].Text;
            NameTextBox.Text = SelectedItem.SubItems[0].Text;
        }

        /// <summary>
        /// Si les modifications sont valides change la marque concernée à l'appuie sur le bouton valider
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void OkButton_Click(object Sender, EventArgs Event)
        {
            if (NameTextBox.Text != "")
            {
                //MessageBox.Show(int.Parse(BrandNameLabel.Text) + " " + NameTextBox.Text);
                BrandDAO.editBrand(int.Parse(BrandNameLabel.Text), NameTextBox.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Les champs doivent etre remplient", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
