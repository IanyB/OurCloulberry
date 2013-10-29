using StudentSystem.Library.Models;

namespace StudentSystem.WpfClient.Extensions
{
    public static class CourseModelExtensions
    {
        public static GlanceCourseModel ToGlanceCourseModel(this CourseModel courseModel)
        {
            var model = new GlanceCourseModel();
            model.CourseTitle = courseModel.CourseTitle;
            model.Description = courseModel.Description;
            model.EndDate = courseModel.EndDate;
            model.LecturesPerWeek = courseModel.LecturesPerWeek;
            model.SignUpDeadline = courseModel.SignUpDeadline;
            model.StartDate = courseModel.StartDate;
            return model;
        }
    }
}
