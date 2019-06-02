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
    public partial class AddBrandForm : Form
    {

        /// <summary>
        /// Constructeur de la fenetre
        /// </summary>
        public AddBrandForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Créer la marque lorsque l'on clique sur le bouton valider
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void OkButton_Click(object Sender, EventArgs Event)
        {
            int value;
            if (int.TryParse(RefTextBox.Text, out value))
            {
                if(NameTextBox.Text != "")
                { 
                    if(BrandDAO.getBrandById(value) == null)
                    {
                        Brand NewBrand = new Brand(value, NameTextBox.Text);
                        BrandDAO.AddBrand(NewBrand);
                        this.Close();
                    } else
                    {
                        MessageBox.Show("Ref existe déjà", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Les champs doivent etre remplient", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Référence doit etre un chiffre", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
