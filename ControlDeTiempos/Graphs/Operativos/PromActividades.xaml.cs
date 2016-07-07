using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;

namespace ControlDeTiempos.Graphs.Operativos
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
