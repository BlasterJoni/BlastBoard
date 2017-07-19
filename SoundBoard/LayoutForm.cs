using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundBoard
{
    public partial class LayoutForm : Form
    {
        public LayoutForm(ComboBox.ObjectCollection ExistingLayoutsParam, string nameParam = "")
        {
            InitializeComponent();
            NameTexbox.Text = nameParam;
            ExistingLayouts = ExistingLayoutsParam;
        }

        private ComboBox.ObjectCollection ExistingLayouts;
        public string name;

        private void LayoutFormSaveButton_Click(object sender, EventArgs e)
        {
            if (NameTexbox.Text.Length < 1)
            {
                MessageBox.Show("Name requires a minimum of 1 character!", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (ExistingLayouts.Contains(NameTexbox.Text))
            {
                MessageBox.Show("That layout name is alredy in use. Layout names must be unique!", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                name = NameTexbox.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
