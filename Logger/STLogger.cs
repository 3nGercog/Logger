using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class STLogger : LoggerBase, ILogger
    {
        public STLogger(Target targets) : base(targets)
        {

        }
        public Target Targets { get { return this.target; } }
        public void Debug(string message)
        {
#if DEBUG
            Log(Level.Debug, message);
#endif
        }
        public void Debug(object obj)
        {
#if DEBUG
            Log(Level.Debug, obj);
#endif
        }
        public void Debug(string format, params object[] args)
        {
#if DEBUG
            Log(Level.Debug, format, args);
#endif
        }
        
        public void Error(string message) { Log(Level.Error, message); }
        public void Error(object obj) { Log(Level.Error, obj); }
        public void Error(string format, params object[] args) { Log(Level.Error, format, args); }

        public void Fatal(string message) { Log(Level.Fatal, message); }
        public void Fatal(object obj) { Log(Level.Fatal, obj); }
        public void Fatal(string format, params object[] args) { Log(Level.Fatal, format, args); }

        public void Info(string message) { Log(Level.Info, message); }
        public void Info(object obj) { Log(Level.Info, obj); }
        public void Info(string format, params object[] args) { Log(Level.Info, format, args); }


        public void Warn(string message) { Log(Level.Warn, message); }
        public void Warn(object obj) { Log(Level.Warn, obj); }
        public void Warn(string format, params object[] args) { Log(Level.Warn, format, args); }
    }
}
