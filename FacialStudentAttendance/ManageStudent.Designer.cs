namespace FacialStudentAttendance
{
    partial class ManageStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageStudent));
            this.txtStudentIDFilter = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCourseFilter = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOthername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImgUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnexit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.txtHomeAddr = new System.Windows.Forms.TextBox();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbogen = new System.Windows.Forms.ComboBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.Label27 = new System.Windows.Forms.Label();
            this.txtOthername = new System.Windows.Forms.TextBox();
            this.txtsurname = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.Label26 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.GroupBox7.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStudentIDFilter
            // 
            this.txtStudentIDFilter.BackColor = System.Drawing.SystemColors.Info;
            this.txtStudentIDFilter.Location = new System.Drawing.Point(210, 20);
            this.txtStudentIDFilter.Multiline = true;
            this.txtStudentIDFilter.Name = "txtStudentIDFilter";
            this.txtStudentIDFilter.Size = new System.Drawing.Size(252, 22);
            this.txtStudentIDFilter.TabIndex = 126;
            this.txtStudentIDFilter.TextChanged += new System.EventHandler(this.txtStudentId_TextChanged);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(29, 21);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(175, 16);
            this.Label6.TabIndex = 125;
            this.Label6.Text = "Filter by Student I.D No :";
            // 
            // GroupBox7
            // 
            this.GroupBox7.BackColor = System.Drawing.SystemColors.Info;
            this.GroupBox7.Controls.Add(this.txtStudentIDFilter);
            this.GroupBox7.Controls.Add(this.label3);
            this.GroupBox7.Controls.Add(this.Label6);
            this.GroupBox7.Controls.Add(this.cboCourseFilter);
            this.GroupBox7.Location = new System.Drawing.Point(2, 235);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(951, 54);
            this.GroupBox7.TabIndex = 128;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "Search Student";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(514, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 125;
            this.label3.Text = "Filter by Course:";
            // 
            // cboCourseFilter
            // 
            this.cboCourseFilter.BackColor = System.Drawing.SystemColors.Info;
            this.cboCourseFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboCourseFilter.FormattingEnabled = true;
            this.cboCourseFilter.Location = new System.Drawing.Point(638, 20);
            this.cboCourseFilter.Name = "cboCourseFilter";
            this.cboCourseFilter.Size = new System.Drawing.Size(156, 21);
            this.cboCourseFilter.TabIndex = 103;
            this.cboCourseFilter.SelectedIndexChanged += new System.EventHandler(this.cboCourseFilter_SelectedIndexChanged);
            this.cboCourseFilter.TextChanged += new System.EventHandler(this.cboCourseFilter_SelectedIndexChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.White;
            this.Label5.Location = new System.Drawing.Point(387, 44);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(276, 30);
            this.Label5.TabIndex = 28;
            this.Label5.Text = "MANAGE MY STUDENTS";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(158, 6);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(789, 27);
            this.Label1.TabIndex = 27;
            this.Label1.Text = "FACIAL RECOGNITION BASED STUDENT ATTENDANCE MANAGEMENT SYSTEM\r\n";
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
            this.Panel1.Size = new System.Drawing.Size(958, 88);
            this.Panel1.TabIndex = 126;
            // 
            // PictureBox2
            // 
            this.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.PictureBox2.Image = global::FacialStudentAttendance.Properties.Resources.UNILORIN;
            this.PictureBox2.Location = new System.Drawing.Point(0, 0);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(132, 88);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox2.TabIndex = 29;
            this.PictureBox2.TabStop = false;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.button3);
            this.GroupBox1.Controls.Add(this.imageBoxFrameGrabber);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.GroupBox7);
            this.GroupBox1.Controls.Add(this.dgvStudents);
            this.GroupBox1.Controls.Add(this.btnexit);
            this.GroupBox1.Controls.Add(this.button2);
            this.GroupBox1.Controls.Add(this.GroupBox3);
            this.GroupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(3, 92);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(953, 619);
            this.GroupBox1.TabIndex = 129;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Students Information";
            this.GroupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(428, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 28);
            this.button3.TabIndex = 130;
            this.button3.Text = "Use Batch Upload";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.BackgroundImage = global::FacialStudentAttendance.Properties.Resources.download;
            this.imageBoxFrameGrabber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.InitialImage = global::FacialStudentAttendance.Properties.Resources.download;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(819, 46);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(128, 112);
            this.imageBoxFrameGrabber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxFrameGrabber.TabIndex = 129;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(954, 30);
            this.label2.TabIndex = 117;
            this.label2.Text = "ALL MY STUDENTS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colSurname,
            this.colOthername,
            this.colGender,
            this.colPhone,
            this.colAddr,
            this.colCourse,
            this.colEmail,
            this.colRegDate,
            this.colUserType,
            this.colImgUrl,
            this.colPassword});
            this.dgvStudents.Location = new System.Drawing.Point(2, 287);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.Size = new System.Drawing.Size(951, 332);
            this.dgvStudents.TabIndex = 116;
            this.dgvStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudents_CellContentClick);
            this.dgvStudents.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvStudents_KeyDown);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "Username";
            this.colID.HeaderText = "Student ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colSurname
            // 
            this.colSurname.DataPropertyName = "Surname";
            this.colSurname.HeaderText = "Surname";
            this.colSurname.Name = "colSurname";
            this.colSurname.ReadOnly = true;
            // 
            // colOthername
            // 
            this.colOthername.DataPropertyName = "Othername";
            this.colOthername.HeaderText = "Othername";
            this.colOthername.Name = "colOthername";
            this.colOthername.ReadOnly = true;
            // 
            // colGender
            // 
            this.colGender.DataPropertyName = "Gender";
            this.colGender.HeaderText = "Gender";
            this.colGender.Name = "colGender";
            this.colGender.ReadOnly = true;
            // 
            // colPhone
            // 
            this.colPhone.DataPropertyName = "PhoneNo";
            this.colPhone.HeaderText = "Phone NO";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            // 
            // colAddr
            // 
            this.colAddr.DataPropertyName = "Address";
            this.colAddr.HeaderText = "Address";
            this.colAddr.Name = "colAddr";
            this.colAddr.ReadOnly = true;
            // 
            // colCourse
            // 
            this.colCourse.DataPropertyName = "CourseCode";
            this.colCourse.HeaderText = "Course";
            this.colCourse.Name = "colCourse";
            this.colCourse.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "EmailAddr";
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colRegDate
            // 
            this.colRegDate.DataPropertyName = "RegDate";
            this.colRegDate.HeaderText = "Reg Date";
            this.colRegDate.Name = "colRegDate";
            this.colRegDate.ReadOnly = true;
            this.colRegDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRegDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colUserType
            // 
            this.colUserType.DataPropertyName = "UserType";
            this.colUserType.HeaderText = "User Type";
            this.colUserType.Name = "colUserType";
            this.colUserType.Visible = false;
            // 
            // colImgUrl
            // 
            this.colImgUrl.DataPropertyName = "ImgUrl";
            this.colImgUrl.HeaderText = "Image Url";
            this.colImgUrl.Name = "colImgUrl";
            this.colImgUrl.Visible = false;
            // 
            // colPassword
            // 
            this.colPassword.DataPropertyName = "Password";
            this.colPassword.HeaderText = "Password";
            this.colPassword.Name = "colPassword";
            this.colPassword.Visible = false;
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.SystemColors.Info;
            this.btnexit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnexit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(741, 12);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(71, 28);
            this.btnexit.TabIndex = 2;
            this.btnexit.Text = "&Close";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PapayaWhip;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(819, 162);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Start Camera";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button3_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.txtStudentId);
            this.GroupBox3.Controls.Add(this.Label20);
            this.GroupBox3.Controls.Add(this.btncancel);
            this.GroupBox3.Controls.Add(this.txtHomeAddr);
            this.GroupBox3.Controls.Add(this.cboCourse);
            this.GroupBox3.Controls.Add(this.button1);
            this.GroupBox3.Controls.Add(this.label7);
            this.GroupBox3.Controls.Add(this.cbogen);
            this.GroupBox3.Controls.Add(this.Label12);
            this.GroupBox3.Controls.Add(this.label8);
            this.GroupBox3.Controls.Add(this.txtemail);
            this.GroupBox3.Controls.Add(this.Label27);
            this.GroupBox3.Controls.Add(this.txtOthername);
            this.GroupBox3.Controls.Add(this.txtsurname);
            this.GroupBox3.Controls.Add(this.txtPhone);
            this.GroupBox3.Controls.Add(this.Label26);
            this.GroupBox3.Controls.Add(this.Label4);
            this.GroupBox3.Controls.Add(this.Label10);
            this.GroupBox3.Location = new System.Drawing.Point(6, 38);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(807, 161);
            this.GroupBox3.TabIndex = 115;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Add New Student";
            // 
            // txtStudentId
            // 
            this.txtStudentId.BackColor = System.Drawing.SystemColors.Info;
            this.txtStudentId.Location = new System.Drawing.Point(95, 26);
            this.txtStudentId.MaxLength = 100;
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(199, 21);
            this.txtStudentId.TabIndex = 135;
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label20.Location = new System.Drawing.Point(584, 30);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(44, 12);
            this.Label20.TabIndex = 104;
            this.Label20.Text = "Course";
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.SystemColors.Info;
            this.btncancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btncancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Image = ((System.Drawing.Image)(resources.GetObject("btncancel.Image")));
            this.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncancel.Location = new System.Drawing.Point(464, 126);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 28);
            this.btncancel.TabIndex = 1;
            this.btncancel.Text = "&Clear";
            this.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // txtHomeAddr
            // 
            this.txtHomeAddr.BackColor = System.Drawing.SystemColors.Info;
            this.txtHomeAddr.Location = new System.Drawing.Point(382, 92);
            this.txtHomeAddr.MaxLength = 100;
            this.txtHomeAddr.Name = "txtHomeAddr";
            this.txtHomeAddr.Size = new System.Drawing.Size(408, 21);
            this.txtHomeAddr.TabIndex = 134;
            // 
            // cboCourse
            // 
            this.cboCourse.BackColor = System.Drawing.SystemColors.Info;
            this.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourse.FormattingEnabled = true;
            this.cboCourse.Location = new System.Drawing.Point(634, 26);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(156, 21);
            this.cboCourse.TabIndex = 103;
            this.cboCourse.SelectedIndexChanged += new System.EventHandler(this.cboCourse_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Info;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(264, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "&Save Information";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(327, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 133;
            this.label7.Text = "Address";
            // 
            // cbogen
            // 
            this.cbogen.BackColor = System.Drawing.SystemColors.Info;
            this.cbogen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbogen.FormattingEnabled = true;
            this.cbogen.Location = new System.Drawing.Point(382, 26);
            this.cbogen.Name = "cbogen";
            this.cbogen.Size = new System.Drawing.Size(156, 21);
            this.cbogen.TabIndex = 7;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(14, 96);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(61, 12);
            this.Label12.TabIndex = 12;
            this.Label12.Text = "Othername";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "Matric No :";
            // 
            // txtemail
            // 
            this.txtemail.BackColor = System.Drawing.SystemColors.Info;
            this.txtemail.Location = new System.Drawing.Point(634, 60);
            this.txtemail.MaxLength = 50;
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(156, 21);
            this.txtemail.TabIndex = 117;
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label27.Location = new System.Drawing.Point(565, 64);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(60, 12);
            this.Label27.TabIndex = 118;
            this.Label27.Text = "Email Addr";
            // 
            // txtOthername
            // 
            this.txtOthername.BackColor = System.Drawing.SystemColors.Info;
            this.txtOthername.Location = new System.Drawing.Point(95, 92);
            this.txtOthername.MaxLength = 50;
            this.txtOthername.Name = "txtOthername";
            this.txtOthername.Size = new System.Drawing.Size(199, 21);
            this.txtOthername.TabIndex = 1;
            // 
            // txtsurname
            // 
            this.txtsurname.BackColor = System.Drawing.SystemColors.Info;
            this.txtsurname.Location = new System.Drawing.Point(95, 60);
            this.txtsurname.MaxLength = 50;
            this.txtsurname.Name = "txtsurname";
            this.txtsurname.Size = new System.Drawing.Size(199, 21);
            this.txtsurname.TabIndex = 0;
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.SystemColors.Info;
            this.txtPhone.Location = new System.Drawing.Point(383, 60);
            this.txtPhone.MaxLength = 11;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(156, 21);
            this.txtPhone.TabIndex = 11;
            // 
            // Label26
            // 
            this.Label26.AutoSize = true;
            this.Label26.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label26.Location = new System.Drawing.Point(325, 64);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(51, 12);
            this.Label26.TabIndex = 12;
            this.Label26.Text = "Phone no";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(15, 64);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(49, 12);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "Surname";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(327, 29);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(49, 12);
            this.Label10.TabIndex = 0;
            this.Label10.Text = "Gender ";
            // 
            // ManageStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 715);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageStudent";
            this.Load += new System.EventHandler(this.ManageStudent_Load);
            this.GroupBox7.ResumeLayout(false);
            this.GroupBox7.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txtStudentIDFilter;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.GroupBox GroupBox7;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.ComboBox cboCourse;
        internal System.Windows.Forms.Button btnexit;
        internal System.Windows.Forms.Button btncancel;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.ComboBox cbogen;
        internal System.Windows.Forms.Button button2;
        internal System.Windows.Forms.TextBox txtOthername;
        internal System.Windows.Forms.TextBox txtsurname;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtemail;
        internal System.Windows.Forms.Label Label27;
        internal System.Windows.Forms.TextBox txtPhone;
        internal System.Windows.Forms.Label Label26;
        internal System.Windows.Forms.TextBox txtHomeAddr;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.DataGridView dgvStudents;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImgUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOthername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        internal System.Windows.Forms.Button button3;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cboCourseFilter;
    }
}