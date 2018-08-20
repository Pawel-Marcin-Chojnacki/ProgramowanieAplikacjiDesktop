using OpenWeatherMap;
using RichardSzalay.MockHttp;
using System;
using Xunit;

namespace OpenWeatherMap_Tests
{
    public class RequestsTests
    {
        [Theory]
        [InlineData(12345)]
        public void GetWeatherAsyncShouldReturnJson(int id)
        {
            var mockHttp = new MockHttpMessageHandler();
            Requests requests = new Requests();
            mockHttp.When("http://api.openweathermap.org/data/2.5/*").Respond("application/json", jsonResponse);

            var client = mockHttp.ToHttpClient();
            requests.client = client;
            var json = requests.GetWeatherAsync(id).Result;

            Assert.Equal(jsonResponse, json);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Get5DaysWeatherRequestShouldReturncorrectUrl(int cityId)
        {
            //arrange
            Requests requests = new Requests();
            
            //act
            var result = requests.Get5DaysWeatherRequestURL(cityId);
            var isCorrectUrl = Uri.IsWellFormedUriString(result, UriKind.Absolute);
            //assert
            Assert.True(isCorrectUrl);
        }

        private string jsonResponse = "{ \"cod\":\"200\", \"message\":0.0154, \"cnt\":40, \"list\":[{\"dt\":1534777200,\"main\":{\"temp\":299.656,\"temp_min\":299.656,\"temp_max\":299.656,\"pressure\":1020.01,\"sea_level\":1030.14,\"grnd_level\":1020.01,\"humidity\":53,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03d\"}],\"clouds\":{\"all\":44},\"wind\":{\"speed\":5.05,\"deg\":289.003},\"rain\":{},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2018-08-20 15:00:00\"}],\"city\":{\"id\":3083271,\"name\":\"Torun\",\"coord\":{\"lat\":53.0137,\"lon\":18.5981},\"country\":\"PL\"}}";
    }
}
