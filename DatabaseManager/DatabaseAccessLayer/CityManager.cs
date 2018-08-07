using Common.Models;
using DatabaseManager.Interfaces;
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
            City newCity = dataContext.City.Where(c => c.Name == city.Name).FirstOrDefault();
            if (newCity == null)
            {
                dataContext.City.Add(city);
            }
            else
            {
                newCity.Observed = true;
            }
            await dataContext.SaveChangesAsync();
        }

        public async void RemoveObservedCity(City city)
        {
            var removedCity = dataContext.City.Where(c => c.Name == city.Name).SingleOrDefault();
            removedCity.Observed = false;
            await dataContext.SaveChangesAsync();
        }
    }
}