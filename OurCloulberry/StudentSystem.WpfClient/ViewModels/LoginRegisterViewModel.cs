using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using StudentSystem.Library;
using StudentSystem.Library.Data;
using StudentSystem.Library.Helpers;
using StudentSystem.Library.Models;
using StudentSystem.WpfClient.Behavior;

namespace StudentSystem.WpfClient.ViewModels
{
    public class LoginRegisterViewModel: PropertyChange
    {
        private RelayCommand loginCommand;
        private RelayCommand registerCommand;
        private string _errorMessage;

        public string Username { get; set; }

        public string Email { get; set; }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    RaisePropertyChanged("ErrorMessage");
                }
            }
        }

        public LoginRegisterViewModel()
        {
            this.Username = "janyBs";
            this.Email = "yancho@ibashev.com";
        }
        public ICommand LoginCommand
        {
            get
            {
                if (this.loginCommand == null)
                {
                    this.loginCommand = new RelayCommand(this.HandleLoginCommand);
                }
                return this.loginCommand;
            }
        }

        private void HandleLoginCommand(object parameter)
        {
            if (!string.IsNullOrEmpty(Username))
            {
                var passwordBox = parameter as PasswordBox;
                var password = passwordBox.Password;
                var authenticationCode = this.GetSHA1HashData(password);

                LoadData.Login(Username, authenticationCode, result =>
                {
                    var loginResult = result as LoginResponseModel;
                    if (loginResult != null)
                    {
                        AppCache.Config.AccessToken = loginResult.AccessToken;
                        AppCache.Config.Username = loginResult.Username;
                    }
                    else
                    {
                        this.ErrorMessage = result.ToString();
                    }
                });
            }
        }

        public ICommand RegisterCommand
        {
            get
            {
                if (this.registerCommand == null)
                {
                    this.registerCommand = new RelayCommand(this.HandleRegisterCommand);
                }
                return this.registerCommand;
            }
        }

        private void HandleRegisterCommand(object parameter)
        {
            if (!string.IsNullOrEmpty(Username))
            {
                var passwordBox = parameter as PasswordBox;
                var password = passwordBox.Password;
                var authenticationCode = this.GetSHA1HashData(password);

                LoadData.Register(Username, Email, authenticationCode, result =>
                {
                    if (result != null)
                    {
                        AppCache.Config.AccessToken = result.AccessToken;
                        AppCache.Config.Username = result.Username;
                    }
                });
            }
        }

        private string GetSHA1HashData(string data)
        {
            return Utils.CalculateSHA1(data, Encoding.Default);
        }
    }
}
