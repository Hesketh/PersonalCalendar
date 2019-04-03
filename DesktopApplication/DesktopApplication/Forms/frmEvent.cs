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
    public enum TypeOfTask
    {
        CREATE,
        UPDATE
    }

    public partial class frmEvent : Form
    {
        private CalendarEvent m_event = new CalendarEvent();
        private TypeOfTask m_taskType = TypeOfTask.CREATE;

        public CalendarEvent ActiveEvent
        {
            set
            {
                m_event = value;

                btnCreate.Text = "Update";
                m_taskType = TypeOfTask.UPDATE;

                txtDescription.Text = m_event.Description.Trim();
                txtTitle.Text = m_event.Title.Trim();
                dtpStart.Value = m_event.Start;
                dtpStartTime.Value = m_event.Start;
                dtpEnd.Value = m_event.End;
                dtpEndTime.Value = m_event.End;
            }
        }

        public DateTime StartTime
        {
            set
            {
                dtpStart.Value = value;
                dtpStartTime.Value = value;

                dtpEnd.Value = value.AddHours(1);
                dtpEndTime.Value = value.AddHours(1);
            }
        }

        public int CalendarID
        {
            set
            {
                m_event.CalendarID = value;
            }
        }

        public frmEvent()
        {
            InitializeComponent();
        }

        private void frmEvent_Load(object sender, EventArgs e)
        {
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            if(txtTitle.Text.Length <= 0)
            {
                MessageBox.Show("Please enter a title!");
                return;
            }

            EventContext eventContext = new EventContext();

            if(m_event.CalendarID > 0)
            {
                m_event.Description = txtDescription.Text.Trim();
                m_event.Title = txtTitle.Text.Trim();
                m_event.Start = dtpStart.Value.Date + dtpStartTime.Value.TimeOfDay;
                m_event.End = dtpEnd.Value.Date + dtpEndTime.Value.TimeOfDay;

                if (m_taskType == TypeOfTask.CREATE)
                {
                    if (await eventContext.CreateEvent(m_event))
                    {
                        MessageBox.Show("Event was created!");

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("There was a problem creating the event");
                    }
                }
                else if (m_taskType == TypeOfTask.UPDATE)
                {
                    if (await eventContext.UpdateEvent(m_event))
                    {
                        MessageBox.Show("Event was updated!");

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("There was a problem updating the event");
                    }
                }

            }
            else
            {
                MessageBox.Show("Reference to calendar was not set!");
            }
        }
    }
}
