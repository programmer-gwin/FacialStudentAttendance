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
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
           
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            FacialAttendance fa = new FacialAttendance(lblusername.Text);
            fa.ShowDialog();
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            ChangePassword fa = new ChangePassword(lblUserType.Text);
            fa.ShowDialog();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            ChangePassword fa = new ChangePassword(lblUserType.Text);
            fa.ShowDialog();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage fa = new LoginPage();
            fa.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ViewAttendanceReport fa = new ViewAttendanceReport(lblusername.Text);
            fa.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ManageStudent fa = new ManageStudent(lblusername.Text);
            fa.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ManageCourses fa = new ManageCourses(lblusername.Text);
            fa.Show();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            HowDoI fa = new HowDoI();
            fa.ShowDialog();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            About fa = new About();
            fa.ShowDialog();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            About fa = new About();
            fa.ShowDialog();
        }
    }
}
