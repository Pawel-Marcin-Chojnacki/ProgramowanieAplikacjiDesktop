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
                    .WithIdentity("CurrentWeatherJob", "group1")
                    .Build();

                // Trigger the job to run now, and then repeat every 10 seconds
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("timetrigger", "group1")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(1)
                        .RepeatForever())
                    .Build();

                // Tell quartz to schedule the job using our trigger
                await scheduler.ScheduleJob(job, trigger);
            }
            catch (SchedulerException se)
            {
                //TODO: Event Log
                throw;
            }
        }

    }
}
