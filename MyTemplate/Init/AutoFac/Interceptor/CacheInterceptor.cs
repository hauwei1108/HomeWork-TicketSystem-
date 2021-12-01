using Castle.DynamicProxy;
using Interfrastructure.DataBase;
using MyTemplateWeb.Init.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyTemplateWeb.Init.AutoFac.Interceptor
{
    public class CacheInterceptor : IInterceptor
    {
        private static readonly ICacheProvider Cache = new DefaultCacheProvider();

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.IsPublic   // 避免內部 private 或 protected method 被呼叫也被修改
                && invocation.Method.Name.StartsWith("Get"))
            {
                var key = GenerateKey(invocation.InvocationTarget.ToString() + invocation.Method.Name, invocation.Arguments);

                if (Cache.IsSet(key))
                {
                    invocation.ReturnValue = Cache.Get(key);
                    return;
                }

                invocation.Proceed();

                if (invocation.ReturnValue != null)
                {
                    var cacheExpiresIn = GetCacheObjectDuration(invocation);

                    Cache.Set(key, invocation.ReturnValue, cacheExpiresIn);
                }
            }
            else
            {
                invocation.Proceed();
            }
        }

        private int GetCacheObjectDuration(IInvocation invocation)
        {
            return 5;
        }

        private string GenerateKey(string methodName, object[] args)
        {
            List<object> argList = args.Where((a) => (a is MyTemplateContext) == false).ToList();

            string tempKey = $@"{methodName}{JsonSerializer.Serialize(argList).GetHashCode().ToString()}";

            return tempKey;
        }

    }
}
