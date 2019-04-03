using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DesktopApplication.Models;
using DesktopApplication.Context;

namespace DesktopApplication.Forms
{
    public partial class frmCalendar : Form
    {
        private Calendar m_calendar;
        private List<CalendarEvent> m_events;

        DateTime m_start;
        DateTime m_end;

        public Calendar ActiveCalendar
        {
            set
            {
                m_calendar = value;
            }
        }

        public frmCalendar(Calendar calendar)
        {
            m_calendar = calendar;
            m_events = new List<CalendarEvent>();

            InitializeComponent();
        }

        private void frmCalendar_Load(object sender, EventArgs e)
        {
            RetrieveEvents();

            txtCalendarName.Text = m_calendar.Name;
            this.Text = m_calendar.Name;

            m_start = DateTime.Now;
            m_end = m_start;

            btnViewDay_Click(sender, e);
        }

        private async void txtCalendarName_TextChanged(object sender, EventArgs e)
        {
            CalendarContext calendarContext = new CalendarContext();

            Calendar updatedCalendar = new Calendar();

            updatedCalendar.ID = m_calendar.ID;
            updatedCalendar.Name = txtCalendarName.Text.Trim();

            if (await calendarContext.UpdateCalendar(updatedCalendar))
            {
                this.Text = m_calendar.Name;
            }
            else
            {
                MessageBox.Show("There was a problem with changing the calendar's title!\n\nPlease ensure you have entered a new name!");
            }
        }

        private void btnViewDay_Click(object sender, EventArgs e)
        {
            btnViewDay.Enabled = false;
            btnViewWeek.Enabled = true;
            btnViewMonth.Enabled = true;

            m_start = new DateTime(m_start.Year, m_start.Month, m_start.Day, 0, 0, 0, 0);
            m_end = m_start.AddDays(1);
            m_end = m_end.AddMilliseconds(-1);

            DisplayEvents();
        }

        private void btnViewWeek_Click(object sender, EventArgs e)
        {
            btnViewDay.Enabled = true;
            btnViewWeek.Enabled = false;
            btnViewMonth.Enabled = true;

            m_start = new DateTime(m_start.Year, m_start.Month, m_start.Day, 0, 0, 0, 0);

            m_start = m_start.AddDays(-DayOfWeekConvert((int)m_start.DayOfWeek));

            m_end = m_start.AddDays(7);
            m_end = m_end.AddMilliseconds(-1);

            DisplayEvents();
        }

        private int DayOfWeekConvert(int dayOfWeek)
        {
            //We start the calendar on monday, it is stored as a sunday
            dayOfWeek -= 1;

            if (dayOfWeek < 0)
            {
                dayOfWeek = 6;
            }

            return dayOfWeek;
        }

        private void btnViewMonth_Click(object sender, EventArgs e)
        {
            btnViewDay.Enabled = true;
            btnViewWeek.Enabled = true;
            btnViewMonth.Enabled = false;

            m_start = new DateTime(m_start.Year, m_start.Month, 1, 0, 0, 0, 0);
            m_end = m_start.AddMonths(1);
            m_end = m_end.AddMilliseconds(-1);

            DisplayEvents();
        }

