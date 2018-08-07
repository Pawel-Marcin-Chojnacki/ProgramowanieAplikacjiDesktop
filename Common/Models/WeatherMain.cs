using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public partial class WeatherMain
    {
        public float Temperature { get; set; }

        public int Pressure { get; set; }

        public int Humidity { get; set; }

        public float TemperatureMin { get; set; }

        public float TemperatureMax { get; set; }

        [Key, ForeignKey("Forecast")]
        public int Id { get; set; }


        public virtual ICollection<Forecast> Forecast { get; set; }
    }
}
