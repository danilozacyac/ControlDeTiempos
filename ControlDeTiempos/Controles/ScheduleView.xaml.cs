using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;
using ControlDeTiempos.Reportes;
using Telerik.Windows.Controls.ScheduleView;
using System.Collections.ObjectModel;
using ControlDeTiempos.Singleton;
using ControlDeTiempos.Formularios;

namespace ControlDeTiempos.Controles
{
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : UserControl
    {
        Appointment selectedAppointment;
        TrabajoAsignado selectedTrabajo;
        PersonalCcst selectedPersonal;

        ObservableCollection<Appointment> listaAppointment;

        bool loadEntregados;

        public ScheduleView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listaAppointment = new CalendarModel().GetPendingAppointments();
            RCalendar.DataContext = listaAppointment;

            if (AccesoUsuario.IdTipoAbogado == 4 || AccesoUsuario.IdTipoAbogado == 2)
                RTFiltros.DataContext = new PersonalModel().GetPersonalForFilter();
            else
                CFiltros.Width = new GridLength(0);
        }

        public void CargaAsuntos(bool entgregado)
        {
            this.loadEntregados = entgregado;
            listaAppointment = (entgregado) ? new CalendarModel().GetCompletedAppointments() : new CalendarModel().GetPendingAppointments();
            RCalendar.DataContext = listaAppointment;
        }

        private void RCalendar_ShowDialog(object sender, Telerik.Windows.Controls.ShowDialogEventArgs e)
        {
            e.Cancel = true;

            if (selectedAppointment != null && selectedTrabajo != null)
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

        public void Agregar()
        {
            TrabajoAsignado trabajo = new TrabajoAsignado();
            VentanaCaptura ventana = new VentanaCaptura(ref trabajo);
            ventana.Owner = this;
            ventana.ShowDialog();

            if (ventana.DialogResult == true)
            {

                string abogado = PersonalSingleton.Personal.SingleOrDefault(n => n.IdPersonal == trabajo.IdAbogado).Nombre;
                string operativo = (trabajo.IdOperativo > 0) ? PersonalSingleton.Personal.SingleOrDefault(n => n.IdPersonal == trabajo.IdOperativo).NombreCompleto : String.Empty;


                Appointment app = new Appointment()
                {
                    Subject = String.Format("{0}/{1} {2} - {3}", trabajo.NumExpediente, trabajo.AnioExpediente, abogado, operativo),
                    Start = trabajo.FechaIndicada ?? DateTime.Now,
                    End = (trabajo.FechaIndicada ?? DateTime.Now).AddMinutes(25),
                    Category = CalendarModel.GetAppointmentCategory(trabajo.IdPrioridad),
                    UniqueId = trabajo.IdTrabajo.ToString()
                };
            }
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

        public void Editar()
        {
            if (selectedAppointment == null)
            {
                MessageBox.Show("Para poder editar la información de un asunto primero debes seleccionar el asunto ");
                return;
            }
            VentanaCaptura ventana = new VentanaCaptura(selectedTrabajo, false);
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

        public void Entregar()
        {
            if (selectedAppointment == null)
            {
                MessageBox.Show("Para marcar un asunto como entregado primero debes seleccionar el asunto ");
                return;
            }

            if (selectedTrabajo.IdOperativo == -1 || selectedTrabajo.IdOperativo == 0)
            {
                MessageBox.Show("Para poder marcar este asunto como entregado primero debes asignar al personal que lo trabajó ");
                return;
            }

            new TrabajoAsignadoModel().UpdateFechaEntrega(selectedTrabajo);
            listaAppointment.Remove(selectedAppointment);
            selectedAppointment = null;
            selectedTrabajo = null;
        }

        public void AsignaOperativo()
        {
            if (selectedAppointment == null)
            {
                MessageBox.Show("Para poder asignar a un operativo para trabajar, primero hay que seleccionar el asunto ");
                return;
            }
            new AsignarOperativo(selectedTrabajo).ShowDialog();
        }


        private void RTFiltros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPersonal = RTFiltros.SelectedItem as PersonalCcst;

            if (selectedPersonal.IdPersonal < 10000)
            {
                if (selectedPersonal.TipoPersonal == 1)
                    RCalendar.DataContext = new TrabajoAsignadoModel().GetTrabajosByAbogado(selectedPersonal.IdPersonal, loadEntregados);
                else
                    RCalendar.DataContext = new TrabajoAsignadoModel().GetTrabajosByOperativo(selectedPersonal.IdPersonal, loadEntregados);
            }
            else
                RCalendar.DataContext = listaAppointment;
        }

    }
}
