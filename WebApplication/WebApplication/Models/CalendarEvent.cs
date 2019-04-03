using System;

namespace WebApplication.Models
{
    public class CalendarEvent
    {
        public int ID { get; set; }
        public int CalendarID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}