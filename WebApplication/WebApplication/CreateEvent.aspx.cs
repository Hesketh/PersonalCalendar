using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebApplication.Context;
using WebApplication.Models;

namespace WebApplication
{
    public partial class CreateEvent : System.Web.UI.Page
    {
        Models.Calendar calendar;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Find the relevant calendar
            CalendarContext calendarContext = new CalendarContext();

            var taskGetCalendar = calendarContext.GetCalendars();
            taskGetCalendar.Wait(200);

            if (taskGetCalendar.Result != null)
            {
                List<WebApplication.Models.Calendar> calendars = taskGetCalendar.Result.ToList();
                calendar = calendars.Find(x => x.ID == int.Parse(Request.QueryString["CID"]));

                if (calendar == null)
                {
                    //this calendar does not exist / user doesnt have right to view
                    Response.Redirect("Default");
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EventContext context = new EventContext();
            CalendarEvent newEvent = new CalendarEvent();

            newEvent.Title = txtName.Text.Trim();
            newEvent.Description = txtDescription.Text.Trim();

            newEvent.Start = Convert.ToDateTime(txtStart.Text);
            newEvent.Start += Convert.ToDateTime(txtStartTime.Text).TimeOfDay;

            newEvent.End = Convert.ToDateTime(txtEnd.Text);
            newEvent.End += Convert.ToDateTime(txtTimeEnd.Text).TimeOfDay;

            newEvent.CalendarID = calendar.ID;

            var task = context.CreateEvent(newEvent);
            task.Wait(200);

            Response.Redirect("CalendarEvents?ID=" + Request.QueryString["CID"]);
        }
    }
}