using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI;

using WebApplication.Context;
using WebApplication.Models;

namespace WebApplication
{
    public partial class Dashboard : System.Web.UI.Page
    {
        List<Calendar> m_calendars = new List<Calendar>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["CalendarError"] == null)
            {
                Session["CalendarError"] = "Calendars";
            }

            if (Session["PasswordError"] == null)
            {
                Session["PasswordError"] = "Password";
            }

            if (!IsPostBack)
            {
                UpdateDropDownCalendars();
            }

            lblCalendars.Text = Session["CalendarError"].ToString();
            lblPassword.Text = Session["PasswordError"].ToString();
        }

        void UpdateDropDownCalendars()
        {
            CalendarContext context = new CalendarContext();

            ddCalendars.Items.Clear();

            var task = context.GetCalendars();
            var calendars = task.Result;

            if(calendars != null)
            {
                m_calendars = calendars.ToList();
            }

            ddCalendars.DataTextField = "Name";
            ddCalendars.DataValueField = "ID";
            ddCalendars.DataSource = m_calendars;
            ddCalendars.DataBind();
        }

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            lblCalendars.Text = "Calendars!";
            if (ddCalendars.SelectedIndex >= 0)
            {
                Response.Redirect("CalendarEvents?ID=" + GetSelectedCalendar().ID.ToString());
            }
            else
            {
                Session["CalendarError"] = "Please select a Calendar from the drop down!";
                Response.Redirect("Dashboard.aspx");
            }
        }

        Calendar GetSelectedCalendar()
        {
            if (ddCalendars.SelectedIndex >= 0)
            {
                Calendar cal = new Calendar();
                cal.ID = int.Parse(ddCalendars.SelectedItem.Value);
                cal.Name = ddCalendars.SelectedItem.Text;

                return cal;
            }
            return null;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (ddCalendars.SelectedIndex >= 0)
            {
                CalendarContext context = new CalendarContext();
                Calendar cal = GetSelectedCalendar();

                if (cal != null)
                {
                    var task = context.DeleteCalendar(cal);
                    task.Wait(200);

                    UpdateDropDownCalendars();
                }
            }
            else
            {
                Session["CalendarError"] = "Please Select a calendar from the drop down";
                Response.Redirect("Dashboard.aspx");
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateCalendar");
        }

        protected void txtChangePassword_Click(object sender, EventArgs e)
        {
            UserContext context = new UserContext();

            var task = context.Change(txtPassword.Text.Trim());
            task.Wait(200);

            Response.Redirect("Dashboard.aspx");

            //if(task.Result)
            //{
            //    Session["PasswordError"] = "Password has been updated!";
            //    Response.Redirect("Dashboard.aspx");
            //}
            //else
            //{
            //    Session["PasswordError"] = "There was a problem changing your password!";
            //    Response.Redirect("Dashboard.aspx");
            //}
        }

        protected void ddCalendars_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}