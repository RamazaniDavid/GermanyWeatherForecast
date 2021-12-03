using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using Newtonsoft.Json;
using NestedJsonConverter = Rmz.WeatherForecast.Api.Common.Helpers.NestedJsonConverter;

namespace Rmz.WeatherForecast.Api.Models.DomainDtos
{
    [JsonConverter(typeof(NestedJsonConverter))]
    public class WeatherInfoDto : BaseDto
    {
        [JsonProperty("city.name")]
        public string Name { get; set; }

        public short Cnt { get; set; }

        [JsonIgnore]
        public WeatherDetailInfoDto Current => Hourly.Count > 0 ? Hourly[0] : null;

        [JsonProperty("list")]
        public List<WeatherDetailInfoDto> Hourly { get; set; }

        [JsonIgnore]
        public List<WeatherDetailInfoDto> Daily =>
            Hourly.GroupBy(x => x.DateTime.Date).Select(x => new WeatherDetailInfoDto
            {
                TempMet = (short)x.Average(xx=>xx.TempMet),
                MaxTempMet = x.Max(xx=>xx.MaxTempMet),
                MinTempMet = x.Min(xx=>xx.MinTempMet),
                Humidity =  Math.Round(x.Average(xx=>xx.Humidity), 0),
                Pressure = Math.Round(x.Average(xx=>xx.Pressure), 0),
                WindSpeedMet = (int)x.Average(xx=>xx.WindSpeedMet),
                Unix = x.Min(xx=>xx.Unix),
                //For finding weather icon, I prefer to find the most frequent weather during a day
                WeatherIcon =
                    $"{x.GroupBy(xx => xx.WeatherIcon.Substring(0, 2)).Select(grouped => new { Icon = grouped.Key, Freq = grouped.Count() }).OrderByDescending(ordered => ordered.Freq).FirstOrDefault()?.Icon}d",
                WeatherDescription = x.GroupBy(xx => xx.WeatherDescription).Select(grouped => new { Des = grouped.Key, Freq = grouped.Count() }).OrderByDescending(ordered => ordered.Freq).FirstOrDefault()?.Des,
                POD = "d",
            }).ToList();

    }
}
