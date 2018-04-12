//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Routing;
//using Unity;

//namespace WebApp
//{
//    public class UnityControllerFactory: DefaultControllerFactory
//    {
//        UnityContainer container;

//        public UnityControllerFactory(UnityContainer container)
//        {
//            this.container = container;
//        }

//        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
//        {
//            IController controller = null;
//            if (controllerType != null)
//            {
//                controller = this.container.Resolve(controllerType) as IController;
//            }
//            return controller;
//        }
//    }
//}