        private void DisplayEvents()
        {
            //Update the label which shows the range of events
            if (!btnViewDay.Enabled)
            {
                lblStartEndSelection.Text = m_start.DayOfWeek.ToString() + " " + m_start.ToShortDateString();
            }
            else if (!btnViewWeek.Enabled)
            {
                lblStartEndSelection.Text = m_start.ToShortDateString() + " - " + m_end.ToShortDateString();
            }
            else if(!btnViewMonth.Enabled)
            {
                lblStartEndSelection.Text = m_start.ToShortDateString().Substring(3,7);
            }

            //Clear currently displayed events and groups
            lstEvents.Items.Clear();
            lstEvents.Groups.Clear();

            //We have a different view for the calendars so a different criteria needs to be met
            if (!btnViewDay.Enabled)
            {
                foreach (CalendarEvent ev in m_events.Where(x => x.Start.Day == m_start.Day && x.Start.Month == m_start.Month && x.Start.Year == m_start.Year))
                {
                    ListViewItem item = new ListViewItem(ev.ID.ToString());
                    item.SubItems.Add(ev.Title);
                    item.SubItems.Add(ev.Description);
                    item.SubItems.Add(ev.Start.ToShortTimeString());
                    item.SubItems.Add(ev.End.ToShortTimeString());

                    lstEvents.Items.Add(item);
                }
            }
            else if (!btnViewWeek.Enabled)
            {
                lstEvents.Groups.Add(new ListViewGroup("Monday"));
                lstEvents.Groups.Add(new ListViewGroup("Tuesday"));
                lstEvents.Groups.Add(new ListViewGroup("Wednesday"));
                lstEvents.Groups.Add(new ListViewGroup("Thursday"));
                lstEvents.Groups.Add(new ListViewGroup("Friday"));
                lstEvents.Groups.Add(new ListViewGroup("Saturday"));
                lstEvents.Groups.Add(new ListViewGroup("Sunday"));

                foreach (CalendarEvent ev in m_events.Where(x => x.Start >= m_start && x.Start <= m_end))
                {
                    ListViewItem item = new ListViewItem(ev.ID.ToString());
                    item.SubItems.Add(ev.Title);
                    item.SubItems.Add(ev.Description);
                    item.SubItems.Add(ev.Start.ToShortTimeString());
                    item.SubItems.Add(ev.End.ToShortTimeString());

                    lstEvents.Groups[DayOfWeekConvert((int)ev.Start.DayOfWeek)].Items.Add(item);

                    lstEvents.Items.Add(item);
                }
            }
            else if (!btnViewMonth.Enabled)
            {
                for (int i = 0; i < DateTime.DaysInMonth(m_start.Year, m_start.Month); i++)
                {
                    lstEvents.Groups.Add(new ListViewGroup(m_start.AddDays(i).ToShortDateString()));
                }

                foreach (CalendarEvent ev in m_events.Where(x => x.Start.Month == m_start.Month && x.Start.Year == m_start.Year))
                {
                    ListViewItem item = new ListViewItem(ev.ID.ToString());
                    item.SubItems.Add(ev.Title);
                    item.SubItems.Add(ev.Description);
                    item.SubItems.Add(ev.Start.ToShortTimeString());
                    item.SubItems.Add(ev.End.ToShortTimeString());

                    lstEvents.Groups[ev.Start.Day-1].Items.Add(item);

                    lstEvents.Items.Add(item);
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(!btnViewDay.Enabled)
            {
                m_start = m_start.AddDays(1);
                m_end = m_end.AddDays(1);
            }
            else if(!btnViewWeek.Enabled)
            {
                m_start = m_start.AddDays(7);
                m_end = m_end.AddDays(7);
            }
            else if(!btnViewMonth.Enabled)
            {
                m_start = m_start.AddMonths(1);
                m_end = m_end.AddMonths(1);
            }

            DisplayEvents();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (!btnViewDay.Enabled)
            {
                m_start = m_start.AddDays(-1);
                m_end = m_end.AddDays(-1);
            }
            else if (!btnViewWeek.Enabled)
            {
                m_start = m_start.AddDays(-7);
                m_end = m_end.AddDays(-7);
            }
            else if (!btnViewMonth.Enabled)
            {
                m_start = m_start.AddMonths(-1);
                m_end = m_end.AddMonths(-1);
            }

            DisplayEvents();
        }

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            frmEvent createForm = new frmEvent();

            createForm.FormClosed += (s, args) => this.Show();   //Show this form when the other is closed
            createForm.StartTime = m_start;
            createForm.CalendarID = m_calendar.ID;

            if (createForm.ShowDialog() == DialogResult.OK)
            {
                RetrieveEvents();
                DisplayEvents();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstEvents.SelectedIndices.Count > 0)
            {
                CalendarEvent ev = (m_events.FirstOrDefault(x => x.ID == int.Parse(lstEvents.SelectedItems[0].Text)));

                if (ev != null)
                {
                    frmEvent createForm = new frmEvent();

                    createForm.FormClosed += (s, args) => this.Show();   //Show this form when the other is closed
                    createForm.ActiveEvent = ev;

                    if (createForm.ShowDialog() == DialogResult.OK)
                    {
                        RetrieveEvents();
                        DisplayEvents();
                    }
                }
            }
        }

        private async void RetrieveEvents()
        {
            EventContext eventContext = new EventContext();
            m_events = (await eventContext.GetEvents(m_calendar)).ToList();
        }

        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstEvents.SelectedIndices.Count > 0)
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstEvents.SelectedIndices.Count > 0)
            {
                CalendarEvent ev = (m_events.FirstOrDefault(x => x.ID == int.Parse(lstEvents.SelectedItems[0].Text)));

                if (ev != null)
                {
                    EventContext eventContext = new EventContext();

                    if (await eventContext.DeleteEvent(ev))
                    {
                        MessageBox.Show("The event has been deleted!");

                        RetrieveEvents();
                        DisplayEvents();
                    }
                    else
                    {
                        MessageBox.Show("There was a problem deleting the event!");
                    }
                }
            }
        }
    }
}
