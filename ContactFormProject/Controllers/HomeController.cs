using Microsoft.AspNetCore.Mvc;

namespace ContactFormProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}