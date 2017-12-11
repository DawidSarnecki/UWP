
namespace Stopwatch.Stopwatch.Converters
{
    using System;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml;

    public class BoolNotConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is bool && ((bool)value) == false) ? true : false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
