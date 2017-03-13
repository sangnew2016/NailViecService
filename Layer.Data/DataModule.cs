using System;
using Autofac;
using Layer.Data.RepositoryBase;
using Layer.Domain.Model;
using Layer.Domain.Services;
using Layer.Data.Repository;
using Layer.Domain.Repositories;

namespace Layer.Data
{
    public class DataModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterContexts(builder);
            RegisterRepositories(builder);
            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>().InstancePerLifetimeScope();
        }

        private void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<CountryRepository>().As<ICountryRepository>().InstancePerLifetimeScope();
        }

        private void RegisterContexts(ContainerBuilder builder)
        {
            builder.RegisterType<NailViecContextProvider>().InstancePerLifetimeScope();
            builder.RegisterType<RequestObjectProvider<NailViecAppContext>>().As<IRequestObjectProvider<NailViecAppContext>>().InstancePerLifetimeScope();
        }
    }
}
