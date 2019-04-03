using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using RestAPI.Models;
using System;

namespace RestAPI.Context
{
    public class CalendarEventContext : BaseContext 
    {
        public CalendarEventContext(DbContextOptions<CalendarEventContext> options) : base(options) { }

        public ICollection<CalendarEvent> Retrieve(int calendarID)
        {
            return Events.Where(x => x.CalendarID == calendarID).ToList();
        }

        public bool Create(CalendarEvent newEvent)
        {
            if(ModelIsNotNull(newEvent))
            {
                if(TimesAreValid(newEvent.Start, newEvent.End) && TitleIsValid(newEvent.Title) && DescriptionIsValid(newEvent.Description))
                {
                    Events.Add(newEvent);
                    SaveChanges();

                    return true;
                }
            }
            return false;
        }

        public bool Change(CalendarEvent changedEvent)
        {
            if (ModelIsNotNull(changedEvent))
            {
                if (TimesAreValid(changedEvent.Start, changedEvent.End) && TitleIsValid(changedEvent.Title) && DescriptionIsValid(changedEvent.Description))
                {
                    if(Events.Where(x => x.ID == changedEvent.ID).Count() == 1)
                    {
                        CalendarEvent ev = Events.Find(changedEvent.ID);

                        ev.Title = changedEvent.Title;
                        ev.Start = changedEvent.Start;
                        ev.End = changedEvent.End;
                        ev.Description = changedEvent.Description;

                        SaveChanges();

                        return true;
                    }
                }
            }
            return false;
        }

        public bool Delete(int calendarID, int eventID)
        {
            if(calendarID > 0 && eventID > 0)
            {
                if(Events.FirstOrDefault(x => x.ID == eventID).CalendarID == calendarID)
                {
                    Events.RemoveRange(Events.Where(x => x.ID == eventID));
                    SaveChanges();

                    return true;
                }
            }
            return false;
        }

        public bool Delete(int calendarID)
        {
            if (calendarID > 0)
            {
                Events.RemoveRange(Events.Where(x => x.CalendarID == calendarID));
                SaveChanges();

                return true;
            }
            return false;
        }

        public bool ModelIsNotNull(CalendarEvent ev)
        {
            return (ev != null) && (ev.CalendarID > 0) && (ev.Title != null && ev.Title.Length > 0);  
        }

        public bool TitleIsValid(string name)
        {
            return (name.Length > 0 && name.Length <= 32);
        }

        public bool DescriptionIsValid(string description)
        {
            return (description == null) || (description.Length <= 256);
        }

        public bool TimesAreValid(DateTime start, DateTime end)
        {
            //Checks that the start is before the end
            return (DateTime.Compare(start, end) < 0);
        }
    }
}