using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Rmz.WeatherForecast.Api.Models.DomainDtos
{
    //[JsonConverter(typeof(JsonPathConverter))]
    public class WeatherInfoDto : BaseDto
    {
        [JsonProperty("city.name")]
        public string Name { get; set; }

        public short Cnt { get; set; }

        public WeatherDetailInfoDto Current => Hourly.Count > 0 ? Hourly[0] : null;

        [JsonProperty("list")]
        public List<WeatherDetailInfoDto> Hourly { get; set; }

        public List<WeatherDetailInfoDto> Daily { get; set; }

    }
}
