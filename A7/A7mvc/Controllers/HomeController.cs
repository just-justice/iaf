using Microsoft.AspNetCore.Mvc;

namespace A7mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
