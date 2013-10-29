using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StudentSystem.Library.Models
{
    public class CourseModel
    {
        public string Username { get; set; }

        public int Id { get; set; }

        public string CourseTitle { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int LecturesPerWeek { get; set; }

        public DateTime SignUpDeadline { get; set; }

        public string Description { get; set; }

        public IEnumerable<LectureModel> Lectures { get; set; }
    }
}
