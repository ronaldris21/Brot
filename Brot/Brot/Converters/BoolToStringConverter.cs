﻿

namespace Brot.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;
    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool like = (bool)value;
            return like ? DLL.constantes.likeImage : DLL.constantes.dislikeImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
