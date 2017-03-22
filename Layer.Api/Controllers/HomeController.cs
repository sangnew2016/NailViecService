using System.Web.Http;
using System.Web.Mvc;

namespace Layer.Api.Controllers
{
    public class HomeController: ApiController
    {
        //public ActionResult Index()
        //{
        //    return Redirect("/swagger");
        //}

        public IHttpActionResult Get()
        {
            return Ok(new { info = "Access any 404 path and check /elmah.axd to see the 404 error in the log." });
        }
    }
}