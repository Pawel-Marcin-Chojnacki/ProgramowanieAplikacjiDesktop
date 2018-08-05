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
    public class CityManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public CityManager(IDataContext context)
        {
            dataContext = context;
        }

        private IDataContext dataContext;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<City> GetObservedCities()
        {
            var observedCities = dataContext.City.ToList();
            return observedCities;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        public async void AddObservedCity(City city)
        {
            dataContext.City.Add(city);
            await dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        public async void RemoveObservedCity(City city)
        {
            dataContext.City.Remove(city);
            await dataContext.SaveChangesAsync();
        }
    }
}