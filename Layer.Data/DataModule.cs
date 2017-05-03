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
            builder.RegisterType<ShopRepository>().As<IShopRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ShopStatusRepository>().As<IShopStatusRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ShopStatusHistoryRepository>().As<IShopStatusHistoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ShopOwnerRepository>().As<IShopOwnerRepository>().InstancePerLifetimeScope();

            builder.RegisterType<JobRepository>().As<IJobRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JobStatusRepository>().As<IJobStatusRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JobStatusHistoryRepository>().As<IJobStatusHistoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JobTypeRepository>().As<IJobTypeRepository>().InstancePerLifetimeScope();
        }

        private void RegisterContexts(ContainerBuilder builder)
        {
            builder.RegisterType<NailViecContextProvider>().InstancePerLifetimeScope();
            builder.RegisterType<RequestObjectProvider<NailViecAppContext>>().As<IRequestObjectProvider<NailViecAppContext>>().InstancePerLifetimeScope();
        }
    }
}
