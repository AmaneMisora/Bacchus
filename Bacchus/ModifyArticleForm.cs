﻿using System;
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
        ListViewItem ItemChanged;

        public ModifyArticleForm(ListViewItem SelectedItem)
        {
            InitializeComponent();

            // rempli les combo box avec la liste des marque existante  
            //DataTable AllBrand = dao.BrandDAO.getBrands();
            //TODO

            // initialise les champs avec les données de l'article modifié 
            ArticleNameLabel.Text = SelectedItem.SubItems[2].Text;
            DescriptionTextBox.Text = SelectedItem.SubItems[1].Text;
            FamilyComboBox.Text = SelectedItem.SubItems[4].Text; //TODO a la plac e
            SubFamilyComboBox.Text = SelectedItem.SubItems[5].Text;
            BrandComboBox.Text = SelectedItem.SubItems[3].Text;
            PriceHTTextBox.Text = SelectedItem.SubItems[6].Text;
            QuantityTextBox.Text = SelectedItem.SubItems[0].Text;
        }
       

        private void OkButton_Click(object sender, EventArgs e)
        {
            model.Article ModifiedArticle = new model.Article();
            // appeler save du dao de article
            // qui va chercher un article avec cette ref et appliquer les modif si il y en a 

            this.Close();
        }
    }
}
