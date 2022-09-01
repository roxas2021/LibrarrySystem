using Microsoft.AspNetCore.Mvc;

namespace LibrarrySystem.Controllers
{
    public class Books : Controller
    {
        public IActionResult Index()
        {
            TempData["HeaderTitle"] = "BOOKS";
            return View();
        }
    }
}
