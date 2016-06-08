using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ControlDeTiempos.Dto
{
    public class ErrorOperativo
    {
        private int idError;
        private int idTrabajo;
        private string descripcion;
        private string nombreArchivo;
        private string comentarios;

        public int IdError
        {
            get
            {
                return this.idError;
            }
            set
            {
                this.idError = value;
            }
        }

        [Range(0,int.MaxValue,ErrorMessage="Este error debe estar asociado a un trabajo")]
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

        [Required(AllowEmptyStrings=false,ErrorMessage="Ingresa una breve descripción del error para que posteriormente sea más fácil localizarlo")]
        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        public string NombreArchivo
        {
            get
            {
                return this.nombreArchivo;
            }
            set
            {
                this.nombreArchivo = value;
            }
        }

        public string Comentarios
        {
            get
            {
                return this.comentarios;
            }
            set
            {
                this.comentarios = value;
            }
        }
    }
}
