using System;
using System.Linq;
using System.Windows;
using ControlDeTiempos.Singleton;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;

namespace ControlDeTiempos.Formularios
{
    /// <summary>
    /// Interaction logic for AsignarOperativo.xaml
    /// </summary>
    public partial class AsignarOperativo
    {
        TrabajoAsignado trabajo;

        public AsignarOperativo(TrabajoAsignado trabajo)
        {
            InitializeComponent();
            this.trabajo = trabajo;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CbxPersonal.DataContext = PersonalSingleton.Personal.Where(n => n.TipoPersonal == 3);
            LstSugerido.DataContext = new PersonalModel().GetPersonalSugerido();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAsignar_Click(object sender, RoutedEventArgs e)
        {
            if (CbxPersonal.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona el nombre del personal operativo a quien asignarás este asunto");
                return;
            }

            trabajo.IdOperativo = Convert.ToInt32(CbxPersonal.SelectedValue);

            new TrabajoAsignadoModel().UpdatePersonalOperativo(trabajo);
            this.Close();
        }
    }
}
