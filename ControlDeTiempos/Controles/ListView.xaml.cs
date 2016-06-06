using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;

namespace ControlDeTiempos.Controles
{
    /// <summary>
    /// Interaction logic for ListView.xaml
    /// </summary>
    public partial class ListView : UserControl
    {
        ObservableCollection<TrabajoAsignado> listaTrabajo;
        TrabajoAsignado selectedTrabajo;

        public ListView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listaTrabajo = new TrabajoAsignadoModel().GetTrabajos();
            GPorTrabajar.DataContext = listaTrabajo;
        }

        private void GPorTrabajar_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            selectedTrabajo = GPorTrabajar.SelectedItem as TrabajoAsignado;
        }

       
    }
}
