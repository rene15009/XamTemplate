using System;
using System.Globalization;
using Xamarin.Forms;

namespace Rene.Xam.Extensions.Converters
{
    public class TextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string param = System.Convert.ToString(parameter) ?? "UPPER";
            if (value != null)
            {
                string valueString = value.ToString();

                switch (param.ToUpper())
                {
                    case "UPPER":
                        return valueString.ToUpper();
                    case "LOWER":
                        return valueString.ToLower();
                    default:
                        return valueString;
                }                                
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
