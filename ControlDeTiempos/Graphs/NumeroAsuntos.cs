using System;
using System.Linq;

namespace ControlDeTiempos.Graphs
{
    public class NumeroAsuntos
    {
        private string nombre;
        private string periodo;
        private int total;

        

        public NumeroAsuntos()
        {
        }

        public NumeroAsuntos(string periodo, int total)
        {
            this.periodo = periodo;
            this.total = total;
        }

        public NumeroAsuntos(string nombre, string periodo, int total)
        {
            this.nombre = nombre;
            this.periodo = periodo;
            this.total = total;
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

        public string Periodo
        {
            get
            {
                return this.periodo;
            }
            set
            {
                this.periodo = value;
            }
        }

        public int Total
        {
            get
            {
                return this.total;
            }
            set
            {
                this.total = value;
            }
        }
    }
}
