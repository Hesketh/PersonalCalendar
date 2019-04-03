using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI;

using WebApplication.Context;
using WebApplication.Models;


namespace WebApplication
{
    public partial class CreateCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CalendarError"] == null)
            {
                Session["CalendarError"] = "Calendar";
            }

            lblError.Text = Session["CalendarError"].ToString();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            CalendarContext context = new CalendarContext();
            Calendar attempt = new Calendar();

            attempt.Name = txtName.Text.Trim();

            var task = context.CreateCalendar(attempt);
            task.Wait(200);
            Response.Redirect("Dashboard.aspx");
        }
    }
}