using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FinalDB
{
    public class AlternatingRowBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int index)
            {
                if (index % 2 == 0)
                {
                    return new SolidColorBrush(Colors.White); // Even rows
                }
                else
                {
                    return new SolidColorBrush(Color.FromRgb(248, 248, 248)); // Odd rows (light grey)
                }
            }
            return new SolidColorBrush(Colors.White); // Default
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}