using Layer.Admin.Results;
using System.Web.Mvc;

namespace Layer.Admin.Controllers
{
    [Authorize]
    public class ElmahController : Controller
    {
        public ActionResult Index(string type)
        {
            return new ElmahResult(type);
        }
    }
}