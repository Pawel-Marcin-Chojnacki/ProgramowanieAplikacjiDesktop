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
using LiveCharts;
using LiveCharts.Wpf;

namespace Weather_Charts
{
    /// <summary>
    /// Interaction logic for BasicColumn.xaml
    /// </summary>
    public partial class BasicColumn : UserControl
    {
        public BasicColumn(ChartValues<double> mininalTemperatureValues, ChartValues<double> maximalTemperatureValues, string[] cities)
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Min",
                    Values = mininalTemperatureValues
                }
            };

            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Max",
                Values = maximalTemperatureValues
            });
;

            Labels = cities;
            Formatter = value => value.ToString();

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

    }
}