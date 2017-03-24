using Layer.Data.RepositoryBase;
using System.Web.Http.Filters;

namespace Layer.Api.Attributes
{
    public class SaveChangesActionFilterAttribute: ActionFilterAttribute
    {
        private readonly ContextService _contextService;
        public SaveChangesActionFilterAttribute(ContextService contextService)
        {
            _contextService = contextService;
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception == null && _contextService.HasChanges)
            {
                _contextService.SaveChanges();
            }
        }
    }
}