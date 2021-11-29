using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NestedJsonConverter = Rmz.WeatherForecast.Api.Common.Helpers.NestedJsonConverter;

namespace Rmz.WeatherForecast.Api.Models.DomainDtos
{
    [JsonConverter(typeof(NestedJsonConverter))]
    public class CurrentWeatherInfoDto : WeatherDetailInfoDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        

    }
}
