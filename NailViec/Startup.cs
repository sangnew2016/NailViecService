using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using NailViec;
using Autofac;
using System.Web.Http;
using System.Reflection;
using Autofac.Integration.WebApi;

[assembly: OwinStartup(typeof(NailViec.Startup))]

namespace NailViec
{
    public partial class Startup
    {
        private IContainer _container;

        public void Configuration(IAppBuilder app)
        {
            var builder = AutofacConfig.Configure();
            var config = new HttpConfiguration();

            _container = builder.Build();
            config.DependencyResolver = new SingleScopeDependcyResolver(_container);
            WebApiConfig.Register(config);
            app.UseWebApi(config);

            ConfigureAuth(app);
        }
    }
}
