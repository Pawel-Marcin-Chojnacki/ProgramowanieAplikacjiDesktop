using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Weather_Charts.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using Common.Models;

namespace Weather_Charts
{
    /// <summary>
    /// Interaction logic for Pressure.xaml
    /// </summary>
    public partial class Pressure : Window
    {
        private PressureViewModel viewModel;
        public Pressure(City selectedCity)
        { 
            viewModel = new PressureViewModel(selectedCity);
            InitializeComponent();
            DataContext = viewModel;
        }

        private void ContentControl_Loaded(object sender, RoutedEventArgs e)
        {
            var contentControl = sender as ContentControl;
            ChartValues<double> values = new ChartValues<double>();
            values = viewModel.ChartValues;
            contentControl.Content = new SolidChart(viewModel.ChartValues, viewModel.CityName, viewModel.DateRange);
        }
    }
}
