using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebApp
{
    public class SessionService : ISession
    {
        private readonly HttpContextBase _httpContext;

        public SessionService(HttpContextBase httpContext)
        {              
            this._httpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
        }

        public void Clear()
        {
            var session = this._httpContext.Session ?? throw new TypeLoadException();
            session.RemoveAll();
        }

        public void Delete(string key)
        {
            var session = this._httpContext.Session ?? throw new TypeLoadException(nameof(this._httpContext.Session));
            session.Remove(key);
        }

        public object Get(string key)
        {
            var session = this._httpContext.Session ?? throw new TypeLoadException(nameof(this._httpContext.Session));
            return session[key];
        }

        public T Get<T>(string key) where T : class
        {
            var session = this._httpContext.Session ?? throw new TypeLoadException(nameof(this._httpContext.Session));
            return session[key] as T;
        }

        public ISession Store(string key, object value)
        {
            var session = this._httpContext.Session ?? throw new TypeLoadException(nameof(this._httpContext.Session));
            session[key] = value;
            return this;
        }
    }
}