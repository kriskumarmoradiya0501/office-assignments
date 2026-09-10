using System;
using System.Windows.Forms;

namespace Practice
{
    public partial class FrmPassingDataOneToOther2 : Form
    {
        private string _name;
        private int _age;
        public FrmPassingDataOneToOther2(string name, int age)
        {
            InitializeComponent();
            _name = name;
            _age = age;
        }

        private void FrmPassingDataOneToOther2_Load(object sender, System.EventArgs e)
        {
            lblCatchData.Text = "Name : "+_name+" Age : "+_age;
        }

    }
}