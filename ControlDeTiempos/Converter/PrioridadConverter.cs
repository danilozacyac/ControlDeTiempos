using System;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace ControlDeTiempos.Converter
{
    public class PrioridadConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int medio = value as int? ?? 0;

            switch (medio)
            {
                case 1: return new SolidColorBrush(Colors.Black);  
                case 2: return new SolidColorBrush(Colors.Red);  // 
                case 3: return new SolidColorBrush(Colors.Green); //
                case 4: return new SolidColorBrush(Colors.Blue);  //
                case 5: return new SolidColorBrush(Colors.Purple);     //
                
                default: return new SolidColorBrush(Colors.Black);
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
