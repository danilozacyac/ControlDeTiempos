using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeTiempos.Graphs
{
    public class ActOperativos
    {
        private int valor;
        private string etiqueta;

        public int Valor
        {
            get
            {
                return this.valor;
            }
            set
            {
                this.valor = value;
            }
        }

        public string Etiqueta
        {
            get
            {
                return this.etiqueta;
            }
            set
            {
                this.etiqueta = value;
            }
        }
    }
}
