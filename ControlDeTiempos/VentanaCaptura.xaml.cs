using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;
using ControlDeTiempos.Singleton;
using ScjnUtilities;
using Telerik.Windows.Controls;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControlDeTiempos
{
    /// <summary>
    /// Interaction logic for VentanaCaptura.xaml
    /// </summary>
    public partial class VentanaCaptura
    {
        TrabajoAsignado trabajo;
        bool isUpdating = false;
        ObservableCollection<Actividades> listaActividades;
        ObservableCollection<TrabajoAsignado> listaTrabajos;


        public VentanaCaptura(ref TrabajoAsignado trabajo)
        {
            InitializeComponent();
            this.trabajo = trabajo;
        }


        public VentanaCaptura(ObservableCollection<TrabajoAsignado> listaTrabajos)
        {
            InitializeComponent();
            trabajo = new TrabajoAsignado();
            this.listaTrabajos = listaTrabajos;
            
        }

        public VentanaCaptura(TrabajoAsignado trabajo, bool isReadOnly)
        {
            InitializeComponent();
            this.trabajo = trabajo;
            isUpdating = true;
            MainPanel.IsEnabled = !isReadOnly;


        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CbxPrioridad.DataContext = new Prioridades().GetPrioridades();
            CbxAbogResp.DataContext = PersonalSingleton.Personal.Where(n => n.TipoPersonal == 1);
            CbxTipoAsunto.DataContext = TipoAsuntoSingleton.TipoAsunto;

            //Condición sobre el usuario que se firma en la aplicación
            if (AccesoUsuario.IdTipoAbogado == 1)
                CbxOperativos.DataContext = PersonalSingleton.Personal.Where(n => n.TipoPersonal == 3 && (n.Seccion == AccesoUsuario.IdSeccion || n.Seccion == 3));
            else
                CbxOperativos.DataContext = PersonalSingleton.Personal.Where(n => n.TipoPersonal == 3);


            listaActividades = new Actividades().GetActividades();
            RLstActividades.DataContext = listaActividades;

            if (!isUpdating)
            {
                RdtpFechaInicio.SelectableDateStart = DateTime.Now;
                LblFEntrega.Visibility = Visibility.Collapsed;
                RdtpEntrega.Visibility = Visibility.Collapsed;
                trabajo.FechaInicio = DateTime.Now.AddMinutes(15);
                RadScjn.IsChecked = true;
            }

            this.DataContext = trabajo;

            if (trabajo.IdTrabajo != -1)
                LoadForUpdate();


        }

        private void CheckBoxList_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox check = sender as CheckBox;

            if (Convert.ToInt16(check.Tag) == 128)
            {
                TxtActOtro.Visibility = Visibility.Visible;
                LblOtraActividad.Visibility = Visibility.Visible;
            }
        }

        private void CheckBoxList_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox check = sender as CheckBox;

            if (Convert.ToInt16(check.Tag) == 128)
            {
                TxtActOtro.Text = String.Empty;
                TxtActOtro.Visibility = Visibility.Collapsed;
                LblOtraActividad.Visibility = Visibility.Collapsed;

            }
        }

        

        PersonalCcst selectedAbogado;
        private void CbxAbogResp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedAbogado = CbxAbogResp.SelectedItem as PersonalCcst;

            
        }

        private void TxtNumExpediente_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = StringUtilities.IsTextAllowed(e.Text);
        }

        PersonalCcst selectedOperativo;
        private void CbxOperativos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedOperativo = CbxOperativos.SelectedItem as PersonalCcst;

            if (selectedOperativo.IdPersonal == 42)
            {
                LblServicioSoc.Visibility = Visibility.Visible;
                TxtServicio.Visibility = Visibility.Visible;
            }
            else
            {
                LblServicioSoc.Visibility = Visibility.Collapsed;
                TxtServicio.Visibility = Visibility.Collapsed;
                TxtServicio.Text = String.Empty;
            }
        }

      


        private void SumarPaginas()
        {
            int paginasTotales = 0;

            if (ChkTesis.IsChecked == true && trabajo.Tesis != null)
            {
                foreach (Tesis tesis in trabajo.Tesis)
                    paginasTotales += tesis.Paginas;
            }

            if (ChkEjecutoria.IsChecked == true)
                paginasTotales += Convert.ToInt32(RNudPagEjecutoria.Value);

            if (ChkVoto.IsChecked == true && trabajo.Votos != null)
            {
                foreach (Voto voto in trabajo.Votos)
                    paginasTotales += voto.Paginas;
            }

            TxtTotalPags.Text = paginasTotales.ToString();
        }

        private void BtnAddTesis_Click(object sender, RoutedEventArgs e)
        {
            TesisWin addTesis = new TesisWin(ref trabajo, isUpdating) { Owner = this };
            addTesis.ShowDialog();

            RLstTesis.DataContext = trabajo.Tesis;
            SumarPaginas();
        }

        
        private void BtnDelTesis_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTesis == null)
            {
                MessageBox.Show("Debes seleccionar la tesis que quieres eliminar");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("¿Estas seguro de eliminar la tesis " + selectedTesis.NumIdentificacion,
                    "Atención:", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    new TesisModel().DeleteTesis(selectedTesis);
                    trabajo.Tesis.Remove(selectedTesis);
                }
            }
            SumarPaginas();
        }

        Tesis selectedTesis;
        private void RLstTesis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTesis = RLstTesis.SelectedItem as Tesis;
        }

        Voto selectedVoto;
        private void RLstVotos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedVoto = RLstVotos.SelectedItem as Voto;
        }

        private void BtnAddVoto_Click(object sender, RoutedEventArgs e)
        {
            VotosWin addVoto = new VotosWin(ref trabajo, isUpdating) { Owner = this };
            addVoto.ShowDialog();

            RLstVotos.DataContext = trabajo.Votos;
            SumarPaginas();
        }

        private void BtnDelVoto_Click(object sender, RoutedEventArgs e)
        {
            if (selectedVoto == null)
            {
                MessageBox.Show("Debes seleccionar el voto que quieres eliminar");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("¿Estas seguro de eliminar este voto?",
                    "Atención:", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    new VotosModel().DeleteVoto(selectedVoto);
                    trabajo.Votos.Remove(selectedVoto);
                }
            }
            SumarPaginas();
        }

        #region Grids

        private void ChkTesis_Checked(object sender, RoutedEventArgs e)
        {
            GTesis.IsEnabled = true;
        }

        private void ChkTesis_Unchecked(object sender, RoutedEventArgs e)
        {
            if (trabajo.Tesis != null && trabajo.Tesis.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("Se eliminarán las tesis relacionadas ¿Deseas continuar?", "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    trabajo.Tesis = null;
                }
                else
                    return;
            }
            RLstTesis.DataContext = trabajo.Tesis;
            GTesis.IsEnabled = false;
            SumarPaginas();
        }

        private void ChkEjecutoria_Checked(object sender, RoutedEventArgs e)
        {
            GEjecutoria.IsEnabled = true;
            RNudPagEjecutoria.Value = 1;
            SumarPaginas();
        }

        private void ChkEjecutoria_Unchecked(object sender, RoutedEventArgs e)
        {
            GEjecutoria.IsEnabled = false;
            trabajo.PaginasEjecutoria = 0;
            SumarPaginas();
        }

        private void ChkVoto_Checked(object sender, RoutedEventArgs e)
        {
            GVotos.IsEnabled = true;
        }

        private void ChkVoto_Unchecked(object sender, RoutedEventArgs e)
        {
            if (trabajo.Votos != null && trabajo.Votos.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("Se eliminarán los votos relacionadas ¿Deseas continuar?", "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    trabajo.Votos = null;
                }
                else
                    return;
            }
            RLstVotos.DataContext = trabajo.Votos;
            GVotos.IsEnabled = false;

            SumarPaginas();
        }

        #endregion

        private void RNudPagEjecutoria_ValueChanged(object sender, RadRangeBaseValueChangedEventArgs e)
        {
            SumarPaginas();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            int tipoDocumento = 0;
            int numActividades = 0;

            if(RdtpFechaIndicada.SelectedTime == null)
            {
                MessageBox.Show("Para continuar selecciona la hora indicada para la entrega del documento");
                return;
            }

            TxtPrioridades.Text = VerificationUtilities.TextBoxStringValidation(TxtPrioridades.Text);

            if (ChkTesis.IsChecked == true)
            {
                tipoDocumento += Convert.ToInt32(ChkTesis.Tag);

                if (trabajo.Tesis == null || trabajo.Tesis.Count == 0)
                {
                    MessageBox.Show("Agrega al menos una tesis o de lo contrario desmarca la casilla de tesis");
                    return;
                }
            }

            if (ChkEjecutoria.IsChecked == true)
                tipoDocumento += Convert.ToInt32(ChkEjecutoria.Tag);

            if (ChkVoto.IsChecked == true)
            {
                tipoDocumento += Convert.ToInt32(ChkVoto.Tag);

                if (trabajo.Votos == null || trabajo.Votos.Count == 0)
                {
                    MessageBox.Show("Agrega al menos un voto o de lo contrario desmarca la casilla de Votos");
                    return;
                }
            }

            if (isUpdating)
            {
                if (RdtpEntrega.SelectedDate != null && RdtpEntrega.SelectedTime == null)
                {
                    MessageBox.Show("Además de la fecha de entrega debes seleccionar la hora");
                    return;
                }
            }
            
            trabajo.IdActividad = 0;
            foreach (Actividades actividad in listaActividades)
                if (actividad.IsSelected)
                {
                    if (actividad.IdActividad == 128 && actividad.IsSelected && String.IsNullOrWhiteSpace(trabajo.OtraActividad) && String.IsNullOrEmpty(trabajo.OtraActividad))
                    {
                        MessageBox.Show("Especifíca la \"Otra\" actividad a realizar");
                        return;
                    }

                    trabajo.IdActividad += actividad.IdActividad;

                    numActividades++;
                }

            trabajo.TipoDocumento = tipoDocumento;
            trabajo.IdAbogado = Convert.ToInt32(CbxAbogResp.SelectedValue);
            trabajo.IdTipoAsunto = Convert.ToInt32(CbxTipoAsunto.SelectedValue);
            trabajo.IdPrioridad = Convert.ToInt32(CbxPrioridad.SelectedValue);
            trabajo.IdOperativo = Convert.ToInt32(CbxOperativos.SelectedValue);
            trabajo.PaginasReales = Convert.ToInt32(TxtTotalPags.Text);
            trabajo.PaginasTotales = trabajo.PaginasReales * numActividades;

            if (trabajo.IdOperativo != -1)
                trabajo.IdQuienAsigna = AccesoUsuario.IdUsuario;

            if (trabajo.IdOperativo == 42 && String.IsNullOrWhiteSpace(trabajo.ServicioSocial) && String.IsNullOrEmpty(trabajo.ServicioSocial))
            {
                MessageBox.Show("Ingresa el nombre del prestador de servicio social");
                return;
            }

            var oVldResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var oVldContext = new ValidationContext(trabajo, null, null);

            if (Validator.TryValidateObject(trabajo, oVldContext, oVldResults, true))
            {
                

                if (isUpdating)
                {
                    if (new TrabajoAsignadoModel().UpdateTrabajo(trabajo))
                    {
                        DialogResult = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo completar la operación, vuelva a intentarlo");
                    }
                }
                else
                {
                    if (new TrabajoAsignadoModel().SetNewTrabajo(ref trabajo))
                    {
                        if(listaTrabajos != null )
                            listaTrabajos.Add(trabajo);

                        DialogResult = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo completar la operación, vuelva a intentarlo");
                    }
                }
            }
            else
            {
                var sVldErrors = String.Join("\n", oVldResults.Select(t => String.Format("- {0}", t.ErrorMessage)));
                ErrorUtilities.MostrarMensajes("ERRORES EN VALIDACIONES ", sVldErrors);
            }
        }


        public void LoadForUpdate()
        {
            if (trabajo.IdInstancia == 1)
                RadScjn.IsChecked = true;
            else if (trabajo.IdInstancia == 2)
                RadPleno.IsChecked = true;

            CbxAbogResp.SelectedValue = trabajo.IdAbogado;
            CbxTipoAsunto.SelectedValue = trabajo.IdTipoAsunto;
            CbxPrioridad.SelectedValue = trabajo.IdPrioridad;
            CbxOperativos.SelectedValue = trabajo.IdOperativo;

            if (trabajo.TipoDocumento == 1 || trabajo.TipoDocumento == 3 || trabajo.TipoDocumento == 5 || trabajo.TipoDocumento == 7)
            {
                ChkTesis.IsChecked = true;
                RLstTesis.DataContext = trabajo.Tesis;
            }

            if (trabajo.TipoDocumento == 2 || trabajo.TipoDocumento == 3 || trabajo.TipoDocumento == 6 || trabajo.TipoDocumento == 7)
            {
                ChkEjecutoria.IsChecked = true;
            }

            if (trabajo.TipoDocumento == 4 || trabajo.TipoDocumento == 5 || trabajo.TipoDocumento == 6 || trabajo.TipoDocumento == 7)
            {
                ChkVoto.IsChecked = true;
                RLstVotos.DataContext = trabajo.Votos;
            }

            List<int> actividades = NumericUtilities.GetDecimalsInBinary(trabajo.IdActividad);

            foreach (Actividades actividad in listaActividades)
                if (actividades.Contains(actividad.IdActividad))
                    actividad.IsSelected = true;

        }

        private void BtnErrores_Click(object sender, RoutedEventArgs e)
        {
            ErrorWin errorWin = new ErrorWin(trabajo) { Owner = this };
            errorWin.ShowDialog();
        }

        int tiempoEstimado;
        private void RLstActividades_LostFocus(object sender, RoutedEventArgs e)
        {
            tiempoEstimado = 0;
            foreach (Actividades actividad in listaActividades)
            {
                if (actividad.IsSelected && actividad.MinutosMedia > 0)
                {
                    tiempoEstimado += (Convert.ToInt32(TxtTotalPags.Text) * actividad.MinutosMedia) / actividad.NumHojas;
                }
            }

            if (tiempoEstimado > 0)
            {
                //trabajo.FechaIndicada = trabajo.FechaInicio.Value.AddMinutes(tiempoEstimado);
                //RdtpFechaIndicada.ToolTip = "Tiempo estimado de entrega sin tomar en cuenta actividades como el cotejo y observaciones";

                TxtEstimado.Text = String.Format("** El tiempo estimado de trabajo es de {0} horas, contando las actividades con tiempo de trabajo medio", (tiempoEstimado / 60));
            }
        }

        private void RadScjn_Checked(object sender, RoutedEventArgs e)
        {
            trabajo.IdInstancia = 1;
        }

        private void RadPleno_Checked(object sender, RoutedEventArgs e)
        {
            trabajo.IdInstancia = 2;
        }

        private void RdtpFechaInicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RdtpFechaIndicada.SelectableDateStart = RdtpFechaInicio.SelectedDate;
            RdtpFechaIndicada.StartTime = RdtpFechaInicio.SelectedTime ?? DateTime.Now.TimeOfDay;
        }
       
    }
}
