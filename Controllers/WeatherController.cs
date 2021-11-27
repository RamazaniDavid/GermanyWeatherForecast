#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Rmz.WeatherForecast.Api.Models.ConfigModels;
using Rmz.WeatherForecast.Api.Models.DomainDtos;
using Rmz.WeatherForecast.Api.Services.ApiServices.OpenWeatherMap;

namespace Rmz.WeatherForecast.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IOwmProvider _owmProvider;
       

        private readonly ILogger<WeatherController> _logger;



        public WeatherController(ILogger<WeatherController> logger, IOwmProvider owmProvider)
        {
            _logger = logger;
            _owmProvider = owmProvider;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<WeatherInfoDto>> Forecast(string? city,string? zipCode )
        {
            return _owmProvider.Get5DayPerHours("München",null).Result;
        }
    }
}
