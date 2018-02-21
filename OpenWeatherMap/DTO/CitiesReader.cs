using Newtonsoft.Json;

namespace OpenWeatherMap.DTO
{
    public partial class CitiesReader
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("coord")]
        public Coord Coord { get; set; }
    }

    public partial class Empty
    {
        public static Empty[] FromJson(string json) => JsonConvert.DeserializeObject<Empty[]>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Empty[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
