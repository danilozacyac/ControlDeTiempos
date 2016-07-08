using System;

namespace ControlDeTiempos.Dto
{
    public class Asignacion
    {
        private int idPersonal;
        private DateTime? ultimaAsignacion;
        private DateTime? ultimaEntrega;
        private int asuntosPendientes;
        private int hojasPendientes;

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

        public DateTime? UltimaAsignacion
        {
            get
            {
                return this.ultimaAsignacion;
            }
            set
            {
                this.ultimaAsignacion = value;
            }
        }

        public DateTime? UltimaEntrega
        {
            get
            {
                return this.ultimaEntrega;
            }
            set
            {
                this.ultimaEntrega = value;
            }
        }

        public int AsuntosPendientes
        {
            get
            {
                return this.asuntosPendientes;
            }
            set
            {
                this.asuntosPendientes = value;
            }
        }

        public int HojasPendientes
        {
            get
            {
                return this.hojasPendientes;
            }
            set
            {
                this.hojasPendientes = value;
            }
        }
    }
}
