using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace FacialStudentAttendance
{
    public partial class SplashPage : Form
    {
        double x=0;
        SpeechSynthesizer voice;

        public SplashPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            voice = new SpeechSynthesizer();
            //voice.Speak("WELCOME TO  CIVIC REGISTRATION MANAGEMENT, DESIGNED BY, CS/ND/P15/27,59, THANKS");
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             lblLoading.Text += ".";
             x = x + 0.5;

            if(x == 15)
            {
                 timer1.Stop();
                 timer2.Start();
            }

            if(lblLoading.Text == "Loading.........")
            {
                lblLoading.Text = "Loading";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
             this.Opacity -= 0.1;

            if (this.Opacity == 0)
            {
            timer2.Stop();
            this.Hide();
            LoginPage log = new LoginPage();
            log.Show();
            }
        }

    }
}
