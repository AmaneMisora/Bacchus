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
    public partial class ModifyArticleForm : Form
    {

        /// <summary>
        /// Constructeur de la fenetre qui initialise tout les champs à partir des données de l'article modifié
        /// </summary>
        /// <param name="SelectedItem"></param>
        public ModifyArticleForm(ListViewItem SelectedItem)
        {
            InitializeComponent();

            // rempli la combo box marque avec la liste des marques existante 
            int Index = 0;
            int IndexBrand = 0;
            Brand[] AllBrand = BrandDAO.GetAllBrands();
            foreach (Brand B in AllBrand)
            {
                BrandComboBox.Items.Add(B);
                if (B.ToString() == SelectedItem.SubItems[3].Text)
                    IndexBrand = Index;
                Index++;
            }

            BrandComboBox.SelectedIndex = IndexBrand;

            // rempli la combo box famille avec la liste des familles existante 
            Index = 0;
            int IndexFamily = 0;
            Family[] AllFamily = FamilyDAO.GetAllFamilies();
            foreach (Family F in AllFamily)
            {
                FamilyComboBox.Items.Add(F);
                if (F.ToString() == SelectedItem.SubItems[4].Text)
                    IndexFamily = Index;
                Index++;
            }

            FamilyComboBox.SelectedIndex = IndexFamily;

            // rempli la combo box sous famille avec la liste des sous familles appartenant à la famille selectionnée
            Index = 0;
            int IndexSubFamily = 0;
            SubFamilyComboBox.Items.Clear();
            SubFamily[] AllLinkedSubFamilies = FamilyDAO.GetAllSubFamilies((Family)FamilyComboBox.SelectedItem);
            foreach (SubFamily SF in AllLinkedSubFamilies)
            {
                SubFamilyComboBox.Items.Add(SF);
                if (SF.ToString() == SelectedItem.SubItems[4].Text)
                    IndexSubFamily = Index;
                Index++;
            }

            SubFamilyComboBox.SelectedIndex = IndexSubFamily;

            // initialise les champs avec les données de l'article modifié 
            ArticleNameLabel.Text = SelectedItem.SubItems[2].Text;
            DescriptionTextBox.Text = SelectedItem.SubItems[1].Text;
            SubFamilyComboBox.Text = SelectedItem.SubItems[5].Text; //TODO
            PriceHTTextBox.Text = SelectedItem.SubItems[6].Text;
            QuantityTextBox.Text = SelectedItem.SubItems[0].Text;
        }

        /// <summary>
        /// Si les modifications sont valides change l'article concerné à l'appuie sur le bouton valider
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void OkButton_Click(object Sender, EventArgs Event)
        {
            // verifie que le prix puis la quantité soient bien des nombres
            double DoublePrice;
            if (double.TryParse(PriceHTTextBox.Text, out DoublePrice))
            {
                int IntQuantity;
                if (int.TryParse(QuantityTextBox.Text, out IntQuantity))
                {
                    // vérifie que les champs soient remplie
                    if (DescriptionTextBox.Text != "" && PriceHTTextBox.Text != "" && QuantityTextBox.Text != "" && BrandComboBox.Text != "" && FamilyComboBox.Text != "" && SubFamilyComboBox.Text != "")
                    {
                        ArticleDAO.EditArticle(ArticleNameLabel.Text, DescriptionTextBox.Text, (SubFamily) SubFamilyComboBox.SelectedItem, (Brand) BrandComboBox.SelectedItem, (float)DoublePrice, IntQuantity);
                        this.Close();
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
        }

        /// <summary>
        /// Remplie la combobox sous famille à chaque changement de la combobox famille
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void SubFamilyComboBox_SelectionChangeCommitted(object Sender, EventArgs Event)
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
