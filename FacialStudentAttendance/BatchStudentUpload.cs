using FacialStudentAttendance.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacialStudentAttendance
{
    public partial class BatchStudentUpload : Form
    {
        private string username;

        public BatchStudentUpload(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void BatchStudentUpload_Load(object sender, EventArgs e)
        {
            LoadCourses();
            LoadStudents();
        }
        private async void LoadStudents()
        {
            DataCentric data2 = new DataCentric(DataCentric.StudentCoursesTBname + username);
            list = await data2.LoadMyCoursesStudents();
        }

        private async void LoadCourses()
        {
            var source = new BindingSource();
            var list2 = new List<CourseModel>();
            DataCentric data = new DataCentric(DataCentric.CourseTBname + username);
            list2 = await data.LoadMyCourses();
            source.DataSource = list2;
            cboCourse.DataSource = source;
            cboCourse.DisplayMember = "courseCode";
            cboCourse.ValueMember = "courseCode";
            cboCourse.SelectedItem = "";
            cboCourse.Text = "";
        }

        string fileName;
        private List<UserModel> list;

        private void LoadExcel()
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();  //create openfileDialog Object
                openFileDialog1.Filter = "XML Files (*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb) |*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb";//open file format define Excel Files(.xls)|*.xls| Excel Files(.xlsx)|*.xlsx| 
                openFileDialog1.FilterIndex = 3;

                openFileDialog1.Multiselect = false;        //not allow multiline selection at the file selection level
                openFileDialog1.Title = "Open Text File-R13";   //define the name of openfileDialog
                openFileDialog1.InitialDirectory = @"Desktop"; //define the initial directory

                if (openFileDialog1.ShowDialog() == DialogResult.OK)        //executing when file open
                {
                    string pathName = openFileDialog1.FileName;
                    fileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    string sheetName = "Sheet1";

                    DataTable src1 = new DataTable();
                    sheetName = textBox1.Text;

                    string strConn = string.Empty;
                    FileInfo file = new FileInfo(pathName);
                    if (!file.Exists) { throw new Exception("Error, file doesn't exists!"); }
                    string extension = file.Extension;
                    switch (extension)
                    {
                        case ".xls":
                            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                            break;
                        case ".xlsx":
                            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                            break;
                        default:
                            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                            break;
                    }
                    OleDbConnection cnnxls = new OleDbConnection(strConn);
                    OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [{0}$]", sheetName), cnnxls);
                   
                        oda.Fill(src1);
                    dataGridView1.DataSource = src1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!" + ex.Message);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            button1.Enabled = false;

            if (string.IsNullOrEmpty(cboCourse.Text))
            {
                MessageBox.Show("Please select course code.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable oTable = (DataTable)dataGridView1.DataSource;
            foreach (DataRow oRow in oTable.Rows)
            {
                SaveData(oRow);
                //write each row to the database as all of them have changed
            }
            ClearData();

            this.Cursor = System.Windows.Forms.Cursors.Default;
            button1.Enabled = true;
        }

        private async void SaveData(DataRow dataRow)
        {
            if (string.IsNullOrEmpty(dataRow.ItemArray[0].ToString())) return;
            DataCentric data = new DataCentric(DataCentric.StudentCoursesTBname + username + "/" + cboCourse.Text + dataRow.ItemArray[0].ToString());
            var success = await data.RegUpdateUser(new UserModel() { Address = dataRow.ItemArray[5].ToString(), EmailAddr = dataRow.ItemArray[6].ToString(), Gender = dataRow.ItemArray[3].ToString(), Othername = dataRow.ItemArray[2].ToString(), Password = "", PhoneNo = dataRow.ItemArray[4].ToString(), RegDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt"), Surname = dataRow.ItemArray[1].ToString(), Username = dataRow.ItemArray[0].ToString(), UserType = "Student", ImgUrl = "", CourseCode = cboCourse.Text }, IsStudentCodeNew(dataRow.ItemArray[0].ToString()));
            if (!success)
            {
                MessageBox.Show("Error occured, pls check your network.", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            LoadStudents();
        }

        private bool IsStudentCodeNew(string text)
        {
            var data = list.Where(p => p.Username.Equals(text)).FirstOrDefault();
            if (data == null) return true;
            else return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadExcel();
        }
    }
}
