using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp
{
    public class LoggerAttribute: ActionFilterAttribute
    {
        public ILogger Logger { get; set; }
        STLogger stLogger;


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                stLogger = Logger.GetSTLogger();
                string actionName = filterContext.ActionDescriptor.ActionName;
                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                stLogger.Info(controllerName + " OnActionExecuting " + actionName);
                base.OnActionExecuting(filterContext);
            }
            catch (Exception ex)
            {
                stLogger.Error(ex.Message);
            }
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                string actionName = filterContext.ActionDescriptor.ActionName;
                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                stLogger.Info(controllerName + " OnActionExecuted " + actionName);
                base.OnActionExecuted(filterContext);
            }
            catch (Exception ex)
            {
                stLogger.Error(ex.Message);
            }

        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            try
            {
                stLogger.Info("OnResultExecuting ");
                base.OnResultExecuting(filterContext);
            }
            catch (Exception ex)
            {
                stLogger.Error(ex.Message);
            }
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            try
            {
                stLogger.Info("OnResultExecuted");
                base.OnResultExecuted(filterContext);
            }
            catch (Exception ex)
            {
                stLogger.Error(ex.Message);
            }
            finally
            {
                stLogger.Start();
            }
        }
    }
}