﻿using System;
using System.Linq;
using System.Windows.Data;
using ControlDeTiempos.Singleton;

namespace ControlDeTiempos.Converter
{
    public class PersonalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                int number = 0;
                int.TryParse(value.ToString(), out number);

                return PersonalSingleton.Personal.SingleOrDefault(n => n.IdPersonal == number).NombreCompleto;
            }

            return " ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
