using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Rmz.WeatherForecast.Api.Common.CommonClasses
{
    /// <summary>
    /// httpClient application wide and avoid socket exhaustion
    /// </summary>
    public sealed class HttpClientSingleton
    {
        private static readonly Lazy<HttpClient> Lazy = new(() =>
        {
            var apiClient = new HttpClient();
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return apiClient;
        });

        public static HttpClient Instance => Lazy.Value;
        
    }
}
