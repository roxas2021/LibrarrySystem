using Microsoft.AspNetCore.Mvc;

namespace LibrarrySystem.Controllers
{
    public class Reports : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Transaction()
        {
            return View();
        }

        public IActionResult Books()
        {
            return View();
        }
    }
}
