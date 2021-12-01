using Autofac;
using MyTemplateWeb.Init.AutoFac.Interceptor;
using MyTemplateWeb.Init.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MyTemplateWeb.Init.AutoFac
{
    /// <summary>
    /// Register objects to AutoFac.
    /// </summary>
    public class AutofacModule : Autofac.Module
    {
        private Type[] cacheDaos = { };

        protected override void Load(ContainerBuilder builder)
        {
            Assembly coreAssembly = Assembly.GetExecutingAssembly();

            builder.Register(c => new CacheInterceptor())
                   .SingleInstance();

            builder.RegisterType<RedisCacheProvider>()
                .As<ICacheProvider>()
                .SingleInstance()
                .PropertiesAutowired();

            builder.RegisterAssemblyTypes(coreAssembly)
                   .Where(t => t.Name.EndsWith("Util"))
                   .SingleInstance()
                   .AsSelf()
                   .PropertiesAutowired();

            //builder.RegisterAssemblyTypes(coreAssembly)
            //       .Where(t => cacheDaos.Where((a) => a.Name == t.Name).Count() == 0 && t.Name.EndsWith("Dao"))
            //       .AsImplementedInterfaces()
            //       .SingleInstance()
            //       .PropertiesAutowired();

            //builder.RegisterAssemblyTypes(coreAssembly)
            //       .Where(t => cacheDaos.Where((a) => a.Name == t.Name).Count() != 0 && t.Name.EndsWith("Dao"))
            //       .AsImplementedInterfaces()
            //       .SingleInstance()
            //       .PropertiesAutowired()
            //       .EnableInterfaceInterceptors()
            //       .InterceptedBy(typeof(CacheInterceptor));

            //builder.RegisterType<Service.LoginService>()
            //       .SingleInstance();

            //builder.RegisterType<NLog.LogNLogService>()
            //       .As<ILog>()
            //       .SingleInstance()
            //       .PropertiesAutowired();

            builder.RegisterAssemblyTypes(coreAssembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .SingleInstance()
                   .PropertiesAutowired();

            builder.RegisterAssemblyTypes(coreAssembly)
                   .Where(t => t.Name.EndsWith("Mware"))
                   .AsImplementedInterfaces()
                   .SingleInstance()
                   .PropertiesAutowired();

            //builder.RegisterAssemblyTypes(coreAssembly)
            //       .Where(t => t.Name.EndsWith("Facade"))
            //       .AsImplementedInterfaces()
            //       .SingleInstance()
            //       .PropertiesAutowired();

            builder.RegisterAssemblyTypes(coreAssembly)
                   .Where(t => t.Name.EndsWith("Hub"))
                   .AsSelf()
                   .SingleInstance()
                   .PropertiesAutowired();

            #region .Net Core
            builder.RegisterType<Microsoft.AspNetCore.Http.HttpContextAccessor>()
                    .As<Microsoft.AspNetCore.Http.IHttpContextAccessor>()
                    .SingleInstance();
            builder.RegisterType<Microsoft.AspNetCore.Mvc.Infrastructure.ActionContextAccessor>()
                    .As<Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor>()
                    .SingleInstance();
            //builder.RegisterType<Package.SignalR.SignalRAuthorizationHandler>()
            //        .As<Microsoft.AspNetCore.Authorization.IAuthorizationHandler>()
            //        .SingleInstance()
            //        .PropertiesAutowired();
            #endregion

            // === 以同樣方式註冊 Controller, 需在 Startup 中變更 ConfigureServices() 設定 ===
            builder.RegisterAssemblyTypes(coreAssembly)
                   .Where(t => t.Name.EndsWith("Controller"))
                   .AsSelf()
                   //.SingleInstance()
                   .PropertiesAutowired();

        }
    }
}
