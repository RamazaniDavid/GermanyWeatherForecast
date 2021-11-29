using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rmz.WeatherForecast.Api.Data.Entities;
using Rmz.WeatherForecast.Api.Data.Repositories.Interfaces;

namespace Rmz.WeatherForecast.Api.Data.Repositories
{
    public class GenericRepository<T,KeyType> :IGenericRepository<T,KeyType> where T : BaseEntity<KeyType>
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        #region Implementation of IGenericRepository<T,KeyType>

        /// <inheritdoc />
        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> Expr = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrdBy = null)
        {
            IQueryable<T> query = _db;
            if (Expr!=null)
            {
                query = query.Where(Expr);
            }

            if (OrdBy!=null)
            {
                query = OrdBy(query);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        #endregion
    }
}
