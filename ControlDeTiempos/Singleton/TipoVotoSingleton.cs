using ControlDeTiempos.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
