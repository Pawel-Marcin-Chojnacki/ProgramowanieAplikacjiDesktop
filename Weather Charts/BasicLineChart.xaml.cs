using System;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;

namespace Weather_Charts
{
    public partial class BasicLineChart : UserControl
    {
        public BasicLineChart(ChartValues<double> temperatures, string cityName, string[] labels)
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = cityName,
                        Values = temperatures,
                        PointGeometrySize = 15
                    }
                };

            Labels = labels;
            YFormatter = value => value.ToString();
            
            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

    }
}