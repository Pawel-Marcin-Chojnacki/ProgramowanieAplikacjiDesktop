using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Models
{
    public partial class Forecast
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        public int WeatherMainId { get; set; }

        public int WindId { get; set; }

        public int CloudsId { get; set; }

        public int TimeId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [ForeignKey("WeatherMainId")]
        public virtual WeatherMain WeatherMain { get; set; }

        [ForeignKey("WindId")]
        public virtual Wind Wind { get; set; }

        [ForeignKey("CloudsId")]
        public virtual Clouds Clouds { get; set; }

        [ForeignKey("TimeId")]
        public virtual PredictionDate Time { get; set; }
    }
}
