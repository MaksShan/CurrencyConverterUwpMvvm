using System;
using Windows.UI.Xaml.Data;

namespace ConverterApp.Infrastructure.Converters
{
    public class DecimalToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            decimal dec;

            if (value == null)
            { dec = 0; }
            else
            { dec = (decimal)value; }

            return dec.ToString("0.###");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string text;

            text = value.ToString();
            
            if (string.IsNullOrEmpty(text))
            { text = "0"; }

            decimal dec;

            try 
            {
                dec = decimal.Parse(text);
            }
            catch (FormatException)
            {
                dec = 0;
            }

            return dec;
        }
    }
}