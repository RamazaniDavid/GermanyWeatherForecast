using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        public async Task<WeatherInfoDto> Get5DayPerHours(string cityName,string zipCode )
        {

            string url =
                $"{BaseUrl}/forecast?{(!string.IsNullOrEmpty(cityName) ? $"q={cityName}" : "")}{(!string.IsNullOrEmpty(zipCode) && string.IsNullOrEmpty(cityName) ? $"zip={zipCode}" : "")},DE&unit=metric&appid={ApiKey}";
            var res=await ApiHelper.GetAsync<WeatherInfoDto>(url);

            

            return res;
            
        }

        #endregion
    }
}
