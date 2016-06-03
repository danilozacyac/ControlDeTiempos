using System;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace ControlDeTiempos.Converter
{
    public class EstadoEntregaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime fechaIndicada = System.Convert.ToDateTime( value);

            if(fechaIndicada < DateTime.Now)
                return new SolidColorBrush(Colors.Red);
            else
                return new SolidColorBrush(Colors.Green);
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}