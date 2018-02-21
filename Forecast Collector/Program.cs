using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace Forecast_Collector
{
    public static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        public static void Main(string[] args)
        {
            Service1 service1 = new Service1();

            if (Environment.UserInteractive)
            {
                service1.RunAsConsole(args);
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] { service1 };
                ServiceBase.Run(ServicesToRun);
            }
        }

        
    }
}
