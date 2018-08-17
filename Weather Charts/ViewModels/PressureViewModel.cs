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
    public class PressureViewModel : INotifyPropertyChanged
    {
        public string CityName { get; set; }
        public string DateRange { get; set; }

        public List<ForecastEntity> forecast
        {
            get;
            set;
        }

        public ChartValues<double>  ChartValues { get; set; }

        public PressureViewModel(City selectedCity)
        {
            InitializeData(selectedCity);

        }

        private void InitializeData(City selectedCity)
        {
            CityName = selectedCity.Name;
            City city = selectedCity;
            WeatherManager weatherManager = new WeatherManager(new WeatherDataContext());
            DateTime fiveDaysLater = new DateTime();
            DateTime now = new DateTime();
            now = fiveDaysLater = DateTime.Now;
            fiveDaysLater = fiveDaysLater.AddDays(5);
            forecast = weatherManager.GetForecasts(selectedCity, now,  fiveDaysLater);
            ModelsService modelsService = new ModelsService();
            ChartValues = modelsService.PressureToChart(forecast);
            DateRange = DateTime.Now.AddDays(5).ToString() + " - " + DateTime.Now.ToString();
        }

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
