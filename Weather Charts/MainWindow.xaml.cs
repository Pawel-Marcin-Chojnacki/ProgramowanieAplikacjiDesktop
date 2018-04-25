using System.Collections.Generic;
using System.Windows;
using Weather_Charts.ViewModels;

namespace Weather_Charts
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CityManagerWindow cityManagerWindow = new CityManagerWindow();
            cityManagerWindow.Show();
        }

        private void SelectedCity_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
        }
    }
}
