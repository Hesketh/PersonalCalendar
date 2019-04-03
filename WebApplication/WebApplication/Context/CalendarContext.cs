using WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.Context
{
    class CalendarContext
    {
        public async Task<ICollection<Calendar>> GetCalendars()
        {
            string path = String.Format("users/{0}/{1}/calendars", APIConnection.Instance.Auth.Username, APIConnection.Instance.Auth.Password);

            return await APIConnection.Instance.Get<ICollection<Calendar>>(path);
        }

        public async Task<bool> DeleteCalendar(Calendar calendar)
        {
            string path = String.Format("users/{0}/{1}/calendars/{2}", APIConnection.Instance.Auth.Username, APIConnection.Instance.Auth.Password, calendar.ID);

            return (await APIConnection.Instance.Delete(path));
        }
        
        public async Task<bool> CreateCalendar(Calendar calendar)
        {
            if(ModelIsValid(calendar))
            {
                string path = String.Format("users/{0}/{1}/calendars", APIConnection.Instance.Auth.Username, APIConnection.Instance.Auth.Password);

                if (await APIConnection.Instance.Post(calendar, path))
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> UpdateCalendar(Calendar calendar)
        {
            if(ModelIsValid(calendar))
            {
                string path = String.Format("users/{0}/{1}/calendars", APIConnection.Instance.Auth.Username, APIConnection.Instance.Auth.Password);

                if(await APIConnection.Instance.Put(calendar, path))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ModelIsValid(Calendar calendar)
        {
            return (calendar != null) && (calendar.Name != null) && TitleIsValid(calendar.Name);
        }

        private bool TitleIsValid(string title)
        {
            return title.Length > 0 && title.Length <= 32;
        }
    }
}
