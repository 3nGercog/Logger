using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class SessionService : ISession
    {
        private readonly HttpSessionStateBase _session;

        public SessionService(HttpSessionStateBase session)
        {
            _session = session;
        }

        public void Clear()
        {
            _session.RemoveAll();
        }

        public void Delete(string key)
        {
            _session.Remove(key);
        }

        public object Get(string key)
        {
            return _session[key];
        }

        public T Get<T>(string key) where T : class
        {
            return _session[key] as T;
        }

        public ISession Store(string key, object value)
        {
            _session[key] = value;

            return this;
        }
    }
}