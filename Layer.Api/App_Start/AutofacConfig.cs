using Autofac;
using Autofac.Features.ResolveAnything;
using Layer.Application;
using Layer.Data;
using Layer.Domain;

namespace Layer.Api
{
    public static class AutofacConfig
    {
        public static ContainerBuilder Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<DomainModule>();
            builder.RegisterModule<DataModule>();

            return builder;
        }
    }
}