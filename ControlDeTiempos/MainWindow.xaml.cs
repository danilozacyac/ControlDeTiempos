using System;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;

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

            new ListaAsuntos().ShowDialog();
        }
    }
}
