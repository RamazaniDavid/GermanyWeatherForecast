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
                MaxTempMet = (short)x.Average(xx=>xx.MaxTempMet),
                MinTempMet = (short)x.Average(xx=>xx.MinTempMet),
                Humidity =  Math.Round(x.Average(xx=>xx.Humidity), 0),
                Pressure = Math.Round(x.Average(xx=>xx.Pressure), 0),
                WindSpeedMet = Math.Round(x.Average(xx=>xx.WindSpeedMet),0),
                Unix = x.Min(xx=>xx.Unix),
                //For finding weather icon, I prefer to find the most frequent weather during a day
                WeatherIcon =
                    $"{x.GroupBy(xx => xx.WeatherIcon.Substring(0, 2)).Select(grouped => new { Icon = grouped.Key, Freq = grouped.Count() }).OrderByDescending(ordered => ordered.Freq).FirstOrDefault()?.Icon}d",
                WeatherDescription = x.FirstOrDefault()?.WeatherDescription,
                POD = "d",
            }).ToList();

    }
}
