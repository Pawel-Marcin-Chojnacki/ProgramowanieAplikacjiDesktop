using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class WeatherManager
    {
        public WeatherManager()
        {
            dataContext = new WeatherDataContext();
        }
        private WeatherDataContext dataContext;

        public void SaveForecastEntity()
        {

        }

        public Forecast GetForecastEntity(City city, DateTime date)
        {
            throw new NotImplementedException();

            Forecast forecasts = new Forecast();
            //dataContext.Forecast.Where(x => x.City.Where);
            //forecasts = dataContext.Forecast.Select(pred => pred.City.Where(c => c.ServiceId == city.ServiceId));
            return forecasts;
        }

        public Forecast GetForecastBetweenDates(City city, DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
            Forecast forecast = new Forecast();
            return forecast;
        }

        public Forecast GetLatestForecast()
        {
            throw new NotImplementedException();
        }
    }
}
