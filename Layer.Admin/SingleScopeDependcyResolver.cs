using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace Layer.Admin
{
    public class SingleScopeDependcyResolver : IDependencyResolver
    {
        private AutofacDependencyResolver _autofacWebApiDependencyResolver;
        //private readonly IContainer _container;

        public SingleScopeDependcyResolver(IContainer container)
        {
            _autofacWebApiDependencyResolver = new AutofacDependencyResolver(container);
        }

        public void Dispose()
        {
        }

        public object GetService(Type serviceType)
        {
            return _autofacWebApiDependencyResolver.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _autofacWebApiDependencyResolver.GetServices(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}