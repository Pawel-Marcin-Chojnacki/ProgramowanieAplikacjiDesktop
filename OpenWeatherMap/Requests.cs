using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeatherMap
{
    /// <summary>
    /// Creates and sends requests to the site.
    /// </summary>
    public class Requests
    {
        private readonly string Forecast5DayAPI = "http://api.openweathermap.org/data/2.5/forecast?id=";
        private string requestAddress;
        public HttpClient client;

        public Requests()
        {
            client = new HttpClient();
        }

        /// <summary>
        /// Retrieves 5 days forecast for one city.
        /// </summary>
        /// <param name="cityId">The id number of the selected city.</param>
        /// <returns>Forecast for 5 days for a given city.</returns>
        public async Task<string> GetWeatherAsync(int cityId)
        {
            requestAddress = Get5DaysWeatherRequestURL(cityId);
            var result = await client.GetAsync(requestAddress);
            var resultContent = await result.Content.ReadAsStringAsync();
            return resultContent;
        }

        private string Get5DaysWeatherRequestURL(int cityId)
        {
            string url = Forecast5DayAPI + cityId.ToString() + "&APPID=" + Credentials.ApiKey;
            return url;
        }
    }
}
