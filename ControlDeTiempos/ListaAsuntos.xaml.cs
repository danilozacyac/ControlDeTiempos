using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Graphs;
using ControlDeTiempos.Model;
using ControlDeTiempos.Reportes;
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
            //listaTrabajo = new TrabajoAsignadoModel().GetTrabajos();
            //GPorTrabajar.DataContext = listaTrabajo;
        }

        private void RBtnAgregarTrabajo_Click(object sender, RoutedEventArgs e)
        {
            VentanaCaptura ventana = new VentanaCaptura(listaTrabajo);
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void RBtnEditarTrabajo_Click(object sender, RoutedEventArgs e)
        {
            VentanaCaptura ventana = new VentanaCaptura(selectedTrabajo, false);
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

        private void RBtnEntregar_Click(object sender, RoutedEventArgs e)
        {
            new TrabajoAsignadoModel().UpdateFechaEntrega(selectedTrabajo);
        }

        private void RBtnHojaControl_Click(object sender, RoutedEventArgs e)
        {
            WordReport wrd = new WordReport();
            wrd.HojaDeControl(selectedTrabajo);
        }

        private void RBtnGraficas_Click(object sender, RoutedEventArgs e)
        {
            //ActiOper graph = new ActiOper();
            //graph.ShowDialog();
        }

        
    }
}
