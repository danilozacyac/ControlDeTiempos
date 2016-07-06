using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;
using DevExpress.Xpf.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace ControlDeTiempos.Graphs.GralStats
{
    /// <summary>
    /// Interaction logic for Generales.xaml
    /// </summary>
    public partial class Generales 
    {

        

        public Generales()
        {
            InitializeComponent();
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (PersonalCcst operativo in new PersonalModel().GetPersonalAsignado())
            {
                devchart1.Diagram.Series.Add(new GraficasModel().GetTotalPaginasTrabajadas(operativo, 1));
            }

            Promedio.Operativo = null;
            Tiempo.Operativo = null;
            //devchart1.Diagram.Series.Add(devSeries);
        }
    }
}
