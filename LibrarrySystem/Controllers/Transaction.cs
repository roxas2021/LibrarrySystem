using Microsoft.AspNetCore.Mvc;

namespace LibrarrySystem.Controllers
{
    public class Transaction : Controller
    {
        public IActionResult Index()
        {
            TempData["HeaderTitle"] = "BORROW TRANSACTION";
            return View();
        }

        public IActionResult Reserve()
        {
            TempData["HeaderTitle"] = "RESERVE TRANSACTION";
            return View();
        }

        public IActionResult Return()
        {
            TempData["HeaderTitle"] = "RETURN TRANSACTION";
            return View();
        }
    }
}
