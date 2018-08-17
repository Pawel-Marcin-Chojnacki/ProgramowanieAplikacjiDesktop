﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DatabaseManager;
using Common.Models;

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
        public MainWindowViewModel()
        {
            currentCity = new City();
            CityList = GetCityListFromDatabase();
            service = new ServiceManager(serviceName);
            data = new DataManager(new WeatherDataContext());

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

        public List<string> GetCityListFromDatabase()
        {
            CityManager cityManager = new CityManager(new WeatherDataContext());
            observedCities = cityManager.GetObservedCities();
            List<string> cityNames = observedCities.Where(o => o.Observed == true).Select(x => x.Name).ToList();
            return cityNames;
        }

        public async void StopService()
        {
            bool success = await service.StopService();
            if (success)
            {
                
            }
            else
            {

            }
        }

        public async void StartService()
        {
            bool success = await service.StopService();
            if (success)
            {

            }
            else
            {

            }
        }

        public void CleanDatabase()
        {
            //Pobierz ścieżkę z app.config
            string dbPath = ConfigurationManager.ConnectionStrings["WeatherDataContext"].ConnectionString;
            dbPath = dbPath.Substring(12);
            bool success = data.CleanAllData(dbPath);
            if (success)
            {
                // Db deleted
            }
            else
            {
                // File is currently used.
            }
        }
    }
}
