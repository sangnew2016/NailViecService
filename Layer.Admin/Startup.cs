using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Autofac;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using Layer.Application;

[assembly: OwinStartup(typeof(Layer.Admin.Startup))]

namespace Layer.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            RegisterDependencies();
        }

        private void RegisterDependencies() {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AdminModule());
            //builder.RegisterModule(new ApplicationModule());
            //builder.RegisterModule(new DomainModule());
            //builder.RegisterModule(new DataModule());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            //set Autofac as default Dependency Resolver for application
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}
