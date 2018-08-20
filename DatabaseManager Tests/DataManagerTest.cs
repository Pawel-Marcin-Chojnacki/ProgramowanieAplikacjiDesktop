using DatabaseManager;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseManager_Tests
{
    public class DataManagerTest
    {
        [Fact]
        public void CleanAllDataShouldDeleteDatabaseFile()
        {
            //Arrange
            string filePath = @"c:\Database\OpenWeather.sqlite";
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { filePath, new MockFileData("Some content.") }
            });
            Assert.True(fileSystem.File.Exists(filePath));
            var dataManager = new DataManager(fileSystem);
            //Act
            dataManager.CleanAllData(filePath);
            //Assert
            Assert.False(fileSystem.File.Exists(filePath));
        }
    }
}
