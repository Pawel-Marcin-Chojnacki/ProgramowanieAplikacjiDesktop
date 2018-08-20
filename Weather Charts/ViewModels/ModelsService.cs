using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using LiveCharts;

namespace Weather_Charts.ViewModels
{
    public class ModelsService
    {
        /// <summary>
        /// Converts pressure points to chart values.
        /// </summary>
        /// <param name="forecast">entity with pressure values.</param>
        /// <param name="density">Divides number of points by this value to avoid information overload.</param>
        /// <returns>List of values for chart.</returns>
        public ChartValues<double> PressureToChart(List<ForecastEntity> forecast, int density)
        {
            ChartValues<double> vs = new ChartValues<double>();
            int filter = 1;
            foreach (var f in forecast)
            {
                if (filter == density)
                {
                    vs.Add(f.WeatherMain.Pressure);
                    filter = 0;
                }
                filter++;
            }
            return vs;
        }

        /// <summary>
        /// Converts predicted temperature to chart points.
        /// </summary>
        /// <param name="forecast">entity with temperature values.</param>
        /// <param name="density">Divides number of points by this value to avoid information overload.</param>
        /// <returns>List of values for chart.</returns>
        public ChartValues<double> TemperaturesToChart(List<ForecastEntity> forecast, int density)
        {
            ChartValues<double> vs = new ChartValues<double>();
            int filter = 1;
            foreach (var f in forecast)
            {
                if (filter == density)
                {
                    vs.Add(f.WeatherMain.Temperature);
                    filter = 0;
                }
                filter++;
            }
            return vs;
        }

        /// <summary>
        /// Converts date of prediction to text format.
        /// </summary>
        /// <param name="forecast">entity with date values.</param>
        /// <param name="density">Divides number of points by this value to avoid information overload.</param>
        /// <returns></returns>
        public List<string> DatesToArray(List<ForecastEntity> forecast, int density)
        {
            List<string> vs = new List<string>();
            int filter = 1;
            foreach (var f in forecast)
            {
                if (filter == density)
                {
                    vs.Add(f.PredictionDate.Time.ToString("dd-MM-yyyy"));
                    filter = 0;
                }
                filter++;
            }
            return vs;
        }
    }
}
