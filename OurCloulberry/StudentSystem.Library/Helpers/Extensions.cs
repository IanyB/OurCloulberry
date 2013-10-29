using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Library.Helpers
{
    public static class Extensions
    {
        public static void TryRemove(this ObservableCollection<string> source, string value)
        {
            if (source.Contains(value))
                source.Remove(value);
        }
    }
}
