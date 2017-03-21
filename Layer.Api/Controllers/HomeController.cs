using System.Web.Mvc;

namespace Layer.Api.Controllers
{
    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}