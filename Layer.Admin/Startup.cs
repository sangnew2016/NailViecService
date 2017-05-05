using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using Layer.Admin.App_Start;

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
            var builder = AutofacConfig.Configure();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}
