using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace Rene.Xam.Extensions.Converters
{
    public class EmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {          

            if (value is string)
            {
                return !string.IsNullOrEmpty(System.Convert.ToString(value));
            }
            else if (value is IEnumerable<object>)
            {
               return ((IEnumerable<object>)value).Any();
            }
            else if (value is null)
            {
                return false;
            }
            else
            {
               throw new NotImplementedException();
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
