using Common.Models;
using DatabaseManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class WeatherManager
    {
        public WeatherManager(IDataContext context)
        {
            dataContext = context;
        }

        private IDataContext dataContext;

        public async void SaveForecastEntity(ForecastEntity forecast)
        {
            dataContext.Clouds.Add(forecast.Clouds);
            dataContext.PredictionDate.Add(forecast.PredictionDate);
            dataContext.WeatherMain.Add(forecast.WeatherMain);
            dataContext.Wind.Add(forecast.Wind);
            forecast.Forecast.CityId = dataContext.City.Where(u => u.ServiceId == forecast.CityServiceId).Single().Id;
            dataContext.Forecast.Add(forecast.Forecast);

            await dataContext.SaveChangesAsync();
        }

        public ForecastEntity GetForecastEntity(City city, DateTime date)
        {
            DateTime preciseTime = GetCLosestForecastTime(date);
            var forecast = dataContext.Forecast.Where(f => f.Time.Time == preciseTime).Where(c => c.City.ServiceId == city.ServiceId).First();
            Clouds clouds = forecast.Clouds;
            PredictionDate predictionDate = forecast.Time;
            WeatherMain weatherMain = forecast.WeatherMain;
            Wind wind = forecast.Wind;
            ForecastEntity forecastEntity = new ForecastEntity
            {
                Clouds = clouds,
                PredictionDate = predictionDate,
                WeatherMain = weatherMain,
                Wind = wind
            };
            return forecastEntity;
        }

        private DateTime GetCLosestForecastTime(DateTime date)
        {
            DateTime cleanDate = new DateTime(date.Year, date.Month, date.Day);
            var remainder = date.Hour % 3;
            int hour = 0;
            switch (remainder)
            {
                case 0:
                    hour = date.Hour;
                    break;
                case 1:
                    hour = date.Hour - 1;
                    break;
                case 2:
                    hour = date.Hour - 2;
                    break;
                default:
                    break;
            }
            cleanDate = cleanDate.AddHours(hour);
            return cleanDate;
        }

        public ForecastEntity GetForecastBetweenDates(City city, DateTime dateFrom, DateTime dateTo)
        {
            DateTime preciseTimeFrom = GetCLosestForecastTime(dateFrom);
            DateTime preciseTimeTo = GetCLosestForecastTime(dateTo);
            var forecast = dataContext.Forecast.Where(f => f.Time.Time >= preciseTimeFrom).Where(f => f.Time.Time <= preciseTimeTo).Where(c => c.City.ServiceId == city.ServiceId).First();
            Clouds clouds = forecast.Clouds;
            PredictionDate predictionDate = forecast.Time;
            WeatherMain weatherMain = forecast.WeatherMain;
            Wind wind = forecast.Wind;
            ForecastEntity forecastEntity = new ForecastEntity
            {
                Clouds = clouds,
                PredictionDate = predictionDate,
                WeatherMain = weatherMain,
                Wind = wind
            };
            return forecastEntity;
        }
        
        public ForecastEntity GetLatestForecast(City city)
        {
            var datesForCity = dataContext.Forecast.Where(c => c.City.ServiceId == city.ServiceId);
            var maxDateTime = datesForCity.Max(d => d.Time.Time);
            var forecast = datesForCity.Where(d => d.Time.Time == maxDateTime).First();
            Clouds clouds = forecast.Clouds;
            PredictionDate predictionDate = forecast.Time;
            WeatherMain weatherMain = forecast.WeatherMain;
            Wind wind = forecast.Wind;
            ForecastEntity forecastEntity = new ForecastEntity
            {
                Clouds = clouds,
                PredictionDate = predictionDate,
                WeatherMain = weatherMain,
                Wind = wind
            };
            return forecastEntity;
        }
    }
}
