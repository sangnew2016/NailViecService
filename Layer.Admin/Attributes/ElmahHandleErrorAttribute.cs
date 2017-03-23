using System.Web.Mvc;
using System.Web;
using Elmah;

namespace Layer.Admin.Attributes
{
    public class ElmahHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //base.OnException(context);
            //var e = context.Exception;
            //var httpcontext = HttpContext.Current;

            //var signal = ErrorSignal.FromContext(httpcontext);
            //if (signal != null)
            //{
            //    signal.Raise(e, httpcontext);
            //}
        }
    }
}