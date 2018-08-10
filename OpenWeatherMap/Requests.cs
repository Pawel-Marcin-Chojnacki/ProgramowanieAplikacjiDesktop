using Newtonsoft.Json;
using OpenWeatherMap.DTO;
using System;
using System.Threading.Tasks;

namespace OpenWeatherMap
{
    /// <summary>
    /// Creates and sends requests to the site.
    /// </summary>
    public class Requests
    {
        private readonly string Forecast5DayAPI = "http://api.openweathermap.org/data/2.5/forecast?id=";
        // private HttpClient client;
        private string requestAddress;
        

        /// <summary>
        /// Retrieves 5 days forecast for one city.
        /// </summary>
        /// <param name="cityId">The id number of the selected city.</param>
        /// <returns>Forecast for 5 days for a given city.</returns>
        internal async Task<string> GetWeatherAsync(int cityId)
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient() ;
            requestAddress = Get5DaysWeatherRequest(cityId);
            var result = await client.GetAsync(requestAddress);
            var resultContent = await result.Content.ReadAsStringAsync();
            return resultContent;
        }

        private string Get5DaysWeatherRequest(int cityId)
        {
            string url = Forecast5DayAPI + cityId.ToString() + "&APPID=" + Credentials.ApiKey;
            return url;
        }
    }
}
