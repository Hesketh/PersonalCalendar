using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DesktopApplication.Models;

namespace DesktopApplication.Context
{
    class EventContext
    {
        public async Task<ICollection<CalendarEvent>> GetEvents(Calendar calendar)
        {
            string path = String.Format("users/{0}/{1}/calendars/{2}/events", APIConnection.Instance.Auth.Username, APIConnection.Instance.Auth.Password, calendar.ID);

            return await APIConnection.Instance.Get<ICollection<CalendarEvent>>(path);
        }

        public async Task<bool> CreateEvent(CalendarEvent ev)
        {
            if(ModelIsValid(ev))
            {
                string path = String.Format("users/{0}/{1}/calendars/{2}/events", APIConnection.Instance.Auth.Username, APIConnection.Instance.Auth.Password, ev.CalendarID);
                return await APIConnection.Instance.Post(ev, path);
            }
            return false;
        }

        private bool ModelIsValid(CalendarEvent ev)
        {
            return TitleIsValid(ev.Title) && DescriptionIsValid(ev.Description) && TimesAreValid(ev.Start, ev.End);
        }

        private bool TimesAreValid(DateTime start, DateTime end)
        {
            return (DateTime.Compare(start, end) < 0);
        }

        private bool TitleIsValid(string title)
        {
            return title != null && title.Length > 0 && title.Length < 32; 
        }

        private bool DescriptionIsValid(string description)
        {
            if(description != null)
            {
                return description.Length < 256;
            }
            return true;
        }

        public async Task<bool> UpdateEvent(CalendarEvent ev)
        {
            if (ModelIsValid(ev))
            {
                string path = String.Format("users/{0}/{1}/calendars/{2}/events", APIConnection.Instance.Auth.Username, APIConnection.Instance.Auth.Password, ev.CalendarID);
                return await APIConnection.Instance.Put(ev, path);
            }
            return false;
        }

        public async Task<bool> DeleteEvent(CalendarEvent ev)
        {
            if (ModelIsValid(ev))
            {
                string path = String.Format("users/{0}/{1}/calendars/{2}/events/{3}", APIConnection.Instance.Auth.Username, APIConnection.Instance.Auth.Password, ev.CalendarID, ev.ID);
                return await APIConnection.Instance.Delete(path);
            }
            return false;
        }
    }
}
