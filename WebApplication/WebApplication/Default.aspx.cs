using System;
using System.Web.UI;

using WebApplication.Context;
using WebApplication.Models;

namespace WebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ErrorText"] == null)
            {
                Session["ErrorText"] = "";
            }

            lblError.Text = Session["ErrorText"].ToString();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserContext context = new UserContext();

            User attempt = new User();

            attempt.Username = txtUsername.Text.ToLower().Trim();
            attempt.Password = txtPassword.Text.Trim();

            var task = context.Login(attempt);

            if(task.Result)
            {
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                Session["ErrorText"] = "Incorrect Username/Password combination!";
                Response.Redirect("Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserContext context = new UserContext();

            User attempt = new User();

            attempt.Username = txtUsername.Text.ToLower().Trim();
            attempt.Password = txtPassword.Text.Trim();

            var task = context.Create(attempt);
            
            if(task.Result)
            {
                Session["ErrorText"] = "The user account was created!";
                Response.Redirect("Default.aspx");
            }
            else
            {
                Session["ErrorText"] = "There was a problem creating the new user!";
                Response.Redirect("Default.aspx");
            }
        }
    }
}