using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Rmz.WeatherForecast.Api.Common.Helpers;
using Rmz.WeatherForecast.Api.Models.ConfigModels;
using Rmz.WeatherForecast.Api.Models.DomainDtos;

namespace Rmz.WeatherForecast.Api.Services.ApiServices.OpenWeatherMap
{
    /// <summary>
    /// To connect to OpenWeatherMap's API
    /// todo: It's better to move services to other project which use only for connect
    /// </summary>
    public class OwmProvider : IOwmProvider
    {
        private readonly string ApiKey;
        private readonly string BaseUrl;


        public OwmProvider(IOptionsSnapshot<ProviderApiConfigs> providerApiConfigs)
        {
            ApiKey = providerApiConfigs.Value.ApiKey;
            BaseUrl = providerApiConfigs.Value.BaseUrl;
        }


        #region Implementation of IWeatherProvider

        /// <inheritdoc />
        public async Task<WeatherInfoDto> GetByCityName(string cityName)
        {
            string url = $"http://api.openweathermap.org/data/2.5/forecast?q={cityName},DE&appid=fcadd28326c90c3262054e0e6ca599cd";
            var res=await ApiHelper.GetAsync<dynamic>(url);
            var data = new WeatherInfoDto();

            return data;

        }

        /// <inheritdoc />
        public Task<WeatherInfoDto> GetByZipCode(string zipCode)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
