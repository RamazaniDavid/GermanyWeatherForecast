using System;
using System.Text.Json.Serialization;
using Conversions.UnitsOfSpeed;
using Conversions.UnitsOfTemperature;
using Newtonsoft.Json;
using NestedJsonConverter = Rmz.WeatherForecast.Api.Common.Helpers.NestedJsonConverter;

namespace Rmz.WeatherForecast.Api.Models.DomainDtos
{
    [Newtonsoft.Json.JsonConverter(typeof(NestedJsonConverter))]
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
        /// Wind speed. meter/sec
        /// </summary>
        [JsonProperty("wind.speed")]
        public double WindSpeedMet { get; set; }


        /// <summary>
        /// Part of the day (n - night, d - day)
        /// </summary>
        [JsonProperty("sys.pod")]
        public string POD { get; set; }

        /// <summary>
        /// Weather condition 
        /// </summary>
        [JsonProperty("weather.#0.description")]
        public string WeatherDescription { get; set; }


        /// <summary>
        /// Weather icon 
        /// </summary>
        [JsonProperty("weather.#0.icon")]
        public string WeatherIcon { get; set; }



        #region Calculated Field


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

        /// <summary>
        /// Wind speed in Imperial system
        /// </summary>
        public double WindSpeedImp => Speed.MetersPerSecondToMilesPerHour(WindSpeedMet);

        #endregion

    }
}
