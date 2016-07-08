using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;

namespace ControlDeTiempos.Formularios
{
    /// <summary>
    /// Interaction logic for SetOperativoForAsunto.xaml
    /// </summary>
    public partial class SetOperativoForAsunto
    {
        Asignacion selectedAsignacion;
        TrabajoAsignado trabajo;

        public SetOperativoForAsunto(TrabajoAsignado trabajo)
        {
            InitializeComponent();
            this.trabajo = trabajo;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LstOperativos.DataContext = new PersonalModel().GetPersonalSugerido1();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LstOperativos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedAsignacion = LstOperativos.SelectedItem as Asignacion;
        }

        private void BtnAsignar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAsignacion == null)
            {
                MessageBox.Show("Selecciona el nombre del personal operativo a quien asignarás este asunto");
                return;
            }

            trabajo.IdOperativo = selectedAsignacion.IdPersonal;

            new TrabajoAsignadoModel().UpdatePersonalOperativo(trabajo);
            this.Close();
        }
    }
}
