using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DatabaseManager;
using Common.Models;
using Weather_Charts.Logging;

namespace Weather_Charts.ViewModels
{
    /// <summary>
    /// ViewModel for main application window.
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<string> cityList;
        private string selectedCity;
        private ServiceManager service;
        private string serviceName = "ForecastCollector";
        private List<City> observedCities;
        public City currentCity;
        private DataManager data;
        private IFileLogger _log;

        /// <summary>
        /// Provides a list of cities selction.
        /// </summary>
        public List<string> CityList
        {
            get
            {
                return cityList;
            }
            set
            {
                cityList = value;
                NotifyPropertyChanged("CityList");
            }
        }

        /// <summary>
        /// Currently selected city in the view.
        /// </summary>
        public string SelectedCity
        {
            get
            {
                return selectedCity;
            }
            set
            {
                selectedCity = value;
                currentCity = observedCities.Single(x => x.Name == selectedCity);
                NotifyPropertyChanged("SelectedCity");
            }
        }

        /// <summary>
        /// Initializes data.
        /// </summary>
        public MainWindowViewModel(IFileLogger log)
        {
            _log = log;
            currentCity = new City();
            CityList = GetCityListFromDatabase();
            service = new ServiceManager(serviceName, _log);
            data = new DataManager();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Gets list of names for observed cities.
        /// </summary>
        /// <returns>Names of observed cities.</returns>
        public List<string> GetCityListFromDatabase()
        {
            CityManager cityManager = new CityManager(new WeatherDataContext());
            observedCities = cityManager.GetObservedCities();
            List<string> cityNames = observedCities.Where(o => o.Observed == true).Select(x => x.Name).ToList();
            return cityNames;
        }

        /// <summary>
        /// Invokes request to stop service.
        /// </summary>
        public void StopService()
        {
            service.StopService();
        }

        /// <summary>
        /// Invokes request to start service.
        /// </summary>
        public void StartService()
        {
            service.StartService();
        }

        /// <summary>
        /// Deletes database file.
        /// </summary>
        public void CleanDatabase()
        {
            string dbPath = ConfigurationManager.ConnectionStrings["WeatherDataContext"].ConnectionString;
            dbPath = dbPath.Substring(12);
            data.CleanAllData(dbPath);
        }
    }
}
