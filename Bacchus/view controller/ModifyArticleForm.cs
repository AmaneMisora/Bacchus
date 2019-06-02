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
            Brand[] AllBrand = BrandDAO.getAllBrands();
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
            Family[] AllFamily = FamilyDAO.getAllFamilys();
            foreach (Family F in AllFamily)
            {
                FamilyComboBox.Items.Add(F);
                if (F.ToString() == SelectedItem.SubItems[4].Text)
                    IndexFamily = Index;
                Index++;
            }

            FamilyComboBox.SelectedIndex = IndexFamily;

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
            //TODO verifier si l'un des champs est vide
            Article ModifiedArticle = new Article();
            // appeler save du dao de article
            // qui va chercher un article avec cette ref et appliquer les modif si il y en a 

            this.Close();
        }
    }
}
