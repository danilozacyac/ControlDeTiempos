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
            DateTime fechaIndicada = System.Convert.ToDateTime(value);

            TimeSpan remain = fechaIndicada.Subtract(DateTime.Now);

            if (remain.Days >=0 && remain.Hours > 1)
                return new SolidColorBrush(Colors.Green);
            if (remain.Days == 0 && remain.Hours == 0)
                return new SolidColorBrush(Colors.Yellow);
            else
                return new SolidColorBrush(Colors.Red);


        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}