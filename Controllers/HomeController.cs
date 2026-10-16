using Microsoft.AspNetCore.Mvc;

namespace OneTOMany.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
