//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using Unity.Lifetime;

//namespace WebApp
//{
//    public class SessionLifetimeManager : LifetimeManager
//    {
//        private string key = Guid.NewGuid().ToString();
//        protected override LifetimeManager OnCreateLifetimeManager()
//        {
//            return this;
//        }
//        public override object GetValue(ILifetimeContainer container = null)
//        {
//            return HttpContext.Current.Items[key];
//        }
//        public override void SetValue(object newValue, ILifetimeContainer container = null)
//        {
//            HttpContext.Current.Items[key] = newValue;
//            base.SetValue(newValue, container);
//        }
//        public override void RemoveValue(ILifetimeContainer container = null)
//        {
//            base.RemoveValue(container);
//        }
//    }
//}