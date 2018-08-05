using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    /// <summary>
    /// 
    /// </summary>
    public class WeatherManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public WeatherManager(IDataContext context)
        {
            dataContext = context;
        }

        private IDataContext dataContext;


        public async void SaveForecastEntity(ForecastEntity forecast)
        {
            dataContext.Forecast.Add(forecast.Forecast); // TODO: Check if it's correct way to add constraints.
            dataContext.Clouds.Add(forecast.Clouds);
            dataContext.PredictionDate.Add(forecast.PredictionDate);
            dataContext.WeatherMain.Add(forecast.WeatherMain);
            dataContext.Wind.Add(forecast.Wind);
            await dataContext.SaveChangesAsync();
        }


        public ForecastEntity GetForecastEntity(City city, DateTime date)
        {


            DateTime preciseTime = GetCLosestForecastTime(date);
            var predDate = dataContext.PredictionDate.Where(p => p.Time == preciseTime).First();
            var timeId = predDate.Id;

            var forecast = dataContext.Forecast.Where(p => p.TimeId == predDate).Where(p => p.CityId.Any(c => c.Id == city.Id)).Single();
            var clouds = dataContext.Clouds.Where(p => p.Id == forecast.CloudsId.Single().Id);
            var weatherMain = dataContext.WeatherMain.Where(p => p.Id == forecast.WeatherMainId.Single().Id);
            var wind = dataContext.Wind.Where(p => p.Id == forecast.WindId.Single().Id);

            ForecastEntity entity = new ForecastEntity();
            entity.CityServiceId = city.ServiceId;
            //entity.Clouds = clouds;
            throw new NotImplementedException();

            //Forecast forecasts = new Forecast();
            //dataContext.Forecast.Where(x => x.CityId.Where);
            //forecasts = dataContext.Forecast.Select(pred => pred.CityId.Where(c => c.ServiceId == city.ServiceId));
            //return forecasts;
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
            cleanDate.AddHours(hour);
            return cleanDate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public Forecast GetForecastBetweenDates(City city, DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
            //Forecast forecast = new Forecast();
            //return forecast;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Forecast GetLatestForecast()
        {
            throw new NotImplementedException();
        }
    }
}
