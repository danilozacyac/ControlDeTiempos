using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ControlDeTiempos.Model;
using Telerik.Windows.Controls.ScheduleView;
using ControlDeTiempos.Dto;

namespace ControlDeTiempos.Controles
{
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : UserControl
    {
        Appointment selectedAppointment;
        TrabajoAsignado selectedTrabajo;

        public ScheduleView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RCalendar.DataContext = new CalendarModel().GetAppointments();
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
    }
}
