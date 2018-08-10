using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseManager;
using Common.Models;
using OpenWeatherMap;
using OpenWeatherMap.DTO;

namespace Forecast_Collector
{
    public class CurrentWeatherJob : IJob
    {
        async Task IJob.Execute(IJobExecutionContext context)
        {
            CityManager cityManager = new CityManager(new WeatherDataContext());
            var observedCities = cityManager.GetObservedCities();

            OpenWeaherAPI openWeaher = new OpenWeaherAPI();
            List<OpenWeatherMap.DTO.Forecast> forecastDTOs = new List<OpenWeatherMap.DTO.Forecast>();
            foreach (var city in observedCities)
            {
                var forecastDTO = await openWeaher.GetForecast(city.ServiceId);
                forecastDTOs.Add(forecastDTO);
            }

            WeatherManager weather = new WeatherManager(new WeatherDataContext());
            List<ForecastEntity> forecastEntities = new List<ForecastEntity>();

            foreach (var f in forecastDTOs) //each city
            {
                var convertedModels = ConvertModel(f);
                forecastEntities.AddRange(convertedModels);
            }

            foreach (var fEntity in forecastEntities)
            {
                weather.SaveForecastEntity(fEntity);
            }
        }

        private List<ForecastEntity> ConvertModel(OpenWeatherMap.DTO.Forecast f)
        {
            List<ForecastEntity> entities = new List<ForecastEntity>();
            ForecastEntity entity = new ForecastEntity();
            foreach (var weather in f.List)
            {
                entity = new ForecastEntity();
                
                entity.CityServiceId = (int)f.City.Id;

                entity.Clouds = new Common.Models.Clouds();
                entity.Clouds.All = weather.Clouds.All;

                entity.PredictionDate = new PredictionDate();
                entity.PredictionDate.Time = weather.DtTxt.DateTime;

                entity.WeatherMain = new WeatherMain();
                entity.WeatherMain.Humidity = (int)weather.Main.Humidity;
                entity.WeatherMain.Pressure = (int)weather.Main.Pressure;
                entity.WeatherMain.Temperature = (int)weather.Main.Pressure;
                entity.WeatherMain.TemperatureMax = (int)weather.Main.TempMax;
                entity.WeatherMain.TemperatureMin = (int)weather.Main.TempMin;

                entity.Wind = new Common.Models.Wind();
                entity.Wind.Direction = weather.Wind.Deg;
                entity.Wind.Speed = weather.Wind.Speed;
                entities.Add(entity);
            }
            return entities;
        }
    }
}
