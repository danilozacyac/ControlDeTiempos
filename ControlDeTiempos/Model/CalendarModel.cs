using ControlDeTiempos.Dto;
using ControlDeTiempos.Singleton;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace ControlDeTiempos.Model
{
    public class CalendarModel
    {

        public ObservableCollection<Appointment> GetAppointments()
        {
            ObservableCollection<TrabajoAsignado> listaTrabajos = new TrabajoAsignadoModel().GetTrabajos();

            ObservableCollection<Appointment> apps = new ObservableCollection<Appointment>();

            foreach (TrabajoAsignado trabajo in listaTrabajos)
            {
                string abogado = PersonalSingleton.Personal.SingleOrDefault(n => n.IdPersonal == trabajo.IdAbogado).Nombre;
                string operativo = PersonalSingleton.Personal.SingleOrDefault(n => n.IdPersonal == trabajo.IdOperativo).NombreCompleto;

                Appointment app = new Appointment()
                {
                    Subject = String.Format("{0}/{1} {2} - {3}", trabajo.NumExpediente, trabajo.AnioExpediente, abogado, operativo),
                    Start = trabajo.FechaIndicada ?? DateTime.Now,
                    End = (trabajo.FechaIndicada ?? DateTime.Now).AddMinutes(25),
                    Category = GetAppointmentCategory(trabajo.IdPrioridad),
                    UniqueId = trabajo.IdTrabajo.ToString()

                };

                apps.Add(app);
            }
            return apps;
        }

        private Category GetAppointmentCategory(int idPrioridad)
        {
            switch (idPrioridad)
            {
                case 1:
                 return new Category("Miércoles siguiente", new SolidColorBrush(Colors.Gray)); 
                case 2:
                 return new Category("Urgente", new SolidColorBrush(Colors.Red));  
                case 3:
                 return new Category("Octava Parte", new SolidColorBrush(Colors.Green)); 
                case 4:
                 return new Category("Subvínculo precedentes", new SolidColorBrush(Colors.Blue));  
                case 5:
                 return new Category("Prioridad media", new SolidColorBrush(Colors.Purple));    

                default: return new Category("Miércoles siguiente", new SolidColorBrush(Colors.Gray)); 
            }
        }
    }
}
