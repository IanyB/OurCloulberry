using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StudentSystem.Library.Models
{
    [DataContract]
    public class SearchResultModel
    {
        [DataMember(Name="users")]
        public List<UserSearchModel> Users { get; set; }
        [DataMember(Name = "courses")]
        public List<CourseSearchModel> Courses { get; set; }
    }
}