using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Singleton;

namespace ControlDeTiempos.Graphs
{
    /// <summary>
    /// Interaction logic for PorOperativo.xaml
    /// </summary>
    public partial class PorOperativo
    {
        PersonalCcst selectedPersonal;

        public PorOperativo()
        {
            InitializeComponent();
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {

            Cbxoperativos.DataContext = PersonalSingleton.Personal.Where(n => n.TipoPersonal == 3);

            Cbxoperativos.SelectedIndex = 2;
        }

        private void Cbxoperativos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPersonal = Cbxoperativos.SelectedItem as PersonalCcst;

            Status.Operativo = selectedPersonal;
            Promedio.Operativo = selectedPersonal;
            Asuntos.Operativo = selectedPersonal;
            Distribucion.Operativo = selectedPersonal;
        }
    }
}
