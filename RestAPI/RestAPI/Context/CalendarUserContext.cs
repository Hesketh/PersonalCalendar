using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using RestAPI.Models;

namespace RestAPI.Context
{
    public class CalendarUserContext : BaseContext
    {
        public CalendarUserContext(DbContextOptions<CalendarUserContext> options) : base(options) { }

        public ICollection<CalendarUser> Retrieve(string username)
        {
            return CalendarUsers.Where(x => x.Username == username).ToList();
        }

        public ICollection<CalendarUser> Retrieve(int calendarID)
        {
            return CalendarUsers.Where(x => x.CalendarID == calendarID).ToList();
        }

        public CalendarUser Retrieve(string username, int calendarID)
        {
            return CalendarUsers.FirstOrDefault(x => x.Username == username && x.CalendarID == calendarID);
        }

        public bool Create(CalendarUser calendaruser)
        {
            if (ModelIsNotNull(calendaruser))
            {
                CalendarUsers.Add(calendaruser);
                SaveChanges();

                return true;
            }
            return false;
        }

        public bool Create(string username, int calendarID, string privilege)
        {
            CalendarUser caluse = new CalendarUser();

            caluse.CalendarID = calendarID;
            caluse.Username = username;
            caluse.PrivilegeKey = privilege;

            CalendarUsers.Add(caluse);

            SaveChanges();

            return true;
        }

        public bool Change(CalendarUser calendaruser)
        {
            if (ModelIsNotNull(calendaruser))
            {
                CalendarUser databaseItem = CalendarUsers.FirstOrDefault(x => x.CalendarID == calendaruser.CalendarID && x.Username == calendaruser.Username);
                if (ModelIsNotNull(databaseItem))
                {
                    databaseItem.Privilege = calendaruser.Privilege;
                    SaveChanges();

                    return true;
                }
            }
            return false;
        }

        public bool Delete(CalendarUser calendaruser)
        {
            if (ModelIsNotNull(calendaruser))
            {
                CalendarUsers.RemoveRange(CalendarUsers.Where(x => x.Username == calendaruser.Username && x.CalendarID == calendaruser.CalendarID));
                SaveChanges();

                return true;
            }
            return false;
        }

        public bool Delete(int calendarID)
        {
            if (calendarID > 0)
            {
                CalendarUsers.RemoveRange(CalendarUsers.Where(x => x.CalendarID == calendarID));
                SaveChanges();

                return true;
            }
            return false;
        }

        private bool ModelIsNotNull(CalendarUser calendaruser)
        {
            return (calendaruser != null) && (calendaruser.CalendarID > 0) && (calendaruser.Username != null) && (calendaruser.PrivilegeKey != null);
        }
    }
}
