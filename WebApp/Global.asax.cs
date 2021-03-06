﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //UnityConfig.RegisterTypes(UnityConfig.Container);
            //ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory((UnityContainer)UnityConfig.Container));
        }

        //protected void Session_Start()
        //{
        //    Debug.WriteLine("----------------------------------"  + Session.Count.ToString());
        //}
    }
}
