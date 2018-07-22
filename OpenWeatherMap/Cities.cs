using OpenWeatherMap.DTO;
using Newtonsoft.Json;
using System.IO;

namespace OpenWeatherMaps
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

    public enum City
    {
        Bydgoszcz = 3102014,
        Torun = 3083271,
        Warszawa = 6695624,
        Krakow = 3094802,
        Gdansk = 3099434,
        Wroclaw = 3081368,
        Londyn,
        Berlin,
        Paryz

    }
}