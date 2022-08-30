using Microsoft.AspNetCore.Mvc;

namespace LibrarrySystem.Controllers
{
    public class Reports : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
