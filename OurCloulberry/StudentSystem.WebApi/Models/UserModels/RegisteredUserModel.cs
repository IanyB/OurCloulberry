using StudentSystem.Model;
using System.Runtime.Serialization;

namespace StudentSystem.WebApi.Models
{
    [DataContract]
    public class RegisteredUserModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "accessToken")]
        public string AccessToken { get; set; }
    }
}