using System.Diagnostics;

namespace Forecast_Collector
{
    class EventLogger
    {
        private static readonly string Name = "WeatherLog";
        private static readonly string Source = "WeatherSource";
        EventLogger()
        {
            EventLog eventLog = new EventLog(Name);
            eventLog.Source = Source;
        }

        public void WriteMessage(string message)
        {

        }

        public void WriteError()
        {

        }


    }
}
