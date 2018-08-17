using Common.Models;
using DatabaseManager;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Charts.ViewModels
{
    public class MultiTemperatureViewModel : INotifyPropertyChanged
    {
        public MultiTemperatureViewModel()
        {
            InitializeData();
        }

        private void InitializeData()
        { 
            DateTime fiveDaysLater = new DateTime();
            DateTime now = new DateTime();
            now = fiveDaysLater = DateTime.Now;
            fiveDaysLater = fiveDaysLater.AddDays(5);
            WeatherManager weatherManager = new WeatherManager(new WeatherDataContext());
            CityManager cityManager = new CityManager(new WeatherDataContext());
            var cities = cityManager.GetObservedCities();
            Dictionary<string, List<ForecastEntity>> entities = new Dictionary<string, List<ForecastEntity>>();

            foreach (var city in cities)
            {
                entities.Add(city.Name, weatherManager.GetForecasts(city, now, fiveDaysLater));
            }
            var labels = new List<string>();
            MinTemperatures = new ChartValues<double>();
            MaxTemperatures = new ChartValues<double>();
            foreach (var entity in entities)
            {
                MinTemperatures.Add(entity.Value.Min(x => x.WeatherMain.TemperatureMin));
                MaxTemperatures.Add(entity.Value.Max(x => x.WeatherMain.TemperatureMax));
                labels.Add(entity.Key);
            }
            Cities = labels.ToArray();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ChartValues<double> MinTemperatures { get; set; }

        public ChartValues<double>   MaxTemperatures { get; set; }

        public string[] Cities { get; set; }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
