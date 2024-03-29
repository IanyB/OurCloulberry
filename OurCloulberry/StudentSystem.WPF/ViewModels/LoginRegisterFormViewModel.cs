﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using StudentSystem.WPF.Behavior;
using StudentSystem.WPF.Data;
using StudentSystem.WPF.Helper;

namespace StudentSystem.WPF.ViewModels
{
    public class LoginRegisterFormViewModel : ViewModelBase, IPageViewModel
    {
        private string message;
        private ICommand loginCommand;
        private ICommand registerCommand;

        public string Name
        {
            get
            {
                return "Login Form";
            }
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
                this.OnPropertyChanged("Message");
            }
        }

        public ICommand Login
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

        public ICommand Register
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

        public event EventHandler<LoginSuccessArgs> LoginSuccess;

        public LoginRegisterFormViewModel()
        {
            this.Username = "DonchoMinkov";
            this.Email = "Minkov@doncho.com";
        }

        private void HandleRegisterCommand(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;
            //SHA1 sha = new SHA1CryptoServiceProvider();
            //var passwordBytes = Encoding.Default.GetBytes(password);
            //passwordBytes = Encoding.Convert(Encoding.Default,Encoding.UTF8,passwordBytes);
            //var authenticationCodeBytes = sha.ComputeHash(passwordBytes);
            //var authenticationCode = Encoding.UTF8.GetString(authenticationCodeBytes);

            var authenticationCode = this.GetSHA1HashData(password);

            DataPersister.RegisterUser(this.Username, this.Email, authenticationCode);
            this.HandleLoginCommand(parameter);
        }

        private void HandleLoginCommand(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;
            var authenticationCode = this.GetSHA1HashData(password);

            var username = DataPersister.LoginUser(this.Username, authenticationCode);

            if (!string.IsNullOrEmpty(username))
            {
                this.RaiseLoginSuccess(username);
            }
        }

        private string GetSHA1HashData(string data)
        {
            return CalculateSHA1(data, Encoding.Default);
        }

        /// <summary>
        /// Calculates SHA1 hash
        /// </summary>
        /// <param name="text">input string</param>
        /// <param name="enc">Character encoding</param>
        /// <returns>SHA1 hash</returns>
        public static string CalculateSHA1(string text, Encoding enc)
        {
            // Convert the input string to a byte array
            byte[] buffer = enc.GetBytes(text);

            // In doing your test, you won't want to re-initialize like this every time you test a 
            // string.
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();

            // The replace won't be necessary for your tests so long as you are consistent in what
            // you compare.    
            string hash = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");

            return hash;
        }

        protected void RaiseLoginSuccess(string username)
        {
            if (this.LoginSuccess != null)
            {
                this.LoginSuccess(this, new LoginSuccessArgs(username));
            }
        }
    }
}