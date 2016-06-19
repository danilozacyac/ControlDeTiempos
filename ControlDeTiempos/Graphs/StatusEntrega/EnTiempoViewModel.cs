using ControlDeTiempos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Charting;
using Telerik.Windows.Controls;

namespace ControlDeTiempos.Graphs.StatusEntrega
{
    public class EnTiempoViewModel : ViewModelBase
    {
        private List<NumeroAsuntos> collection1, collection2;
        private List<string> _chartTypes;
        private List<ChartSeriesCombineMode> _combineModes;
        private ChartSeriesCombineMode _selectedCombineMode;
        private bool _isShowLabelsEnabled = true;
        private bool _showLabels = true;
        private string _selectedChartType;

        public EnTiempoViewModel()
        {
            this.InitializeChartTypes();
            this.SelectedChartType = this.ChartTypes[5];
        }

        public List<string> ChartTypes
        {
            get { return this._chartTypes; }
        }

        public string SelectedChartType
        {
            get
            {
                return this._selectedChartType;
            }
            set
            {
                if (this._selectedChartType == value)
                    return;

                this._selectedChartType = value;
                this.OnPropertyChanged("SelectedChartType");
                this.OnSelectedChartTypeChanged();
            }
        }

        public List<NumeroAsuntos> Collection1
        {
            get
            {
                if (this.collection1 == null)
                {
                    this.collection1 = new GraficasModel().GetTotalQueTiempo(1, 32, DateTime.Now.Month, DateTime.Now.Year);
                    this.collection1.AddRange(new GraficasModel().GetTotalQueTiempo(1, 32, 7, DateTime.Now.Year));
                }
                return this.collection1;
            }
        }

        public List<NumeroAsuntos> Collection2
        {
            get
            {
                if (this.collection2 == null)
                {
                    this.collection2 = new GraficasModel().GetTotalQueTiempo(0, 32, DateTime.Now.Month, DateTime.Now.Year);
                    this.collection2.AddRange(new GraficasModel().GetTotalQueTiempo(0, 32, 7, DateTime.Now.Year));
                }
                return this.collection2;
            }
        }

        public List<ChartSeriesCombineMode> CombineModes
        {
            get
            {
                return this._combineModes;
            }
            private set
            {
                if (this._combineModes == value)
                    return;

                this._combineModes = value;
                this.OnPropertyChanged("CombineModes");
            }
        }

        public ChartSeriesCombineMode SelectedCombineMode
        {
            get
            {
                return this._selectedCombineMode;
            }
            set
            {
                if (this._selectedCombineMode != value)
                {
                    this._selectedCombineMode = value;
                    this.OnPropertyChanged("SelectedCombineMode");
                }
            }
        }

        public bool ShowLabels
        {
            get
            {
                return this._showLabels;
            }
            set
            {
                if (this._showLabels != value)
                {
                    this._showLabels = value;
                    this.OnPropertyChanged("ShowLabels");
                }
            }
        }

        public bool IsShowLabelsEnabled
        {
            get
            {
                return this._isShowLabelsEnabled;
            }
            set
            {
                if (this._isShowLabelsEnabled != value)
                {
                    this._isShowLabelsEnabled = value;
                    this.OnPropertyChanged("IsShowLabelsEnabled");
                }
            }
        }

        private void InitializeChartTypes()
        {
            this._chartTypes = new List<string>();
            this._chartTypes.Add("Line");
            this._chartTypes.Add("Spline");
            this._chartTypes.Add("Area");
            this._chartTypes.Add("Spline Area");
            this._chartTypes.Add("Step Line");
            this._chartTypes.Add("Step Area");
        }

        private void OnSelectedChartTypeChanged()
        {
            List<ChartSeriesCombineMode> combineModes = new List<ChartSeriesCombineMode>();
            if (this.SelectedChartType == "Line" || this.SelectedChartType == "Spline" || this.SelectedChartType == "Step Line")
            {
                combineModes.Add(ChartSeriesCombineMode.None);
                combineModes.Add(ChartSeriesCombineMode.Stack);
                this.ShowLabels = true;
                this.IsShowLabelsEnabled = true;
            }
            else if (this.SelectedChartType == "Area" || this.SelectedChartType == "Spline Area" || this.SelectedChartType == "Step Area")
            {
                combineModes.Add(ChartSeriesCombineMode.Stack);
                combineModes.Add(ChartSeriesCombineMode.Stack100);
                this.ShowLabels = false;
                this.IsShowLabelsEnabled = false;
            }

            this.CombineModes = combineModes;
            if (!this.CombineModes.Contains(this.SelectedCombineMode))
            {
                this.SelectedCombineMode = this.CombineModes[0];
            }
        }
    }
}
