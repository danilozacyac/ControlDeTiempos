using ControlDeTiempos.Model;
using System.Configuration;
using System.IO;
using System.Windows;
using Telerik.Windows.Controls;

namespace ControlDeTiempos
{
    /// <summary>
    /// Interaction logic for Intro.xaml
    /// </summary>
    public partial class Intro : Window
    {

       public Intro()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StyleManager.ApplicationTheme = new Windows8Theme();

            string path = ConfigurationManager.AppSettings["ErrorPath"];

            if (!File.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (new AccesoUsuarioModel().IsValidUser())
            {
                //Thread.Sleep(2000);

               // new TrabajoAsignadoModel().ObtenMinutosTrabajo();

                MainView main = new MainView();
                main.Show();
                this.Close();
            }
            else
            {
                MainWindow logIn = new MainWindow();
                logIn.ShowDialog();
            }
        }


    }
}

