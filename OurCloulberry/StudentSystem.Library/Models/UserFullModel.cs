using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Library.Models
{
    public class UserFullModel
    {
        public string Username { get; set; }

        public string Nickname { get; set; }

        public UserType UserType { get; set; }

        public string WebSite { get; set; }

        public Gender Gender { get; set; }

        public string Hometown { get; set; }

        public DateTime? Birthday { get; set; }

        public string Email { get; set; }

        public string Occupation { get; set; }

        public string AboutMe { get; set; }

        public int StudentNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime LastVisit { get; set; }

        //public IEnumerable<CourseUserModel> Courses { get; set; }

        //public string AccessToken { get; set; }
    }
}
