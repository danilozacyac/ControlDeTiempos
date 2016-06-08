using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;
using ControlDeTiempos.Reportes;
using Telerik.Windows.Controls.ScheduleView;

namespace ControlDeTiempos.Controles
{
    /// <summary>
    /// Interaction logic for ScheduleViewEntregados.xaml
    /// </summary>
    public partial class ScheduleViewEntregados : UserControl
    {
        Appointment selectedAppointment;
        TrabajoAsignado selectedTrabajo;

        ObservableCollection<Appointment> listaAppointment;

        public ScheduleViewEntregados()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listaAppointment = new CalendarModel().GetCompletedAppointments();
            RCalendar.DataContext = listaAppointment;
        }

        private void RCalendar_ShowDialog(object sender, Telerik.Windows.Controls.ShowDialogEventArgs e)
        {
            e.Cancel = true;

            if (selectedTrabajo != null)
            {
                VentanaCaptura vantana = new VentanaCaptura(selectedTrabajo, true);
                vantana.Owner = this;
                vantana.ShowDialog();
            }
        }

        private void RCalendar_AppointmentSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedAppointment = RCalendar.SelectedAppointment as Appointment;

            if(selectedAppointment != null)
            selectedTrabajo = new TrabajoAsignadoModel().GetTrabajos(selectedAppointment.UniqueId);
        }

        

        public void VerInfo()
        {
            if (selectedAppointment == null)
            {
                MessageBox.Show("Para poder visualizar la información de un asunto primero debes seleccionar el asunto ");
                return;
            }

            VentanaCaptura ventana = new VentanaCaptura(selectedTrabajo, true);
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        

        public void HojaControl()
        {
            if (selectedAppointment == null)
            {
                MessageBox.Show("Para poder generar una hoja de control primero debes seleccionar el asunto ");
                return;
            }

            WordReport wrd = new WordReport();
            wrd.HojaDeControl(selectedTrabajo);
        }

       

    }
}
