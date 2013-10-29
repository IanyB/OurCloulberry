using System.Runtime.Serialization;

namespace StudentSystem.Library.Models
{
    [DataContract]
    public class CourseSearchModel
    {
        [DataMember(Name="courseId")]
        public int Id { get; set; }
        [DataMember(Name = "courseName")]
        public string Name { get; set; }
    }
}