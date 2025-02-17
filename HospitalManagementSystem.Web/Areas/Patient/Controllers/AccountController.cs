using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Web.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class AccountController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
