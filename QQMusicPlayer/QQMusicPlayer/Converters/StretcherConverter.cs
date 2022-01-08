using System;
using System.Windows.Data;
using System.Globalization;

namespace QQMusicPlayer.Converters
{
    [ValueConversion(typeof(double), typeof(double))]
    class StretcherConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var reValue = System.Convert.ToDouble(value);
            if (reValue == 0)
                reValue = 810;
            var bias = 0.12 * (1 - Math.Pow(810 / reValue, 3));

            return reValue * 0.2 * (1 - bias);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
