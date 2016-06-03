using ControlDeTiempos.Singleton;
using System;
using System.Linq;
using System.Windows.Data;

namespace ControlDeTiempos.Converter
{
    public class TipoVotoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
                if (value != null)
                {
                    int number = 0;
                    int.TryParse(value.ToString(), out number);

                    return TipoVotoSingleton.TipoVoto.SingleOrDefault(n => n.IdTipoAsunto == number).Descripcion;
                }

                return " ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
