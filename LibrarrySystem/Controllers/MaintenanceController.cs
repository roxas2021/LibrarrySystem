using Microsoft.AspNetCore.Mvc;

namespace LibrarrySystem.Controllers
{
    public class MaintenanceController : Controller
    {

        private readonly ILogger<MaintenanceController> _logger;

        public MaintenanceController(ILogger<MaintenanceController> logger)
        {
            _logger = logger;
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
