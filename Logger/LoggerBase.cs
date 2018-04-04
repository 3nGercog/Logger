using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logger
{
    public abstract class LoggerBase
    {
        Queue<Entry> entries;
        bool isRunning;
        Thread thread;

        protected readonly object lockObj = new object();
        protected Target target;

        public LoggerBase(Target targets)
        {
            this.target = targets;
            entries = new Queue<Entry>();
            isRunning = false;
            thread = null;
        }
        void Run()
        {
            while (true)
            {
                lock (lockObj)
                {
                    if (entries.Count == 0)
                    {
                        if (!isRunning)
                            break;
                    }
                    else
                    {
                        try
                        {
                            var entry = entries.Dequeue();
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
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception);
                            isRunning = false;
                        }
                    }
                }
                Thread.Sleep(10);
            }
        }
        public void Start()
        {
            lock (lockObj)
            {
                if (isRunning)
                    return;
                isRunning = true;
            }
            thread = new Thread(Run);
            thread.Start();
        }
        public void Stop()
        {
            lock (lockObj)
            {
                if (!isRunning)
                    return;
                isRunning = false;
            }
            thread.Join();
            thread = null;
        }

        public virtual void Log(Level level, string message)
        {
            lock (lockObj)
            {
                if (isRunning)
                    return;
                var timeStamp = DateTime.Now;
                var entry = new Entry(timeStamp, level, message);
                entries.Enqueue(entry);
            }
        }
        public virtual void Log(Level level, string format, params object[] args) { this.Log(level, string.Format(format, args)); }
        public virtual void Log(Level level, object obj) { Log(level, obj.ToString()); }
    }
}
