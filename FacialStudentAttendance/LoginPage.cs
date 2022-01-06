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
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SignUpPage sp = new SignUpPage();
            sp.Show();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            Button1.Enabled = false;
            if (string.IsNullOrEmpty(txtuser.Text) || string.IsNullOrEmpty(txtpass.Text) || string.IsNullOrEmpty(cboUserType.Text))
            {
                MessageBox.Show("Pls enter username, password, and select user type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cboUserType.Text.Equals("Student"))
                    MessageBox.Show("Sorry, student interface is not available.");
                
                else {
                    DataCentric data = new DataCentric(DataCentric.UserTBname + cboUserType.Text + "/" + txtuser.Text);
                    var user = await data.LoadSingleUser();
                    if (user != null)
                    {
                        if (user.Password.Equals(txtpass.Text))
                        {
                            MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            MainPage mp = new MainPage();
                            mp.lblusername.Text = txtuser.Text;
                            mp.lblFullname.Text = user.Surname + " " + user.Othername;
                            mp.lblUserType.Text = user.UserType;
                            //  if(!string.IsNullOrEmpty(user.ImgUrl)) mp.pictureBox3.ImageLocation = user.ImgUrl;
                            mp.lbltime1.Text = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
                            mp.Show();
                        }
                        else
                            MessageBox.Show("You entered incorrect password, try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Error from server, Check your network and details.", "Invalid Response", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Button1.Enabled = true;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void Button2_Click(object sender, EventArgs e) 
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
