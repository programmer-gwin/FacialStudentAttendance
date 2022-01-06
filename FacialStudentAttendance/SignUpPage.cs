using FacialStudentAttendance.Controls;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FacialStudentAttendance
{
    public partial class SignUpPage : Form
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        WebCam webcam;
        private void SignUpPage_Load(object sender, EventArgs e)
        {
            webcam = new WebCam();
            webcam.InitializeWebCam(ref pictUser);
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginPage lp = new LoginPage();
            lp.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnregister_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            btnregister.Enabled = false;
            if (string.IsNullOrEmpty(txtuser.Text) || string.IsNullOrEmpty(txtpass.Text) || string.IsNullOrEmpty(txtphone.Text)
                || string.IsNullOrEmpty(txtSurname.Text) || string.IsNullOrEmpty(txtemail.Text) || string.IsNullOrEmpty(txtAddress.Text)
                || string.IsNullOrEmpty(cboGender.Text) || string.IsNullOrEmpty(txtOthername.Text) || string.IsNullOrEmpty(txtpass.Text) 
                || string.IsNullOrEmpty(cboUserType.Text))
            {
                MessageBox.Show("Pls provide data for all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (txtphone.Text.Length < 11)
            {
                MessageBox.Show("Invalid Phone Number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!DataCentric.IsValidEmailFormat(txtemail.Text))
            {
                MessageBox.Show("Invalid Email Format", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (pictureByte == null)
            {
                MessageBox.Show("Pls capture your image", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataCentric data = new DataCentric(DataCentric.UserTBname + cboUserType.Text + "/" + txtuser.Text);
                var user = await data.LoadSingleUser();
                if (user != null)
                {
                    MessageBox.Show("Sorry, This User ID has already been used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    try
                    {
                        if (pictureByte != null)
                        {
                            ImgUrl = await DataCentric.sendFileToFireBase(txtuser.Text + ".png", pictureByte, DataCentric.UserImgFolder + cboUserType.Text + "/" + txtuser);
                        }
                        var success = await data.RegUpdateUser(new UserModel() { Address = txtAddress.Text, EmailAddr = txtemail.Text, Gender = cboGender.Text, Othername = txtOthername.Text, Password = txtpass.Text, PhoneNo = txtphone.Text, RegDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt"), Surname = txtSurname.Text, Username = txtuser.Text, UserType = cboUserType.Text, ImgUrl = ImgUrl, CourseCode = "" }, true);
                        if (success)
                        {
                            MessageBox.Show("Your Registration is Successfully..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            LoginPage mp = new LoginPage();
                            mp.Show();
                        }
                        else
                        {
                            MessageBox.Show("Error occured, pls check your network.", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            btnregister.Enabled = true;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        string ImgUrl = "";
        byte[] pictureByte = null;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (button2.Text.Equals("Start Camera"))
                {
                    webcam.Start();
                    //webcam.Continue();
                    button2.Text = "Capture";

                    //webcam.ResolutionSetting();
                    //webcam.AdvanceSetting();
                }
                else if (button2.Text.Equals("Capture"))
                {
                    pictUser.Image = pictUser.Image;
                    webcam.Stop();
                    //Helper.SaveImageCapture(pictUser.Image);
                    button2.Text = "Start Camera";

                    ImageConverter converter = new ImageConverter();
                    pictureByte = (byte[])converter.ConvertTo(pictUser.Image, typeof(byte[]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Occurred!");
            }
           
        }

    }
}
