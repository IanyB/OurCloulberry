using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Library;
using StudentSystem.Library.Models;
using StudentSystem.WpfClient.Behavior;
using System.Windows.Input;
using StudentSystem.Library.Data;
using StudentSystem.Library.Helpers;
using System.Windows.Controls;

namespace StudentSystem.WpfClient.ViewModels
{
    public class ProfileViewModel: PropertyChange, INameViewModel
    {
        private RelayCommand editCommand;
        private UserFullModel _currentUser;

        public ICommand EditComand
        {
            get
            {
                if (this.editCommand == null)
                {
                    this.editCommand = new RelayCommand(this.HandleEditCommand);
                }
                return this.editCommand;
            }
        }

        private void HandleEditCommand(object parameter)
        {
            if (!string.IsNullOrEmpty(Username))
            {
                
                LoadData.PrintProfile(Username, AppCache.Config.AccessToken, result =>
                {
                    if (result != null)
                    {
                        //AppCache.Config.AccessToken = result.
                        //AppCache.Config.Username = result.Username;
                    }
                });
            }
        }

        public UserFullModel CurrentUser
        {
            get { return _currentUser; }
            set
            {
                if (_currentUser != value)
                {
                    _currentUser = value;
                    RaisePropertyChanged("CurrentUser");
                }
            }
        }

        public string Name { get; private set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public string UserType { get; set; }
        public string Website { get; set; }
        public string Gender { get; set; }
        public string Hometown { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public string Aboutme { get; set; }
        public string StudentNumber { get; set; }
        public string RegistrationDate { get; set; }
        public string LastVisit { get; set; }
        public string Courses { get; set; }

        public ProfileViewModel()
        {
            LoadData.PrintProfile(AppCache.Config.Username, AppCache.Config.AccessToken, result =>
            {
                if (result != null)
                {
                    this.CurrentUser = result;
                }
            });

            this.Name = "Welcome to the profile page";
        }
    }
}
