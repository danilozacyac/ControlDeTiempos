using System;
using System.Collections.ObjectModel;
using System.Linq;
using ControlDeTiempos.Dto;

namespace ControlDeTiempos.Singleton
{
    public class ActividadesSingleton
    {
        private static ObservableCollection<Actividades> actividades;


        private ActividadesSingleton()
        {
        }

        public static ObservableCollection<Actividades> Actividades
        {
            get
            {
                if (actividades == null)
                    actividades = new Actividades().GetActividades();

                return actividades;
            }
        }

    }
}