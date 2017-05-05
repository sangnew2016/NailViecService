using Autofac;
using Layer.Application.AppServices;

namespace Layer.Application
{
    public class ApplicationModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShopAppService>().As<ShopAppService>().InstancePerLifetimeScope();
        }
    }
}
