
namespace ControlDeTiempos.Dto
{
    public class Graficas
    {
        private string nombre;
        private string actividad;
        private string mes;
        private int numeroAsuntos;
        private int numeroPaginas;
        private int numeroHojas;
        private int promedio;

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

        public string Actividad
        {
            get
            {
                return this.actividad;
            }
            set
            {
                this.actividad = value;
            }
        }

        public string Mes
        {
            get
            {
                return this.mes;
            }
            set
            {
                this.mes = value;
            }
        }

        public int NumeroAsuntos
        {
            get
            {
                return this.numeroAsuntos;
            }
            set
            {
                this.numeroAsuntos = value;
            }
        }

        public int NumeroPaginas
        {
            get
            {
                return this.numeroPaginas;
            }
            set
            {
                this.numeroPaginas = value;
            }
        }

        public int NumeroHojas
        {
            get
            {
                return this.numeroHojas;
            }
            set
            {
                this.numeroHojas = value;
            }
        }

        public int Promedio
        {
            get
            {
                return this.promedio;
            }
            set
            {
                this.promedio = value;
            }
        }
    }
}
