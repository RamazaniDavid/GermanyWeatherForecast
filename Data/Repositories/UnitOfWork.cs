using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rmz.WeatherForecast.Api.Data.Entities;
using Rmz.WeatherForecast.Api.Data.Repositories.Interfaces;

namespace Rmz.WeatherForecast.Api.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<City, long> _cities;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }


        #region Implementation of IDisposable

        /// <inheritdoc />
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Implementation of IUnitOfWork

        /// <inheritdoc />
        public IGenericRepository<City, long> Cities => _cities ??= new GenericRepository<City, long>(_context);

        #endregion
    }
}
