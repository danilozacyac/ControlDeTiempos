using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;

namespace ControlDeTiempos.Graphs.Operativos
{
    /// <summary>
    /// Interaction logic for EnTiempoNoTiempo.xaml
    /// </summary>
    public partial class EnTiempoNoTiempo : UserControl, INotifyPropertyChanged
    {
        private PersonalCcst operativo;

        public PersonalCcst Operativo
        {
            get
            {
                return this.operativo;
            }
            set
            {
                this.operativo = value;
                this.OnPropertyChanged("Operativo");
            }
        }

        public EnTiempoNoTiempo()
        {
            InitializeComponent();
        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            



        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            if (TiempoNoTiempo.Diagram.Series.Count() > 1)
            {
                TiempoNoTiempo.Diagram.Series.RemoveAt(1);
                TiempoNoTiempo.Diagram.Series.RemoveAt(0);
            }
            else if (TiempoNoTiempo.Diagram.Series.Count() == 1)
            {
                TiempoNoTiempo.Diagram.Series.RemoveAt(0);
            }

            TiempoNoTiempo.Diagram.Series.Add(new GraficasModel().GetTiemposTrbajo(Operativo, 1, 1));
            TiempoNoTiempo.Diagram.Series.Add(new GraficasModel().GetTiemposTrbajo(Operativo, 1, 0));
        }

        #endregion // INotifyPropertyChanged Members
    }
}
