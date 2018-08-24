using DatabaseManager;
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
    /// Interaction logic for AddCity.xaml
    /// </summary>
    public partial class AddCity : Window
    {
        private string name;
        private bool observed;
        private int serviceId;

        public AddCity()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            CityManager cm = new CityManager(new WeatherDataContext());
            await cm.AddObservedCity(new Common.Models.City() { Name = name, Observed = observed, ServiceId = serviceId });
            this.Close();
        }

        private void ServiceId_LostFocus(object sender, RoutedEventArgs e)
        {
            int.TryParse(ServiceId.Text, out serviceId);
        }

        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            name = Name.Text;
        }

        private void Observed_Click(object sender, RoutedEventArgs e)
        {
            if (Observed.IsChecked != null && Observed.IsChecked == true)
            {
                observed = true;    
            }
        }
    }
}
