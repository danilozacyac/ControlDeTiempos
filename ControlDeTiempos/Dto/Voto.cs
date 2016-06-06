using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ControlDeTiempos.Dto
{
    public class Voto
    {
        private int idVoto;
        private int idTrabajo;
        private int paginas;
        private int idEmisor;
        private int idTipoVoto;

        public int IdVoto
        {
            get
            {
                return this.idVoto;
            }
            set
            {
                this.idVoto = value;
            }
        }

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

        [Range(1, int.MaxValue, ErrorMessage = "Indicar el número de páginas que tiene este voto")]
        public int Paginas
        {
            get
            {
                return this.paginas;
            }
            set
            {
                this.paginas = value;
            }
        }

        [Range(1, int.MaxValue, ErrorMessage = "Selecciona el emisor del voto")]
        public int IdEmisor
        {
            get
            {
                return this.idEmisor;
            }
            set
            {
                this.idEmisor = value;
            }
        }

        [Range(1, int.MaxValue, ErrorMessage = "Selecciona el tipo de voto")]
        public int IdTipoVoto
        {
            get
            {
                return this.idTipoVoto;
            }
            set
            {
                this.idTipoVoto = value;
            }
        }
    }
}
