using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;
using System.Threading;

namespace ControlDeTiempos
{
    /// <summary>
    /// Interaction logic for Intro.xaml
    /// </summary>
    public partial class Intro : Window
    {
        ObservableCollection<Appointment> listaAppointment;

       public Intro()
        {
            InitializeComponent();
            worker.DoWork += this.WorkerDoWork;
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StyleManager.ApplicationTheme = new Windows8Theme();

            string path = ConfigurationManager.AppSettings["ErrorPath"].ToString();

            if (!File.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (new AccesoUsuarioModel().IsValidUser())
            {
                Thread.Sleep(2000);

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


        #region Background Worker

        private BackgroundWorker worker = new BackgroundWorker();

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            listaAppointment = new CalendarModel().GetPendingAppointments();
        }

        void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Dispatcher.BeginInvoke(new Action<ObservableCollection<Organismos>>(this.UpdateGridDataSource), e.Result);
            this.BusyIndicator.IsBusy = false;
            
        }

        private void LaunchBusyIndicator()
        {
            if (!worker.IsBusy)
            {
                this.BusyIndicator.IsBusy = true;
                worker.RunWorkerAsync();
            }
        }

        #endregion
    }
}

