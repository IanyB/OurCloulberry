using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.WPF.Models;

namespace StudentSystem.WPF.Data
{
    public class DataPersister
    {
        protected static string AccessToken { get; set; }

        private const string BaseServicesUrl = "http://localhost:9290/api/";

        internal static void RegisterUser(string username, string email, string authenticationCode)
        {
            //Validation!!!!!
            //validate username
            //validate email
            //validate authentication code
            //use validation from WebAPI
            var userModel = new UserModel()
            {
                Username = username,
                Email = email,
                AuthCode = authenticationCode
            };
            HttpRequester.Post(BaseServicesUrl + "users/register",
                userModel);
        }

        internal static string LoginUser(string username, string authenticationCode)
        {
            //Validation!!!!!
            //validate username
            //validate email
            //validate authentication code
            //use validation from WebAPI
            var userModel = new UserModel()
            {
                Username = username,
                AuthCode = authenticationCode
            };
            var loginResponse = HttpRequester.Post<LoginResponseModel>(BaseServicesUrl + "auth/token", userModel);
            AccessToken = loginResponse.AccessToken;
            return loginResponse.Username;
        }

        internal static bool LogoutUser()
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;
            var isLogoutSuccessful = HttpRequester.Put(BaseServicesUrl + "users/logout", headers);
            return isLogoutSuccessful;
        }
    }
}
