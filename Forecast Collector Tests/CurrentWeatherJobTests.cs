using Forecast_Collector;
using OpenWeatherMap.DTO;
using System;
using System.Collections.Generic;
using Xunit;

namespace Forecast_Collector_Tests
{
    public class CurrentWeatherJobTests
    {
        [Fact]
        public void ConvertModelReturnsNonEmptyList()
        {
            var forecast = Forecast.FromJson(jsonString);
            CurrentWeatherJob job = new CurrentWeatherJob();
            var result = job.ConvertModel(forecast);

            Assert.Single(result);
        }

        [Fact]
        public void ConvertModelContainsCityServiceId()
        {
            var forecast = Forecast.FromJson(jsonString);
            CurrentWeatherJob job = new CurrentWeatherJob();
            var result = job.ConvertModel(forecast);

            Assert.Equal(3083271, result[0].CityServiceId);
        }

        [Fact]
        public void ConvertModelsReturnsListOfEntities()
        {
            //arrange
            CurrentWeatherJob currentJob = new CurrentWeatherJob();
            List<Forecast> models = new List<Forecast>();

            models.Add(Forecast.FromJson(jsonString));
            models.Add(Forecast.FromJson(jsonString));
            models.Add(Forecast.FromJson(jsonString));
            //act
            var result = currentJob.ConvertModels(models);
            //assert
            Assert.Equal(3, result.Count);
        }

        private string jsonString =  "{ \"cod\":\"200\", \"message\":0.0154, \"cnt\":40, \"list\":[{\"dt\":1534777200,\"main\":{\"temp\":299.656,\"temp_min\":299.656,\"temp_max\":299.656,\"pressure\":1020.01,\"sea_level\":1030.14,\"grnd_level\":1020.01,\"humidity\":53,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03d\"}],\"clouds\":{\"all\":44},\"wind\":{\"speed\":5.05,\"deg\":289.003},\"rain\":{},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2018-08-20 15:00:00\"}],\"city\":{\"id\":3083271,\"name\":\"Torun\",\"coord\":{\"lat\":53.0137,\"lon\":18.5981},\"country\":\"PL\"}}";
    }
}