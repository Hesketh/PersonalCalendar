using System;
using System.Windows.Forms;

using DesktopApplication.Models;
using DesktopApplication.Context;

namespace DesktopApplication.Forms
{
    public partial class frmCalendarCreate : Form
    {
        public frmCalendarCreate()
        {
            InitializeComponent();
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            CalendarContext calendarContext = new CalendarContext();

            Calendar newCalendar = new Calendar();
            newCalendar.Name = txtCalendarName.Text.Trim();

            if(await calendarContext.CreateCalendar(newCalendar))
            {
                MessageBox.Show("Calendar Created!");
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("There was a problem creating the calendar!\n\nPlease ensure you have entered something!");
            }
        }
    }
}
