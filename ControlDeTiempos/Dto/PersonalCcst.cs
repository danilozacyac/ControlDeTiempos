using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using ScjnUtilities;

namespace ControlDeTiempos.Dto
{
    public class PersonalCcst
    {
        private int idPersonal;
        private string nombre;
        private string apellidos;
        private string nombreCompleto;
        private int tipoPersonal;
        private int seccion;
        public ObservableCollection<PersonalCcst> child;
        private int tiempoNoLaborableDiario;

        public int IdPersonal
        {
            get
            {
                return this.idPersonal;
            }
            set
            {
                this.idPersonal = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Apellidos
        {
            get
            {
                return this.apellidos;
            }
            set
            {
                this.apellidos = value;
            }
        }

        public string NombreCompleto
        {
            get
            {
                return this.nombreCompleto;
            }
            set
            {
                this.nombreCompleto = value;
            }
        }

        public int TipoPersonal
        {
            get
            {
                return this.tipoPersonal;
            }
            set
            {
                this.tipoPersonal = value;
            }
        }

        public int Seccion
        {
            get
            {
                return this.seccion;
            }
            set
            {
                this.seccion = value;
            }
        }

        public ObservableCollection<PersonalCcst> Child
        {
            get
            {
                return this.child;
            }
            set
            {
                this.child = value;
            }
        }

        public int TiempoNoLaborableDiario
        {
            get
            {
                return this.tiempoNoLaborableDiario;
            }
            set
            {
                this.tiempoNoLaborableDiario = value;
            }
        }

        

        
    }
}
