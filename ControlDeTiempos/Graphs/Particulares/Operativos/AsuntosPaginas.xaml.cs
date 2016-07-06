using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlDeTiempos.Graphs.Particulares.Operativos
{
    /// <summary>
    /// Interaction logic for AsuntosPaginas.xaml
    /// </summary>
    public partial class AsuntosPaginas : UserControl, INotifyPropertyChanged
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

        public AsuntosPaginas()
        {
            InitializeComponent();


        }
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            Series.DataSource = new GraficasModel().GetAsuntosPaginas("IdPerOperativo", Operativo.IdPersonal, 1);
            Series.ToolTipPointPattern = "{A} ({W})";
            ChAsuntoPags.Animate();

        #endregion // INotifyPropertyChanged Members
        }
    }
}