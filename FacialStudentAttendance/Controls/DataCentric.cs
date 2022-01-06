using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Firebase.Storage;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Mail;
using System.Net.NetworkInformation;

namespace FacialStudentAttendance.Controls
{
    public class DataCentric
    {
        internal static readonly string DateTimeMillSecs = DateTime.Now.ToString("dd MMM, yyyy - hh:mm tt");
        #region firebase_properties 
        internal static readonly string bitlyShortenUrlPath = "fa894c247e6781898021a81847da7362aeecdafd";
        internal static readonly string firebaseCheckUpdateLink = "https://bit.ly/2RrgvpT";
        internal static readonly string firebasAuthSecret = "GXOxNiGq5WRSUKTDwc64tzVpMqKL9R27OmtOoOi6";
        internal static readonly string firebaseBasePath = "https://facialstudentattendance-default-rtdb.firebaseio.com/";
        internal static readonly string firebaseFileStoragePath = "facialstudentattendance.appspot.com";


        internal static readonly string CourseTBname = "tblCourses/";
        internal static readonly string UserTBname = "tblUsers/"; 
        internal static readonly string StudentCoursesTBname = "tblStudentCourses/";

        internal static readonly string FaceAndLabelTBname = "FacesAndLabel/";
        internal static readonly string TrainedLabelsUrl = "/TrainedLabels/";
        internal static readonly string TrainedFacesUrl = "/TrainedFaces/";

        internal static readonly string UserImgFolder = "User_Image/";
        internal static readonly string UserCoursesImgFolder = "User_Course_Image/";
        internal static readonly string AttendanceTBName = "tblStudentAttendance/";
        #endregion

        string firebaseMsgDirectory = ""; string WMID, POID;
        internal static int NoOfLecture = 0;


