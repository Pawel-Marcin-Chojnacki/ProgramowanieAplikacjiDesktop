using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class ForecastEntity
    {

        public int CityServiceId { get; set; }

        public WeatherMain WeatherMain { get; set; }

        public Wind Wind { get; set; }

        public Clouds Clouds { get; set; }

        public PredictionDate PredictionDate { get; set; }

        public Forecast Forecast { get; set; }
        
    }
}
