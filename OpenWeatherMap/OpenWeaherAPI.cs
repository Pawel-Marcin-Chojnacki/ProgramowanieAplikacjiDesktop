using System;

namespace OpenWeatherMap
{
    public class OpenWeaherAPI
    {
        public async void GetWeather(string city)
        {
            // Pobierz klucz
            string key = Credentials.ApiKey;
            // Złóż zapytanie
            Requests weatherRequest = new Requests();
            // Wyślij zapytanie
            var weather = await weatherRequest.GetWeatherAsync(cityName: city);
            // Sparsuj jsona
            // Oddaj dane które przyszły z internetu.
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
