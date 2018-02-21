using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast_Collector
{
    public class CurrentWeatherJob : IJob
    {
            public async Task Execute(IJobExecutionContext context)
            {
                await Console.Out.WriteLineAsync("Greetings from HelloJob!");
            }


        
    }
}
