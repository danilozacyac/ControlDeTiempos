using System;
using System.Collections.ObjectModel;
using System.Linq;
using ControlDeTiempos.Dto;

namespace ControlDeTiempos.Singleton
{
    public class EmisorSingleton
    { 
        private static ObservableCollection<Emisor> emisor;


        private EmisorSingleton()
        {
        }

        public static ObservableCollection<Emisor> Emisor
        {
            get
            {
                if (emisor == null)
                    emisor = new Emisor().GetEmisor();

                return emisor;
            }
        }

    }
}
