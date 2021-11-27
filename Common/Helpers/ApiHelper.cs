using System;
using System.Net.Http;
using System.Threading.Tasks;
using Rmz.WeatherForecast.Api.Common.CommonClasses;

namespace Rmz.WeatherForecast.Api.Common.Helpers
{

    /// <summary>
    /// API helper to call API 
    /// </summary>
    public static class ApiHelper
    {
        /// <summary>
        /// Get Method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">API Url</param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(string url)
        {
            using var response = await HttpClientSingleton.Instance.GetAsync(url);
            if (response.IsSuccessStatusCode)
                return await response.Content.rea<T>();

            throw new Exception(response.ReasonPhrase);
        }
    }
}
