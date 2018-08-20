using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OpenWeatherMap.DTO
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using QuickType;
    //
    //    var forecast = Forecast.FromJson(jsonString);

    public partial class Forecast
    {
        [JsonProperty("cod")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Cod { get; set; }

        [JsonProperty("message")]
        public double Message { get; set; }

        [JsonProperty("cnt")]
        public long Cnt { get; set; }

        [JsonProperty("list")]
        public List<List> List { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }
    }


    public partial class MainClass
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("sea_level")]
        public double SeaLevel { get; set; }

        [JsonProperty("grnd_level")]
        public double GrndLevel { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("temp_kf")]
        public double TempKf { get; set; }
    }

    public partial class Rain
    {
        [JsonProperty("3h", NullValueHandling = NullValueHandling.Ignore)]
        public double? The3H { get; set; }
    }

    public enum Pod { D, N };

    public enum Icon { The01D, The01N, The02D, The03D, The04D, The10N, The10D, The02N, The03N, The04N, The09D, The09N, The11D, The11N, The13D, The13N, The50D, The50N };

    public enum MainEnum { Clear, Clouds, Rain };

    public partial class Forecast
    {
        public static Forecast FromJson(string json) => JsonConvert.DeserializeObject<Forecast>(json, OpenWeatherMap.DTO.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Forecast self)
        {
            return JsonConvert.SerializeObject(self, OpenWeatherMap.DTO.Converter.Settings);
        }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                PodConverter.Singleton,
                IconConverter.Singleton,
                MainEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class PodConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Pod) || t == typeof(Pod?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "d":
                    return Pod.D;
                case "n":
                    return Pod.N;
            }
            throw new Exception("Cannot unmarshal type Pod");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Pod)untypedValue;
            switch (value)
            {
                case Pod.D:
                    serializer.Serialize(writer, "d");
                    return;
                case Pod.N:
                    serializer.Serialize(writer, "n");
                    return;
            }
            throw new Exception("Cannot marshal type Pod");
        }

        public static readonly PodConverter Singleton = new PodConverter();
    }

    internal class IconConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Icon) || t == typeof(Icon?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "01d":
                    return Icon.The01D;
                case "01n":
                    return Icon.The01N;
                case "02d":
                    return Icon.The02D;
                case "02n":
                    return Icon.The02N;
                case "03d":
                    return Icon.The03D;
                case "03n":
                    return Icon.The03N;
                case "04d":
                    return Icon.The04D;
                case "04n":
                    return Icon.The04N;
                case "09d":
                    return Icon.The09D;
                case "09n":
                    return Icon.The09N;
                case "10d":
                    return Icon.The10D;
                case "10n":
                    return Icon.The10N;
                case "11d":
                    return Icon.The11D;
                case "11n":
                    return Icon.The11N;
                case "13d":
                    return Icon.The13D;
                case "13n":
                    return Icon.The13N;
                case "50d":
                    return Icon.The50D;
                case "50n":
                    return Icon.The50N;
            }
            throw new Exception("Cannot unmarshal type Icon");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Icon)untypedValue;
            switch (value)
            {
                case Icon.The01D:
                    serializer.Serialize(writer, "01d");
                    return;
                case Icon.The01N:
                    serializer.Serialize(writer, "01n");
                    return;
                case Icon.The02D:
                    serializer.Serialize(writer, "02d");
                    return;
                case Icon.The02N:
                    serializer.Serialize(writer, "02n");
                    return;
                case Icon.The03D:
                    serializer.Serialize(writer, "03d");
                    return;
                case Icon.The03N:
                    serializer.Serialize(writer, "03n");
                    return;
                case Icon.The04D:
                    serializer.Serialize(writer, "04d");
                    return;
                case Icon.The04N:
                    serializer.Serialize(writer, "04n");
                    return;
                case Icon.The09D:
                    serializer.Serialize(writer, "09d");
                    return;
                case Icon.The09N:
                    serializer.Serialize(writer, "09n");
                    return;
                case Icon.The10D:
                    serializer.Serialize(writer, "10d");
                    return;
                case Icon.The10N:
                    serializer.Serialize(writer, "10n");
                    return;
                case Icon.The11D:
                    serializer.Serialize(writer, "11d");
                    return;
                case Icon.The11N:
                    serializer.Serialize(writer, "11n");
                    return;
                case Icon.The13D:
                    serializer.Serialize(writer, "13d");
                    return;
                case Icon.The13N:
                    serializer.Serialize(writer, "13n");
                    return;
                case Icon.The50D:
                    serializer.Serialize(writer, "50d");
                    return;
                case Icon.The50N:
                    serializer.Serialize(writer, "50n");
                    return;
            }
            throw new Exception("Cannot marshal type Icon");
        }

        public static readonly IconConverter Singleton = new IconConverter();
    }

    internal class MainEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MainEnum) || t == typeof(MainEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Clear":
                    return MainEnum.Clear;
                case "Clouds":
                    return MainEnum.Clouds;
                case "Rain":
                    return MainEnum.Rain;
            }
            throw new Exception("Cannot unmarshal type MainEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (MainEnum)untypedValue;
            switch (value)
            {
                case MainEnum.Clear:
                    serializer.Serialize(writer, "Clear");
                    return;
                case MainEnum.Clouds:
                    serializer.Serialize(writer, "Clouds");
                    return;
                case MainEnum.Rain:
                    serializer.Serialize(writer, "Rain");
                    return;
            }
            throw new Exception("Cannot marshal type MainEnum");
        }

        public static readonly MainEnumConverter Singleton = new MainEnumConverter();
    }
}