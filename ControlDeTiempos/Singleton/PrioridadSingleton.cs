using System;
using System.Collections.ObjectModel;
using System.Linq;
using ControlDeTiempos.Dto;

namespace ControlDeTiempos.Singleton
{
    public class PrioridadSingleton
    {
        
        private static ObservableCollection<Prioridades> prioridades;


        private PrioridadSingleton()
        {
        }

        public static ObservableCollection<Prioridades> Prioridades
        {
            get
            {
                if (prioridades == null)
                    prioridades = new Prioridades().GetPrioridades();

                return prioridades;
            }
        }

    }
}