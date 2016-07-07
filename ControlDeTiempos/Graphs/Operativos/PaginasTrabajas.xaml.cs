using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;

namespace ControlDeTiempos.Graphs.Operativos
{
    /// <summary>
    /// Interaction logic for PaginasTrabajas.xaml
    /// </summary>
    public partial class PaginasTrabajas : UserControl
    {
        public PaginasTrabajas()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (PersonalCcst operativo in new PersonalModel().GetPersonalAsignado())
            {
                devchart1.Diagram.Series.Add(new GraficasModel().GetTotalPaginasTrabajadas(operativo, 1));
            }
        }
    }
}
