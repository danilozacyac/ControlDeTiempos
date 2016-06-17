using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;
using ScjnUtilities;
using ControlDeTiempos.Singleton;

namespace ControlDeTiempos
{
    /// <summary>
    /// Interaction logic for VotosWin.xaml
    /// </summary>
    public partial class VotosWin
    {
        TrabajoAsignado trabajo;
        bool isUpdating = false;
        Voto voto;

        public VotosWin(ref TrabajoAsignado trabajo, bool isUpdating)
        {
            InitializeComponent();
            this.trabajo = trabajo;
            this.isUpdating = isUpdating;
            voto = new Voto() { IdTrabajo = trabajo.IdTrabajo };
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CbxTipoVoto.DataContext = TipoVotoSingleton.TipoVoto;
            CbxEmisores.DataContext = from n in EmisorSingleton.Emisor
                                      where n.IdSeccion == trabajo.IdInstancia
                                      select n;

            this.DataContext = voto;
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            voto.IdEmisor = Convert.ToInt32(CbxEmisores.SelectedValue);
            voto.IdTipoVoto = Convert.ToInt32(CbxTipoVoto.SelectedValue);

            var oVldResults = new List<ValidationResult>();
            var oVldContext = new ValidationContext(voto, null, null);

            if (Validator.TryValidateObject(voto, oVldContext, oVldResults, true))
            {
                if (isUpdating)
                {
                    if (new VotosModel().SetNewVoto(voto))
                    {
                        if (trabajo.Votos == null)
                            trabajo.Votos = new ObservableCollection<Voto>();

                        trabajo.Votos.Add(voto);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo completar la operación, vuelva a intentarlo");
                    }
                }
                else
                {
                    if (trabajo.Votos == null)
                        trabajo.Votos = new ObservableCollection<Voto>();

                    trabajo.Votos.Add(voto);
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
