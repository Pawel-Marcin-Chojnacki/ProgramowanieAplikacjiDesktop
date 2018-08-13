using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Charts
{
    class ServiceManager
    {
        private ServiceController controller;

        public ServiceManager(string serviceName)
        {
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
                    return true; // Log service started
                }
                catch(InvalidOperationException)
                {
                    return false; //Log Service exception
                }
            }
            else if (controller.Status == ServiceControllerStatus.Running)
            {
                return true; // Log service was already running.
            }
            return false; //what happnd?
        }

        public async Task<bool> StopService()
        {
            if (controller.Status != ServiceControllerStatus.Stopped)
            {
                try
                {
                    controller.Stop();
                    controller.WaitForStatus(ServiceControllerStatus.Stopped);
                    return true; // Log service stopped
                }
                catch (InvalidOperationException)
                {
                    return false; //Log Service exception
                }
            }
            else if (controller.Status == ServiceControllerStatus.Stopped)
            {
                return true; // Log service was already stopped.
            }

            return false; //What happnd?
        }
    }
}
