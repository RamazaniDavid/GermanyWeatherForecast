using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Rmz.WeatherForecast.Api.Models.ConfigModels;

namespace Rmz.WeatherForecast.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IOptionsSnapshot<ApiSettings> _apiSettingsConfig;
       

        private readonly ILogger<WeatherForecastController> _logger;


        /// <summary>
        /// List of most important city in Germany
        /// </summary>
        public string[] MostImportantCity =
        {
            "Berlin",
            "Hamburg",
            "Munich",
            "Koeln",
            "Frankfurt am Main",
            "Essen",
            "Stuttgart",
            "Dortmund",
            "Duesseldorf",
            "Bremen",
            "Hannover",
            "Leipzig",
            "Duisburg",
            "Nuernberg",
            "Dresden",
        };

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptionsSnapshot<ApiSettings> apiSettingsConfig)
        {
            _logger = logger;
            _apiSettingsConfig = apiSettingsConfig;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
            })
            .ToArray();
        }
    }
}
