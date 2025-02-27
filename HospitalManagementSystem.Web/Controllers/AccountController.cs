using HospitalManagementSystem.Models.UIModels;
using HospitalManagementSystem.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalManagementSystem.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _logger;
        private readonly IConfiguration _configuration;

        public AccountController(IAccountRepository logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var loginUIModel = new LoginUIModel
            {
                Email = "rohan@gmail.com",
                Password = "abc123"
            };
            return View(loginUIModel);
        }

        [HttpPost]
        public IActionResult Login(LoginUIModel loginUIModel)
        {
            try
            {
                var returnResponse = _logger.CheckLoginDetails(loginUIModel.Email, loginUIModel.Password);

                if (returnResponse.status)
                {
                    HttpContext.Session.SetString("User", JsonConvert.SerializeObject(returnResponse.Data));
                    return RedirectToAction("Dashboard", "Account", new { area = returnResponse.Data.Area });
                }
                else
                {
                    loginUIModel.status = false;
                    loginUIModel.Message = returnResponse.message;
                }
            }
            catch (Exception ex)
            {
                loginUIModel.status = false;
                loginUIModel.Message = ex.Message;
            }
            return View("Login", loginUIModel);
        }
    }
}
