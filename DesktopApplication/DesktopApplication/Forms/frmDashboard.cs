using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using DesktopApplication.Models;
using DesktopApplication.Context;

namespace DesktopApplication.Forms
{
    public partial class frmDashboard : Form
    {
        private List<Calendar> m_calendars;
        private CalendarContext m_calendarContext = new CalendarContext();

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void btnOpenCalendar_Click(object sender, EventArgs e)
        {
            this.Hide();

            //Open the calendar with blocking show dialog
            frmCalendar calendarForm = new frmCalendar(GetSelectedCalendar());
            calendarForm.FormClosed += (s, args) => this.Show();   //Show this form when the other is closed
            calendarForm.ShowDialog();

            //After done with this form refresh the calendar list in case a name was changed
            UpdateCalendarList();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            btnOpenCalendar.Enabled = false;
            btnChangePassword.Enabled = false;
            btnDeleteCalendar.Enabled = false;
            cmbCalendarSelect.Enabled = false;

            UpdateCalendarList();
        }

        private async void UpdateCalendarList()
        {
            m_calendars = (await m_calendarContext.GetCalendars()).ToList();

            cmbCalendarSelect.Items.Clear();
            foreach (Calendar cal in m_calendars)
            {
                cmbCalendarSelect.Items.Add(cal.Name);
            }

            if (cmbCalendarSelect.Items.Count > 0)
            {
                cmbCalendarSelect.SelectedIndex = 0;

                cmbCalendarSelect.Enabled = true;
                btnOpenCalendar.Enabled = true;
                btnDeleteCalendar.Enabled = true;
            }
            else
            {
                cmbCalendarSelect.Enabled = false;
                btnOpenCalendar.Enabled = false;
                btnDeleteCalendar.Enabled = false;
            }
        }

        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            UserContext userFunctions = new UserContext();

            string password = txtPassword.Text.Trim();

            if (await userFunctions.Change(password))
            {
                MessageBox.Show("Your password has been updated!");
            }
            else
            {
                MessageBox.Show("There was a problem changing your password!");
            }
        }

        private async void btnDeleteCalendar_Click(object sender, EventArgs e)
        {
            if(await m_calendarContext.DeleteCalendar(GetSelectedCalendar()))
            {
                MessageBox.Show("The Calendar has been deleted");

                UpdateCalendarList();
            }
            else
            {
                MessageBox.Show("There was a problem deleting the calendar");
            }
        }

        private Calendar GetSelectedCalendar()
        {
            if(cmbCalendarSelect.SelectedIndex >= 0)
            {
                return m_calendars[cmbCalendarSelect.SelectedIndex];
            }
            return null;
        }

        private void btnCreateCalendar_Click(object sender, EventArgs e)
        {
            frmCalendarCreate creationForm = new frmCalendarCreate();

            if(creationForm.ShowDialog() == DialogResult.OK)
            {
                UpdateCalendarList();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if(txtPassword.Text.Length > 0)
            {
                btnChangePassword.Enabled = true;
            }
            else
            {
                btnChangePassword.Enabled = false;
            }
        }
    }
}
