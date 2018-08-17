using DatabaseManager;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Weather_Charts.ViewModels;

namespace Weather_Charts
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;
        public MainWindow()
        {
            viewModel = new MainWindowViewModel();
            InitializeComponent();
            DataContext = viewModel;
        }

        private void CleanDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.CleanDatabase();
        }

        private void ShowTemperature_Click(object sender, RoutedEventArgs e)
        {
            Temperature chart = new Temperature(viewModel.currentCity);
            chart.Show();
        }

        private void ShowMultiTemperature_Click(object sender, RoutedEventArgs e)
        {
            MultiTemperature chart = new MultiTemperature();
            chart.Show();
        }

        private void StartServiceButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.StartService();
        }

        private void StopServiceButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.StopService();
        }

        private void ShowPressure_Click(object sender, RoutedEventArgs e)
        {
            Pressure chart = new Pressure(viewModel.currentCity);
            chart.Show();
        }
    }
}
