using LiveCharts;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Weather_Charts
{
    /// <summary>
    /// Interaction logic for Chart.xaml
    /// </summary>
    public partial class SolidChart : UserControl
    {
        public SolidChart(ChartValues<double> chartValues, string city, string date)
        {
            InitializeComponent();

            Values = chartValues;

            DataContext = this;

            City = city;

            Date = date;
        }

        public ChartValues<double> Values { get; set; }

        public string City { get; set; }

        public string Date { get; set; }

        private void UpdateOnclick(object sender, RoutedEventArgs e)
        {
            Chart.Update(true);
        }
    }
}

