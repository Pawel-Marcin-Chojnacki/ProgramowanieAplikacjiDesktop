using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDataContext
    {
        DatabaseSet<City> City { get; set; }
        DatabaseSet<Clouds> Clouds { get; set; }
        DatabaseSet<WeatherMain> WeatherMain { get; set; }
        DatabaseSet<Forecast> Forecast { get; set; }
        DatabaseSet<Wind> Wind { get; set; }
        DatabaseSet<PredictionDate> PredictionDate { get; set; }

        Task<int> SaveChangesAsync();
    }
}
