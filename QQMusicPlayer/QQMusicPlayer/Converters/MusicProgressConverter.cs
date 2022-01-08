using System;
using System.Windows.Data;

namespace QQMusicPlayer.Converters
{
    [ValueConversion(typeof(double), typeof(double))]
    class MusicProgressConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var v = (double)value;
            if (v == 0.0)
                return 100.0;
            return (double)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (double)value;
        }
    }
}
