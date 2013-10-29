using StudentSystem.Library.Models;
using System;

namespace StudentSystem.WpfClient.Extensions
{
    public static class GlanceCourseModelExtensions
    {
        public static CourseModel ToCourseModel(this GlanceCourseModel glanceCourseModel)
        {
            var courseModel = new CourseModel();
            courseModel.Description = glanceCourseModel.Description;
            courseModel.EndDate = (DateTime)glanceCourseModel.EndDate;
            courseModel.Id = (int)glanceCourseModel.CourseId;
            courseModel.LecturesPerWeek = glanceCourseModel.LecturesPerWeek;
            courseModel.CourseTitle = glanceCourseModel.CourseTitle;
            courseModel.SignUpDeadline = (DateTime)glanceCourseModel.SignUpDeadline;
            courseModel.StartDate = (DateTime)glanceCourseModel.StartDate;
            return courseModel;
        }
    }
}
