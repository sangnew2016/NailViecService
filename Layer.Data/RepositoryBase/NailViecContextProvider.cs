using Layer.Domain.Model;
using System.Diagnostics;

namespace Layer.Data.RepositoryBase
{
    public class NailViecContextProvider
    {
        private readonly IRequestObjectProvider<NailViecAppContext> _requestNailViecContext;

        public NailViecContextProvider(IRequestObjectProvider<NailViecAppContext> requestSurveyContext)
        {
            _requestNailViecContext = requestSurveyContext;
        }


        public NailViecAppContext Get()
        {
            var context = _requestNailViecContext.Get();
            if (context == null)
            {
                context = new NailViecAppContext();
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;
                context.Database.Log = Logger;
                _requestNailViecContext.Set(context);
            }
            return context;
        }

        private static void Logger(string obj)
        {
            Debug.WriteLine(obj);
        }
    }
}
