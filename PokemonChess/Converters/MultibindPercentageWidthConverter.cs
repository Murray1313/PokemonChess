using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PokemonChess.Converters
{
    public class MultibindPercentageWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[1] != null && values[1] != DependencyProperty.UnsetValue)
            {
                return System.Convert.ToDouble(values[0]) * System.Convert.ToDouble(values[1]);
            }
            return 0.0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
