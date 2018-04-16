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
            DataContext = new string[] { "course1", "course2" };
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
