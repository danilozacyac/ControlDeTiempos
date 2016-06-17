using System;
using System.Collections.ObjectModel;
using System.Linq;
using ControlDeTiempos.Dto;
using System.Collections.Generic;

namespace ControlDeTiempos.Singleton
{
    public class EmisorSingleton
    { 
        private static List<Emisor> emisor;


        private EmisorSingleton()
        {
        }

        public static List<Emisor> Emisor
        {
            get
            {
                if (emisor == null)
                {
                    

                    emisor = new Emisor().GetEmisor().ToList();
                    emisor.AddRange(new Emisor().GetMagistrados());
                }
                return emisor;
            }
        }

    }
}
