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
using Common.Logging;
using City = Common.Models.City;
using Forecast = OpenWeatherMap.DTO.Forecast;

namespace Forecast_Collector
{
    public class CurrentWeatherJob : IJob
    {
        private double KelvinToCelciusDifference = 273.15;
        private EventLogger logger;

        public CurrentWeatherJob()
        {
            logger = new EventLogger();
        }

        async Task IJob.Execute(IJobExecutionContext context)
        {
            List<ForecastEntity> forecastEntities = new List<ForecastEntity>();
            WeatherManager weather = new WeatherManager(new WeatherDataContext());

            var observedCities = LoadCitiesFromDatabase();
            var forecastDTOs = await LoadDataFromWebservice(observedCities);
            forecastEntities = ConvertModels(forecastDTOs);
            await SaveEntities(forecastEntities, weather);
        }

        private async Task SaveEntities(IEnumerable<ForecastEntity> forecastEntities, WeatherManager weather)
        {
            foreach (var fEntity in forecastEntities)
            {
                try
                {
                    await weather.SaveForecastEntity(fEntity);
                }
                catch (Exception)
                {
                    logger.WriteMessage("Failed to save a forecast to dabatabase.");
                }
            }
        }

        public List<ForecastEntity> ConvertModels(List<Forecast> forecastDTOs)
        {
            List<ForecastEntity> forecastEntities = new List<ForecastEntity>();
            foreach (var f in forecastDTOs)
            {
                var convertedModels = ConvertModel(f);
                forecastEntities.AddRange(convertedModels);
            }
            return forecastEntities;
        }

        private async Task<List<Forecast>> LoadDataFromWebservice(List<City> observedCities)
        {
            List<Forecast> forecastDTOs = new List<Forecast>();
            Forecast forecastDTO;
            OpenWeaherAPI openWeaher = new OpenWeaherAPI();
            foreach (var city in observedCities)
            {
                try
                {
                    forecastDTO = await openWeaher.GetForecast(city.ServiceId);
                }
                catch (Exception)
                {
                    logger.WriteMessage("Failed to get a forecast from webservice.");
                    continue;
                }
                forecastDTOs.Add(forecastDTO);
            }
            return forecastDTOs;
        }

        private List<City> LoadCitiesFromDatabase()
        {
            List<City> observedCities;
            CityManager cityManager = new CityManager(new WeatherDataContext());
            try
            {
                observedCities = cityManager.GetObservedCities();
            }
            catch (Exception exception)
            {
                logger.WriteMessage("Failed to retrieve City data. " + exception.Message);
                throw;
            }

            return observedCities;
        }

        /// <summary>
        /// Converts a DTO object to entity.
        /// </summary>
        /// <param name="forecastDTO">Model converted from JSON string.</param>
        /// <returns>List of forecast entites to store in a database.</returns>
        public List<ForecastEntity> ConvertModel(Forecast forecastDTO)
        {
            List<ForecastEntity> entities = new List<ForecastEntity>();
            ForecastEntity entity = new ForecastEntity();
            foreach (var weather in forecastDTO.List)
            {
                entity = new ForecastEntity
                {
                    CityServiceId = (int)forecastDTO.City.Id,

                    Clouds = new Common.Models.Clouds()
                };
                entity.Clouds.All = weather.Clouds.All;

                entity.PredictionDate = new PredictionDate
                {
                    Time = weather.DtTxt.DateTime
                };

                entity.WeatherMain = new WeatherMain
                {
                    Humidity = (int)weather.Main.Humidity,
                    Pressure = (int)weather.Main.Pressure,
                    Temperature = weather.Main.Temp - KelvinToCelciusDifference,
                    TemperatureMax = weather.Main.TempMax - KelvinToCelciusDifference,
                    TemperatureMin = weather.Main.TempMin - KelvinToCelciusDifference
                };

                entity.Wind = new Common.Models.Wind
                {
                    Direction = weather.Wind.Deg,
                    Speed = weather.Wind.Speed
                };
                entities.Add(entity);
            }
            return entities;
        }
    }
}
