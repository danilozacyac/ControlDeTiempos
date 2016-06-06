using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using ControlDeTiempos.Dto;
using Telerik.Windows.Controls;
using ControlDeTiempos.Model;

namespace ControlDeTiempos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StyleManager.ApplicationTheme = new Windows8Theme();
            //VentanaCaptura ven = new VentanaCaptura();
            //ven.ShowDialog();

            
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string path = ConfigurationManager.AppSettings["ErrorPath"].ToString();

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

            }

            if (new AccesoUsuarioModel().IsValidUser(TxtUsuario.Text, TxtPass.Password))
            {
                new ListaAsuntos().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
    }
}
