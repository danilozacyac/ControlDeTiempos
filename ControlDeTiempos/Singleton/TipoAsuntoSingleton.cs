using System;
using System.Collections.ObjectModel;
using System.Linq;
using ControlDeTiempos.Dto;

namespace ControlDeTiempos.Singleton
{
    public class TipoAsuntoSingleton
    {
        private static ObservableCollection<TipoAsunto> tipoAsunto;


        private TipoAsuntoSingleton()
        {
        }

        public static ObservableCollection<TipoAsunto> TipoAsunto
        {
            get
            {
                if (tipoAsunto == null)
                    tipoAsunto = new TipoAsunto().GetTipoAsunto();

                return tipoAsunto;
            }
        }
    }
}
