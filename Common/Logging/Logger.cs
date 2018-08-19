using System.Diagnostics;

namespace Common.Logging
{
    public class EventLogger
    {
        private static readonly string Name = "WeatherLog";
        private static readonly string Source = "WeatherSource";
        private EventLog eventLog;
        public EventLogger()
        {
            if(!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, Name);
            }

            eventLog = new EventLog(Name);
            eventLog.Source = Source;
        }

        public void WriteMessage(string message)
        {
            eventLog.WriteEntry(message);
        }
    }
}
