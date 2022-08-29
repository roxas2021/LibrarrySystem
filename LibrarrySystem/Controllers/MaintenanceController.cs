using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using LibrarrySystem.Models;
using System.Data;
using System.Configuration;
using LibrarrySystem.ServicesController;

namespace LibrarrySystem.Controllers
{
    public class MaintenanceController : Controller
    {

        private readonly ILogger<MaintenanceController> _logger;
        AccountVerify accverify = new AccountVerify();
        

        public MaintenanceController(ILogger<MaintenanceController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginUser([Bind] LoginData data)
        {
            var account = accverify.VerifyAccount(data.UserID, data.Password);

            if(account != null)
            {
                return RedirectToAction("Index","Home");
            }

            TempData["msg"] = "Invalid Account and Password. Please try again!.";
            return View("Login");
        }
    }
}
