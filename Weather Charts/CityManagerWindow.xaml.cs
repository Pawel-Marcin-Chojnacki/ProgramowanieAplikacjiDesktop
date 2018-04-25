using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Weather_Charts
{
    /// <summary>
    /// Interaction logic for CityManagerWindow.xaml
    /// </summary>
    public partial class CityManagerWindow : Window
    {
        public CityManagerWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DatabaseManager.WeatherDataContext weatherDataContext = new DatabaseManager.WeatherDataContext();
            weatherDataContext.Weather.ToList();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}