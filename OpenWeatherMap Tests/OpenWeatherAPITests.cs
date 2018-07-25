using System;
using Xunit;
using OpenWeatherMap;

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

        [Theory]
        public void GetWeatherShouldReturnJSON()
        {
            //Arrange
            //Act
            //Assert
        }

        [Theory]
        public void GetAPIKeyShouldReturnCorrectKey()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
