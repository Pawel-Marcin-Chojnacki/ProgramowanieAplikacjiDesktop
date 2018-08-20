using OpenWeatherMap.DTO;
using System.Threading.Tasks;

namespace OpenWeatherMap
{
    /// <summary>
    /// Allows access to Open Weather services.
    /// </summary>
    public class OpenWeaherAPI
    {
        /// <summary>
        /// Gets weather for a given city.
        /// </summary>
        /// <param name="cityId">Preselected city name. Must exist in database mappings.</param>
        public async Task<Forecast> GetForecast(int cityId)
        {
            Requests weatherRequest = new Requests();
            var weather = await weatherRequest.GetWeatherAsync(cityId);
            var forecast = Forecast.FromJson(weather);
            return forecast;
        }

        /// <summary>
        /// Sets new API key to OpenWeatherMap service.
        /// </summary>
        /// <param name="key"></param>
        public void SetAPIKey(string key)
        {
            Credentials.ApiKey = key;
        }

        /// <summary>
        /// Gets users API key to OpenWeatherMap.
        /// </summary>
        /// <returns>Current API key.</returns>
        public string GetAPIKey()
        {
            return Credentials.ApiKey;
        }
    }
}
