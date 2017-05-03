using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Reflection;

namespace Layer.Admin
{
    public class AdminModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder), "Argument builder can not be null.");
            }

            //The line below tells autofac, when a controller is initialized, pass into its constructor, the implementations of the required interfaces
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            base.Load(builder);
        }
    }
}