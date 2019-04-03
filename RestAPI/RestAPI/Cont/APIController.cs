using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

using RestAPI.Context;
using RestAPI.Models;

namespace RestAPI.Cont
{
    [Route("api")]
    public class APIController : Controller
    {
        private UserContext m_users;
        private CalendarContext m_calendars;
        private CalendarEventContext m_events;
        private CalendarUserContext m_calendarUsers;

        public APIController(UserContext users, CalendarContext calendars, CalendarEventContext calendarEvents, CalendarUserContext calendarUsers)
        {
            m_users = users;
            m_calendars = calendars;
            m_events = calendarEvents;
            m_calendarUsers = calendarUsers;
        }

        // USERS //

        // Login: Returns true if the username/password combination matches one in the database
        [HttpGet("users/{username}/{password}")]
        public bool UserLogin(string username, string password)
        {
            User user = m_users.Retrieve(username);

            if(user != null)
            {
                return user.Password == password;
            }
            return false;
        }

        // Create: Creates a new user account
        [HttpPost("users")]
        public IActionResult UserCreate([FromBody] User newUser)
        {
            if(m_users.Create(newUser))
            {
                return new NoContentResult();
            }
            return new BadRequestResult();
        }

        // ChangePassword: Changes an accounts password
        [HttpPut("users/{username}/{password}")]
        public IActionResult UserChangePassword(string username, string password, [FromBody] User changedUser)
        {
            if(UserLogin(username, password) && username == changedUser.Username)
            {
                if(m_users.Change(changedUser))
                {
                    return new NoContentResult();
                }
            }
            return new BadRequestResult();
        }

        // CALENDARS //

        // GetAll: Get all of a users calendars
        [HttpGet("users/{username}/{password}/calendars")]
        public ICollection<Calendar> CalendarGetAll(string username, string password)
        {
            if(UserLogin(username, password))
            {
                List<Calendar> calendars = new List<Calendar>();

                foreach(CalendarUser calUser in m_calendarUsers.Retrieve(username))
                {
                    calendars.Add(m_calendars.Retrieve(calUser.CalendarID));
                }

                return calendars;
            }
            return null;
        }

        // Get: Get a calendar belonging to a user
        [HttpGet("users/{username}/{password}/calendars/{calendarid}")]
        public Calendar CalendarGet(string username, string password, int calendarID)
        {
            if (UserLogin(username, password))
            {
                Calendar calendar = null;

                calendar = CalendarGetAll(username, password).ToList().Find(x => x.ID == calendarID);

                return calendar;
            }
            return null;
        }


        // Update: update the title of a calendar
        [HttpPut("users/{username}/{password}/calendars")]
        public IActionResult CalendarUpdate(string username, string password, [FromBody] Calendar calendar)
        {
            if (UserLogin(username, password))
            {
                if(m_calendarUsers.Retrieve(username, calendar.ID) != null && m_calendarUsers.Retrieve(username, calendar.ID).PrivilegeKey == "OWNER" || m_calendarUsers.Retrieve(username, calendar.ID).PrivilegeKey == "WRITE")
                {
                    m_calendars.Change(calendar);

                    return new NoContentResult();
                }
            }
            return new BadRequestResult();
        }

        // Delete: delete a calendar
        [HttpDelete("users/{username}/{password}/calendars/{calendarid}")]
        public IActionResult CalendarDelete(string username, string password, int calendarID)
        {
            if (UserLogin(username, password))
            {
                if (m_calendarUsers.Retrieve(username, calendarID) != null && m_calendarUsers.Retrieve(username, calendarID).PrivilegeKey == "OWNER")
                {
                    m_calendarUsers.Delete(calendarID);
                    m_events.Delete(calendarID);
                    m_calendars.Delete(calendarID);

                    return new NoContentResult();
                }
            }
            return new BadRequestResult();
        }

        // Create: create a calendar
        [HttpPost("users/{username}/{password}/calendars")]
        public bool CalendarCreate(string username, string password, [FromBody] Calendar calendar)
        {
            if (UserLogin(username, password))
            {
                m_calendars.Create(calendar);
                m_calendarUsers.Create(username, calendar.ID, "OWNER");
                return true;
            }
            return false;
        }

        // CALENDAR USERS //
        //UsersGet : gets all the calendars users and their privileges
        [HttpGet("users/{username}/{password}/calendars/{calendarid}/users")]
        public ICollection<CalendarUser> CalendarUsersGet(string username, string password, int calendarID)
        {
            if (UserLogin(username, password))
            {
                return m_calendarUsers.Retrieve(calendarID);
            }
            return null;
        }

