using System;
using Common.Models;
using DatabaseManager;
using DatabaseManager.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DatabaseManagerTests
{
    [TestClass]
    public class CityManagerTest
    {
        [TestMethod]
        public void AddObservedCityShouldAddRecordToDatabase()
        {
            //Arrange
            City city = new City() { ServiceId = 11234, Name = "City", Observed = true };
            var mockedCity = new Mock<IDataContext>();
            mockedCity.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);
            CityManager cityManager = new CityManager(mockedCity.Object);
            //Act
            var result = cityManager.AddObservedCity(city).Result;
            //Assert
            Assert.Equals(1, result);
        }
    }
}
