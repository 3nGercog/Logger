using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp
{
    public interface ISession
    {
        void Clear();
        void Delete(string key);
        object Get(string key);
        T Get<T>(string key) where T : class;
        ISession Store(string key, object value);
    }
}
