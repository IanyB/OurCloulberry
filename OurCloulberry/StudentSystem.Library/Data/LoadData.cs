using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Library.Helpers;
using StudentSystem.Library.Models;
using StudentSystem.WpfClient.ViewModels;

namespace StudentSystem.Library.Data
{
    public static class LoadData
    {
        private const string BaseServicesUrl = "http://localhost:9290/api/";

        public static void Login(string username, string authenticationCode, Action<object> callback)
        {
            AppCache.Config.IsBusyPool.Add("Logging, please wait");
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += ((se, ea) =>
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
                try
                {
                    var loginResponse = HttpRequester.Post<LoginResponseModel>(BaseServicesUrl + "auth/token", userModel);
                    ea.Result = loginResponse;
                }
                catch (Exception ex)
                {
                    ea.Result = "User Not Found! Please try again.";
                }
                
            });
            bw.RunWorkerAsync();
            bw.RunWorkerCompleted += ((se, ea) =>
            {
                AppCache.Config.IsBusyPool.TryRemove("Logging, please wait");
                if (callback != null)
                {
                    callback(ea.Result);
                }
            });
        }

        public static void Register(string username, string email, string authenticationCode, Action<LoginResponseModel> callback)
        {
            AppCache.Config.IsBusyPool.Add("Registering, please wait");
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += ((se, ea) =>
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
                var loginResponse = HttpRequester.Post<LoginResponseModel>(BaseServicesUrl + "users/register", userModel);
                ea.Result = loginResponse;
            });
            bw.RunWorkerAsync();
            bw.RunWorkerCompleted += ((se, ea) =>
            {
                AppCache.Config.IsBusyPool.TryRemove("Registering, please wait");
                var result = ea.Result as LoginResponseModel;
                if (callback != null)
                {
                    callback(result);
                }
            });
        }

        public static void GetCourseById(int id, string sessionKey, Action<CourseModel> callback)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += ((se, ea) =>
            {
                var courseByIdResponse =
                    HttpRequester.Get<CourseModel>(BaseServicesUrl + "courses/" + id + "?sessionKey=" + sessionKey);
                ea.Result = courseByIdResponse;
            });
            bw.RunWorkerAsync();
            bw.RunWorkerCompleted += ((se, ea) =>
            {
                var result = ea.Result as CourseModel;
                if (callback != null)
                {
                    callback(result);
                }
            });
        }

        public static void LoadAllCourses(Action<IEnumerable<GlanceCourseModel>> callBack)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += ((se, ea) =>
            {
                var loginResponse = HttpRequester.Get<IEnumerable<GlanceCourseModel>>(BaseServicesUrl + "Courses");
                ea.Result = loginResponse;
            });

            backgroundWorker.RunWorkerCompleted += ((se, ea) =>
            {
                var result = ea.Result as IEnumerable<GlanceCourseModel>;
                if (callBack != null)
                {
                    callBack(result);
                }
            });

            backgroundWorker.RunWorkerAsync();
        }

        public static void AddCourse(GlanceCourseModel courseModel, string sessionKey, Action<GlanceCourseModel> callBack)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += ((se, ea) =>
            {
                var url = BaseServicesUrl + "admin/course?sessionKey=" + sessionKey;
                var model = HttpRequester.Post<GlanceCourseModel>(url, courseModel);
                ea.Result = model;
            });

            backgroundWorker.RunWorkerCompleted += ((se, ea) =>
            {
                if (callBack != null)
                {
                    callBack(ea.Result as GlanceCourseModel);
                }
            });

            backgroundWorker.RunWorkerAsync();
        }

        public static void DeactivateCourse(int courseId, string sessionKey, Action callBack)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += ((se, ea) =>
            {
                var url = string.Format("{0}admin/deletecourse/{1}?sessionKey={2}", BaseServicesUrl, courseId, sessionKey);
                HttpRequester.Delete(url);
            });

            backgroundWorker.RunWorkerCompleted += ((se, ea) =>
            {
                if (callBack != null)
                {
                    callBack();
                }
            });

            backgroundWorker.RunWorkerAsync();
        }

        public static void UpdateCourse(GlanceCourseModel courseModel, string sessionKey, Action callBack)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += ((se, ea) =>
            {
                var url = string.Format("{0}admin/updatecourse/{1}?sessionKey={2}", BaseServicesUrl, courseModel.CourseId, sessionKey);
                HttpRequester.Put(url, courseModel);
            });

            backgroundWorker.RunWorkerCompleted += ((se, ea) =>
            {
                if (callBack != null)
                {
                    callBack();
                }
            });

            backgroundWorker.RunWorkerAsync();
        }

        public static void Search(string qeryString, string authenticationCode, Action<SearchResultModel> callback)
        {
            AppCache.Config.IsBusyPool.Add("Searching, please wait");
            var bw = new BackgroundWorker();
            bw.DoWork += ((se, ea) =>
            {
                var searchResponse = HttpRequester.Get<SearchResultModel>(BaseServicesUrl + "search?q=" + qeryString);
                ea.Result = searchResponse;
            });
            bw.RunWorkerAsync();
            bw.RunWorkerCompleted += ((se, ea) =>
            {
                AppCache.Config.IsBusyPool.TryRemove("Searching, please wait");
                var result = ea.Result as SearchResultModel;
                if (callback != null)
                {
                    callback(result);
                }
            });
        }

        public static void CreateLectures(AddLectureModel newLecture, string sessionKey, int id, Action callback)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += ((se, ea) =>
            {
                HttpRequester.Post(BaseServicesUrl + "admin/addlecture/" + id + "?sessionKey=" + sessionKey, newLecture);
            });
            bw.RunWorkerAsync();
            bw.RunWorkerCompleted += ((se, ea) =>
            {
                if (callback != null)
                {
                    callback();
                }
            });
        }


        //public static void Edit(string username, string nickname, UserType userType,
        //    string website, Gender gender, string hometown, DateTime? birthday,
        //    string email, string occupation, string aboutme, int studentNumber, DateTime registerDate,
        //    DateTime lastVisit, IEnumerable<CourseUserModel> courses, Action<LoginResponseModel> callback)
        //{
        //    //Username, Nickname, UserType, Website, Gender,Hometown,
        //    //        Birthday, Email, Occupation, Aboutme, StudentNumber, RegistrationDate,
        //    //        LastVisit, Courses


        //    AppCache.Config.IsBusyPool.Add("Editing, please wait");
        //    BackgroundWorker bw = new BackgroundWorker();
        //    bw.DoWork += ((se, ea) =>
        //    {
        //        //Validation!!!!!
        //        //validate username
        //        //validate email
        //        //validate authentication code
        //        //use validation from WebAPI
        //        var userFullModel = new UserFullModel()
        //        {
        //            Username = username,
        //            Nickname = nickname,
        //            UserType = userType,
        //            WebSite=website,
        //            Gender=gender,
        //            Hometown=hometown,
        //            Birthday=birthday,
        //            Email=email,
        //            Occupation=occupation,
        //            AboutMe=aboutme,
        //            StudentNumber=studentNumber,
        //            RegistrationDate=registerDate,
        //            LastVisit=lastVisit,
        //            Courses=courses,
        //        };
        //        var loginResponse = HttpRequester.Get<UserFullModel>(BaseServicesUrl + "users/register", userFullModel);
        //        ea.Result = loginResponse;
        //    });
        //    bw.RunWorkerAsync();
        //    bw.RunWorkerCompleted += ((se, ea) =>
        //    {
        //        AppCache.Config.IsBusyPool.TryRemove("Registering, please wait");
        //        var result = ea.Result as LoginResponseModel;
        //        if (callback != null)
        //        {
        //            callback(result);
        //        }
        //    });
        //}

        public static void PrintProfile(string username, string accessToken, Action<UserFullModel> callback)
        {
            AppCache.Config.IsBusyPool.Add("Loading user profile, please wait");
            var bw = new BackgroundWorker();
            bw.DoWork += ((se, ea) =>
            {
                var searchResponse = HttpRequester.Get<UserFullModel>(BaseServicesUrl + "/users/GetUser/" + username + "/?sessionKey=" + accessToken);
                // // api/users/get/{id}
                ea.Result = searchResponse;
            });
            bw.RunWorkerAsync();
            bw.RunWorkerCompleted += ((se, ea) =>
            {
                AppCache.Config.IsBusyPool.TryRemove("Loading user profile, please wait");
                var result = ea.Result as UserFullModel;
                if (callback != null)
                {
                    callback(result);
                }
            });
        }
    }
}
