using StudentSystem.Library.Models;
using StudentSystem.WpfClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace StudentSystem.WpfClient.Converters
{
    public class CourseModelToCourseViewModelConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var courseModel = value as CourseModel;
            if (courseModel.Id != 0)
            {
                var courseViewModel = new CourseViewModel(courseModel.Id);
                return courseViewModel;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
