using System;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Layer.Api
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //RouteTable.Routes.Ignore("{resource}.axd/{*pathInfo}");
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //try
            //{
            //    Exception exception = Server.GetLastError();
            //    System.Diagnostics.Debug.WriteLine(exception);
            //    Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
            //}
            //catch (Exception ex)
            //{
            //    Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            //}

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}