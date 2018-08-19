using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Forecast_Collector
{
    public partial class Service1 : ServiceBase
    {
        public const string ServiceTitle = "Forecast collector";
        private IScheduler scheduler;
        private Timer timer = new Timer();
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
            WriteToFile("Service is started at " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 5000;
            timer.Enabled = true;
            await RunService();
        }

        protected override async void OnStop()
        {
            await scheduler.Shutdown();
            WriteToFile("Service is stopped at " + DateTime.Now);
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {

            WriteToFile("Service is recall at " + DateTime.Now);

        }

        public void WriteToFile(string Message)
        {

            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";

            if (!Directory.Exists(path))
            {

                Directory.CreateDirectory(path);

            }

            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            
                using (StreamWriter sw = File.AppendText(filepath))
                {

                    sw.WriteLine(Message);
                }
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
                WriteToFile("Exception: "+ se.Message);
                throw se;
            }
        }

    }
}
