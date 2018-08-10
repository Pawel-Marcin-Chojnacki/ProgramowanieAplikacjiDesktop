using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.DTO
{
    public partial class Sys
    {
        [JsonProperty("pod")]
        public Pod Pod { get; set; }
    }
}
