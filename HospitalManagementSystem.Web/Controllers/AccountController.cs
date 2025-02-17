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
            var loginUIModel = new LoginUIModel();

            loginUIModel.Email = "amrit@gmail.com";
            loginUIModel.Password = "admin123";

            return View(loginUIModel);
        }

        [HttpPost]
        public IActionResult Login(LoginUIModel loginUIModel)
        {
            var loginUIObject = new LoginUIModel();
            try
            {

                loginUIObject.Email = loginUIModel.Email;
                loginUIObject.Password = loginUIModel.Password;

                var returnResponse = _logger.Login(loginUIObject.Email, loginUIObject.Password);

                if (returnResponse.status)
                {
                    HttpContext.Session.SetString("User", JsonConvert.SerializeObject(returnResponse.Data));
                    return RedirectToAction("Dashboard", "Account", new { area = "Staff" });
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
            
            return View(loginUIModel);
        }

        public IActionResult Success()
        {
            return View();
        }

    }
}
