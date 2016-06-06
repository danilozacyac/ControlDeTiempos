using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using ControlDeTiempos.Dto;
using ScjnUtilities;
using ControlDeTiempos.Model;

namespace ControlDeTiempos
{
    /// <summary>
    /// Interaction logic for TesisWin.xaml
    /// </summary>
    public partial class TesisWin
    {
        TrabajoAsignado trabajo;
        bool isUpdating;
        Tesis tesis;

        public TesisWin(ref TrabajoAsignado trabajo, bool isUpdating)
        {
            InitializeComponent();
            this.trabajo = trabajo;
            this.isUpdating = isUpdating;

            tesis = new Tesis() { IdTrabajo = trabajo.IdTrabajo };
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            this.DataContext = tesis;
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {

            var oVldResults = new List<ValidationResult>();
            var oVldContext = new ValidationContext(tesis, null, null);

            if (Validator.TryValidateObject(tesis, oVldContext, oVldResults, true))
            {
                if (isUpdating)
                {
                    if (new TesisModel().SetNewTesis(tesis))
                    {
                        if (trabajo.Tesis == null)
                            trabajo.Tesis = new ObservableCollection<Tesis>();

                        trabajo.Tesis.Add(tesis);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo completar la operación, vuelva a intentarlo");
                    }
                }
                else
                {
                    if (trabajo.Tesis == null)
                        trabajo.Tesis = new ObservableCollection<Tesis>();

                    trabajo.Tesis.Add(tesis);
                    this.Close();
                }
            }
            else
            {
                var sVldErrors = String.Join("\n", oVldResults.Select(t => String.Format("- {0}", t.ErrorMessage)));
                ErrorUtilities.MostrarMensajes("ERRORES EN VALIDACIONES ", sVldErrors);
            }

        }
    }
}
