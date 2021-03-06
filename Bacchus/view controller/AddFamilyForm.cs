﻿using Bacchus.dao;
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
    public partial class AddFamilyForm : Form
    {
        /// <summary>
        /// Constructeur de la fenetre
        /// </summary>
        public AddFamilyForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Créer la famille lorsque l'on clique sur le bouton valider
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Event"></param>
        private void OkButton_Click(object Sender, EventArgs Event)
        {
            int IntRef;
            // vérifie si le contenue du champ reference est bien un nombre
            if (int.TryParse(RefTextBox.Text, out IntRef))
            {
                // vérifie que le champ nom soit remplie
                if (NameTextBox.Text != "")
                {
                    if (FamilyDAO.GetFamilyById(IntRef) == null)
                    {
                        Family NewFamily = new Family(IntRef, NameTextBox.Text);
                        FamilyDAO.AddFamily(NewFamily);
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
