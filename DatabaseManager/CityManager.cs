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
        public CityManager()
        {
            dataContext = new WeatherDataContext();
        }
        //private static int counter = 0;
        private WeatherDataContext dataContext;

        public List<City> GetObservedCities()
        {
            //counter++;
            //if (counter > 1) return null;

            //var city = new City() { Id = 1, Name = "2", Observed = true, ServiceId = 5 };
            //dataContext.City.Add(city);
            var observedCities = dataContext.City.ToList();
            //dataContext.SaveChanges();
            //List<City> cities = dataContext.City.ToList();
            //return cities;
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
