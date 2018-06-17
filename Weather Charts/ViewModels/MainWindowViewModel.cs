using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Charts.ViewModels
{
    /// <summary>
    /// ViewModel for main application window.
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<string> cityList;
        private string selectedCity;

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
                NotifyPropertyChanged("SelectedCity");
            }
        }

        /// <summary>
        /// Initializes data.
        /// </summary>
        public MainWindowViewModel()
        {
            CityList = GetCityListFromDatabase();

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

        private List<string> GetCityListFromDatabase()
        {
            DatabaseManager.WeatherDataContext dataContext = new DatabaseManager.WeatherDataContext();
            dataContext.
        }
    }
}
