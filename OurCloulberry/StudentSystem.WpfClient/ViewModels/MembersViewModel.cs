using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using StudentSystem.Library;
using StudentSystem.Library.Models;
using StudentSystem.WpfClient.Behavior;
using StudentSystem.WpfClient.Views;

namespace StudentSystem.WpfClient.ViewModels
{
    public class MembersViewModel: PropertyChange
    {
        private ObservableCollection<MenuItemModel> _menuItems = new ObservableCollection<MenuItemModel>();
        private INameViewModel _currentViewModel;
        private UserControl _currentView;

        public ObservableCollection<MenuItemModel> MenuItems
        {
            get
            {
                return _menuItems;
            }
            set
            {
                if (_menuItems != value)
                {
                    _menuItems = value;
                    RaisePropertyChanged("MenuItems");
                }
            }
        }

        public MembersViewModel()
        {
            MenuItems.Add(new MenuItemModel()
            {
                Name = "Profile",
                CurrentViewModel = new ProfileViewModel(),
                IsActive = true
            });
            MenuItems.Add(new MenuItemModel()
            {
                Name = "Courses",
                CurrentViewModel = new CoursesViewModel(),
                IsActive = false
            });
            MenuItems.Add(new MenuItemModel()
            {
                Name = "Single Course",
                IsActive = false
            });
            MenuItems.Add(new MenuItemModel()
            {
                Name = "Search",
                CurrentViewModel = new SearchViewModel(),
                IsActive = false
            });
        }
    }
}
