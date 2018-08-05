using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public partial class Forecast
    {
        public int Id { get; set; }

        public virtual ICollection<City> CityId { get; set; }

        public virtual ICollection<WeatherMain> WeatherMainId { get; set; }

        public virtual ICollection<Wind> WindId { get; set; }

        public virtual ICollection<Clouds> CloudsId { get; set; }

        public virtual ICollection<PredictionDate> TimeId { get; set; }
    }
}
