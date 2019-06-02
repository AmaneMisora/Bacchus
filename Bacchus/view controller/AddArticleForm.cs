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
    public partial class AddArticleForm : Form
    {

        /// <summary>
        /// Constructeur de la fenetre
        /// </summary>
        public AddArticleForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Créer l'article lorsque l'on clique sur le bouton valider
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void OkButton_Click(object Sender, EventArgs Event)
        {
            int value;
            // vérifie si le contenue du champ reference est bien un nombre
            if (int.TryParse(RefTextBox.Text, out value))
            {
                // vérifie que les champs soientt remplie
                if ( DescriptionTextBox.Text != "" || PriceHTTextBox.Text != "" || QuantityTextBox.Text != "")
                {
                    // faire une verif sur la ref TODO
                    /*if (ArticleDAO.getArticleById(value) == null)
                    {
                        //SubFamily NewSubFamily = new SubFamily(value, NameTextBox.Text, FamilyComboBox);
                        //SubFamilyDAO.addSubFamily(NewSubFamily);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ref existe déjà", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }*/
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
