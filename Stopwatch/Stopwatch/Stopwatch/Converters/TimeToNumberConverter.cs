
namespace Stopwatch.Converters
{
    using System;
    using Windows.UI.Xaml.Data;

    public class TimeToNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is decimal)
            {
                return ((decimal)value).ToString("00.00");
            };

            if (value is int)
            {
                if (parameter != null)
                {
                    return ((int)value).ToString(parameter.ToString());
                }

                return ((int)value).ToString("d1");
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
