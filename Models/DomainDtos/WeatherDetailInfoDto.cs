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
        public DateTime DateTime => DateTimeOffset.FromUnixTimeSeconds(Unix).DateTime
            //todo: here use static code and add 1 hour to UTC, because it's about germany cities. if you want to correct it dynamically, you can use timezone, or pass UTC to client and show in local timezone
            .AddHours(1);

        /// <summary>
        /// Day name
        /// </summary>
        public string DayName => DateTime.DayOfWeek.ToString();
        /// <summary>
        /// Time
        /// </summary>
        public string Time => DateTime.Hour.ToString();
        
        /// <summary>
        /// Temp in metric system
        /// </summary>
        [JsonProperty("main.temp")]
        public short TempMet { get; set; }
        /// <summary>
        /// Max temp in metric system
        /// </summary>
        [JsonProperty("main.temp_max")]
        public short MaxTempMet { get; set; }
        /// <summary>
        /// Min temp in metric system
        /// </summary>
        [JsonProperty("main.temp_min")]
        public short MinTempMet { get; set; }

        /// <summary>
        /// Wind speed. meter/sec
        /// </summary>
        [JsonProperty("wind.speed")]
        public int WindSpeedMet { get; set; }


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

        /// <summary>
        /// Pressure
        /// </summary>
        [JsonProperty("main.pressure")]
        public double Pressure { get; set; }

        /// <summary>
        /// Humidity 
        /// </summary>
        [JsonProperty("main.humidity")]
        public double Humidity { get; set; }



        #region Calculated Field


        /// <summary>
        /// Temp in imperial system
        /// </summary>
        public short TempImp => (short)Temperature.CelciusToFarenheit(TempMet);
        /// <summary>
        /// Max temp  in imperial system
        /// </summary>
        public short MaxTempImp => (short)Temperature.CelciusToFarenheit(MaxTempMet);
        /// <summary>
        /// Min temp in imperial system
        /// </summary>
        public short MinTempImp =>(short)Temperature.CelciusToFarenheit(MinTempMet);

        /// <summary>
        /// Wind speed in Imperial system
        /// </summary>
        public int WindSpeedImp => (int)Speed.MetersPerSecondToMilesPerHour(WindSpeedMet);

        #endregion

    }
}
