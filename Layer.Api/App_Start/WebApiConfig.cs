using Autofac;
using Elmah.Contrib.WebApi;
using Layer.Api.Attributes;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Layer.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            IContainer _container;

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.Services.Add(typeof(IExceptionLogger), new ElmahExceptionLogger());

            log4net.Config.XmlConfigurator.Configure();

            // Web API routes
            config.MapHttpAttributeRoutes();

            // catch all route mapped to ErrorController so 404 errors
            // can be logged in elmah
            config.Routes.MapHttpRoute(
                name: "NotFound",
                routeTemplate: "{*path}",
                defaults: new { controller = "Error", action = "NotFound" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Register Filter
            config.Filters.Add(new ElmahHandleWebApiErrorAttribute());

            var builder = AutofacConfig.Configure();
            _container = builder.Build();
            config.Filters.Add(_container.Resolve<SaveChangesActionFilterAttribute>());

            //Register Exception
            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
        }
    }
}