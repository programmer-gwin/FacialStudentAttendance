using FacialStudentAttendance.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacialStudentAttendance
{
    public partial class ManageCourses : Form
    {
        List<CourseModel> list;
        string username = "";
        public ManageCourses(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            button1.Enabled = false;
            if(string.IsNullOrEmpty(txtCourseCode.Text) || string.IsNullOrEmpty(txtCourseName.Text))
            {
                MessageBox.Show("Pls enter both Course Code and Course Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataCentric data = new DataCentric(DataCentric.CourseTBname + username + "/" + txtCourseCode.Text);
                var success = await data.RegUpdateCourse(new CourseModel() { courseCode = txtCourseCode.Text, courseName = txtCourseName.Text, endTime = endTime.Text, startTime = startTime.Text }, IsCourseCodeNew(txtCourseCode.Text));
                if (success)
                {
                    MessageBox.Show("Course Updated Successfully..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                    LoadAllData();
                }
                else
                {
                    MessageBox.Show("Error occured, pls check your network.", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            button1.Enabled = true;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private bool IsCourseCodeNew(string text)
        {
            var data = list.Where(p => p.courseCode.Equals(text)).FirstOrDefault();
            if (data == null) return true;
            else return false;
        }

        private void ClearData()
        {
            txtCourseName.Text = "";
            txtCourseCode.Text = "";
            startTime.Value = DateTime.Now;
            endTime.Value = DateTime.Now;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void ManageCourses_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private async void LoadAllData()
        {
            var source = new BindingSource();
            list = new List<CourseModel>();
            DataCentric data = new DataCentric(DataCentric.CourseTBname + username);
            list = await data.LoadMyCourses();
            source.DataSource = list;
            dgvCourseList.DataSource = source;
        }

        private void dgvCourseList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvCourseList.Rows[e.RowIndex];
                txtCourseCode.Text = row.Cells["Column1"].Value.ToString();
                txtCourseName.Text = row.Cells["Column2"].Value.ToString();
                startTime.Text = row.Cells["Column3"].Value.ToString();
                endTime.Text = row.Cells["Column4"].Value.ToString();
            }
        }

        private async void dgvCourseList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this item ??", "Confirm Delete!!",  MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    DataGridViewRow row = this.dgvCourseList.SelectedRows[0]; 
                    string deleteCode = row.Cells["Column1"].Value.ToString();
                    DataCentric data = new DataCentric(DataCentric.CourseTBname + username + "/" + deleteCode);
                    bool success = await data.DeleteTable();
                    if (success)
                    {
                        MessageBox.Show("Course Deleted Successfully..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllData();
                    }
                    else
                        MessageBox.Show("Unable to delete course..", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
