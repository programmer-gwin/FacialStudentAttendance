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
    public partial class ChangePassword : Form
    {
        string usertype = "";
        public ChangePassword(string usertype)
        {
            InitializeComponent();
            this.usertype = usertype;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnchange_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            btnchange.Enabled = false;
            if (string.IsNullOrEmpty(txtuser.Text) || string.IsNullOrEmpty(txtold.Text) || string.IsNullOrEmpty(txtnew.Text) || string.IsNullOrEmpty(txtconfirm.Text))
            {
                MessageBox.Show("One or more fields are empty", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (!txtnew.Text.Equals(txtconfirm.Text)){
                MessageBox.Show("New password do not match", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataCentric data = new DataCentric(DataCentric.UserTBname + usertype + "/" + txtuser.Text);
                var user = await data.LoadSingleUser();
                if (user != null)
                {
                    if (user.Password.Equals(txtold.Text))
                    {
                        user.Password = txtnew.Text;
                        bool res = await data.RegUpdateUser(user, false);
                        if (res)
                        {
                            MessageBox.Show("Your password has been changed successfully to : "+ txtnew.Text, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtuser.Text = ""; txtold.Text = ""; txtnew.Text = ""; txtconfirm.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Unable to change password, check network and try again.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Old password do not match", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Unable to get user detail, check username and network, then try again.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            btnchange.Enabled = true;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
    }
}
