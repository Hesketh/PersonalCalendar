using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using RestAPI.Models;

namespace RestAPI.Context
{
    public class CalendarContext : BaseContext
    {
        public CalendarContext(DbContextOptions<CalendarContext> options) : base(options) { }

        public Calendar Retrieve(int calendarID)
        {
            return Calendars.Find(calendarID);
        }

        public bool Create(Calendar calendar)
        {
            if(ModelIsNotNull(calendar))
            {
                if(NameIsValid(calendar.Name))
                {
                    Calendars.Add(calendar);
                    SaveChanges();

                    return true;
                }
            }
            return false;
        }

        public bool Change(Calendar calendar)
        {
            if (ModelIsNotNull(calendar))
            {
                if (NameIsValid(calendar.Name) && Calendars.Where(x => x.ID == calendar.ID).Count() == 1)
                {
                    Calendars.Find(calendar.ID).Name = calendar.Name;
                    SaveChanges();

                    return true;
                }
            }
            return false;
        }

        public bool Delete(int calendarID)
        {
            if(calendarID > 0)
            {
                Calendars.RemoveRange(Calendars.Where(x => x.ID == calendarID));
                SaveChanges();

                return true;
            }
            return false;
        }

        private bool ModelIsNotNull(Calendar calendar)
        {
            return (calendar != null) && (calendar.Name != null);
        }

        private bool NameIsValid(string name)
        {
            return (name != null) && (name.Length > 0);
        }
    }
}
