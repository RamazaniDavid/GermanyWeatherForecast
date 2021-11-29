using Newtonsoft.Json;
using Rmz.WeatherForecast.Api.Common.Helpers;

namespace Rmz.WeatherForecast.Api.Data.Entities
{
    [JsonConverter(typeof(NestedJsonConverter))]
    public class City :BaseEntity<long>
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        [JsonProperty("coord.lon")]
        public double Lon { get; set; }
        [JsonProperty("coord.lat")]
        public double Lat { get; set; }
    }
}
