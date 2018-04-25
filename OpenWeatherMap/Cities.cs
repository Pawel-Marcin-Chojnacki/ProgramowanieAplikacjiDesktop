using OpenWeatherMap.DTO;
using Newtonsoft.Json;
using System.IO;

namespace OpenWeatherMap
{
    /// <summary>
    /// A type for city management.
    /// </summary>
    public class Cities
    {
        /// <summary>
        /// Converts json with cities to model class.
        /// </summary>
        /// <returns>Model with city entities.</returns>
        public Forecast5 GetListOfCities()
        {
            Forecast5 cities = JsonConvert.DeserializeObject<Forecast5>(File.ReadAllText(@"city.list.json"));
            return cities;
        }
        
    }
}