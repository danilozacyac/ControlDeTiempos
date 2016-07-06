
namespace ControlDeTiempos.Graphs.Particulares.Operativos
{
    public class PaginasAsuntos
    {
        private string mes;
        private int numeroAsuntos;
        private int numeroPaginas;

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
    }
}
