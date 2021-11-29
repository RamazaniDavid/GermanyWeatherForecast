using System.Threading.Tasks;
using Rmz.WeatherForecast.Api.Models.DomainDtos;

namespace Rmz.WeatherForecast.Api.Services.ApiServices
{
    /// <summary>
    /// You may want to get weather information from another source, so this interface helps you know what you want and implement.
    /// </summary>
    public interface IWeatherProvider
    {
        /// <summary>
        /// Get weather information by city name or zip code
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        Task<WeatherInfoDto> Get5DayPerHours(string cityName,string zipCode);
        Task<CurrentWeatherInfoDto> GetCurrent(string cityName,string zipCode);
        
    }
}
