using System.Web.Http.ExceptionHandling;

namespace Layer.Api.Attributes
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        //Exception on Level 2
        public override void Log(ExceptionLoggerContext context)
        {
            var log = context.Exception.ToString();
            //Do whatever logging you need to do here.

        }
    }
}