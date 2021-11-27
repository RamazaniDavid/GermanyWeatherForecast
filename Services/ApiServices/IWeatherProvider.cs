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
        /// Get weather information by city name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cityName"></param>
        /// <returns></returns>
        Task<WeatherInfoDto> GetByCityName(string cityName);

        /// <summary>
        /// Get weather information by zip code
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="zipCode">Send your zip code</param>
        /// <returns></returns>
        Task<WeatherInfoDto> GetByZipCode(string zipCode);
    }
}
