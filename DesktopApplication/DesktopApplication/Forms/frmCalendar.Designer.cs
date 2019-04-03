namespace DesktopApplication.Forms
{
    partial class frmCalendar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCalendarName = new System.Windows.Forms.TextBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblStartEndSelection = new System.Windows.Forms.Label();
            this.btnViewDay = new System.Windows.Forms.Button();
            this.btnViewWeek = new System.Windows.Forms.Button();
            this.btnViewMonth = new System.Windows.Forms.Button();
            this.lstEvents = new System.Windows.Forms.ListView();
            this.btnCreateEvent = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.clmnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // txtCalendarName
            // 
            this.txtCalendarName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCalendarName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCalendarName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalendarName.Location = new System.Drawing.Point(14, 5);
            this.txtCalendarName.Margin = new System.Windows.Forms.Padding(5);
            this.txtCalendarName.MaxLength = 32;
            this.txtCalendarName.Multiline = true;
            this.txtCalendarName.Name = "txtCalendarName";
            this.txtCalendarName.ShortcutsEnabled = false;
            this.txtCalendarName.Size = new System.Drawing.Size(596, 33);
            this.txtCalendarName.TabIndex = 999;
            this.txtCalendarName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCalendarName.TextChanged += new System.EventHandler(this.txtCalendarName_TextChanged);
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.Location = new System.Drawing.Point(14, 46);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(28, 28);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(48, 46);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(28, 28);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblStartEndSelection
            // 
            this.lblStartEndSelection.AutoSize = true;
            this.lblStartEndSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartEndSelection.Location = new System.Drawing.Point(82, 50);
            this.lblStartEndSelection.Name = "lblStartEndSelection";
            this.lblStartEndSelection.Size = new System.Drawing.Size(80, 20);
            this.lblStartEndSelection.TabIndex = 1004;
            this.lblStartEndSelection.Text = "April 2017";
            // 
            // btnViewDay
            // 
            this.btnViewDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDay.Location = new System.Drawing.Point(346, 46);
            this.btnViewDay.Name = "btnViewDay";
            this.btnViewDay.Size = new System.Drawing.Size(84, 28);
            this.btnViewDay.TabIndex = 1005;
            this.btnViewDay.Text = "Day";
            this.btnViewDay.UseVisualStyleBackColor = true;
            this.btnViewDay.Click += new System.EventHandler(this.btnViewDay_Click);
            // 
            // btnViewWeek
            // 
            this.btnViewWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewWeek.Location = new System.Drawing.Point(436, 46);
            this.btnViewWeek.Name = "btnViewWeek";
            this.btnViewWeek.Size = new System.Drawing.Size(84, 28);
            this.btnViewWeek.TabIndex = 1006;
            this.btnViewWeek.Text = "Week";
            this.btnViewWeek.UseVisualStyleBackColor = true;
            this.btnViewWeek.Click += new System.EventHandler(this.btnViewWeek_Click);
            // 
            // btnViewMonth
            // 
            this.btnViewMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewMonth.Location = new System.Drawing.Point(526, 46);
            this.btnViewMonth.Name = "btnViewMonth";
            this.btnViewMonth.Size = new System.Drawing.Size(84, 28);
            this.btnViewMonth.TabIndex = 1007;
            this.btnViewMonth.Text = "Month";
            this.btnViewMonth.UseVisualStyleBackColor = true;
            this.btnViewMonth.Click += new System.EventHandler(this.btnViewMonth_Click);
            // 
            // lstEvents
            // 
            this.lstEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnID,
            this.clmnTitle,
            this.clmnDescription,
            this.clmnStart,
            this.clmnEnd});
            this.lstEvents.FullRowSelect = true;
            this.lstEvents.GridLines = true;
            this.lstEvents.Location = new System.Drawing.Point(12, 80);
            this.lstEvents.MultiSelect = false;
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(596, 315);
            this.lstEvents.TabIndex = 1008;
            this.lstEvents.UseCompatibleStateImageBehavior = false;
            this.lstEvents.View = System.Windows.Forms.View.Details;
            this.lstEvents.SelectedIndexChanged += new System.EventHandler(this.lstEvents_SelectedIndexChanged);
            // 
            // btnCreateEvent
            // 
            this.btnCreateEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateEvent.Location = new System.Drawing.Point(12, 401);
            this.btnCreateEvent.Name = "btnCreateEvent";
            this.btnCreateEvent.Size = new System.Drawing.Size(115, 28);
            this.btnCreateEvent.TabIndex = 1009;
            this.btnCreateEvent.Text = "Create";
            this.btnCreateEvent.UseVisualStyleBackColor = true;
            this.btnCreateEvent.Click += new System.EventHandler(this.btnCreateEvent_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(458, 401);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(150, 28);
            this.btnUpdate.TabIndex = 1010;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(387, 401);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 28);
            this.btnDelete.TabIndex = 1011;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // clmnTitle
            // 
            this.clmnTitle.DisplayIndex = 0;
            this.clmnTitle.Text = "Title";
            this.clmnTitle.Width = 150;
            // 
            // clmnDescription
            // 
            this.clmnDescription.DisplayIndex = 1;
            this.clmnDescription.Text = "Description";
            this.clmnDescription.Width = 292;
            // 
            // clmnStart
            // 
            this.clmnStart.DisplayIndex = 2;
            this.clmnStart.Text = "Start";
            this.clmnStart.Width = 75;
            // 
            // clmnEnd
            // 
            this.clmnEnd.DisplayIndex = 3;
            this.clmnEnd.Text = "End";
            this.clmnEnd.Width = 75;
            // 
            // clmnID
            // 
            this.clmnID.DisplayIndex = 4;
            this.clmnID.Text = "ID";
            this.clmnID.Width = 0;
            // 
            // frmCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCreateEvent);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.btnViewMonth);
            this.Controls.Add(this.btnViewWeek);
            this.Controls.Add(this.btnViewDay);
            this.Controls.Add(this.lblStartEndSelection);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.txtCalendarName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCalendar";
            this.Text = "Calendar";
            this.Load += new System.EventHandler(this.frmCalendar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCalendarName;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblStartEndSelection;
        private System.Windows.Forms.Button btnViewDay;
        private System.Windows.Forms.Button btnViewWeek;
        private System.Windows.Forms.Button btnViewMonth;
        private System.Windows.Forms.ListView lstEvents;
        private System.Windows.Forms.Button btnCreateEvent;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ColumnHeader clmnTitle;
        private System.Windows.Forms.ColumnHeader clmnDescription;
        private System.Windows.Forms.ColumnHeader clmnStart;
        private System.Windows.Forms.ColumnHeader clmnEnd;
        private System.Windows.Forms.ColumnHeader clmnID;
    }
}