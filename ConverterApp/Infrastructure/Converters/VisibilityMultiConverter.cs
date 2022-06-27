using System;
using System.Globalization;
using Windows.UI.Xaml;
using Cimbalino.Toolkit.Converters;

namespace ConverterApp.Infrastructure.Converters
{
    public class VisibilityMultiConverter : MultiValueConverterBase
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values[0] != null && values[0] == values[1] ? Visibility.Visible : Visibility.Collapsed;
        }

        public override object[] ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
