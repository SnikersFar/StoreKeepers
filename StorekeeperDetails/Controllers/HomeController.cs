using Microsoft.AspNetCore.Mvc;

namespace StorekeeperDetails.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
