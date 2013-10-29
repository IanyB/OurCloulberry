using System.Windows.Input;

namespace StudentSystem.Library.Models
{
    public class MenuItemModel
    {
        public string Name { get; set; }
        public ICommand ActivateCommand { get; set; }
        public bool IsActive { get; set; }

        public INameViewModel CurrentViewModel { get; set; }

    }
}
