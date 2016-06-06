using System;
using System.Linq;

namespace ControlDeTiempos.Graphs
{
    public class ActividadOperativos
    {
        private int legislacion;
        private int estandarizacion;
        private int cotejo;
        private int correcciones;
        private int octavaParte;
        private int subvinculoPrec;
        private int otros;

        public int Legislacion
        {
            get
            {
                return this.legislacion;
            }
            set
            {
                this.legislacion = value;
            }
        }

        public int Estandarizacion
        {
            get
            {
                return this.estandarizacion;
            }
            set
            {
                this.estandarizacion = value;
            }
        }

        public int Cotejo
        {
            get
            {
                return this.cotejo;
            }
            set
            {
                this.cotejo = value;
            }
        }

        public int Correcciones
        {
            get
            {
                return this.correcciones;
            }
            set
            {
                this.correcciones = value;
            }
        }

        public int OctavaParte
        {
            get
            {
                return this.octavaParte;
            }
            set
            {
                this.octavaParte = value;
            }
        }

        public int SubvinculoPrec
        {
            get
            {
                return this.subvinculoPrec;
            }
            set
            {
                this.subvinculoPrec = value;
            }
        }

        public int Otros
        {
            get
            {
                return this.otros;
            }
            set
            {
                this.otros = value;
            }
        }
    }
}
