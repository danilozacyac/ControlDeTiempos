using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using ControlDeTiempos.Controles;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Graphs;
using ControlDeTiempos.Notificaciones;
using Telerik.Windows.Controls;
using ControlDeTiempos.Model;
using System.Collections.ObjectModel;
using System.Threading;

namespace ControlDeTiempos
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView
    {
        ScheduleView scheduleControl;


        int vista = 1; //1. Pendientes   2. Entregados  3. Listado

        public MainView()
        {
            InitializeComponent();
            ShowInTaskbar(this, "Control de asignaciones");
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

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            EnableButtons();

            if (scheduleControl == null)
                scheduleControl = new ScheduleView();

            CentralPanel.Children.Add(scheduleControl);

            if (AccesoUsuario.IdTipoAbogado != 4)
                GraphReports.Visibility = Visibility.Collapsed;

            //NotificationBalloon ballon = new NotificationBalloon();
            //ballon.BalloonText = "Estoy probando";
            //ballon.TxtInfo.Text = "Este mensaje es de prueba";

            //MyNotifyIcon.ShowCustomBalloon(ballon, PopupAnimation.Slide, 10000);
            DoBackgroundWork();
        }

        private void RBtnVistaCal_Click(object sender, RoutedEventArgs e)
        {
            //CleanCentralPanel();
            //if (scheduleControl == null)
            //    scheduleControl = new ScheduleView();

            //CentralPanel.Children.Add(scheduleControl);
            scheduleControl.CargaAsuntos(false);
            vista = 1;
            EnableButtons();
        }

        private void RBtnVistaCalOk_Click(object sender, RoutedEventArgs e)
        {
            //CleanCentralPanel();
            //if (scheduleControlEn == null)
            //    scheduleControlEn = new ScheduleViewEntregados();

            //CentralPanel.Children.Add(scheduleControlEn);
            scheduleControl.CargaAsuntos(true);
            vista = 2;
            EnableButtons();
        }

        private void RBtnVistaListado_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RBtnVerTrabajo_Click(object sender, RoutedEventArgs e)
        {
            scheduleControl.VerInfo();
        }

        private void RBtnAgregarTrabajo_Click(object sender, RoutedEventArgs e)
        {
            scheduleControl.Agregar();
        }

        private void RBtnEditarTrabajo_Click(object sender, RoutedEventArgs e)
        {
            scheduleControl.Editar();
        }

        private void RBtnEntregar_Click(object sender, RoutedEventArgs e)
        {
            scheduleControl.Entregar();
        }

        private void RBtnHojaControl_Click(object sender, RoutedEventArgs e)
        {
            scheduleControl.HojaControl();
        }

        private void RBtnGraficas_Click(object sender, RoutedEventArgs e)
        {
            ActiOper graph = new ActiOper();
            graph.ShowDialog();
        }

        

        private void CleanCentralPanel()
        {
            if (CentralPanel.Children.Count > 0)
                CentralPanel.Children.RemoveAt(0);
        }

        private void EnableButtons()
        {
            if (AccesoUsuario.IdTipoAbogado == 1)
            {
                GrpAcciones.Visibility = Visibility.Visible;
                GrpAsignaciones.Visibility = Visibility.Collapsed;
            }
            else if (AccesoUsuario.IdTipoAbogado == 4)
            {
                GrpAcciones.Visibility = Visibility.Visible;
                GrpAsignaciones.Visibility = Visibility.Visible;
            }
            else
            {
                GrpAcciones.Visibility = Visibility.Collapsed;
                GrpAsignaciones.Visibility = Visibility.Visible;
            }

            if (vista == 2)
            {
                RBtnAgregarTrabajo.IsEnabled = false;
                RBtnEditarTrabajo.IsEnabled = false;
                RBtnEntregar.IsEnabled = false;
            }
            else
            {
                RBtnAgregarTrabajo.IsEnabled = true;
                RBtnEditarTrabajo.IsEnabled = true;
                RBtnEntregar.IsEnabled = true;
            }
        }

        private void RBtnColores_Click(object sender, RoutedEventArgs e)
        {
            new Colores().ShowDialog();
        }

        private void RBtnAsignarOperativo_Click(object sender, RoutedEventArgs e)
        {
            scheduleControl.AsignaOperativo();
        }


        #region BackgroundWorker


        /// <summary>
        /// Creates a BackgroundWorker class to do work
        /// on a background thread.
        /// </summary>
        private void DoBackgroundWork()
        {
            BackgroundWorker worker = new BackgroundWorker();

            // Tell the worker to report progress.
            worker.WorkerReportsProgress = true;

            worker.ProgressChanged += ProgressChanged;
            worker.DoWork += DoWork;
            worker.RunWorkerCompleted += WorkerCompleted;
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// The work for the BackgroundWorker to perform.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        void DoWork(object sender, DoWorkEventArgs e)
        {
            ObservableCollection<TrabajoAsignado> listaTrabajos = new TrabajoAsignadoModel().GetTrabajos(0);

            var tiempoExcedido = from n in listaTrabajos
                                 where n.FechaIndicada < DateTime.Now
                                 select n;
            trabajosTiempoExcedido = tiempoExcedido.Count();

            var porVencer = from n in listaTrabajos
                            where (n.FechaIndicada.Value.Subtract(DateTime.Now)).Minutes < 120 && (n.FechaIndicada.Value.Subtract(DateTime.Now)).Minutes > 0
                            select n;
            trabajosPorVencer = porVencer.Count();

        }

        int trabajosTiempoExcedido = 0;
        int trabajosPorVencer = 0;

        /// <summary>
        /// Occurs when the BackgroundWorker reports a progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //pbLoad.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Occurs when the BackgroundWorker has completed its work.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (trabajosTiempoExcedido > 0 || trabajosPorVencer > 0)
            {

                NotificationBalloon balloon = new NotificationBalloon() { BalloonText = "Atención" };

                if (trabajosTiempoExcedido > 0)
                    balloon.TxtInfo.Text = String.Format("Tienes {0} trabajos pendientes cuyo tiempo de indicado de entrega ya fue excedido", trabajosTiempoExcedido);
                else
                {
                    balloon.TxtInfo.Visibility = Visibility.Collapsed;
                    balloon.RedCircle.Visibility = Visibility.Collapsed;
                }

                if (trabajosPorVencer > 0)
                    balloon.TxtPorVencer.Text = String.Format("Tienes {0} trabajos pendientes cuyo tiempo de indicado de entrega esta por vencer", trabajosPorVencer);
                else
                {
                    balloon.TxtPorVencer.Visibility = Visibility.Collapsed;
                    balloon.YellowCircle.Visibility = Visibility.Collapsed;
                }

                //show balloon and close it after 4 seconds
                MyNotifyIcon.ShowCustomBalloon(balloon, PopupAnimation.Slide, 50000);
                //_backgroundButton.IsEnabled = true;
                //pbLoad.Visibility = Visibility.Collapsed;
            }
        }

        #endregion
    }
}
