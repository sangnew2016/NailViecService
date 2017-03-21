using log4net;

namespace Layer.Domain.Services
{
    public static class ExceptionLogger
    {
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
