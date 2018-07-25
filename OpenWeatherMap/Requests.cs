using Newtonsoft.Json;
using OpenWeatherMap.DTO;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeatherMap
{
    /// <summary>
    /// Creates and sends requests to the site.
    /// </summary>
    public class Requests
    {
        private readonly string Forecast5DayAPI = "api.openweathermap.org/data/2.5/forecast";
        private HttpClient client = new HttpClient();
        private string requestAddress;

        /// <summary>
        /// Retrieves 5 days forecast for one city.
        /// </summary>
        /// <param name="cityId">The id number of the selected city.</param>
        /// <returns>Forecast for 5 days.</returns>
        public async Task<Forecast5> GetWeatherAsync(string cityName)
        {
            requestAddress = Get5DaysWeatherRequest(cityName);
            var result = await client.GetAsync(requestAddress);
            var resultContent = result.Content.ToString();
            var forecast = JsonConvert.DeserializeObject<Forecast5>(resultContent);
            return forecast;
        }

        private string Get5DaysWeatherRequest(string cityName)
        {
            int cityId = GetCityIdFromName(cityName);
            string url = Forecast5DayAPI + "?" + cityId.ToString() + "&" + Credentials.ApiKey;
            return url;
        }

        private int GetCityIdFromName(string Name)
        {
            return 0;
        }

    }
}
