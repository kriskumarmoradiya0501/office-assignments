using System;
using System.Drawing;
using System.Windows.Forms;

namespace IncomeExpenseTracker.Forms
{
    public class LoginForm : Form
    {
        // Fixed credentials as per the specification.
        private const string ValidUsername = "admin";
        private const string ValidPassword = "password123";

        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblError;

        public LoginForm()
        {
            BuildForm();
        }

        // All controls are created here in code, in the order they appear on screen.
        private void BuildForm()
        {
            this.Text = "Login - Income & Expense Tracker";
            this.Size = new Size(360, 260);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            lblTitle = new Label
            {
                Text = "Income & Expense Tracker",
                Location = new Point(20, 15),
                Size = new Size(300, 25),
                Font = new Font(this.Font, FontStyle.Bold)
            };

            lblUsername = new Label { Text = "Username:", Location = new Point(20, 60), Size = new Size(90, 20) };
            txtUsername = new TextBox { Location = new Point(120, 58), Size = new Size(180, 20) };

            lblPassword = new Label { Text = "Password:", Location = new Point(20, 95), Size = new Size(90, 20) };
            txtPassword = new TextBox { Location = new Point(120, 93), Size = new Size(180, 20), UseSystemPasswordChar = true };

            btnLogin = new Button { Text = "Login", Location = new Point(120, 130), Size = new Size(100, 28) };
            btnLogin.Click += BtnLogin_Click;

            lblError = new Label
            {
                Text = "",
                Location = new Point(20, 175),
                Size = new Size(300, 40),
                ForeColor = Color.Red
            };

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(lblError);

            // Pressing Enter in the password box also triggers login.
            this.AcceptButton = btnLogin;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == ValidUsername && txtPassword.Text == ValidPassword)
            {
                // Tell Program.cs that login succeeded, then close this form.
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Text = "Invalid username or password. Please try again.";
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
    }
}
