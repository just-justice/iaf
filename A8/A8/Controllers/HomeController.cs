using Microsoft.AspNetCore.Mvc;

namespace A8.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
