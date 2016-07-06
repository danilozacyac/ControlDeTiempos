using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;
using DevExpress.Xpf.Charts;
using ControlDeTiempos.Singleton;

namespace ControlDeTiempos.Graphs.Particulares.Operativos
{
    /// <summary>
    /// Interaction logic for AvgActividades.xaml
    /// </summary>
    public partial class AvgActividades : UserControl, INotifyPropertyChanged
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

        public AvgActividades()
        {
            InitializeComponent();


        }
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            if (ChartPromedio.Diagram.Series != null)
                while (ChartPromedio.Diagram.Series.Count() > 0)
                    ChartPromedio.Diagram.Series.RemoveAt(0);

            

            foreach (Actividades actividad in ActividadesSingleton.Actividades)
            {
                if (Operativo == null)
                    ChartPromedio.Diagram.Series.Add(new GraficasModel().GetAvgTimeActOperativos(null, 1, actividad));
                else
                    ChartPromedio.Diagram.Series.Add(new GraficasModel().GetAvgTimeActOperativos(Operativo, 1, actividad));
            }
            if (Operativo == null)
                ChartPromedio.Legend = null;

            ChartPromedio.Animate();
        }
        #endregion // INotifyPropertyChanged Members
        
    }
}