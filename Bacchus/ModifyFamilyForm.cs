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
    public partial class ModifyFamilyForm : Form
    {
        public ModifyFamilyForm(ListViewItem SelectedItem)
        {
            InitializeComponent();
            FamilyNameLabel.Text = SelectedItem.SubItems[1].Text;
            NameTextBox.Text = SelectedItem.SubItems[0].Text;
        }

        private void ModifyFamilyForm_Load(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
