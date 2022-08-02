using System;
using System.Globalization;
using Xamarin.Forms;

namespace MarvelApp.Converters
{
    public class BooleanToObjectConverter<T> : IValueConverter
    {
        public T? FalseObject { set; get; }

        public T? TrueObject { set; get; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b && TrueObject is not null && FalseObject is not null)
            {
                return  b ? TrueObject : FalseObject;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((T) value).Equals(TrueObject);
        }
    }
}