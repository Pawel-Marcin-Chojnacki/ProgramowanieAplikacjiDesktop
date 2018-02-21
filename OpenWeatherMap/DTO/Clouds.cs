using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.DTO
{
    public partial class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }
}
