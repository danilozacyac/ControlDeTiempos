using System;
using System.ComponentModel.DataAnnotations;

namespace ControlDeTiempos.Dto
{
    public class Tesis
    {
        private int idTesis;
        private int idTrabajo;
        private string numIdentificacion = String.Empty;
        private int paginas = 1;
        public int IdTesis
        {
            get
            {
                return this.idTesis;
            }
            set
            {
                this.idTesis = value;
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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Debes ingresar el número de identificación de la tesis")]
        public string NumIdentificacion
        {
            get
            {
                return this.numIdentificacion;
            }
            set
            {
                this.numIdentificacion = value;
            }
        }

        [Range(1,100,ErrorMessage="Ingresa el número de páginas que tiene la tesis")]
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
    }
}
