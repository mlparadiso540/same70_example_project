using System;
using System.Globalization;
using System.Windows.Data;

namespace SAME70_CLIENT
{

    /* Converts boolean value to fill color for IO indicators */
    public class IndicatorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return System.Windows.Media.Brushes.Green;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
