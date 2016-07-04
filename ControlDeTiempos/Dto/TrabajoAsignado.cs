using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ControlDeTiempos.Dto
{
    public class TrabajoAsignado : INotifyPropertyChanged
    {
        private int idTrabajo = -1;
        private int idAbogado = -1;
        private int idInstancia = 0;
        private int tipoDocumento =  -1;
        private int idActividad = 0;
        private string otraActividad;
        private string particularidades;
        private int idPrioridad = -1;
        private DateTime? fechaInicio;
        private DateTime? fechaIndicada;
        private DateTime? fechaEntrega;
        private int idOperativo = -1;
        private string servicioSocial;
        private int idQuienAsigna = -1;
        private int enTiempo = 0;
        private int idTipoAsunto;
        private int numExpediente;
        private int anioExpediente = 2016;
        private int paginasEjecutoria = 0;
        private ObservableCollection<Tesis> tesis;
        private ObservableCollection<Voto> votos;
        private int paginasTotales;
        private int paginasReales;

        
        public int IdTrabajo
        {
            get
            {
                return this.idTrabajo;
            }
            set
            {
                this.idTrabajo = value;
            }
        }

        [Range(1,int.MaxValue,ErrorMessage="Debes seleccionar al abogado responsable del asunto")]
        public int IdAbogado
        {
            get
            {
                return this.idAbogado;
            }
            set
            {
                this.idAbogado = value;
            }
        }

        [Range(1,3,ErrorMessage="Selecciona la instancia a la que pertence este asunto")]
        public int IdInstancia
        {
            get
            {
                return this.idInstancia;
            }
            set
            {
                this.idInstancia = value;
            }
        }

        

        [Range(1,128,ErrorMessage="Debes seleccionar al menos un tipo de documento para continuar")]
        public int TipoDocumento
        {
            get
            {
                return this.tipoDocumento;
            }
            set
            {
                this.tipoDocumento = value;
                this.OnPropertyChanged("TipoDocumento");
            }
        }

        [Range(1,int.MaxValue,ErrorMessage="Se debe seleccionar al menos una actividad del listado")]
        public int IdActividad
        {
            get
            {
                return this.idActividad;
            }
            set
            {
                this.idActividad = value;
            }
        }

        public string OtraActividad
        {
            get
            {
                return this.otraActividad;
            }
            set
            {
                this.otraActividad = value;
            }
        }

        public string Particularidades
        {
            get
            {
                return this.particularidades;
            }
            set
            {
                this.particularidades = value;
            }
        }

        [Range(1,512,ErrorMessage="Debes seleccionar la prioridad del trabajo que estas asignando")]
        public int IdPrioridad
        {
            get
            {
                return this.idPrioridad;
            }
            set
            {
                this.idPrioridad = value;
                this.OnPropertyChanged("IdPrioridad");
            }
        }

        [Required(ErrorMessage="Debes ingresar la fecha y hora en que se le entregará al personal operativo")]
        public DateTime? FechaInicio
        {
            get
            {
                return this.fechaInicio;
            }
            set
            {
                this.fechaInicio = value;
                this.OnPropertyChanged("FechaInicio");
            }
        }

        [Required(ErrorMessage = "Debes ingresar la fecha y hora en que se sugiere que el personal operativo entregue el trabajo")]
        public DateTime? FechaIndicada
        {
            get
            {
                return this.fechaIndicada;
            }
            set
            {
                this.fechaIndicada = value;
                this.OnPropertyChanged("FechaIndicada");
            }
        }

        public DateTime? FechaEntrega
        {
            get
            {
                return this.fechaEntrega;
            }
            set
            {
                this.fechaEntrega = value;
                this.OnPropertyChanged("FechaEntrega");
            }
        }

        public int IdOperativo
        {
            get
            {
                return this.idOperativo;
            }
            set
            {
                this.idOperativo = value;
                this.OnPropertyChanged("IdOperativo");
            }
        }

        public string ServicioSocial
        {
            get
            {
                return this.servicioSocial;
            }
            set
            {
                this.servicioSocial = value;
            }
        }

        public int IdQuienAsigna
        {
            get
            {
                return this.idQuienAsigna;
            }
            set
            {
                this.idQuienAsigna = value;
            }
        }

        public int EnTiempo
        {
            get
            {
                return this.enTiempo;
            }
            set
            {
                this.enTiempo = value;
            }
        }

        [Range(1,200,ErrorMessage="Selecciona el tipo de asunto")]
        public int IdTipoAsunto
        {
            get
            {
                return this.idTipoAsunto;
            }
            set
            {
                this.idTipoAsunto = value;
                this.OnPropertyChanged("IdTipoAsunto");
            }
        }

        [Range(1,int.MaxValue,ErrorMessage="Ingresa el número de expediente")]
        public int NumExpediente
        {
            get
            {
                return this.numExpediente;
            }
            set
            {
                this.numExpediente = value;
                this.OnPropertyChanged("NumExpediente");
            }
        }

        [Range(2000,2030,ErrorMessage="Ingresa un año comprendido entre 2000 y 2030")]
        public int AnioExpediente
        {
            get
            {
                return this.anioExpediente;
            }
            set
            {
                this.anioExpediente = value;
                this.OnPropertyChanged("AnioExpediente");
            }
        }

        

        public int PaginasEjecutoria
        {
            get
            {
                return this.paginasEjecutoria;
            }
            set
            {
                this.paginasEjecutoria = value;
                this.OnPropertyChanged("PaginasEjecutoria");
            }
        }

        public ObservableCollection<Tesis> Tesis
        {
            get
            {
                return this.tesis;
            }
            set
            {
                this.tesis = value;
            }
        }

        public ObservableCollection<Voto> Votos
        {
            get
            {
                return this.votos;
            }
            set
            {
                this.votos = value;
            }
        }

        /// <summary>
        /// Indica el número de páginas que se van a trabajar multiplicadas por el número de actividades
        /// que fueron asignadas
        /// </summary>
        public int PaginasTotales
        {
            get
            {
                return this.paginasTotales;
            }
            set
            {
                this.paginasTotales = value;
            }
        }
    
        /// <summary>
        /// Indica el número de páginas que incluye el documento. La suma incluye tesis, ejecutorias y votos
        /// </summary>
        public int PaginasReales
        {
            get
            {
                return this.paginasReales;
            }
            set
            {
                this.paginasReales = value;
            }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        #endregion // INotifyPropertyChanged Members
    }
}
