using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTemplateWeb.Init.Cache
{
    public interface ICacheProvider
    {
        T Get<T>(string key);
        object Get(string key);
        void Set(string key, object data, int cacheSeconds);
        bool IsSet(string key);
        void Invalidate(string key);

    }
}
