using System.Web;
using System.Web.Http.Filters;

namespace Layer.Api.Attributes
{
    public class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        //Exception on Level 1
        public override void OnException(HttpActionExecutedContext context)
        {
            Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(context.Exception));
        }
    }
}