        //UsersAdd : adds a user to the calendar
        [HttpPost("users/{username}/{password}/calendars/{calendarid}/users")]
        public IActionResult CalendarUsersAdd(string username, string password, int calendarID, [FromBody] CalendarUser caluse)
        {
            if (UserLogin(username, password))
            {
                if (m_calendarUsers.Retrieve(username, calendarID) != null && m_calendarUsers.Retrieve(username, calendarID).PrivilegeKey == "OWNER")
                {
                    if (m_calendarUsers.Create(caluse))
                    {
                        return new NoContentResult();
                    }
                }
            }
            return new BadRequestResult();
        }

        //UserChange : change the privilege right of a user
        [HttpPut("users/{username}/{password}/calendars/{calendarid}/users")]
        public IActionResult CalendarUsersChange(string username, string password, int calendarID, [FromBody] CalendarUser caluse)
        {
            if (UserLogin(username, password))
            {
                if (m_calendarUsers.Retrieve(username, calendarID) != null && m_calendarUsers.Retrieve(username, calendarID).PrivilegeKey == "OWNER")
                {
                    if (m_calendarUsers.Change(caluse))
                    {
                        return new NoContentResult();
                    }
                }
            }
            return new BadRequestResult();
        }

        //UserDelete : remove a user from the calendar
        [HttpDelete("users/{username}/{password}/calendars/{calendarid}/users")]
        public IActionResult CalendarUsersRemove(string username, string password, int calendarID, [FromBody] CalendarUser caluse)
        {
            if (UserLogin(username, password))
            {
                if (m_calendarUsers.Retrieve(username, calendarID) != null && m_calendarUsers.Retrieve(username, calendarID).PrivilegeKey == "OWNER")
                {
                    if (m_calendarUsers.Delete(caluse))
                    {
                        return new NoContentResult();
                    }
                }
            }
            return new BadRequestResult();
        }

        // EVENTS //
        //EventsGet : gets all events in a calendar
        [HttpGet("users/{username}/{password}/calendars/{calendarid}/events")]
        public ICollection<CalendarEvent> EventsGet(string username, string password, int calendarID)
        {
            if (UserLogin(username, password))
            {
                return m_events.Retrieve(calendarID);
            }
            return null;
        }

        //EventGet : get a specific event in a calendar
        [HttpGet("users/{username}/{password}/calendars/{calendarid}/events/{eventid}")]
        public CalendarEvent EventGet(string username, string password, int calendarID, int eventID)
        {
            if (UserLogin(username, password))
            {
                return m_events.Retrieve(calendarID).FirstOrDefault(x => x.ID == eventID);
            }
            return null;
        }

        //EventsCreate : creates a new event in a calendar
        [HttpPost("users/{username}/{password}/calendars/{calendarid}/events")]
        public IActionResult EventCreate(string username, string password, int calendarID, [FromBody] CalendarEvent newEvent)
        {
            if (UserLogin(username, password))
            {
                if (m_calendarUsers.Retrieve(username, calendarID) != null && (m_calendarUsers.Retrieve(username, calendarID).PrivilegeKey == "OWNER" || m_calendarUsers.Retrieve(username, calendarID).PrivilegeKey == "WRITE"))
                {
                    if(m_events.Create(newEvent))
                    {
                        return new NoContentResult();
                    }
                }
            }
            return new BadRequestResult();
        }

        //EventUpdate : change information about an event in the calendar
        [HttpPut("users/{username}/{password}/calendars/{calendarid}/events")]
        public IActionResult EventChange(string username, string password, int calendarID, [FromBody] CalendarEvent newEvent)
        {
            if (UserLogin(username, password))
            {
                if (m_calendarUsers.Retrieve(username, calendarID) != null && (m_calendarUsers.Retrieve(username, calendarID).PrivilegeKey == "OWNER" || m_calendarUsers.Retrieve(username, calendarID).PrivilegeKey == "WRITE"))
                {
                    m_events.Change(newEvent);

                    return new NoContentResult();
                }
            }
            return new BadRequestResult();
        }

        //EventDelete : delete an event in a calendar
        [HttpDelete("users/{username}/{password}/calendars/{calendarid}/events/{eventID}")]
        public IActionResult EventDelete(string username, string password, int calendarID, int eventID)
        {
            if (UserLogin(username, password))
            {
                if (m_calendarUsers.Retrieve(username, calendarID) != null && (m_calendarUsers.Retrieve(username, calendarID).PrivilegeKey == "OWNER" || m_calendarUsers.Retrieve(username, calendarID).PrivilegeKey == "WRITE"))
                {
                    m_events.Delete(calendarID, eventID);

                    return new NoContentResult();
                }
            }
            return new BadRequestResult();
        }

    }
}
