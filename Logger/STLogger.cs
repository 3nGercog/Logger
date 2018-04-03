using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class STLogger : LogBase, ILogger
    { 
        public STLogger(Target targets):base(targets)
        {
            
        }
        public Target Targets { get { return this.target; } }
        public void Debug(string message)
        {
            Log(Level.Debug, message);
        }

        public void Error(string message)
        {
            Log(Level.Error, message);
        }

        public void Fatal(string message)
        {
            Log(Level.Fatal, message);
        }

        public void Info(string message)
        {
            Log(Level.Info, message);
        }

        public void Warn(string message)
        {
            Log(Level.Warn, message);
        }
    }
}
