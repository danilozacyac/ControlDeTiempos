using System;
using System.Linq;

namespace ControlDeTiempos.Dto
{
    public class AccesoUsuario
    {
        private static int idUsuario;
        private static int idSeccion;
        private static int idTipoAbogado;
        private static string nombre;
        private static string usuario;

        public static int IdUsuario
        {
            get
            {
                return idUsuario;
            }
            set
            {
                idUsuario = value;
            }
        }

        public static int IdSeccion
        {
            get
            {
                return idSeccion;
            }
            set
            {
                idSeccion = value;
            }
        }

        public static int IdTipoAbogado
        {
            get
            {
                return idTipoAbogado;
            }
            set
            {
                idTipoAbogado = value;
            }
        }

        public static string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public static string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }
    }
}
