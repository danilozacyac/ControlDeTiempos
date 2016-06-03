using ControlDeTiempos.Dto;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ControlDeTiempos.Singleton
{
    public class PersonalSingleton
    {
        private static ObservableCollection<PersonalCcst> personal;


        private PersonalSingleton()
        {
        }

        public static ObservableCollection<PersonalCcst> Personal
        {
            get
            {
                if (personal == null)
                    personal = new PersonalCcst().GetPersonal();

                return personal;
            }
        }

    }
}
