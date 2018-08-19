using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace Forecast_Collector
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        protected override void OnAfterInstall(IDictionary savedState)
        {
            using (var sc = new ServiceController(serviceInstaller1.ServiceName))
            {
                 sc.Start();   
            }
        }

        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            using (var sc = new ServiceController(serviceInstaller1.ServiceName))
            {
                sc.Start();
            }
        }

        protected override void OnBeforeInstall(IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);
        }

    }
}
