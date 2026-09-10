using System;
using System.Windows.Forms;

namespace StudentManagment
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            txtResult.Clear();
            int num1;
            if(int.TryParse(txtNum1.Text,out num1))
            {
                
            }
            else
            {
                MessageBox.Show("Please enter valid Number 1.");
                return;
            }
            int num2;
            if(int.TryParse(txtNum2.Text,out num2))
            {
                
            }
            else
            {
                MessageBox.Show("Please enter valid Number 2.");
                return;
            }

            txtResult.Text += (num1+num2);
        }

        private void BtnHello_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Hello world");
        }

        private void BtnHi_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Hi world");
        }



        private void TxtNum1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtNum2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}