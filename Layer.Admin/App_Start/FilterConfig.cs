using Layer.Admin.Attributes;
using System.Web.Mvc;

namespace Layer.Admin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ElmahHandleErrorAttribute());
        }
    }
}
