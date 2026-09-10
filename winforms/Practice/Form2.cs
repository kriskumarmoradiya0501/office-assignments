using System;
using System.Windows.Forms;

namespace Practice
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void BtnHello_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Hello "+ txtName.Text);
        }
    }
}