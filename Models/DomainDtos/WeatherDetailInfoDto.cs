using System;
using Conversions.UnitsOfTemperature;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Rmz.WeatherForecast.Api.Models.DomainDtos
{
    public class WeatherDetailInfoDto : BaseDto
    {
        /// <summary>
        /// Unix 
        /// </summary>
        [JsonProperty("dt")]
        public long Unix { get; set; }

        /// <summary>
        /// Record time
        /// </summary>
        public DateTime DateTime => DateTimeOffset.FromUnixTimeSeconds(Unix).DateTime;

        /// <summary>
        /// Temp in metric system
        /// </summary>
        [JsonProperty("main.temp")]
        public double TempMet { get; set; }
        /// <summary>
        /// Max temp in metric system
        /// </summary>
        [JsonProperty("main.temp_max")]
        public double MaxTempMet { get; set; }
        /// <summary>
        /// Min temp in metric system
        /// </summary>
        [JsonProperty("main.temp_min")]
        public double MinTempMet { get; set; }
        /// <summary>
        /// Temp in imperial system
        /// </summary>
        public double TempImp => Temperature.CelciusToFarenheit(TempMet);
        /// <summary>
        /// Max temp  in imperial system
        /// </summary>
        public double MaxTempImp => Temperature.CelciusToFarenheit(MaxTempMet);
        /// <summary>
        /// Min temp in imperial system
        /// </summary>
        public double MinTempImp => Temperature.CelciusToFarenheit(MinTempMet);

    }
}
