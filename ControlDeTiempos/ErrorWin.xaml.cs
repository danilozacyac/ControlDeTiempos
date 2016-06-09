using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Formularios;
using ControlDeTiempos.Model;

namespace ControlDeTiempos
{
    /// <summary>
    /// Interaction logic for ErrorWin.xaml
    /// </summary>
    public partial class ErrorWin
    {
        TrabajoAsignado trabajo;
        ErrorOperativo selecteddError;
        ObservableCollection<ErrorOperativo> listaErrores;

        public ErrorWin(TrabajoAsignado trabajo)
        {
            InitializeComponent();
            this.trabajo = trabajo;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            listaErrores = new ErrorModel().GetErroresByTrabajo(trabajo.IdTrabajo);
            RLstErrores.DataContext = listaErrores;
        }

        private void RadListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selecteddError = RLstErrores.SelectedItem as ErrorOperativo;
            this.DataContext = selecteddError;
        }

        private void BtnVerArchivo_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(selecteddError.NombreArchivo);
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            AltaErrores alta = new AltaErrores(trabajo.IdTrabajo);
            alta.Owner = this;
            alta.ShowDialog();

            listaErrores = new ErrorModel().GetErroresByTrabajo(trabajo.IdTrabajo);
            RLstErrores.DataContext = listaErrores;
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            AltaErrores update = new AltaErrores(selecteddError);
            update.Owner = this;
            update.ShowDialog();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Estas seguro de eliminar esta entrada?", "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                new ErrorModel().DeleteError(selecteddError);
            }
        }

        
    }
}
