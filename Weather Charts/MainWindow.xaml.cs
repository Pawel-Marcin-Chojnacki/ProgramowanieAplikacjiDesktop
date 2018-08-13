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

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    cityManagerWindow.Show();
        //    CityManagerWindow cityManagerWindow = new CityManagerWindow();
        //}

        //private void SelectedCity_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        //{
        //   // viewModel.CurrentCity = 
        //}

        private void CleanDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.CleanDatabase();
        }

        private void ShowStatistics_Click(object sender, RoutedEventArgs e)
        {
            GeneralChart chart = new GeneralChart();
            chart.Show();
        }
    }
}
