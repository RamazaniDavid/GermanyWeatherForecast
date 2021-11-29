using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Rmz.WeatherForecast.Api.Data.Entities;

namespace Rmz.WeatherForecast.Api.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<City> Cities { set; get; }


        #region Overrides of DbContext

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(SeedCitiesData());
            base.OnModelCreating(modelBuilder);
        }

        private IEnumerable<City> SeedCitiesData()
        {
            var cities = new List<City>();
            using (MemoryStream stream = new MemoryStream(Properties.Resources.city_list))
            {
                using (StreamReader r = new StreamReader(stream))
                {
                    string json = r.ReadToEnd();
                    cities = JsonConvert.DeserializeObject<List<City>>(json);
                }
            }

            return cities.Where(ct=>ct.Country.ToLower()=="de");
        }

        #endregion
    }
}
