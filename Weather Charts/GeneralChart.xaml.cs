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
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Shapes;

namespace Weather_Charts
{
    /// <summary>
    /// Interaction logic for GeneralChart.xaml
    /// </summary>
    public partial class GeneralChart : Window
    {
        public GeneralChart()
        {
           
            SeriesCollection = new SeriesCollection
            {
        new LineSeries
        {
            Values = new ChartValues<double> { 3, 5, 7, 4 }
},
        new ColumnSeries
        {
            Values = new ChartValues<decimal> { 5, 6, 2, 7 }
        }
    };
            InitializeComponent();
        }

        public SeriesCollection SeriesCollection { set; get; }

    }
}
