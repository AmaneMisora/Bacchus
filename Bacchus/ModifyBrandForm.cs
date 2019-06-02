using Bacchus.dao;
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
    public partial class ModifyBrandForm : Form
    {
        public ModifyBrandForm(ListViewItem SelectedItem)
        {
            InitializeComponent();
            BrandNameLabel.Text = SelectedItem.SubItems[1].Text;
            NameTextBox.Text = SelectedItem.SubItems[0].Text;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(int.Parse(BrandNameLabel.Text) + " " + NameTextBox.Text);
            BrandDAO.editBrand(int.Parse(BrandNameLabel.Text),NameTextBox.Text);
            this.Close();
        }
    }
}
