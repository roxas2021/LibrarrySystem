using Microsoft.AspNetCore.Mvc;

namespace LibrarrySystem.Controllers
{
    public class Reports : Controller
    {
        public IActionResult Index()
        {
            TempData["HeaderTitle"] = "STUDENT REPORTS";
            return View();
        }

        public IActionResult Transaction()
        {
            TempData["HeaderTitle"] = "TRANSACTION REPORTS";
            return View();
        }

        public IActionResult Books()
        {
            TempData["HeaderTitle"] = "BOOKS REPORTS";
            return View();
        }
    }
}
