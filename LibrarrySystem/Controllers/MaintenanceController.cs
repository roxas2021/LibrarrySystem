using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using LibrarrySystem.Models;
using System.Data;
using System.Configuration;
using LibrarrySystem.DAL;
using MODELS;

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

        [HttpGet]
        public IActionResult Index()
        {

            TempData["HeaderTitle"] = "MAINTENANCE";
            var li = accverify.GetAccountData();

            return View(li);
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

        [HttpPost]
        public JsonResult AddRecord(T_UserMaster data)
        {
            string message = string.Empty;
            int isSuccess;

            try
            {
                isSuccess = accverify.InsertUser(data);
                message = "success";
            }
            catch(Exception ex)
            {
                isSuccess = 0;
                message = ex.Message;
            }
            return Json(isSuccess);
        }

        public IActionResult VerifyID(T_UserMaster data)
        {
            int isSuccess;

            var result = accverify.VerifyID(data.Umt_UserID);
            if(result != null)
            {
                isSuccess = 1;
            }
            else
            {
                isSuccess = 0;
            }
            return Json(isSuccess);
        }

        public IActionResult DeleteRecord(string userid)
        {
            int isSuccess;

            isSuccess = accverify.DeleteRecord(userid);

            return Json(isSuccess);
        }
    }
}
