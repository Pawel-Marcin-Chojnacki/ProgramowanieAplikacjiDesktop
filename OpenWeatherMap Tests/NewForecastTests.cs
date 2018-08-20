using System;
using AutoFixture.Xunit2;
using OpenWeatherMap.DTO;
using Xunit;

namespace OpenWeatherMap_Tests
{
    public class NewForecastTests
    {
        [Fact]
        public void FromJsonShouldReturnForecastObject()
        {
            var forecast = Forecast.FromJson(jsonResponse);
            Assert.Equal("Torun", forecast.City.Name);
        }

        [Theory, AutoData]
        public void ToJsonShouldReturnJsonObject(Forecast forecast)
        {
            var result = forecast.ToJson();
            var transformBack = Forecast.FromJson(result); 
            Assert.Equal(forecast.City.Country, transformBack.City.Country);
            Assert.Equal(forecast.List.Count, transformBack.List.Count);
        }

        private string jsonResponse = "{ \"cod\":\"200\", \"message\":0.0154, \"cnt\":40, \"list\":[{\"dt\":1534777200,\"main\":{\"temp\":299.656,\"temp_min\":299.656,\"temp_max\":299.656,\"pressure\":1020.01,\"sea_level\":1030.14,\"grnd_level\":1020.01,\"humidity\":53,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03d\"}],\"clouds\":{\"all\":44},\"wind\":{\"speed\":5.05,\"deg\":289.003},\"rain\":{},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2018-08-20 15:00:00\"}],\"city\":{\"id\":3083271,\"name\":\"Torun\",\"coord\":{\"lat\":53.0137,\"lon\":18.5981},\"country\":\"PL\"}}";

    }
}
