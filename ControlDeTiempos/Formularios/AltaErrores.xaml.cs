using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;
using Microsoft.Win32;
using ScjnUtilities;

namespace ControlDeTiempos.Formularios
{
    /// <summary>
    /// Interaction logic for AltaErrores.xaml
    /// </summary>
    public partial class AltaErrores
    {

        ErrorOperativo error;
        bool isUpdating = false;

        public AltaErrores()
        {
            InitializeComponent();
            error = new ErrorOperativo();

        }

        public AltaErrores(ErrorOperativo error)
        {
            InitializeComponent();
            this.error = error;
            isUpdating = true;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = error;
        }

        private void BtnVerArchivo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            Nullable<bool> result = open.ShowDialog();

            if (result == true)
            {
                string filename = open.FileName;
                TxtArchivo.Text = filename;
                error.NombreArchivo = filename;
            }

        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TxtDescripcion.Text) || String.IsNullOrWhiteSpace(TxtDescripcion.Text))
            {
                MessageBox.Show("Ingresa una descripción breve del error para que su localización posterior sea más sencilla");
                return;
            }

            error.NombreArchivo = Path.GetFileName(error.NombreArchivo);


            string nuevaRuta = String.Format("{0}{1}{2}", ConfigurationManager.AppSettings["ArchivosErrores"],Guid.NewGuid(), Path.GetExtension(TxtArchivo.Text));

            bool fileCopy = FilesUtilities.CopyToLocalResource(TxtArchivo.Text, nuevaRuta);


            if (fileCopy)
            {
                ErrorModel model = new ErrorModel();
                bool complete = (!isUpdating) ? model.SetNewError(ref error) : model.UpdateError(error);

                if (!complete)
                {
                    MessageBox.Show("No se pudo completar la operación, favor de volver a intentarlo", "Error de actualización", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    DialogResult = true;
                    this.Close();
                }
            }

        }
    }
}
