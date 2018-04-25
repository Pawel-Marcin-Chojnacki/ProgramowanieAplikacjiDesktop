using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Charts.ViewModels
{
    /// <summary>
    /// ViewModel for main application window.
    /// </summary>
    public class MainWindowViewModel
    {
        /// <summary>
        /// Provides a list of cities selction.
        /// </summary>
        public List<string> CityList { get; set; }

        /// <summary>
        /// Initializes data.
        /// </summary>
        public MainWindowViewModel()
        {
            CityList = new List<string>();
        }
    }
}
