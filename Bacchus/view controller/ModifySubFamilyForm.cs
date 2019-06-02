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
    public partial class ModifySubFamilyForm : Form
    {

        /// <summary>
        /// Constructeur de la fenetre qui initialise tout les champs à partir des données de la sous famille modifiée
        /// </summary>
        /// <param name="SelectedItem"></param>
        public ModifySubFamilyForm(ListViewItem SelectedItem)
        {
            InitializeComponent();


            // rempli la combo box famille avec la liste des familles existante 
            int Index = 0;
            int IndexFamily = 0;
            Family[] AllFamily = FamilyDAO.getAllFamilys();
            foreach (Family F in AllFamily)
            {
                FamilyComboBox.Items.Add(F);
                if (F.ToString() == SelectedItem.SubItems[2].Text)
                    IndexFamily = Index;
                Index++;
            }

            FamilyComboBox.SelectedIndex = IndexFamily;

            // initialise les champs avec les données de la sous famille modifiée
            SubFamilyNameLabel.Text = SelectedItem.SubItems[1].Text;
            NameTextBox.Text = SelectedItem.SubItems[0].Text;
        }

        private void SubFamilyModifyForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Si les modifications sont valides change la sous famille concernée à l'appuie sur le bouton valider
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void OkButton_Click(object Sender, EventArgs Event)
        {
            if (NameTextBox.Text != "")
            {
                //MessageBox.Show(int.Parse(BrandNameLabel.Text) + " " + NameTextBox.Text);
                //editSubFamily
                this.Close();
            }
            else
            {
                MessageBox.Show("Les champs doivent etre remplient", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
