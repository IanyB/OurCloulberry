using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.WpfClient.ViewModels
{
    public class LectureViewModel
    {
        public LectureViewModel()
        {
            this.Homeworks = new ObservableCollection<HomeworkViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? HomeworkDeadline { get; set; }
        public ObservableCollection<HomeworkViewModel> Homeworks { get; set; }
    }
}
