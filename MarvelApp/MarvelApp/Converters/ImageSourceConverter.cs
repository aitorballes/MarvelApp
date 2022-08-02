using System;
using System.Globalization;
using System.IO;
using System.Net;
using Xamarin.Forms;

namespace MarvelApp.Converters
{
    public class ImageSourceConverter : IValueConverter
    {
        private static readonly WebClient Client = new();
        public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return null;

            var byteArray = Client.DownloadData(value.ToString());
            return ImageSource.FromStream(() => new MemoryStream(byteArray));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}