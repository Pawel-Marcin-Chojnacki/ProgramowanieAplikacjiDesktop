using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Forecast_Collector
{
    public partial class Service1 : ServiceBase
    {
        public const string ServiceTitle = "Weather data collection";
        private IScheduler scheduler;

        public Service1()
        {
            this.ServiceName = ServiceTitle;
            InitializeComponent();
        }

        public void RunAsConsole(string[] args)
        {
            OnStart(args);
            Console.ReadLine();
            OnStop();
        }

        protected override async void OnStart(string[] args)
        {
            await RunService();
        }

        protected override async void OnStop()
        {
            await scheduler.Shutdown();
        }

        private async Task RunService()
        {
            try
            {
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                scheduler = await factory.GetScheduler();

                await scheduler.Start();

                IJobDetail job = JobBuilder.Create<CurrentWeatherJob>()
                    .WithIdentity("CurrentWeatherJob", "mainGroup")
                    .Build();

                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("updateDataTrigger", "mainGroup")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInMinutes(10))
                    .Build();

                await scheduler.ScheduleJob(job, trigger);
            }
            catch (SchedulerException se)
            {
                throw se;
            }
        }

    }
}
