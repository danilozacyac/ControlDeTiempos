using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;
using DevExpress.Xpf.Charts;

namespace ControlDeTiempos.Graphs.Operativos
{
    /// <summary>
    /// Interaction logic for Distribucion.xaml
    /// </summary>
    public partial class Distribucion : UserControl, INotifyPropertyChanged
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

        public Distribucion()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            GlossyPie2DModel glossy = new GlossyPie2DModel();
            DistrPoints.Model = glossy;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            if (DistrPoints.Points != null)
                while(DistrPoints.Points.Count > 0)
                DistrPoints.Points.RemoveAt(0);

            DistrPoints.Points.AddRange(new GraficasModel().GetDistribucionPersonal(Operativo));
            DistribucionChart.Animate();
        }

        #endregion // INotifyPropertyChanged Members
    }

}
