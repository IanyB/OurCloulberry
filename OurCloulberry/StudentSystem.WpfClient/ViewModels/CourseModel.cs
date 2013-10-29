using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.WpfClient.ViewModels
{
    public class CourseModel
    {
        public CourseModel()
        {
            this.Lectures = new List<LectureViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int LecturesPerWeek { get; set; }

        public DateTime SignUpDeadline { get; set; }

        public string Description { get; set; }

        public IEnumerable<LectureViewModel> Lectures { get; set; }
    }
}
