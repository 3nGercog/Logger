using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public abstract class LogBase
    {
        protected readonly object lockObj = new object();
        protected Target target;
        public LogBase(Target targets)
        {
            this.target = targets;
        }
        public virtual void Log(Level level, string message)
        {
            lock (lockObj)
            {
                var timeStamp = DateTime.Now;
                var entry = new Entry(timeStamp, level, message);
                if (target.HasFlag(Target.Console))
                    entry.WriteToConsole();
                if (target.HasFlag(Target.File))
                    entry.WriteToFile();
                if (target.HasFlag(Target.DataBase))
                    entry.WriteToDataBase();
                if (target.HasFlag(Target.EventLog))
                    entry.WriteToEventLog();
                if (target.HasFlag(Target.Output))
                    entry.WriteToOutput();
            }
        }
    }
}
