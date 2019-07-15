using System;
using System.Globalization;
using Xamarin.Forms;

namespace GamesCompendium.Converters
{
    public class PlayerSymbolColourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null && (string)value == "O")
            {
                return "Black";
            }
            return "Red";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
