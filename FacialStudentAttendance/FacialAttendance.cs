using FacialStudentAttendance.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Drawing;
using System.Net;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace FacialStudentAttendance
{
    public partial class FacialAttendance : Form
    {
        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels;
        string name, names = null;

        string username = "";
        List<CourseModel> list2;
        bool canLoad = false;
        List<AttendanceModel> list; 
        List<AttendanceModel> FullList; 

        public FacialAttendance(string username)
        {
            InitializeComponent();
            this.username = username;     
            //Load haarcascades for face detection 
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            //eye = new HaarCascade("haarcascade_eye.xml");
        }

        //todo use server system for rec testing
        private async void LoadAllFaces()
        {
            try
            {
                //Load of previus trainned faces and labels for each image 
                DataCentric data = new DataCentric(DataCentric.FaceAndLabelTBname + username + "/" + cboCourse.Text + DataCentric.TrainedLabelsUrl);
                string Labelsinfo = await data.LoadTrainedFaceTxt();
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;

                string CourseStudentPicUrl = DataCentric.FaceAndLabelTBname + username + "/" + cboCourse.Text + DataCentric.TrainedFacesUrl + "face";
                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    DataCentric dataPic = new DataCentric(CourseStudentPicUrl + tf);
                    string ImgUrl = await dataPic.LoadTrainedFaceTxt();
                    trainingImages.Add(new Image<Gray, byte>(DownloadImage(ImgUrl)));
                    labels.Add(Labels[tf]);
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                // MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public Bitmap DownloadImage(string imageUrl)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            Bitmap bitmap; bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                bitmap.Save(stream, ImageFormat.Bmp);
            }

            stream.Flush();
            stream.Close();
            client.Dispose();
            return bitmap;
        }

        private void FacialAttendance_Load(object sender, EventArgs e)
        {
            LoadCourses(); LoadAttendance();
        }

        private async void LoadAttendance()
        {
            DataCentric data = new DataCentric(DataCentric.AttendanceTBName + username + "/" + cboCourse.Text + "/" + DateTime.Now.ToString("MMMM dd, yyyy"));
            list = new List<AttendanceModel>();
            FullList = new List<AttendanceModel>();
            list = await data.LoadMyCoursesStudentAttendance();
            FullList = list;
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = list;
            dgvAttendantList.DataSource = bindingSource1.DataSource;
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

        private void startAttendant_Click(object sender, EventArgs e)
        {
            startAttendant.Enabled = false;
            if(startAttendant.Text.Equals("Start Attendance"))
            {
                if (string.IsNullOrEmpty(cboCourse.Text))
                {
                    MessageBox.Show("Pls select Course", "Input Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CourseModel course = list2.Where(p => p.courseCode.Equals(cboCourse.Text)).FirstOrDefault();
                    DateTime courseStartTime = DateTime.Parse(course.startTime);
                    DateTime courseEndTime = DateTime.Parse(course.endTime);

                    TimeSpan start = new TimeSpan(courseStartTime.Hour, courseStartTime.Minute, courseStartTime.Second);
                    TimeSpan end = new TimeSpan(courseEndTime.Hour, courseEndTime.Minute, courseEndTime.Second);
                    TimeSpan now = DateTime.Now.TimeOfDay;

                    if ((now >= start) && (now <= end))
                    {
                        LoadAllFaces();
                        StartCamera();
                        startAttendant.Text = "Stop Attendance";
                    }
                    else if (now < start)
                    {
                        MessageBox.Show("Sorry, This is not time for Lecture start time, wait for the time.", "Lecture not started", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (now > end)
                    {
                        MessageBox.Show("Sorry, Lecture time has gone, you miss the lecture time.", "Lecture has ended", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                StopCamera();
            }
            startAttendant.Enabled = true;
        }

        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAttendance();
        }

        private void StartCamera()
        {
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
        }

        int totalAllow=0, totalDenied = 0;
        async void FrameGrabber(object sender, EventArgs e)
        {
            //label4.Text = "";
            NamePersons.Add("");


            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
          face,
          1.2,
          10, //10
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, //DO_PRUNNING
          new Size(20, 20));

            name = "";
            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with blue color
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 1);
                
                if (trainingImages.ToArray().Length != 0)
                {
                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                    //Eigen face recognizer
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       trainingImages.ToArray(),
                       labels.ToArray(),
                       3000, //3000
                       ref termCrit);

                    name = recognizer.Recognize(result);

                    if (!string.IsNullOrEmpty(name))
                    {
                        StopCamera(); 
                        //Draw the label for each face detected and recognized
                        currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));

                        await CheckAndPostForAttendannce(name);
                    }
                    else
                    {
                        totalDenied += 1;
                        StopCamera(); //Draw the label for each face detected and recognized
                        currentFrame.Draw("Not Registered", ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.Red));

                        name = "You are not a registered student for this course!";
                        MessageBox.Show(name, "Not Registered!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                

               // NamePersons[t - 1] = name;
               // NamePersons.Add("");
               

                //Set the number of faces detected on the scene
               // lblTotalFace.Text = facesDetected[0].Length.ToString();
            }

            names = name;
            //Names concatenation of persons recognized
            /*  for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
              {
                  StopCamera();
                  names = names + NamePersons[nnn] + ", ";
                  CheckAndPostForAttendannce(NamePersons[nnn]);
              }
              */

            //Show the faces procesed and recognized
            imageBoxFrameGrabber.Image = currentFrame;
            label4.Text = names;
            names = "";
            //Clear the list(vector) of names
            NamePersons.Clear();

            lblTotalAllowed.Text = totalAllow.ToString();
            lblTotalDenied.Text = totalDenied.ToString();
        }

        private void StopCamera()
        {
            imageBoxFrameGrabber.Image = null;
            imageBoxFrameGrabber.BackgroundImage= Properties.Resources.download;
            grabber.Dispose();
            Application.Idle -= new EventHandler(FrameGrabber);
            startAttendant.Text = "Start Attendance";
        }


        private async Task CheckAndPostForAttendannce(string studentID)
        {
            try
            {
                DataCentric data = new DataCentric(DataCentric.AttendanceTBName + username + "/" + cboCourse.Text + "/" + DateTime.Now.ToString("MMMM dd, yyyy") + "/" + studentID );
                AttendanceModel attendance = await data.LoadSingleStudentAttendance();
                if (attendance != null)
                {
                    MessageBox.Show("Your attendance has already been marked for today!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    CourseModel course = list2.Where(p => p.courseCode.Equals(cboCourse.Text)).FirstOrDefault();
                    bool res = await data.MarkAttendant(new AttendanceModel() { clockInTime = DateTime.Now.ToString("hh:mm ss tt"), courseCode=cboCourse.Text, studentID=studentID, startTime=course.startTime });
                    if (res)
                    {
                        MessageBox.Show( studentID + ", Your attendance has been successfully marked for today!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAttendance();
                        totalAllow += 1;
                    }
                    else
                    {
                        MessageBox.Show("Unable to mark the attendance, pls check your network!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
