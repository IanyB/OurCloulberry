using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StudentSystem.Library;
using StudentSystem.Library.Data;
using StudentSystem.Library.Helpers;
using StudentSystem.Library.Models;
using StudentSystem.WpfClient.Behavior;

namespace StudentSystem.WpfClient.ViewModels
{
    public class CourseViewModel: PropertyChange, INameViewModel
    {
        private ICommand addLecture;
        private ICommand editLecture;
        private ICommand deleteLecture;

        private string name;

        private ObservableCollection<LectureViewModel> lectures;

        private DateTime startDate;

        private DateTime endDate;

        private int lecturesPerWeek;

        private DateTime signUpDeadline;

        private string description;

        public CourseViewModel()
        {
            this.Lectures = new ObservableCollection<LectureViewModel>();
        }

        public CourseViewModel(int id)
        {
            this.Lectures = new ObservableCollection<LectureViewModel>();
            LoadData .GetCourseById(id, AppCache.Config.AccessToken, c =>
            {
                this.Name = c.CourseTitle;
                this.StartDate = c.StartDate;
                this.EndDate = c.EndDate;
                this.LecturesPerWeek = c.LecturesPerWeek;
                this.SignUpDeadline = c.SignUpDeadline;
                this.Description = c.Description;

                foreach (var lecture in c.Lectures)
                {
                    var newLecture = new LectureViewModel
                    {
                        Id = lecture.Id,
                        Name = lecture.Name,
                        HomeworkDeadline = lecture.HomeworkDeadline
                    };

                    foreach (var homework in lecture.Homeworks)
                    {
                        var newHomework = new HomeworkViewModel
                        {
                            Id = homework.Id, FileName = homework.FileName
                        };

                        newLecture.Homeworks.Add(newHomework);
                    }
                    
                    this.Lectures.Add(newLecture);
                }
            });
        }


        public int Id { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.RaisePropertyChanged("Name");
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }

            set
            {
                this.startDate = value;
                this.RaisePropertyChanged("StartDate");
            }
        }

        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }

            set
            {
                this.endDate = value;
                this.RaisePropertyChanged("EndDate");
            }
        }

        public int LecturesPerWeek
        {
            get
            {
                return this.lecturesPerWeek;
            }

            set
            {
                this.lecturesPerWeek = value;
                this.RaisePropertyChanged("LecturesPerWeek");
            }
        }

        public DateTime SignUpDeadline
        {
            get
            {
                return this.signUpDeadline;
            }

            set
            {
                this.signUpDeadline = value;
                this.RaisePropertyChanged("SignUpDeadline");
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                this.description = value;
                this.RaisePropertyChanged("Description");
            }
        }

        public ObservableCollection<LectureViewModel> Lectures
        {
            get
            {
                return this.lectures;
            }

            set
            {
                this.lectures = value;
                this.RaisePropertyChanged("Lectures");
            }
        }

        public ICommand AddLecture
        {
            get
            {
                if (this.addLecture == null)
                {
                    this.addLecture = new RelayCommand(this.HandleAddLecture);
                }

                return this.addLecture;
            }
        }



        private void HandleAddLecture(object parameter)
        {
            var newLecture = new AddLectureModel();

            LoadData.CreateLectures(newLecture, AppCache.Config.AccessToken, this.Id, () =>
            {
                var lecture = new LectureViewModel();
                lecture.Name = newLecture.Name;
                lecture.HomeworkDeadline = newLecture.HomeworkDeadline;
                this.Lectures.Add(lecture);
            });
        }
    }
}
