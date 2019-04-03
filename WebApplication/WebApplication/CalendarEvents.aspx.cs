using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebApplication.Context;
using WebApplication.Models;

namespace WebApplication
{
    public partial class CalendarEvents : System.Web.UI.Page
    {
        WebApplication.Models.Calendar m_calendar = new Models.Calendar();
        List<CalendarEvent> m_events;
        //DateTime m_start;
        //DateTime m_end;

        protected void Page_Load(object sender, EventArgs e)
        {
            CalendarContext context = new CalendarContext();

            var task = context.GetCalendars();
            var result = task.Result;

            if(result != null && result.Count > 0 && Request.QueryString["ID"] != null)
            {
                List<WebApplication.Models.Calendar> calendars = result.ToList();
                m_calendar = calendars.Find(x => x.ID == int.Parse(Request.QueryString["ID"]));

                if(m_calendar == null)
                {
                    //this calendar does not exist / user doesnt have right to view
                    Response.Redirect("Default");
                }

                if(!IsPostBack)
                {
                    Session["StartTime"] = DateTime.Today.ToString();
                    Session["EndTime"] = DateTime.Today.AddDays(1).AddMilliseconds(-1).ToString();
                }
                txtCalendarName.Text = m_calendar.Name;
                GetCalendarEvents();
                DisplayCalendarEvents();
            }
        }

        protected void DisplayCalendarEvents()
        {
            lblDate.Text = "Date: " + Convert.ToDateTime(Session["StartTime"]).ToShortDateString();
            gvEvents.DataSource = m_events.Where(x => x.Start.Date == Convert.ToDateTime(Session["StartTime"]).Date);
            gvEvents.DataBind();
        }

        protected void GetCalendarEvents()
        {
            EventContext context = new EventContext();

            var task = context.GetEvents(m_calendar);
            var result = task.Result;

            if (result != null)
            {
                m_events = result.ToList();
            }
        }

        protected void btnUpdateCalendarName_Click(object sender, EventArgs e)
        {
            CalendarContext context = new CalendarContext();
            Models.Calendar updatedCalendar = new Models.Calendar();

            updatedCalendar.ID = m_calendar.ID;
            updatedCalendar.Name = txtCalendarName.Text.Trim();

            var task = context.UpdateCalendar(updatedCalendar);
            task.Wait(200);

            Response.Redirect("CalendarEvents.aspx?ID=" + Request.QueryString["ID"]);
        }

        protected void btnNextDay_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = Convert.ToDateTime(Session["StartTime"]).AddDays(1);
            Session["EndTime"] = Convert.ToDateTime(Session["EndTime"]).AddDays(1);

            DisplayCalendarEvents();
        }

        protected void btnPreviousDay_Click(object sender, EventArgs e)
        {
            Session["StartTime"] = Convert.ToDateTime(Session["StartTime"]).AddDays(-1);
            Session["EndTime"] = Convert.ToDateTime(Session["EndTime"]).AddDays(-1);

            DisplayCalendarEvents();
        }

        protected void gvEvents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Delete")
            {
                EventContext context = new EventContext();

                var task = context.DeleteEvent(m_events.Where(x => x.Start.Date == Convert.ToDateTime(Session["StartTime"]).Date).ToList()[int.Parse(e.CommandArgument.ToString())]);
                task.Wait(200);

                //if (result)
                //{
                //    GetCalendarEvents();
                //    DisplayCalendarEvents();
                //}
                Response.Redirect("CalendarEvents.aspx?ID=" + Request.QueryString["ID"]);
            }
            else if (e.CommandName == "Edit")
            {
                Response.Redirect("EditEvent?CID=" + m_calendar.ID.ToString() + "&EID=" + m_events.Where(x => x.Start.Date == Convert.ToDateTime(Session["StartTime"]).Date).ToList()[int.Parse(e.CommandArgument.ToString())].ID);
            }
        }

        protected void btnNewEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateEvent?CID=" + m_calendar.ID.ToString());
        }

        protected void gvEvents_SelectedIndexChanged(object sender, EventArgs e) { }

        protected void gvEvents_RowDataBound(object sender, EventArgs e) { }

        protected void txtCalendarName_TextChanged(object sender, EventArgs e) { }
    }
}