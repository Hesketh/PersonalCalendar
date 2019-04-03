namespace DesktopApplication.Forms
{
    partial class frmDashboard
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
            this.btnOpenCalendar = new System.Windows.Forms.Button();
            this.btnDeleteCalendar = new System.Windows.Forms.Button();
            this.cmbCalendarSelect = new System.Windows.Forms.ComboBox();
            this.btnCreateCalendar = new System.Windows.Forms.Button();
            this.grpCalendar = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.grpCalendar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenCalendar
            // 
            this.btnOpenCalendar.Location = new System.Drawing.Point(6, 46);
            this.btnOpenCalendar.Name = "btnOpenCalendar";
            this.btnOpenCalendar.Size = new System.Drawing.Size(254, 46);
            this.btnOpenCalendar.TabIndex = 0;
            this.btnOpenCalendar.Text = "Open";
            this.btnOpenCalendar.UseVisualStyleBackColor = true;
            this.btnOpenCalendar.Click += new System.EventHandler(this.btnOpenCalendar_Click);
            // 
            // btnDeleteCalendar
            // 
            this.btnDeleteCalendar.Location = new System.Drawing.Point(6, 98);
            this.btnDeleteCalendar.Name = "btnDeleteCalendar";
            this.btnDeleteCalendar.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCalendar.TabIndex = 1;
            this.btnDeleteCalendar.Text = "Delete";
            this.btnDeleteCalendar.UseVisualStyleBackColor = true;
            this.btnDeleteCalendar.Click += new System.EventHandler(this.btnDeleteCalendar_Click);
            // 
            // cmbCalendarSelect
            // 
            this.cmbCalendarSelect.FormattingEnabled = true;
            this.cmbCalendarSelect.Location = new System.Drawing.Point(6, 19);
            this.cmbCalendarSelect.Name = "cmbCalendarSelect";
            this.cmbCalendarSelect.Size = new System.Drawing.Size(254, 21);
            this.cmbCalendarSelect.TabIndex = 2;
            // 
            // btnCreateCalendar
            // 
            this.btnCreateCalendar.Location = new System.Drawing.Point(87, 98);
            this.btnCreateCalendar.Name = "btnCreateCalendar";
            this.btnCreateCalendar.Size = new System.Drawing.Size(173, 23);
            this.btnCreateCalendar.TabIndex = 3;
            this.btnCreateCalendar.Text = "Create New";
            this.btnCreateCalendar.UseVisualStyleBackColor = true;
            this.btnCreateCalendar.Click += new System.EventHandler(this.btnCreateCalendar_Click);
            // 
            // grpCalendar
            // 
            this.grpCalendar.Controls.Add(this.cmbCalendarSelect);
            this.grpCalendar.Controls.Add(this.btnOpenCalendar);
            this.grpCalendar.Controls.Add(this.btnCreateCalendar);
            this.grpCalendar.Controls.Add(this.btnDeleteCalendar);
            this.grpCalendar.Location = new System.Drawing.Point(12, 12);
            this.grpCalendar.Name = "grpCalendar";
            this.grpCalendar.Size = new System.Drawing.Size(265, 139);
            this.grpCalendar.TabIndex = 4;
            this.grpCalendar.TabStop = false;
            this.grpCalendar.Text = "Calendars";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChangePassword);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Location = new System.Drawing.Point(12, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 80);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Password";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(6, 45);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(254, 23);
            this.btnChangePassword.TabIndex = 1;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(6, 19);
            this.txtPassword.MaxLength = 32;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(254, 20);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpCalendar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.grpCalendar.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenCalendar;
        private System.Windows.Forms.Button btnDeleteCalendar;
        private System.Windows.Forms.ComboBox cmbCalendarSelect;
        private System.Windows.Forms.Button btnCreateCalendar;
        private System.Windows.Forms.GroupBox grpCalendar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.TextBox txtPassword;
    }
}