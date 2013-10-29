using System;
using System.Collections.ObjectModel;
using StudentSystem.Library.Models;

namespace StudentSystem.Library
{
    public class Configuration : PropertyChange
    {

        private Uri _navigationSource = new Uri("Views/LoginRegister.xaml", UriKind.Relative);

        public Uri NavigationSource
        {
            get { return _navigationSource; }
            set
            {
                if (_navigationSource != value)
                {
                    _navigationSource = value;
                    RaisePropertyChanged("NavigationSource");
                }
            }
        }

        private string _accessToken = string.Empty;

        public string AccessToken
        {
            get { return _accessToken; }
            set
            {
                if (_accessToken != value)
                {
                    AppCache.Config.NavigationSource = new Uri("/StudentSystem.WpfClient;component/Views/MembersPage.xaml", UriKind.Relative);
                    _accessToken = value;
                    RaisePropertyChanged("AccessToken");
                }
            }
        }

        private string _username = string.Empty;

        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    RaisePropertyChanged("Username");
                }
            }
        }

        #region BusyIndicator

        private ObservableCollection<string> _isBusyPool = new ObservableCollection<string>();
        public ObservableCollection<string> IsBusyPool
        {
            get { return _isBusyPool; }
            set
            {
                if (_isBusyPool != value)
                {
                    _isBusyPool = value;
                    RaisePropertyChanged("IsBusyPool");
                }
            }
        }

        private bool _showMessageBox = false;

        public bool ShowMessageBox
        {
            get { return _showMessageBox; }
            set
            {
                if (_showMessageBox != value)
                {
                    _showMessageBox = value;
                    RaisePropertyChanged("ShowMessageBox");
                }
            }
        }

        //private MessageBoxDataContext _messageBoxDataContext = new MessageBoxDataContext();
        //public MessageBoxDataContext MessageBoxDataContext
        //{
        //    get { return _messageBoxDataContext; }
        //    set
        //    {
        //        _messageBoxDataContext = value;
        //        RaisePropertyChanged("MessageBoxDataContext");
        //    }
        //}

        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    RaisePropertyChanged("IsBusy");
                }
            }
        }

        private string _isBusyMessage = "Please Wait...";
        public string IsBusyMessage
        {
            get { return _isBusyMessage; }
            set
            {
                if (_isBusyMessage != value)
                {
                    _isBusyMessage = value;
                    RaisePropertyChanged("IsBusyMessage");
                }
            }
        }

        #endregion

       
    }
}