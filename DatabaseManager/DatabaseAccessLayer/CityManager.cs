using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class CityManager
    {
        public CityManager(IDataContext context)
        {
            dataContext = context;
        }

        private IDataContext dataContext;

        public List<City> GetObservedCities()
        {
            var observedCities = dataContext.City.ToList();
            return observedCities;
        }

        public async void AddObservedCity(City city)
        {
            dataContext.City.Add(city);
            await dataContext.SaveChangesAsync();
        }

        public async void RemoveObservedCity(City city)
        {
            dataContext.City.Remove(city);
            await dataContext.SaveChangesAsync();
        }

    }
}
