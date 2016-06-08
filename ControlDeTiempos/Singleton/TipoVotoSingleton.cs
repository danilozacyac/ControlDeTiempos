using System;
using System.Collections.ObjectModel;
using System.Linq;
using ControlDeTiempos.Dto;

namespace ControlDeTiempos.Singleton
{
    public class TipoVotoSingleton
    {
        
        private static ObservableCollection<TipoAsunto> tipoVoto;


        private TipoVotoSingleton()
        {
        }

        public static ObservableCollection<TipoAsunto> TipoVoto
        {
            get
            {
                if (tipoVoto == null)
                    tipoVoto = new TipoAsunto().GetTipoVoto();

                return tipoVoto;
            }
        }

    }
}
