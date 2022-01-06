using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacialStudentAttendance.Controls
{
    public class AllModels
    { 

    }


    public class CourseModel
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string courseName { get; set; }
        public string courseCode { get; set; }
    }

    public class AttendanceModel
    {
        public string startTime { get; set; }
        public string clockInTime { get; set; }
        public string studentID { get; set; }
        public string courseCode { get; set; }
        public string date { get; set; }
        public string LectureNumber { get; set; }
        public string AttendNumber { get; set; }
        public string Percentage { get; set; }
    }

    public class UserModel
    {
        public string CourseCode { get; set; }
        public string ImgUrl { get; set; }
        public string UserType { get; set; }
        public string RegDate { get; set; } 
        public string Surname { get; set; }
        public string Othername { get; set; }
        public string Gender { get; set; }
        public string PhoneNo { get; set; }
        public string EmailAddr { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class FaceModel
    {
        public string Data { get; set; }
    }
}
