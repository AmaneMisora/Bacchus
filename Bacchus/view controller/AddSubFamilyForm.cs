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
    public partial class AddSubFamilyForm : Form
    {

        /// <summary>
        /// Constructeur de la fenetre
        /// </summary>
        public AddSubFamilyForm()
        {
            InitializeComponent();

            // rempli la combo box famille avec la liste des familles existante 
            Family[] AllFamily = FamilyDAO.getAllFamilys();
            foreach (Family F in AllFamily)
            {
                FamilyComboBox.Items.Add(F);
            }
        }

        /// <summary>
        /// Créer la sous famille lorsque l'on clique sur le bouton valider
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void OkButton_Click(object Sender, EventArgs Event)
        {
            int value;
            // vérifie si le contenue du champ reference est bien un nombre
            if (int.TryParse(RefTextBox.Text, out value))
            {
                // vérifie que le champ nom soit remplie
                if (NameTextBox.Text != "" || FamilyComboBox.Text != "")
                {
                    if (FamilyDAO.getFamilyById(value) == null)
                    {
                        //SubFamily NewSubFamily = new SubFamily(value, NameTextBox.Text, FamilyComboBox);
                        //SubFamilyDAO.addSubFamily(NewSubFamily);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ref existe déjà", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
