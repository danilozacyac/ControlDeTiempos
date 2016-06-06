using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ControlDeTiempos.Converter
{
    public class ATiempoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            
                int number = 0;
                int.TryParse(value.ToString(), out number);

                if (number == 1)
                    return @"Resources\good.png";
                else
                    return @"Resources\bad.png";

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}