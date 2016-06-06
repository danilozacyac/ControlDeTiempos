using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;
using ControlDeTiempos.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace ControlDeTiempos.Graphs
{
    /// <summary>
    /// Interaction logic for ActiOper.xaml
    /// </summary>
    public partial class ActiOper
    {
        PersonalCcst selectedPersonal;

        public ActiOper()
        {
            InitializeComponent();
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Cbxoperativos.DataContext = PersonalSingleton.Personal.Where(n => n.TipoPersonal == 3);
        }

        private void Cbxoperativos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPersonal = Cbxoperativos.SelectedItem as PersonalCcst;

            List<ActOperativos> distr = new ActividadesModel().GetActividadesByOperativo(selectedPersonal.IdPersonal);

            this.DataContext = distr;
        }
    }
}
