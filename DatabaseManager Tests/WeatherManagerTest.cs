using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoFixture;
using AutoFixture.Xunit2;
using Common.Models;
using DatabaseManager;
using DatabaseManager.Interfaces;
using Moq;
using Xunit;

namespace DatabaseManager_Tests
{

    public class WeatherManagerTest
    {
        private static DbSet<T> GetQueryableMockDbSet<T>(params T[] sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            return dbSet.Object;
        }

        [Fact]
        public void SaveNullShouldNotTryAddToDatabase()
        {
            //Arrange
            WeatherMain expecWeatherMain = new WeatherMain()
            {
                Humidity = 0,
                Pressure = 0,
                Temperature = 0,
                TemperatureMin = 0,
                TemperatureMax = 0,
            };
            Wind expectedWind = new Wind()
            {
                Direction = 0,
                Speed = 0
            };
            PredictionDate expectedPredictionDate = new PredictionDate()
            {
                Time = DateTime.Now,

            };
            Clouds expectedClouds = new Clouds()
            {
                All = 0
            };
            Forecast expectedForecast = new Forecast()
            {
                Clouds = expectedClouds,
                WeatherMain = expecWeatherMain,
                Wind = expectedWind,
                Time = expectedPredictionDate,
                CityId = 0
            };
            ForecastEntity expectedEntity = new ForecastEntity()
            {
                WeatherMain = expecWeatherMain,
                Wind = expectedWind,
                PredictionDate = expectedPredictionDate,
                Clouds = expectedClouds,
                CityServiceId = 0,
                Forecast = expectedForecast
            };

        var weatherContextMock = new Mock<WeatherDataContext>();
            weatherContextMock.Setup(x => x.Forecast.Add(It.IsAny<Forecast>())).Returns((Forecast f) => f);
            weatherContextMock.Setup(x => x.City.Add(It.IsAny<City>())).Returns((City f) => f);
            weatherContextMock.Setup(x => x.Clouds.Add(It.IsAny<Clouds>())).Returns((Clouds f) => f);
            weatherContextMock.Setup(x => x.PredictionDate.Add(It.IsAny<PredictionDate>())).Returns((PredictionDate f) => f);
            weatherContextMock.Setup(x => x.WeatherMain.Add(It.IsAny<WeatherMain>())).Returns((WeatherMain f) => f);
            weatherContextMock.Setup(x => x.Wind.Add(It.IsAny<Wind>())).Returns((Wind f) => f);
            WeatherManager weather = new WeatherManager(weatherContextMock.Object);

            //Act
            
            var savedEntities = weather.SaveForecastEntity(expectedEntity).Result;
            //Assert
            Assert.Equal(1, savedEntities);
            weatherContextMock.Verify(x => x.SaveChangesAsync(), Times.Never);
        }

        [Fact]
        public void GetForecastEntityShouldReturnForecastObject()
        {

        }

        [Fact]
        public void GetForecastBetweenDatesShouldReturnCityForecastObjectForSpecificDate()
        {

        }

        [Fact]
        public void GetLatestForecastShouldReturnObjectWithLis3tOfForecasts()
        {

        }
    }
}
