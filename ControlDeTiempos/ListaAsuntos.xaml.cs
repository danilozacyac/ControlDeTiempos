using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace ControlDeTiempos
{
    /// <summary>
    /// Interaction logic for ListaAsuntos.xaml
    /// </summary>
    public partial class ListaAsuntos
    {
        ObservableCollection<TrabajoAsignado> listaTrabajo;
        TrabajoAsignado selectedTrabajo;
        public ListaAsuntos()
        {
            InitializeComponent();
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            listaTrabajo = new TrabajoAsignadoModel().GetTrabajos();
            GPorTrabajar.DataContext = listaTrabajo;
        }

        private void RBtnAgregarTrabajo_Click(object sender, RoutedEventArgs e)
        {
            VentanaCaptura ventana = new VentanaCaptura(listaTrabajo);
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void RBtnVerTrabajo_Click(object sender, RoutedEventArgs e)
        {
            VentanaCaptura ventana = new VentanaCaptura(selectedTrabajo, true);
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void GPorTrabajar_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            selectedTrabajo = GPorTrabajar.SelectedItem as TrabajoAsignado;
        }
    }
}
