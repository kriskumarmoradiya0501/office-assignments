using System;
using System.Windows.Forms;
using IncomeExpenseTracker.Forms;

namespace IncomeExpenseTracker
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show the login form first. Only open the main window if login succeeds.
            using (var login = new LoginForm())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm());
                }
            }
        }
    }
}
