using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class ForecastEntity
    {
        //ForecastEntity()
        //{
        //    WeatherMain = new WeatherMain();
        //    Wind = new Wind();
        //    Clouds = new Clouds();
        //    PredictionDate = new PredictionDate();
        //    Forecast = new Forecast();
        //}

        public int CityServiceId { get; set; }

        public WeatherMain WeatherMain { get; set; }

        public Wind Wind { get; set; }

        public Clouds Clouds { get; set; }

        public PredictionDate PredictionDate { get; set; }

        public Forecast Forecast { get; set; }
        
    }
}
