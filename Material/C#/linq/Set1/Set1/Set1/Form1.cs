using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Set1
{
    public partial class Form1 : Form
    {
        string query;
        SqlConnection conn;
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            string connstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\dot net\\Employee_DB\\Employee_DB2.mdf\";Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(connstring);
            conn.Open();
            ex2();
        }
        private void ex2()
        {
            query = "Select Dept_Name,Dept_ID from Dept";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt); // Fills data to data table from adapter
            cmbDep.DataSource = dt;
            cmbDep.ValueMember = "Dept_ID"; // Changed "PID" to "bid" to match the column name
            cmbDep.DisplayMember = "Dept_Name"; // Added DisplayMember to show the bid values in the ComboBox
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Enter Employee Name : ");
                txtName.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtSalary.Text))
            {
                MessageBox.Show("Enter Employee Salary : ");
                txtSalary.Focus();
                return;
            }
            else
            {
                string name = txtName.Text;
                int salary = int.Parse(txtSalary.Text);
                int deptId = (int)cmbDep.SelectedValue;  

                string query = "INSERT INTO Emp (Emp_Name, Emp_Sal, Dept_Id) VALUES ('"+name+"',"+salary+","+deptId+")";
                SqlCommand cmd = new SqlCommand(query, conn);
               
                MessageBox.Show(query);
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Record  Inderted...");
                txtName.Clear();
                txtSalary.Clear();
            }
        }

        private void ex()
        {
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            // MessageBox.Show("Record  Updated...");
            query = "Select * from Emp";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);//fills data to data table from adapter
            dg1.DataSource = dt;


        }
        private void btnView_Click(object sender, EventArgs e)
        {
            ex();
        }
    }
}
