//using System.Web;
//using System.Web.Mvc;
//using Unity;
//using Unity.Injection;
//using Unity.Mvc5;
//using WebAp;

//namespace WebApp
//{
//    public static class UnityConfig
//    {
//        public static void RegisterComponents()
//        {
//			var container = new UnityContainer();

//            // register all your components with the container here
//            // it is NOT necessary to register your controllers

//            // e.g. container.RegisterType<ITestService, TestService>();
//            container.RegisterType<HttpSessionStateBase>(new InjectionFactory(x => new HttpSessionStateWrapper(HttpContext.Current.Session)));
//            container.RegisterType<ILogger, LoggerService>();
//            container.RegisterType<ISession, SessionService>(new InjectionConstructor(new ResolvedParameter(typeof(HttpContextBase))));
//            container.RegisterType<IReader, ReaderService>();
//            container.RegisterType<ISum, SumService>();


//            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
//        }
//    }
//}