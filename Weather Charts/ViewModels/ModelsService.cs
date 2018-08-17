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
        public ChartValues<double> PressureToChart(List<ForecastEntity> forecast)
        {
            ChartValues<double> vs = new ChartValues<double>();
            int filter = 4;
            foreach (var f in forecast)
            {
                if (filter == 4)
                {
                    vs.Add(f.WeatherMain.Pressure);
                    filter = 0;
                }
                filter++;
            }
            return vs;
        }

        public ChartValues<double> TemperaturesToChart(List<ForecastEntity> forecast)
        {
            ChartValues<double> vs = new ChartValues<double>();
            int filter = 4;
            foreach (var f in forecast)
            {
                if (filter == 4)
                {
                    vs.Add(f.WeatherMain.Temperature);
                    filter = 0;
                }
                filter++;
            }
            return vs;
        }

         public List<string> DatesToArray(List<ForecastEntity> forecast)
        {
            List<string> vs = new List<string>();
            int filter = 4;
            foreach (var f in forecast)
            {
                if (filter == 4)
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
