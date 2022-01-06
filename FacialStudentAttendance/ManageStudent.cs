using Emgu.CV;
using Emgu.CV.Structure;
using FacialStudentAttendance.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacialStudentAttendance
{
    public partial class ManageStudent : Form
    {
        string username = "";
        List<UserModel> list;
        List<UserModel> FullList;

        //Declararation of all variables, vectors and haarcascades
        int ContTrain, NumLabels, t;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        string Labelsinfo="";
        bool canLoad = false;

        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<string> NamePersons = new List<string>();
        string name, names = null;


        public ManageStudent(string username)
        {
            InitializeComponent();
            face = new HaarCascade("haarcascade_frontalface_default.xml");

            this.username = username;
            list = new List<UserModel>();
            FullList = new List<UserModel>();
            cbogen.Items.Add("Male");
            cbogen.Items.Add("Female");
            cbogen.Text = ""; cbogen.SelectedText = "";
        }

        WebCam webcam;
        private void ManageStudent_Load(object sender, EventArgs e)
        {
            webcam = new WebCam();
           // webcam.InitializeWebCam(ref pictUser);
            LoadCourses(); LoadStudents(); LoadStudentsPictures();
        }

        private async void LoadStudentsPictures()
        {
            try
            {
                //Load of previus trainned faces and labels for each image 
                DataCentric data = new DataCentric(DataCentric.FaceAndLabelTBname + username + "/" + cboCourse.Text + DataCentric.TrainedLabelsUrl);
                Labelsinfo = await data.LoadTrainedFaceTxt();
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
            }
            canLoad = true;
        }

      

        public Bitmap DownloadImage(string imageUrl)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            Bitmap bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                bitmap.Save(stream, ImageFormat.Bmp);
            }

            stream.Flush();
            stream.Close();
            client.Dispose();
            return bitmap;
        }

        private async void LoadStudents()
        {
            DataCentric data2 = new DataCentric(DataCentric.StudentCoursesTBname + username);
            list = await data2.LoadMyCoursesStudents();
            FullList = list;
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = list;
            dgvStudents.DataSource = bindingSource1.DataSource;
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

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void ClearData()
        {
            txtStudentId.Text = ""; txtsurname.Text = ""; txtOthername.Text = "";
            cbogen.SelectedText = ""; cboCourse.SelectedItem = ""; txtPhone.Text = "";
            txtemail.Text = ""; txtHomeAddr.Text = "";
            ImgUrl = ""; TrainedFace = null; imageBoxFrameGrabber.Image = null; imageBoxFrameGrabber.BackgroundImage = Properties.Resources.download;
        }

        string ImgUrl = "";
        private void Button3_Click(object sender, EventArgs e)
        {
            if (button2.Text.Equals("Start Camera"))
            {
                StartCamera();
                button2.Text = "Capture";
                /*
                webcam.Start();
                //webcam.Continue();

                //webcam.ResolutionSetting();
                //webcam.AdvanceSetting();
                */
            }
            else if (button2.Text.Equals("Capture"))
            {
                StopCamera();
                button2.Text = "Start Camera";
                /*
                pictUser.Image = pictUser.Image;
                webcam.Stop();
                //Helper.SaveImageCapture(pictUser.Image);

                ImageConverter converter = new ImageConverter();
                pictureByte = (byte[])converter.ConvertTo(pictUser.Image, typeof(byte[]));
                */
            }
        }


        private void StartCamera()
        {
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
        }

        void FrameGrabber(object sender, EventArgs e)
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
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with blue color
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);

                if (trainingImages.ToArray().Length != 0)
                {
                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                    //Eigen face recognizer
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       trainingImages.ToArray(),
                       labels.ToArray(),
                       3000,
                       ref termCrit);

                    name = recognizer.Recognize(result);
                }


                NamePersons[t - 1] = name;
                NamePersons.Add("");


            }
            t = 0;

            //Names concatenation of persons recognized
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                names = names + NamePersons[nnn] + ", ";
            }
            //Show the faces procesed and recognized
            imageBoxFrameGrabber.Image = currentFrame;
            names = "";
            //Clear the list(vector) of names
            NamePersons.Clear();

        }

        private void StopCamera()
        {
            try
            {
                //Trained face counter
                ContTrain = ContTrain + 1;

                //Get a gray frame from capture device
                gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }

                //resize face detected image for force to compare the same size with the 
                //test image with cubic interpolation type method
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Show face added in gray scale
                imageBoxFrameGrabber.Image = TrainedFace;
            }
            catch
            {
                MessageBox.Show("Pls capture the image in clear environment", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            grabber.Dispose();
            Application.Idle -= new EventHandler(FrameGrabber);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            button1.Enabled = false;
            if (string.IsNullOrEmpty(txtStudentId.Text) || string.IsNullOrEmpty(txtsurname.Text) || string.IsNullOrEmpty(txtOthername.Text) || string.IsNullOrEmpty(cboCourse.Text) || string.IsNullOrEmpty(cbogen.Text) || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtemail.Text) || string.IsNullOrEmpty(txtHomeAddr.Text) )
            {
                MessageBox.Show("One or more field is empty, pls provide data for all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtStudentId.Text.Contains("/") || txtsurname.Text.Contains("/") || txtOthername.Text.Contains("/") || txtPhone.Text.Contains("/") || txtemail.Text.Contains("/") || txtHomeAddr.Text.Contains("/") )
            {
                MessageBox.Show("Please remove \"/\" from all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPhone.Text.Length < 11)
            {
                MessageBox.Show("Invalid Phone Number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!DataCentric.IsValidEmailFormat(txtemail.Text))
            {
                MessageBox.Show("Invalid Email Format", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (TrainedFace == null)
            {
                MessageBox.Show("Pls capture image of the student", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (TrainedFace != null)
                {
                    ImgUrl = await DataCentric.sendFileToFireBase("face" + (trainingImages.ToArray().Length + 1) + ".bmp", imageToByteArray(imageBoxFrameGrabber.Image.Bitmap), DataCentric.UserCoursesImgFolder + username + "/" + cboCourse.Text);
                    DataCentric dataImg = new DataCentric(DataCentric.FaceAndLabelTBname + username + "/" + cboCourse.Text + DataCentric.TrainedFacesUrl + "face" + (trainingImages.ToArray().Length + 1));
                    bool val = await dataImg.RegUpdateTrainedFaceTxt(ImgUrl, true);


                    trainingImages.Add(TrainedFace);
                    labels.Add(txtStudentId.Text);
                    /*
                    trainingImages.Add(new Image<Gray, byte>(DownloadImage(ImgUrl))); 
                    labels.Add(txtStudentId.Text);
                    */

                    //Write the number of triained faces in a file text for further load  
                    DataCentric dat = new DataCentric(DataCentric.FaceAndLabelTBname + username + "/" + cboCourse.Text + DataCentric.TrainedLabelsUrl);
                    bool isNew = false;
                    if (NumLabels == 0) isNew = true; 
                    var res = await dat.RegUpdateTrainedFaceTxt(trainingImages.ToArray().Length.ToString() + "%", isNew);

                    //Write the labels of triained faces in a file text for further load 
                    Labelsinfo = trainingImages.ToArray().Length.ToString() + "%";
                    for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                    {
                       // trainingImages.ToArray()[i - 1].Save(DataCentric.UserCoursesImgFolder + username + cboCourse.Text + "face" + i + ".bmp");
                        Labelsinfo += labels.ToArray()[i - 1] + "%";
                    }
                    bool r = await dat.RegUpdateTrainedFaceTxt(Labelsinfo, isNew);
                }

                DataCentric data = new DataCentric(DataCentric.StudentCoursesTBname + username + "/" + cboCourse.Text + txtStudentId.Text);
                var success = await data.RegUpdateUser(new UserModel() { Address = txtHomeAddr.Text, EmailAddr = txtemail.Text, Gender = cbogen.Text, Othername = txtOthername.Text, Password = "", PhoneNo = txtPhone.Text, RegDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt"), Surname = txtsurname.Text, Username = txtStudentId.Text, UserType = "Student", ImgUrl = ImgUrl, CourseCode=cboCourse.Text }, IsStudentCodeNew(txtStudentId.Text));
                if (success)
                {
                    MessageBox.Show("Registration is Successfully..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                    LoadStudents();
                }
                else
                {
                    MessageBox.Show("Error occured, pls check your network.", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            button1.Enabled = true;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        public byte[] imageToByteArray(System.Drawing.Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();
            }
        }
        private bool IsStudentCodeNew(string text)
        {
            var data = list.Where(p => p.Username.Equals(text)).FirstOrDefault();
            if (data == null) return true;
            else return false;
        }

        private async void txtStudentId_TextChanged(object sender, EventArgs e)
        {
            if (canLoad)
            {
                if (string.IsNullOrEmpty(txtStudentIDFilter.Text))
                {
                    LoadStudents();
                }
                else
                {
                    list = FullList.Where(p => p.Surname.Contains(txtStudentIDFilter.Text)).ToList();
                    var bindingSource1 = new BindingSource();
                    bindingSource1.DataSource = list;
                    dgvStudents.DataSource = bindingSource1.DataSource;
                }
            }
            if (canLoad)
            {
                DataCentric data = new DataCentric(DataCentric.UserTBname + "Student/" + txtStudentId.Text);
                var user = await data.LoadSingleUser();
                if (user != null)
                {
                    try
                    {
                        txtStudentId.Text = user.Username; txtsurname.Text = user.Surname; txtOthername.Text = user.Othername;
                        cbogen.SelectedText = user.Gender; cboCourse.SelectedItem = user.CourseCode; txtPhone.Text = user.PhoneNo;
                        txtemail.Text = user.EmailAddr; txtHomeAddr.Text = user.Address;
                        ImgUrl = user.ImgUrl;
                        imageBoxFrameGrabber.ImageLocation = user.ImgUrl;
                        ImageConverter converter = new ImageConverter();
                        if(imageBoxFrameGrabber.Image!=null)
                        TrainedFace = new Image<Gray, byte>(imageBoxFrameGrabber.Image.Bitmap);
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            } 
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            BatchStudentUpload br = new BatchStudentUpload(username);
            br.ShowDialog();
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.dgvStudents.Rows[e.RowIndex];
                    txtStudentId.Text = row.Cells["colID"].Value.ToString();
                    cbogen.SelectedText = row.Cells["colGender"].Value.ToString();

                    txtsurname.Text = row.Cells["colSurname"].Value.ToString();
                    txtOthername.Text = row.Cells["colOthername"].Value.ToString();
                    cboCourse.SelectedItem = row.Cells["colCourse"].Value.ToString();
                    txtPhone.Text = row.Cells["colPhone"].Value.ToString();
                    txtemail.Text = row.Cells["colEmail"].Value.ToString();
                    txtHomeAddr.Text = row.Cells["colAddr"].Value.ToString();
                    ImgUrl = row.Cells["colImgUrl"].Value.ToString();
                    imageBoxFrameGrabber.ImageLocation = ImgUrl;
                    ImageConverter converter = new ImageConverter();
                    if (imageBoxFrameGrabber.Image != null)
                        TrainedFace = new Image<Gray, byte>(imageBoxFrameGrabber.Image.Bitmap);
                }
                catch (Exception)
                {
                    
                }
             
            }
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudentsPictures();
        }

        private async void dgvStudents_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this item ??", "Confirm Delete!!", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    DataGridViewRow row = this.dgvStudents.SelectedRows[0];
                    string deleteCode = row.Cells["colCourse"].Value.ToString() + row.Cells["colID"].Value.ToString();
                    DataCentric data = new DataCentric(DataCentric.StudentCoursesTBname + username + "/"  + deleteCode);
                    bool success = await data.DeleteTable();
                    if (success)
                    {
                        MessageBox.Show("Student Deleted Successfully..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStudents();
                    }
                    else
                        MessageBox.Show("Unable to delete student..", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboCourseFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboCourseFilter.Text))
            {
                LoadStudents();
            }
            else
            {
                list = FullList.Where(p => p.CourseCode.Contains(cboCourseFilter.Text)).ToList();
                var bindingSource1 = new BindingSource();
                bindingSource1.DataSource = list;
                dgvStudents.DataSource = bindingSource1.DataSource;
            }
        }

    }
}
