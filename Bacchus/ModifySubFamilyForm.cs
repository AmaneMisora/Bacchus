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
    public partial class ModifySubFamilyForm : Form
    {
        public ModifySubFamilyForm(ListViewItem SelectedItem)
        {
            InitializeComponent();

            SubFamilyNameLabel.Text = SelectedItem.SubItems[1].Text;
            NameTextBox.Text = SelectedItem.SubItems[0].Text;
            FamilyComboBox.Text = SelectedItem.SubItems[2].Text;
        }

        private void SubFamilyModifyForm_Load(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