        public static bool IsConnected()
        {
            string host = "http://www.c-sharpcorner.com";  
            bool result = false;
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send(host,1000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch { }
            return result;
        }
        
        //To check if the data is a valid json response
        public static bool IsValidJson(string value)
        {
            try
            {
                var json = JContainer.Parse(value);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        private static Regex _regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);

        public static bool IsValidEmailFormat(string emailInput)
        {
            return _regex.IsMatch(emailInput);
        }

       IFirebaseClient client;
       IFirebaseConfig config = new FirebaseConfig
       {
           AuthSecret = firebasAuthSecret,
           BasePath = firebaseBasePath
       }; 
        

        public DataCentric(string FirebaseMsgLink, string wMID="", string pOID="")
        {
            client = new FireSharp.FirebaseClient(config);
            firebaseMsgDirectory = FirebaseMsgLink;
            POID = pOID; WMID = wMID;
        }

        public static async Task<string> sendFileToFireBase(string fileNamee, byte[] contentByte, string subFolder)
        {
           // string filename = Path.GetFileName(fileNamee);

            string flag = "";
            try
            {
                if (fileNamee != null && contentByte != null)
                {
                   //string fileName = DateTimeMillSecs + filename;
                    var task = new FirebaseStorage(DataCentric.firebaseFileStoragePath)
                            .Child(subFolder)
                            .Child(fileNamee)
                            .PutAsync(new MemoryStream(contentByte));
                    var downloadUrl = await task;
                    //for chat been notify await SendChatToFireBase(new ChatAndUserModel() { Message = filename, ImgUrl = downloadUrl, DateTimeInMillSecs = DateTimeMillSecs, ReceiverID = POID, SenderID = WMID, SenderName = "Victor ETL" });
                    flag = downloadUrl;
                }
            }
            catch (Exception ex)
            {
                flag = ex.Message;
            }
            return flag;
        }


        public async Task<bool> RegUpdateUser(UserModel user, bool isNew)
        {
            bool flag = false;
            if (client != null)
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("ImgUrl", user.ImgUrl);
                values.Add("UserType", user.UserType);
                values.Add("RegDate", user.RegDate);
                values.Add("Surname", user.Surname);
                values.Add("Othername", user.Othername);
                values.Add("Gender", user.Gender);
                values.Add("PhoneNo", user.PhoneNo);
                values.Add("EmailAddr", user.EmailAddr);
                values.Add("Address", user.Address);
                values.Add("Username", user.Username); 
                values.Add("Password", user.Password);
                values.Add("CourseCode", user.CourseCode);

                if (isNew)
                {
                    var response = await client.SetAsync(firebaseMsgDirectory, values);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        flag = true;
                    }
                }
                else
                {
                    var response = await client.UpdateAsync(firebaseMsgDirectory, values);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }

        public async Task<UserModel> LoadSingleUser()
        {
            UserModel tempDataSet = null;
            try
            {
                FirebaseResponse firebaseResponse = await client.GetAsync(firebaseMsgDirectory);
                string JsTxt = firebaseResponse.Body;
                if (JsTxt != "null")
                {
                    tempDataSet = JsonConvert.DeserializeObject<UserModel>(JsTxt);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return tempDataSet;
        }

        public async Task<List<UserModel>> LoadMyCoursesStudents()
        {
            List<UserModel> tempDataSetList = new List<UserModel>();
            UserModel tempDataSet = null;
            try
            {
                FirebaseResponse firebaseResponse = await client.GetAsync(firebaseMsgDirectory);
                string JsTxt = firebaseResponse.Body;
                if (JsTxt != "null")
                {
                    dynamic mresponse = JsonConvert.DeserializeObject<dynamic>(JsTxt);
                    foreach (var jresult in mresponse)
                    {
                        tempDataSet = JsonConvert.DeserializeObject<UserModel>(((JProperty)jresult).Value.ToString());
                        tempDataSetList.Add(tempDataSet);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return tempDataSetList;
        }

        public async Task<bool> RegUpdateCourse(CourseModel course, bool isNew)
        {
            bool flag = false;
            if (client != null)
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("courseCode", course.courseCode);
                values.Add("courseName", course.courseName);
                values.Add("startTime", course.startTime);
                values.Add("endTime", course.endTime);

                if (isNew)
                {
                    var response = await client.SetAsync(firebaseMsgDirectory, values);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        flag = true;
                    }
                }
                else
                {
                   var response = await client.UpdateAsync(firebaseMsgDirectory, values);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }


        public async Task<CourseModel> LoadSingleCourse()
        {
            CourseModel tempDataSet = null;
            try
            {
                FirebaseResponse firebaseResponse = await client.GetAsync(firebaseMsgDirectory);
                string JsTxt = firebaseResponse.Body;
                if (JsTxt != "null")
                {
                    tempDataSet = JsonConvert.DeserializeObject<CourseModel>(JsTxt);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return tempDataSet;
        }

        public async Task<List<CourseModel>> LoadMyCourses()
        {
            List<CourseModel> tempDataSetList = new List<CourseModel>();
            CourseModel tempDataSet = null;
            try
            {
                FirebaseResponse firebaseResponse = await client.GetAsync(firebaseMsgDirectory);
                string JsTxt = firebaseResponse.Body;
                if (JsTxt != "null")
                {
                    dynamic mresponse = JsonConvert.DeserializeObject<dynamic>(JsTxt);
                    foreach (var jresult in mresponse)
                    {
                        tempDataSet = JsonConvert.DeserializeObject<CourseModel>(((JProperty)jresult).Value.ToString());
                        tempDataSetList.Add(tempDataSet);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return tempDataSetList;
        }

        public async Task<bool> DeleteTable()
        {
            bool flag = false;
            if (client != null)
            {
                var response = await client.DeleteAsync(firebaseMsgDirectory);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public async Task<bool> RegUpdateTrainedFaceTxt(string data, bool isNew)
        {
            bool flag = false;
            if (client != null)
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("Data", data);

                if (isNew)
                {
                    var response = await client.SetAsync(firebaseMsgDirectory, values);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        flag = true;
                    }
                }
                else
                {
                    var response = await client.UpdateAsync(firebaseMsgDirectory, values);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }
        public async Task<string> LoadTrainedFaceTxt()
        {
            string tempDataSet = "";
            try
            {
                FirebaseResponse firebaseResponse = await client.GetAsync(firebaseMsgDirectory);
                string JsTxt = firebaseResponse.Body;
                if (JsTxt != "null")
                {
                    FaceModel tempData = JsonConvert.DeserializeObject<FaceModel>(JsTxt);
                    tempDataSet = tempData.Data;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return tempDataSet;
        }

        internal async Task<bool> MarkAttendant(AttendanceModel course)
        {
            bool flag = false;
            if (client != null)
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("courseCode", course.courseCode);
                values.Add("studentID", course.studentID);
                values.Add("startTime", course.startTime);
                values.Add("clockInTime", course.clockInTime);
                var response = await client.SetAsync(firebaseMsgDirectory, values);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    flag = true;
                }
            }
            return flag;
        }
        public async Task<List<AttendanceModel>> LoadMyCoursesStudentAttendance()
        {
            List<AttendanceModel> tempDataSetList = new List<AttendanceModel>();
            AttendanceModel tempDataSet = null;
            try
            {
                FirebaseResponse firebaseResponse = await client.GetAsync(firebaseMsgDirectory);
                string JsTxt = firebaseResponse.Body;
                if (JsTxt != "null")
                {
                    dynamic mresponse = JsonConvert.DeserializeObject<dynamic>(JsTxt);
                    foreach (var jresult in mresponse)
                    {
                        tempDataSet = JsonConvert.DeserializeObject<AttendanceModel>(((JProperty)jresult).Value.ToString());
                        tempDataSetList.Add(tempDataSet);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return tempDataSetList;
        }

        public async Task<AttendanceModel> LoadSingleStudentAttendance()
        {
            AttendanceModel tempDataSet = null;
            try
            {
                FirebaseResponse firebaseResponse = await client.GetAsync(firebaseMsgDirectory);
                string JsTxt = firebaseResponse.Body;
                if (JsTxt != "null")
                {
                    tempDataSet = JsonConvert.DeserializeObject<AttendanceModel>(JsTxt);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return tempDataSet;
        }

        public async Task<List<AttendanceModel>> LoadMyCoursStudAttendPercentage()
        {
            List<AttendanceModel> tempDataSetList = new List<AttendanceModel>();
            AttendanceModel tempDataSet = null;
            try
            {
                FirebaseResponse firebaseResponse = await client.GetAsync(firebaseMsgDirectory);
                string JsTxt = firebaseResponse.Body;
                if (JsTxt != "null")
                {
                    dynamic mresponse = JsonConvert.DeserializeObject<dynamic>(JsTxt);
                    NoOfLecture = 0;
                    foreach (var jresult in mresponse)
                    {
                        NoOfLecture += 1;
                        string date = ((JProperty)jresult).Name.ToString();
                        foreach(var result in jresult)
                        {
                            foreach(var mresult in result)
                            {
                                tempDataSet = JsonConvert.DeserializeObject<AttendanceModel>(((JProperty)mresult).Value.ToString());
                                tempDataSet.date = date;
                                tempDataSetList.Add(tempDataSet);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return tempDataSetList;
        }

        /*
        public async Task<List<ChatAndUserModel>> LoadAllFireBaseComplaint()
        {
            List<ChatAndUserModel> tempDataSetList = new List<ChatAndUserModel>();
            try
            {
                FirebaseResponse firebaseResponse = await client.GetAsync(firebaseMsgDirectory);
                string JsTxt = firebaseResponse.Body;
                if (JsTxt != "null")
                {
                    dynamic mresponse = JsonConvert.DeserializeObject<dynamic>(JsTxt);
                    foreach (var result in mresponse)
                    {
                        foreach (var mresult in result)
                        {
                            foreach (var jresult in mresult)
                            {
                                var tempDataSet = JsonConvert.DeserializeObject<ChatAndUserModel>(((JProperty)jresult).Value.ToString());
                                tempDataSetList.Add(tempDataSet);
                            }
                        }
                    }
                    // var tempDataSet = JsonConvert.DeserializeObject<List<GetComplaintModel>>(JsTxt);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return tempDataSetList;
        }
        */

        internal static void SendMailReciept(string message, string email_address)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("etldeveloperteam@gmail.com");
                mail.To.Add(email_address);
                mail.Subject = "Receipt for WMBS Payment";
                mail.Body = message;

                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("etldeveloperteam@gmail.com", "etldeveloperteam1377");

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

    }
}
