#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Rmz.WeatherForecast.Api.Data.Repositories.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;


        private readonly ILogger<WeatherController> _logger;

        static WeatherController()
        {
            
        }

        public WeatherController(ILogger<WeatherController> logger, IOwmProvider owmProvider, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _owmProvider = owmProvider;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<WeatherInfoDto>> Forecast(string? city, string? zipCode)
        {
            if (string.IsNullOrEmpty(city) && string.IsNullOrEmpty(zipCode))
            {
                return BadRequest("Both inputs are not possible to be null");
            }

            try
            {
                return _owmProvider.Get5DayPerHours(city, zipCode).Result;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("[action]")]
        public async Task<ActionResult<CurrentWeatherInfoDto>> Current(string? city, string? zipCode)
        {
            if (string.IsNullOrEmpty(city) && string.IsNullOrEmpty(zipCode))
            {
                return BadRequest("Both inputs are not possible to be null");
            }
            return _owmProvider.GetCurrent(city, zipCode).Result;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<CurrentWeatherInfoDto>>> SearchByCityName(string? cityExpr)
        {
            var res = new List<CurrentWeatherInfoDto>();
            var cities = (await _unitOfWork.Cities.GetAll(x => x.Name.StartsWith(cityExpr),
                cts => cts.OrderBy(xx => xx.Name == cityExpr ? 1 : 2), Limit: 20)).Select(x=>x.Name).Distinct();
            foreach (var city in cities)
            {
                res.Add(await _owmProvider.GetCurrent(city, null));
            }
            return res;
        }
    }
}
