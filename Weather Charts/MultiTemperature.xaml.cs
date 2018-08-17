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

namespace Weather_Charts
{
    /// <summary>
    /// Interaction logic for MultiTemperature.xaml
    /// </summary>
    public partial class MultiTemperature : Window
    {
        private MultiTemperatureViewModel viewModel;

        public MultiTemperature()
        {
            viewModel = new MultiTemperatureViewModel();

            InitializeComponent();
            DataContext = viewModel;

        }

        private void ContentControl_Loaded(object sender, RoutedEventArgs e)
        {
            var contentControl = sender as ContentControl;

            contentControl.Content = new BasicColumn(viewModel.MinTemperatures, viewModel.MaxTemperatures, viewModel.Cities);
        }
    }
}
