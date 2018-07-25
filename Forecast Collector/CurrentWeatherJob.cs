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
            //public async Task Execute(IJobExecutionContext context)
            //{
                
            //}

        void Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }

        Task IJob.Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
