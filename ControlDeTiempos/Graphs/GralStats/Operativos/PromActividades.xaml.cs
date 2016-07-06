using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;
using DevExpress.Xpf.Charts;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlDeTiempos.Graphs.GralStats.Operativos
{
    /// <summary>
    /// Interaction logic for PromActividades.xaml
    /// </summary>
    public partial class PromActividades : UserControl
    {
        public PromActividades()
        {
            InitializeComponent();
        }

        

        private void Promedio_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (PersonalCcst operativo in new PersonalModel().GetPersonalAsignado())
            {
                Promedio.Diagram.Series.Add(new GraficasModel().GetTiempoPromedio(operativo));
            }
        }
    }
}
