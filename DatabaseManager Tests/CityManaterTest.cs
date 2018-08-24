using Common.Models;
using DatabaseManager;
using DatabaseManager.Interfaces;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseManager_Tests
{
    public class CityManaterTest
    {
        [Fact]
        public void AddObservedCityShouldAddRecordToDatabase()
        {
            //Arrange
            City city = new City() { ServiceId = 11234, Name = "City", Observed = true };
            var mockedCity = new Mock<IDataContext>();
            mockedCity.SetupProperty(c => c.City.Add(new City() { ServiceId = 1, Name = "Olsztyn", Observed = true }));

            mockedCity.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);
            CityManager cityManager = new CityManager(mockedCity.Object);
            //Act
            var result = cityManager.AddObservedCity(city).Result;
            //Assert
            Assert.Equal(1, result);
        }

    }
}
