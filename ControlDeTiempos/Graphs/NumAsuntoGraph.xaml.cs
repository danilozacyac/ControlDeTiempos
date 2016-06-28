using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ControlDeTiempos.Model;
using Telerik.Windows.Controls.Charting;

namespace ControlDeTiempos.Graphs
{
    /// <summary>
    /// Interaction logic for NumAsuntoGraph.xaml
    /// </summary>
    public partial class NumAsuntoGraph : UserControl
    {
        public NumAsuntoGraph()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Rad6M.IsChecked = true;
            
        }

        private void Rad3M_Checked(object sender, RoutedEventArgs e)
        {
            RemoveSeries();
            GetSeries(DateTime.Now.AddMonths(-2));
            GetSeries(DateTime.Now.AddMonths(-1));
            GetSeries(DateTime.Now);
        }

        private void Rad6M_Checked(object sender, RoutedEventArgs e)
        {
            RemoveSeries();
            GetSeries(DateTime.Now.AddMonths(-5));
            GetSeries(DateTime.Now.AddMonths(-4));
            GetSeries(DateTime.Now.AddMonths(-3));
            GetSeries(DateTime.Now.AddMonths(-2));
            GetSeries(DateTime.Now.AddMonths(-1));
            GetSeries(DateTime.Now);
        }

        private void Rad12M_Checked(object sender, RoutedEventArgs e)
        {
            RemoveSeries();
            GetSeries(DateTime.Now.AddMonths(-11));
            GetSeries(DateTime.Now.AddMonths(-10));
            GetSeries(DateTime.Now.AddMonths(-9));
            GetSeries(DateTime.Now.AddMonths(-8));
            GetSeries(DateTime.Now.AddMonths(-7));
            GetSeries(DateTime.Now.AddMonths(-6));
            GetSeries(DateTime.Now.AddMonths(-5));
            GetSeries(DateTime.Now.AddMonths(-4));
            GetSeries(DateTime.Now.AddMonths(-3));
            GetSeries(DateTime.Now.AddMonths(-2));
            GetSeries(DateTime.Now.AddMonths(-1));
            GetSeries(DateTime.Now);
        }


        public void GetSeries(DateTime getMonthInfo)
        {

            DataSeries dataSeries = new DataSeries() { Definition = new BarSeriesDefinition() };
            string legendLabel = String.Empty;

            foreach (NumeroAsuntos num in new GraficasModel().GetTotalAsuntoByMesYear(getMonthInfo.Month,getMonthInfo.Year))
            {
                dataSeries.Add(new DataPoint() { XCategory = num.Nombre, YValue = num.Total });
                legendLabel = num.Periodo;
            }
            dataSeries.LegendLabel = legendLabel;

            RchNumAsun.DefaultView.ChartArea.DataSeries.Add(dataSeries);
        }

        public void RemoveSeries()
        {
            while (RchNumAsun.DefaultView.ChartArea.DataSeries.Count > 0)
            {
                RchNumAsun.DefaultView.ChartArea.DataSeries.RemoveAt(0);
            }
        }

    }
}
