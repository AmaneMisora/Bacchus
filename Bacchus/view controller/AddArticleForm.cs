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
    public partial class AddArticleForm : Form
    {

        /// <summary>
        /// Constructeur de la fenetre
        /// </summary>
        public AddArticleForm()
        {
            InitializeComponent();

            // rempli la combo box marque avec la liste des marques existante 
            Brand[] AllBrand = BrandDAO.GetAllBrands();
            foreach (Brand B in AllBrand)
            {
                BrandComboBox.Items.Add(B);
            }

            // rempli la combo box famille avec la liste des familles existante 
            Family[] AllFamily = FamilyDAO.GetAllFamilies();
            foreach (Family F in AllFamily)
            {
                FamilyComboBox.Items.Add(F);
            }
            

        }

        /// <summary>
        /// Créer l'article lorsque l'on clique sur le bouton valider
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void OkButton_Click(object Sender, EventArgs Event)
        {
            // vérifie si le contenue du champ reference une reference d'article valide
            if (ArticleDAO.VerifArticleRef(RefTextBox.Text) == true)
            {
                // verifie que le prix puis la quantité soient bien des nombres
                double DoublePrice;
                if (double.TryParse(PriceHTTextBox.Text, out DoublePrice))
                {
                    int IntQuantity;
                    if (int.TryParse(PriceHTTextBox.Text, out IntQuantity))
                    {
                        // vérifie que les champs soient remplie
                        if (DescriptionTextBox.Text != "" && PriceHTTextBox.Text != "" && QuantityTextBox.Text != "" && BrandComboBox.Text != "" && FamilyComboBox.Text != "" && SubFamilyComboBox.Text != "")
                        {
                            if (ArticleDAO.GetArticleById(RefTextBox.Text) == null)
                            {
                                Article NewArticle = new Article(RefTextBox.Text, DescriptionTextBox.Text, (SubFamily)SubFamilyComboBox.SelectedItem, (Brand)BrandComboBox.SelectedItem, DoublePrice, IntQuantity);
                                ArticleDAO.AddArticle(NewArticle);
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
                        MessageBox.Show("La quantite doit etre un nombre", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Le prix doit etre un nombre", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            } else
            {
                MessageBox.Show("Référence non valide, elle doit etre de cette forme : F0000000", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FamilyComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SubFamily[] AllLinkedSubFamilies = FamilyDAO.GetAllSubFamilies((Family)FamilyComboBox.SelectedItem);
            foreach (SubFamily SF in AllLinkedSubFamilies)
            {
                SubFamilyComboBox.Items.Add(SF);
            }

        }

        private void FamilyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(((Family)FamilyComboBox.SelectedItem).ToString());
        }
    }
}
