using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Library.Models
{
    public class LectureModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? HomeworkDeadline { get; set; }
        public IEnumerable<HomeworkModel> Homeworks { get; set; }
    }
}
