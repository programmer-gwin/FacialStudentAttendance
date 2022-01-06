namespace FacialStudentAttendance
{
    partial class FacialAttendance
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacialAttendance));
            this.Label20 = new System.Windows.Forms.Label();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.startAttendant = new System.Windows.Forms.Button();
            this.dgvAttendantList = new System.Windows.Forms.DataGridView();
            this.studentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clockInTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalAllowed = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalDenied = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendantList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            this.SuspendLayout();
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label20.Location = new System.Drawing.Point(99, 127);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(81, 12);
            this.Label20.TabIndex = 106;
            this.Label20.Text = "Select Course";
            // 
            // cboCourse
            // 
            this.cboCourse.BackColor = System.Drawing.SystemColors.Info;
            this.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourse.FormattingEnabled = true;
            this.cboCourse.Location = new System.Drawing.Point(186, 123);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(156, 21);
            this.cboCourse.TabIndex = 105;
            this.cboCourse.SelectedIndexChanged += new System.EventHandler(this.cboCourse_SelectedIndexChanged);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Panel1.Controls.Add(this.PictureBox2);
            this.Panel1.Controls.Add(this.Label5);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(805, 108);
            this.Panel1.TabIndex = 127;
            // 
            // PictureBox2
            // 
            this.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.PictureBox2.Image = global::FacialStudentAttendance.Properties.Resources.UNILORIN;
            this.PictureBox2.Location = new System.Drawing.Point(0, 0);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(132, 108);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox2.TabIndex = 29;
            this.PictureBox2.TabStop = false;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.White;
            this.Label5.Location = new System.Drawing.Point(235, 78);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(359, 30);
            this.Label5.TabIndex = 28;
            this.Label5.Text = "MARK STUDENTS ATTENDANCE";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(181, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(486, 54);
            this.Label1.TabIndex = 27;
            this.Label1.Text = "FACIAL RECOGNITION BASED \r\nSTUDENT ATTENDANCE MANAGEMENT SYSTEM\r\n";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startAttendant
            // 
            this.startAttendant.BackColor = System.Drawing.SystemColors.Info;
            this.startAttendant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startAttendant.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.startAttendant.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startAttendant.Image = ((System.Drawing.Image)(resources.GetObject("startAttendant.Image")));
            this.startAttendant.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startAttendant.Location = new System.Drawing.Point(561, 118);
            this.startAttendant.Name = "startAttendant";
            this.startAttendant.Size = new System.Drawing.Size(149, 29);
            this.startAttendant.TabIndex = 128;
            this.startAttendant.Text = "Start Attendance";
            this.startAttendant.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.startAttendant.UseVisualStyleBackColor = false;
            this.startAttendant.Click += new System.EventHandler(this.startAttendant_Click);
            // 
            // dgvAttendantList
            // 
            this.dgvAttendantList.AllowUserToAddRows = false;
            this.dgvAttendantList.AllowUserToDeleteRows = false;
            this.dgvAttendantList.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvAttendantList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendantList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentID,
            this.courseCode,
            this.clockInTime,
            this.startTime});
            this.dgvAttendantList.Location = new System.Drawing.Point(12, 154);
            this.dgvAttendantList.Name = "dgvAttendantList";
            this.dgvAttendantList.Size = new System.Drawing.Size(443, 306);
            this.dgvAttendantList.TabIndex = 129;
            // 
            // studentID
            // 
            this.studentID.DataPropertyName = "studentID";
            this.studentID.HeaderText = "Student ID";
            this.studentID.Name = "studentID";
            // 
            // courseCode
            // 
            this.courseCode.DataPropertyName = "courseCode";
            this.courseCode.HeaderText = "Course Code";
            this.courseCode.Name = "courseCode";
            // 
            // clockInTime
            // 
            this.clockInTime.DataPropertyName = "clockInTime";
            this.clockInTime.HeaderText = "Clock In Time";
            this.clockInTime.Name = "clockInTime";
            // 
            // startTime
            // 
            this.startTime.DataPropertyName = "startTime";
            this.startTime.HeaderText = "Lecture Start Time";
            this.startTime.Name = "startTime";
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(473, 154);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(320, 257);
            this.imageBoxFrameGrabber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxFrameGrabber.TabIndex = 130;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(474, 414);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 132;
            this.label2.Text = "Total Allowed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(474, 439);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 19);
            this.label4.TabIndex = 131;
            this.label4.Text = "Nobody";
            // 
            // lblTotalAllowed
            // 
            this.lblTotalAllowed.AutoSize = true;
            this.lblTotalAllowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAllowed.ForeColor = System.Drawing.Color.Green;
            this.lblTotalAllowed.Location = new System.Drawing.Point(571, 414);
            this.lblTotalAllowed.Name = "lblTotalAllowed";
            this.lblTotalAllowed.Size = new System.Drawing.Size(16, 16);
            this.lblTotalAllowed.TabIndex = 133;
            this.lblTotalAllowed.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(647, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 132;
            this.label3.Text = "Total Denied:";
            // 
            // lblTotalDenied
            // 
            this.lblTotalDenied.AutoSize = true;
            this.lblTotalDenied.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDenied.ForeColor = System.Drawing.Color.Red;
            this.lblTotalDenied.Location = new System.Drawing.Point(742, 414);
            this.lblTotalDenied.Name = "lblTotalDenied";
            this.lblTotalDenied.Size = new System.Drawing.Size(16, 16);
            this.lblTotalDenied.TabIndex = 133;
            this.lblTotalDenied.Text = "0";
            // 
            // FacialAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 466);
            this.Controls.Add(this.lblTotalDenied);
            this.Controls.Add(this.lblTotalAllowed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.imageBoxFrameGrabber);
            this.Controls.Add(this.dgvAttendantList);
            this.Controls.Add(this.startAttendant);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Label20);
            this.Controls.Add(this.cboCourse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FacialAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facial Attendance";
            this.Load += new System.EventHandler(this.FacialAttendance_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendantList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.ComboBox cboCourse;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.Button startAttendant;
        internal System.Windows.Forms.DataGridView dgvAttendantList;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalAllowed;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clockInTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalDenied;
    }
}