using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Library.Models
{
    public class GlanceCourseModel
    {
        public int? CourseId { get; set; }

        public string CourseTitle { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int LecturesPerWeek { get; set; }

        public DateTime? SignUpDeadline { get; set; }
    }
}
