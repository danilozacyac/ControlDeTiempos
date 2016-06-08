using System;
using System.Linq;
using System.Windows.Data;

namespace ControlDeTiempos.Converter
{
    public class TipoDocumentoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                int number = 0;
                int.TryParse(value.ToString(), out number);

                switch (number)
                {
                    case 1: return "Tesis";
                    case 2: return "Ejecutoria";
                    case 4: return "Voto(s)";
                    case 3: return "Tesis y Ejecutoria";
                    case 5: return "Tesis y Voto(s)";
                    case 6: return "Ejecutoria y Voto(s)";
                    case 7: return "Tesis, Ejecutoria y Voto(s)";
                }
            }

            return " ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
