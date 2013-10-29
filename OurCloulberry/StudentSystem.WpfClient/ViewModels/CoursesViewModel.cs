using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Library;
using StudentSystem.Library.Models;
using System.Collections.ObjectModel;
using StudentSystem.Library.Data;
using System.Windows.Input;
using StudentSystem.WpfClient.Behavior;
using StudentSystem.WpfClient.Extensions;
using StudentSystem.Library.Helpers;

namespace StudentSystem.WpfClient.ViewModels
{
    public class CoursesViewModel : PropertyChange, INameViewModel
    {
        private ObservableCollection<CourseModel> courses;
        private ICommand goToCourse;
        private CourseModel currentCourse;
        private ICommand addCourse;
        private ICommand editCourse;
        private ICommand deleteCourse;

        public CoursesViewModel()
        {
            this.Name = "Welcome to the courses page";
        }

        public string Name { get; private set; }

        public CourseModel CurrentCourse
        {
            get
            {
                if (this.currentCourse == null)
                {
                    this.currentCourse = new CourseModel();
                }

                return this.currentCourse;
            }

            set
            {
                if (this.currentCourse != value)
                {

                    this.currentCourse = value;
                    this.RaisePropertyChanged("CurrentCourse");
                }
            }
        }

        public ObservableCollection<CourseModel> Courses
        {
            get
            {
                if (this.courses == null)
                {
                    this.Courses = new ObservableCollection<CourseModel>();
                    AppCache.Config.IsBusyPool.Add("Loading, please wait");
                    LoadData.LoadAllCourses(c =>
                    {
                        AppCache.Config.IsBusyPool.TryRemove("Loading, please wait");
                        foreach (var course in c)
                        {
                            this.courses.Add(course.ToCourseModel());
                        }
                    });
                }

                return this.courses;
            }

            set
            {
                this.courses = value;
                this.RaisePropertyChanged("Courses");
            }
        }

        public ICommand GoToCourse
        {
            get
            {
                if (this.goToCourse == null)
                {
                    this.goToCourse = new RelayCommand(this.HandleGoToCourse);
                }

                return this.goToCourse;
            }
        }

        public ICommand AddCourse
        {
            get
            {
                if (this.addCourse == null)
                {
                    this.addCourse = new RelayCommand(this.HandleAddCourse);
                }

                return this.addCourse;
            }
        }

        public ICommand EditCourse
        {
            get
            {
                if (this.editCourse == null)
                {
                    this.editCourse = new RelayCommand(this.HandleEditCourse);
                }

                return this.editCourse;
            }
        }

        public ICommand DeleteCourse
        {
            get
            {
                if (this.deleteCourse == null)
                {
                    this.deleteCourse = new RelayCommand(this.HandleDeleteCourse);
                }

                return this.deleteCourse;
            }
        }

        private void HandleDeleteCourse(object courseObject)
        {
            var course = courseObject as CourseModel;
            LoadData.DeactivateCourse(course.Id, AppCache.Config.AccessToken, () =>
                {

                });
        }

        private void HandleGoToCourse(object courseObject)
        {
            //this.CurrentCourse = courseObject as CourseModel;
        }

        private void HandleAddCourse(object obj)
        {
            var model = this.CurrentCourse.ToGlanceCourseModel();
            LoadData.AddCourse(model, AppCache.Config.AccessToken, m =>
            {
                model.CourseId = m.CourseId;
                var newModel = model.ToCourseModel();
                this.Courses.Add(newModel);
            });
        }

        private void HandleEditCourse(object courseObject)
        {
            var model = this.CurrentCourse.ToGlanceCourseModel();
            string message = "Updating, please wait.";
            AppCache.Config.IsBusyPool.Add(message);
            LoadData.UpdateCourse(model, AppCache.Config.AccessToken, () =>
            {
                AppCache.Config.IsBusyPool.TryRemove(message);
            });
        }
    }
}
