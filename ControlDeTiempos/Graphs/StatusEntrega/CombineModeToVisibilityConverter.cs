using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Telerik.Charting;

namespace ControlDeTiempos.Graphs.StatusEntrega
{
    public class CombineModeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ChartSeriesCombineMode combineMode = (ChartSeriesCombineMode)value;
            if (combineMode == ChartSeriesCombineMode.Stack100)
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
