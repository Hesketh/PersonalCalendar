using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebApplication.Context;
using WebApplication.Models;

namespace WebApplication
{
    public partial class EditEvent : System.Web.UI.Page
    {
        Models.CalendarEvent m_event;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Find the relevant calendar
            CalendarContext calendarContext = new CalendarContext();

            Models.Calendar calendar = new Models.Calendar();
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

            //Retrieve all events then find the relevant event - in retrospect having the api have a way to retrieve a single event would be easier
            EventContext eventContext = new EventContext();

            var task = eventContext.GetEvents(calendar);
            task.Wait(200);

            if(task.Result != null)
            {
                List<Models.CalendarEvent> events = task.Result.ToList();
                m_event = events.Find(x => x.ID == int.Parse(Request.QueryString["EID"]));
            }

            if (m_event == null)
            {
                //this event does not exist / user doesnt have right to view
                Response.Redirect("Default");
            }

            //Write all event information into the fields on the form
            txtName.Text = m_event.Title;
            txtDescription.Text = m_event.Description;

            //dd/mm/yyyy hh:mm
            txtStart.Text = m_event.Start.ToString("yyyy-MM-dd");
            txtStartTime.Text = m_event.Start.ToShortTimeString();
            txtEnd.Text = m_event.End.ToString("yyyy-MM-dd");
            txtTimeEnd.Text = m_event.End.ToShortTimeString();

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EventContext context = new EventContext();

            m_event.Title = txtName.Text.Trim();
            m_event.Description = txtDescription.Text.Trim();

            m_event.Start = Convert.ToDateTime(txtStart.Text);
            m_event.Start += Convert.ToDateTime(txtStartTime.Text).TimeOfDay;

            m_event.End = Convert.ToDateTime(txtEnd.Text);
            m_event.End += Convert.ToDateTime(txtTimeEnd.Text).TimeOfDay;

            var task = context.UpdateEvent(m_event);
            task.Wait(200);

            Response.Redirect("CalendarEvents?ID=" + Request.QueryString["CID"]);
        }
    }
}