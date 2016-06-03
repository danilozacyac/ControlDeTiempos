using ControlDeTiempos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace ControlDeTiempos
{
    /// <summary>
    /// Interaction logic for ErrorWin.xaml
    /// </summary>
    public partial class ErrorWin
    {
        ErrorOperativo selecteddError;

        public ErrorWin()
        {
            InitializeComponent();
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void RadListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selecteddError = RLstErrores.SelectedItem as ErrorOperativo;
            this.DataContext = selecteddError;
        }
    }
}
