﻿using Newtonsoft.Json;
using OpenWeatherMap.DTO;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeatherMap
{
    /// <summary>
    /// Creates and sends requests to the site.
    /// </summary>
    class Requests
    {
        private readonly string Forecast5DayAPI = "api.openweathermap.org/data/2.5/forecast";
        private HttpClient client = new HttpClient();
        private string requestAddress;

        /// <summary>
        /// Retrieves 5 days forecast for one city.
        /// </summary>
        /// <param name="cityId">The id number of the selected city.</param>
        /// <returns>Forecast for 5 days.</returns>
        public async Task<Forecast5> GetWeatherAsync(int cityId)
        {
            requestAddress = Get5DaysWeatherRequest(cityId);
            var result = await client.GetAsync(requestAddress);
            var resultContent = result.Content.ToString();
            var forecast = JsonConvert.DeserializeObject<Forecast5>(resultContent);
            return forecast;
        }

        private string Get5DaysWeatherRequest(int cityId)
        {
            string url = Forecast5DayAPI + "?" + cityId.ToString() + "&" + Credentials.ApiKey;
            return url;
        }

        public async Task<City> GetCitiesListAsynch()
        {
            throw new System.Exception();
        }


    }
}
