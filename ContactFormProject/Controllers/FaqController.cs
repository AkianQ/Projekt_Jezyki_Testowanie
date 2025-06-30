using Microsoft.AspNetCore.Mvc;

namespace ContactFormProject.Controllers
{
    public class FaqController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
