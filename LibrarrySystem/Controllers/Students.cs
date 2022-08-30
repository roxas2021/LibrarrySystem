using Microsoft.AspNetCore.Mvc;

namespace LibrarrySystem.Controllers
{
    public class Students : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
