using System;
using Rmz.WeatherForecast.Api.Data.Entities;

namespace Rmz.WeatherForecast.Api.Data.Repositories.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<City,long> Cities {  get; }
    }
}
