using Microsoft.AspNetCore.Mvc;

namespace Ness_Mizarhi_Zeev_Test.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
