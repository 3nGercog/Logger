using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logger
{
    class EventLogWriter : IWriter
    {
        string source = "";
        public EventLogWriter(string source)
        {
            this.source = source;
        }
        const string LOGNAME = "Application";
        public void Write(DateTime dateTime, Level level, string message)
        {
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, LOGNAME);
            }
            using (EventLog myLog = new EventLog())
            {
                myLog.Source = source;
                switch (level)
                {
                    case Level.Debug:
                        myLog.WriteEntry(message, EventLogEntryType.SuccessAudit, 0);
                        break;
                    case Level.Info:
                        myLog.WriteEntry(message, EventLogEntryType.Information, 1);
                        break;
                    case Level.Warn:
                        myLog.WriteEntry(message, EventLogEntryType.Warning, 2);
                        break;
                    case Level.Error:
                        myLog.WriteEntry(message, EventLogEntryType.Error, 3);
                        break;
                    case Level.Fatal:
                        myLog.WriteEntry(message, EventLogEntryType.FailureAudit, 4);
                        break;
                    default:
                        myLog.WriteEntry(message, EventLogEntryType.Information, 1);
                        break;
                }                 
            }
        }
    }
}
