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
    public partial class ViewAttendanceReport : Form
    {
        public string username="";
        List<AttendanceModel> list;
        List<AttendanceModel> FullList;
        List<CourseModel> list2;
        List<UserModel> studentList;
        List<UserModel> FullStudentList;

        public ViewAttendanceReport(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void dgvlogindetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ViewAttendanceReport_Load(object sender, EventArgs e)
        {
            LoadCourses(); LoadAttendance(); LoadStudents(); LoadPercentage(); 
        }

        private async void LoadStudents()
        {
            DataCentric data2 = new DataCentric(DataCentric.StudentCoursesTBname + username);
            FullStudentList = await data2.LoadMyCoursesStudents();
            studentList = FullStudentList;
        }

        private async void LoadPercentage()
        {
            try
            {
                DataCentric data = new DataCentric(DataCentric.AttendanceTBName + username + "/" + cboCourse.Text );
                var dataResult = await data.LoadMyCoursStudAttendPercentage();
                List<AttendanceModel> PercentageData = new List<AttendanceModel>();
                studentList = FullStudentList.Where(p => p.CourseCode.Equals(cboCourse.Text)).ToList();
                if (studentList == null) return;
                foreach (var stud in studentList)
                {
                    var studExist = PercentageData.Where(p => p.studentID.Equals(stud.Username)).FirstOrDefault();
                    if (studExist == null)
                    {
                        var studAttendList = dataResult.Where(p => p.studentID.Equals(stud.Username)).ToList();
                        float NoOfLecture = DataCentric.NoOfLecture;
                        float NoOfAttend = studAttendList.Count;
                        double div = (double) NoOfAttend/NoOfLecture;
                        double percent = div*100;
                        decimal percentage = (decimal)percent;

                        PercentageData.Add(new AttendanceModel() { studentID = stud.Username, LectureNumber = NoOfLecture.ToString() + " Lectures", AttendNumber = NoOfAttend.ToString() + " Attended", Percentage = percentage.ToString() + " %" });
                    }
                }
                var bindingSource1 = new BindingSource();
                bindingSource1.DataSource = PercentageData;
                dgvPercentage.DataSource = bindingSource1.DataSource;
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Error Loading Percentage " + ex.Message);
            }
        }

        private async void LoadAttendance()
        {
            DataCentric data = new DataCentric(DataCentric.AttendanceTBName + username + "/" + cboCourse.Text + "/" + dateTimePicker1.Value.ToString("MMMM dd, yyyy"));
            list = new List<AttendanceModel>();
            FullList = new List<AttendanceModel>();
            list = await data.LoadMyCoursesStudentAttendance();
            FullList = list;
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = list;
            dgvAttendantList.DataSource = bindingSource1.DataSource;
            if(list!=null) LoadPercentage();
        }

        private async void LoadCourses()
        {
            var source = new BindingSource();
            list2 = new List<CourseModel>();
            DataCentric data = new DataCentric(DataCentric.CourseTBname + username);
            list2 = await data.LoadMyCourses();
            source.DataSource = list2;
            cboCourse.DataSource = source;
            cboCourse.DisplayMember = "courseCode";
            cboCourse.ValueMember = "courseCode";
            cboCourse.Text = "";
            cboCourse.SelectedItem = "";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadAttendance();
        }

        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAttendance(); 
        }

        private void startAttendant_Click(object sender, EventArgs e)
        {
            startAttendant.Enabled = false;
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                copyAlltoClipboard();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            startAttendant.Enabled = true;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void copyAlltoClipboard()
        {
            dgvAttendantList.SelectAll();
            DataObject dataObj = dgvAttendantList.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void copyAlltoClipboard2()
        {
            dgvPercentage.SelectAll();
            DataObject dataObj = dgvPercentage.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                copyAlltoClipboard2();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            button1.Enabled = true;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
    }
}
