using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Common.Models;
using LiveCharts;
using Weather_Charts.ViewModels;
using Xunit;
namespace Weather_Charts_Tests
{
    public class ModelsServiceTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void PressureToChartShouldReturnList(int density)
        {
            List<WeatherMain> expecWeatherMain = new List<WeatherMain>();
            expecWeatherMain.Add(new WeatherMain(){
                Humidity = 0,
                Pressure = 0,
                Temperature = 0,
                TemperatureMin = 0,
                TemperatureMax = 0,
            });
            expecWeatherMain.Add(new WeatherMain()
            {
                Humidity = 0,
                Pressure = 3,
                Temperature = 0,
                TemperatureMin = 0,
                TemperatureMax = 0,
            });
            expecWeatherMain.Add(new WeatherMain()
            {
                Humidity = 0,
                Pressure = 4,
                Temperature = 0,
                TemperatureMin = 0,
                TemperatureMax = 0,
            });
            expecWeatherMain.Add(new WeatherMain()
            {
                Humidity = 0,
                Pressure = 4,
                Temperature = 0,
                TemperatureMin = 0,
                TemperatureMax = 0,
            });
            expecWeatherMain.Add(new WeatherMain()
            {
                Humidity = 0,
                Pressure = 4,
                Temperature = 0,
                TemperatureMin = 0,
                TemperatureMax = 0,
            });
            expecWeatherMain.Add(new WeatherMain()
            {
                Humidity = 0,
                Pressure = 4,
                Temperature = 0,
                TemperatureMin = 0,
                TemperatureMax = 0,
            });
            expecWeatherMain.Add(new WeatherMain()
            {
                Humidity = 0,
                Pressure = 4,
                Temperature = 0,
                TemperatureMin = 0,
                TemperatureMax = 0,
            });

            List<ForecastEntity> expectedEntity = new List<ForecastEntity>();
            foreach (var weatherMain in expecWeatherMain)
            {
                expectedEntity.Add(new ForecastEntity(){WeatherMain = weatherMain});
            }
            ModelsService models = new ModelsService();

            //Act
            ChartValues<double> result = models.PressureToChart(expectedEntity, density);
            //Assert 
            Assert.Equal(result.Count, expecWeatherMain.Count / density);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void TemperaturesToChartsShouldReturnList(int density)
        {
            List<WeatherMain> expecWeatherMain = new List<WeatherMain>();
            expecWeatherMain.Add(new WeatherMain()
            {
                Humidity = 0,
                Pressure = 0,
                Temperature = 7,
                TemperatureMin = 0,
                TemperatureMax = 0,
            });
            expecWeatherMain.Add(new WeatherMain()
            {
                Humidity = 0,
                Pressure = 3,
                Temperature = 8,
                TemperatureMin = 0,
                TemperatureMax = 0,
            });
            expecWeatherMain.Add(new WeatherMain()
            {
                Humidity = 0,
                Pressure = 4,
                Temperature = 4,
                TemperatureMin = 0,
                TemperatureMax = 0,
            });
            expecWeatherMain.Add(new WeatherMain()
            {
                Humidity = 0,
                Pressure = 4,
                Temperature = 3,
                TemperatureMin = 0,
                TemperatureMax = 0,
            });
            expecWeatherMain.Add(new WeatherMain()
            {
                Humidity = 0,
                Pressure = 4,
                Temperature = 77,
                TemperatureMin = 0,
                TemperatureMax = 0,
            });
            expecWeatherMain.Add(new WeatherMain()
            {
                Humidity = 0,
                Pressure = 4,
                Temperature = 9,
                TemperatureMin = 0,
                TemperatureMax = 0,
            });
            expecWeatherMain.Add(new WeatherMain()
            {
                Humidity = 0,
                Pressure = 4,
                Temperature = 23,
                TemperatureMin = 0,
                TemperatureMax = 0,
            });

            List<ForecastEntity> expectedEntity = new List<ForecastEntity>();
            foreach (var weatherMain in expecWeatherMain)
            {
                expectedEntity.Add(new ForecastEntity() { WeatherMain = weatherMain });
            }
            ModelsService models = new ModelsService();

            //Act
            ChartValues<double> result = models.TemperaturesToChart(expectedEntity, density);
            //Assert 
            Assert.Equal(result.Count, expecWeatherMain.Count / density);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void DatesToArrayShouldReturnListOfStrings(int density)
        {
            List<PredictionDate> expectedPredictionDate = new List<PredictionDate>();
            expectedPredictionDate.Add(new PredictionDate()
            {
                Time = DateTime.Now
            });
            expectedPredictionDate.Add(new PredictionDate()
            {
                Time = DateTime.MaxValue
            });
            expectedPredictionDate.Add(new PredictionDate()
            {
                Time = DateTime.Today
            });
            expectedPredictionDate.Add(new PredictionDate()
            {
                Time = DateTime.MinValue
            });
            expectedPredictionDate.Add(new PredictionDate()
            {
                Time = DateTime.UtcNow
            });
  

            List<ForecastEntity> expectedEntity = new List<ForecastEntity>();
            foreach (var date in expectedPredictionDate)
            {
                expectedEntity.Add(new ForecastEntity() { PredictionDate = date });
            }
            ModelsService models = new ModelsService();

            //Act
            List<string> result = models.DatesToArray(expectedEntity, density);
            //Assert 
            Assert.Equal(result.Count, expectedPredictionDate.Count / density);
        }
    }
}
