using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;
using DevExpress.Xpf.Charts;

namespace ControlDeTiempos.Graphs.Particulares.Operativos
{
    /// <summary>
    /// Interaction logic for DistrActividades.xaml
    /// </summary>
    public partial class DistrActividades : UserControl, INotifyPropertyChanged
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

        public DistrActividades()
        {
            InitializeComponent();
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            List<ActOperativos> distr = new ActividadesModel().GetActividadesByOperativo(Operativo.IdPersonal);
            foreach (ActOperativos actividad in distr)
                DistrActsSerie.Points.Add(new SeriesPoint(actividad.Etiqueta, actividad.Valor));

            DistrChart.Animate();

        #endregion // INotifyPropertyChanged Members
        }
    }
}
