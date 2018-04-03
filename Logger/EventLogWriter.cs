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
        const string SOURCE = "STLoger";
        const string LOGNAME = "Application";
        public void Write(DateTime dateTime, Level level, string message)
        {
            if (!EventLog.SourceExists(SOURCE))
            {
                EventLog.CreateEventSource(SOURCE, LOGNAME);
            }
            // Create an EventLog instance and assign its source.
            using (EventLog myLog = new EventLog())
            {
                myLog.Source = SOURCE;
                switch (level)
                {
                    case Level.Debug:
                        myLog.WriteEntry(message, EventLogEntryType.SuccessAudit, Thread.CurrentThread.ManagedThreadId);
                        break;
                    case Level.Info:
                        myLog.WriteEntry(message, EventLogEntryType.Information, Thread.CurrentThread.ManagedThreadId);
                        break;
                    case Level.Warn:
                        myLog.WriteEntry(message, EventLogEntryType.Warning, Thread.CurrentThread.ManagedThreadId);
                        break;
                    case Level.Error:
                        myLog.WriteEntry(message, EventLogEntryType.Error, Thread.CurrentThread.ManagedThreadId);
                        break;
                    case Level.Fatal:
                        myLog.WriteEntry(message, EventLogEntryType.FailureAudit, Thread.CurrentThread.ManagedThreadId);
                        break;
                    default:
                        myLog.WriteEntry(message, EventLogEntryType.Information, Thread.CurrentThread.ManagedThreadId);
                        break;
                }                 
            }
        }
    }
}
