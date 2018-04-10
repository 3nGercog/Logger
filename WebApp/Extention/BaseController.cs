using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp
{
    public class BaseController : Controller
    {
        protected readonly ILogger logger;
        public STLogger STLogger { get; private set; }
        public BaseController(ILogger logger)
        {
            this.logger = logger;
            STLogger = this.logger.GetSTLogger();
        }
    }
}