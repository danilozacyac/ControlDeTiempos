using System;
using System.Linq;
using System.Windows.Data;
using ControlDeTiempos.Singleton;

namespace ControlDeTiempos.Converter
{
    public class TipoAsuntoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                int number = 0;
                int.TryParse(value.ToString(), out number);

                if (number > 0)
                    return TipoAsuntoSingleton.TipoAsunto.SingleOrDefault(n => n.IdTipoAsunto == number).Descripcion;
                else
                    return " ";
            }

            return " ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
