using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logger;

namespace WebApp
{
    public class LoggerService : ILogger
    {
        public STLogger GetSTLogger() { return new STLogger(Target.File | Target.Output); } 
    }
}