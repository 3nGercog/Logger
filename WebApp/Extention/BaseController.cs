using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAp;

namespace WebApp
{
    public class BaseController : Controller
    {
        readonly ILogger _logger;
        readonly IReader _reader;
        readonly ISession _session;
        readonly ISum _sum;

        protected STLogger STLogger { get; private set; }
        protected ISession ISession { get; set; }
        protected IReader Reader { get; private set; }
        protected ISum Sum { get; private set; }
        public BaseController() { }
        public BaseController(ILogger logger)
        {
            this._logger = logger;
            STLogger = this._logger.GetSTLogger();
        }
        public BaseController(ILogger logger, ISession session)
        {
            this._logger = logger;
            STLogger = this._logger.GetSTLogger();
            this._session = session;
            ISession = this._session;
        }
        public BaseController(ILogger logger, ISession session, IReader reader)
        {
            this._logger = logger;
            STLogger = this._logger.GetSTLogger();
            this._session = session;
            ISession = this._session;
            this._reader = reader;
            Reader = this._reader;
        }
        public BaseController(ILogger logger, ISession session, IReader reader, ISum sum)
        {
            this._logger = logger;
            STLogger = this._logger.GetSTLogger();
            this._session = session;
            ISession = this._session;
            this._reader = reader;
            Reader = this._reader;
            this._sum = sum;
            Sum = this._sum;
        }
    }
}