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
    public class TemperatureViewModel : INotifyPropertyChanged
    {
        public TemperatureViewModel(City selectedCity)
        {
            InitializeData(selectedCity);
        }

        private void InitializeData(City selectedCity)
        {
            CityName = selectedCity.Name;
            City city = selectedCity;
            DateTime fiveDaysLater = new DateTime();
            DateTime now = new DateTime();
            now = fiveDaysLater = DateTime.Now;
            fiveDaysLater = fiveDaysLater.AddDays(5);
            WeatherManager weatherManager = new WeatherManager(new WeatherDataContext());
            forecast = weatherManager.GetForecasts(selectedCity, now, fiveDaysLater);
            ModelsService modelsService = new ModelsService();
            ChartValues = modelsService.TemperaturesToChart(forecast);
            Dates = modelsService.DatesToArray(forecast).ToArray();
        }


        public string CityName { get; set; }

        public string[] Dates { get; set; }

        public ChartValues<double> ChartValues { get; set; }

        private List<ForecastEntity> forecast { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

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
