using System;
using System.Globalization;
using Xamarin.Forms;

namespace Rene.Xam.Extensions.Converters
{
    public class ResumeTextConverter : IValueConverter
    {
        /// <summary>
        /// Recorta un texto hasta el último espacio dentro del límite de caracteres y añade ... en caso que el texto sea mayor al límite
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //ing param = System.Convert.ToInt16(parameter) ?? Int16.MaxValue;

            var strParam = System.Convert.ToString(parameter) ?? string.Empty;
            short maxLength;       

            if (!short.TryParse(strParam, out maxLength))
            {
                maxLength = short.MaxValue;
            }

            if (value != null)
            {
                // Eliminar espacios en blanco al principio y reemplazar saltos de linea.
                string valueString = value.ToString().TrimStart().Replace("\r\n", System.Environment.NewLine).Replace("\r", System.Environment.NewLine).Replace(System.Environment.NewLine, " ");
                if (valueString.Length <= maxLength)
                {
                    return valueString;
                }

                //buscamos el últimos espacio dentro del texto recortado para no partir palabras
                valueString = valueString.Substring(0, maxLength);

                int lastSpacePosition = valueString.LastIndexOf(" ", StringComparison.Ordinal);

                if (lastSpacePosition > -1)
                {
                    valueString = valueString.Substring(0, lastSpacePosition + 1);
                }

                return $"{valueString} ...";

            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
