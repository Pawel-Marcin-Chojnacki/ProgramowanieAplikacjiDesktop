using System;
using Xunit;
using OpenWeatherMap;
using OpenWeatherMap.DTO;
using Moq;

namespace OpenWeatherMap_Tests
{
    public class OpenWeatherAPITests
    {
        [Theory]
        [InlineData("garbage")]
        [InlineData("1234567890")]
        [InlineData("00004c9e75d9616702ff283de99c0000")]
        public void SetAPIKeyShouldChangeKey(string key)
        {
            //Arrange
            OpenWeaherAPI api = new OpenWeaherAPI();
            string currentKey = api.GetAPIKey();
            Assert.NotSame(currentKey, key);
            //Act
            api.SetAPIKey(key);
            //Assert
            currentKey = api.GetAPIKey();
            Assert.Equal(currentKey, key);
        }

       
        [Fact]
        public void GetAPIKeyShouldReturnCorrectKey()
        {
            //Arrange
            OpenWeaherAPI api = new OpenWeaherAPI();
            //Act
            string currentKey = api.GetAPIKey();
            //Assert
            Assert.NotNull(currentKey);
        }

        private string jsonResponse = "{ \"cod\":\"200\", \"message\":0.0154, \"cnt\":40, \"list\":[{\"dt\":1534777200,\"main\":{\"temp\":299.656,\"temp_min\":299.656,\"temp_max\":299.656,\"pressure\":1020.01,\"sea_level\":1030.14,\"grnd_level\":1020.01,\"humidity\":53,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03d\"}],\"clouds\":{\"all\":44},\"wind\":{\"speed\":5.05,\"deg\":289.003},\"rain\":{},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2018-08-20 15:00:00\"}],\"city\":{\"id\":3083271,\"name\":\"Torun\",\"coord\":{\"lat\":53.0137,\"lon\":18.5981},\"country\":\"PL\"}}";
    }
}
