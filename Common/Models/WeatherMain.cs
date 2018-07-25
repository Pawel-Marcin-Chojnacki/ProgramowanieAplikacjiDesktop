using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public partial class WeatherMain
    {
        public float Temperature { get; set; }

        public int Pressure { get; set; }

        public int Humidity { get; set; }

        public float TemperatureMin { get; set; }

        public float TemperatureMax { get; set; }

        public long Id { get; set; }
    }
}
