using Microsoft.AspNetCore.Mvc;

namespace LibrarrySystem.Controllers
{
    public class Transaction : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reserve()
        {
            return View();
        }

        public IActionResult Return()
        {
            return View();
        }
    }
}
