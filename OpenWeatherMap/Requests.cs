using Newtonsoft.Json;
using OpenWeatherMap.DTO;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeatherMap
{
    class Requests
    {
        private readonly string Forecast5DayAPI = "api.openweathermap.org/data/2.5/forecast";
        private HttpClient client = new HttpClient();
        private string requestAddress;

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

        public async Task<null> GetCitiesListAsynch()
        {
            throw new HttpRequestException;

        }


    }
}
