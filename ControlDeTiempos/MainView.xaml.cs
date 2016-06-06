using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using ControlDeTiempos.Controles;
using Telerik.Windows.Controls;

namespace ControlDeTiempos
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView
    {
        ScheduleView scheduleControl;


        public MainView()
        {
            InitializeComponent();
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (scheduleControl == null)
                scheduleControl = new ScheduleView();

            CentralPanel.Children.Add(scheduleControl);
        }

        private void RBtnVistaCal_Click(object sender, RoutedEventArgs e)
        {
            if (scheduleControl == null)
                scheduleControl = new ScheduleView();

            CentralPanel.Children.Add(scheduleControl);
        }

        private void RBtnVistaListado_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RBtnVerTrabajo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RBtnAgregarTrabajo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RBtnEditarTrabajo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RBtnEntregar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RBtnHojaControl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RBtnGraficas_Click(object sender, RoutedEventArgs e)
        {

        }

        public void ShowInTaskbar(RadWindow control, string title)
        {
            control.Show();
            var window = control.ParentOfType<Window>();
            window.ShowInTaskbar = true;
            window.Title = title;
            var uri = new Uri("pack://application:,,,/ControlDeTiempos;component/Resources/monitor.ico");
            window.Icon = BitmapFrame.Create(uri);
        }

        private void CleanCentralPanel()
        {
            if (CentralPanel.Children.Count > 0)
                CentralPanel.Children.RemoveAt(0);
        }
    }
}
