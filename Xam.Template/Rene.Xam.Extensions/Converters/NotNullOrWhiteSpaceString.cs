using System;
using Xamarin.Forms;

namespace Rene.Xam.Extensions.Converters
{
    public class NotNullOrWhiteSpaceString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !string.IsNullOrWhiteSpace((String)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
