using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rmz.WeatherForecast.Api.Data.Entities;

namespace Rmz.WeatherForecast.Api.Data.Repositories.Interfaces
{
    public interface IGenericRepository<T, KeyType> where T : BaseEntity<KeyType>
    {
        Task<IList<T>> GetAll(Expression<Func<T, bool>> Expr = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> OrdBy = null);
    }
}
