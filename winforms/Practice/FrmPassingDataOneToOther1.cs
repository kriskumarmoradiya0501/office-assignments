using System;
using System.Windows.Forms;

namespace Practice
{
    public partial class FrmPassingDataOneToOther1 : Form
    {
        public FrmPassingDataOneToOther1()
        {
            InitializeComponent();
        }

        private void BtnOpenForm_Click(object sender, System.EventArgs e)
        {
            string name  = txtName.Text;

            if(name == "")
            {
                MessageBox.Show("Please eneter the name.");
                txtName.Focus();
                return;
            }

            int age;

            if(!int.TryParse(txtAge.Text,out age))
            {
                MessageBox.Show("Please enter valid age.");
                return;
            }
            age = int.Parse(txtAge.Text);
            if(age < 1 && age > 128)
            {
                MessageBox.Show("Age must be between 1 to 128.");
                return;
            }

            FrmPassingDataOneToOther2 frm2 = new FrmPassingDataOneToOther2(name,age);
            frm2.Show();

        }

        private void TxtAge_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}