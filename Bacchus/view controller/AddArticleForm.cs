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

            //attend qu'une famille soit sélectionnée
            SubFamilyComboBox.Items.Add("Selectionnez d'abord une famille");

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
                float FloatPrice;
                if (float.TryParse(PriceHTTextBox.Text, out FloatPrice))
                {
                    PriceToAdd = DoublePrice;
                    int IntQuantity;
                    if (int.TryParse(QuantityTextBox.Text, out IntQuantity))
                    {
                        QuantityToAdd = IntQuantity;
                        // vérifie que les champs soient remplie
                        if (DescriptionTextBox.Text != "" && PriceHTTextBox.Text != "" && QuantityTextBox.Text != "" && BrandComboBox.Text != "" && FamilyComboBox.Text != "" && SubFamilyComboBox.Text != "")
                        {
                            if (ArticleDAO.GetArticleById(RefTextBox.Text) == null)
                            {
                                Article NewArticle = new Article(RefTextBox.Text, DescriptionTextBox.Text, (SubFamily)SubFamilyComboBox.SelectedItem, (Brand)BrandComboBox.SelectedItem, FloatPrice, IntQuantity);
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

        /// <summary>
        /// Remplie la combobox SubFamilies à chaque changement de la combobox families
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void FamilyComboBox_SelectionChangeCommitted(object Sender, EventArgs Event)
        {
            SubFamilyComboBox.Items.Clear();
            SubFamily[] AllLinkedSubFamilies = FamilyDAO.GetAllSubFamilies((Family)FamilyComboBox.SelectedItem);
            foreach (SubFamily SF in AllLinkedSubFamilies)
            {
                SubFamilyComboBox.Items.Add(SF);
            }

        }
        
    }
}
