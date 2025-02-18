using HospitalManagementSystem.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Web.Areas.Staff.Controllers
{
    [Area("Staff")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
