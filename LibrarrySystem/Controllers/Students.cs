using Microsoft.AspNetCore.Mvc;

namespace LibrarrySystem.Controllers
{
    public class Students : Controller
    {
        public IActionResult Index()
        {
            TempData["HeaderTitle"] = "STUDENTS";
            return View();
        }
    }
}
