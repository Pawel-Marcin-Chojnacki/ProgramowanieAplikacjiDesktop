using Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager.Interfaces
{
    public interface IDataContext
    {
        DbSet<City> City { get; set; }
        DbSet<Clouds> Clouds { get; set; }
        DbSet<WeatherMain> WeatherMain { get; set; }
        DbSet<Forecast> Forecast { get; set; }
        DbSet<Wind> Wind { get; set; }
        DbSet<PredictionDate> PredictionDate { get; set; }

        Task<int> SaveChangesAsync();
    }
}
