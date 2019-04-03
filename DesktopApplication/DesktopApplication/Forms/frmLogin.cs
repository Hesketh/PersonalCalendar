using System;
using System.Windows.Forms;

using DesktopApplication.Models;
using DesktopApplication.Context;
using DesktopApplication.Forms;

namespace DesktopApplication
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            ToggleButtons();

            UserContext userFunctions = new UserContext();
            User attempt = new User();

            attempt.Username = txtUsername.Text.ToLower().Trim();
            attempt.Password = txtPassword.Text.Trim();

            if (await userFunctions.Login(attempt))
            {
                this.Hide();

                frmDashboard dashboardForm = new frmDashboard();
                dashboardForm.FormClosed += (s, args) => this.Close();   //Close this hidden login form when the calendar form is closed
                dashboardForm.Show();
            }
            else
            {
                MessageBox.Show("The Username/Password combination is incorrect!");
            }

            ToggleButtons();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            ToggleButtons();

            UserContext userFunctions = new UserContext();
            User attempt = new User();

            attempt.Username = txtUsername.Text.ToLower().Trim();
            attempt.Password = txtPassword.Text.Trim();

            if (await userFunctions.Create(attempt))
            {
                MessageBox.Show("Account Created!");
            }
            else
            {
                MessageBox.Show("There was a problem creating the account!");
            }

            ToggleButtons();
        }

        private void ToggleButtons()
        {
            btnLogin.Enabled = !btnLogin.Enabled;
            btnRegister.Enabled = !btnRegister.Enabled;
        }
    }
}
