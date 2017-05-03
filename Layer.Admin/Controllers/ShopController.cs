using Layer.Application.AppServices;
using System.Web.Mvc;

namespace Layer.Admin.Controllers
{
    //[Authorize]
    public class ShopController : Controller
    {
        private readonly ShopAppService _shopAppService;

        public ShopController(ShopAppService shopAppService) {
            _shopAppService = shopAppService;
        }

        public string Index()
        {
            return "Minh";
        }
    }
}
