using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Weather_Charts.Logging;

namespace Weather_Charts
{
    class ServiceManager
    {
        private ServiceController controller;

        private IFileLogger _log;
        public ServiceManager(string serviceName, IFileLogger logger)
        {
            _log = logger;
            controller = new ServiceController();
            controller.ServiceName = serviceName;
        }

        public bool StartService()
        {
            if(controller.Status != ServiceControllerStatus.Running)
            {
                try
                {
                    controller.Start();
                    controller.WaitForStatus(ServiceControllerStatus.Running);
                    _log.WriteToFile("Service has been started.");
                    return true;
                }
                catch(InvalidOperationException)
                {
                    _log.WriteToFile("Service hasn't been started. Exception occured.");
                    return false;
                }
            }
            if (controller.Status == ServiceControllerStatus.Running)
            {
                _log.WriteToFile("Service has been already running.");
                return true;
            }
            return false;
        }

        public bool StopService()
        {
            if (controller.Status != ServiceControllerStatus.Stopped)
            {
                try
                {
                    controller.Stop();  
                    controller.WaitForStatus(ServiceControllerStatus.Stopped);
                    _log.WriteToFile("Service has been stopped.");

                    return true; 
                }
                catch (InvalidOperationException)
                {
                    _log.WriteToFile("Service hasn't been stopped. Exception occured.");
                    return false;
                }
            }
            else if (controller.Status == ServiceControllerStatus.Stopped)
            {
                _log.WriteToFile("Service has been already stopped.");
                return true;
            }

            return false;
        }
    }
}
