using AutoMapper;
using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.InputModels;
using HospitalManagementSystem.Models.Models;
using HospitalManagementSystem.Models.UIModels;
using HospitalManagementSystem.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalManagementSystem.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AccountController(IAccountRepository accountRepository, IConfiguration configuration, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var loginUIModel = new LoginUIModel
            {
                Email = "rohan@gmail.com",
                Password = "abc123",
                registerUser = new RegisterUserUIModel()
            };

            loginUIModel.registerUser.DesignationList = _accountRepository.GetDesignationList().Select(x => new KeyValueModel<int, string>() { key = x.Id, value = x.Designation }).ToList();
            loginUIModel.registerUser.DepartmentList = _accountRepository.GetDepartmentList().Select(x => new KeyValueModel<int, string>() { key = x.Id, value = x.Department }).ToList();

            return View(loginUIModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginUIModel loginUIModel)
        {
            try
            {
                var returnResponse = _accountRepository.LoginCredentialCheck(loginUIModel.Email, loginUIModel.Password);

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

        [HttpPost]
        public IActionResult ForgotPasswordCheck(ForgotPasswordUIModel forgetPasswordUIModel)
        {
            var returnResponseModel = new ForgotPasswordUIModel();

            try
            {
                ModelState.Clear();

                if (ModelState.IsValid)
                {
                    var returnResponse = _accountRepository.ForgotPasswordCheck(forgetPasswordUIModel.EmailPhoneNumber);
                    returnResponseModel.Status = returnResponse.status;
                    returnResponseModel.Message = returnResponse.message;
                }
                else
                {
                    returnResponseModel.Status = false;
                    returnResponseModel.Message = "Invalid input.";
                }
            }
            catch (Exception ex)
            {
                returnResponseModel.Status = false;
                returnResponseModel.Message = ex.Message;
            }
            return PartialView("_ForgotPassword", returnResponseModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterUser(RegisterUserUIModel registerUser)
        {
            try
            {
                var loginUIModel = new LoginUIModel
                {
                    registerUser = registerUser
                };

                if (!ModelState.IsValid)
                {
                    loginUIModel.status = false;
                    loginUIModel.Message = "Invalid registration attempt.";
                    loginUIModel.registerUser.DesignationList = _accountRepository.GetDesignationList()
                        .Select(x => new KeyValueModel<int, string> { key = x.Id, value = x.Designation })
                        .ToList();
                    loginUIModel.registerUser.DepartmentList = _accountRepository.GetDepartmentList()
                        .Select(x => new KeyValueModel<int, string> { key = x.Id, value = x.Department })
                        .ToList();

                    return View("Login", loginUIModel);
                }

                var mapRegisterUserInputModel = _mapper.Map<RegisterUserInputModel>(registerUser);
                var returnResponse = _accountRepository.RegisterUser(mapRegisterUserInputModel);

                loginUIModel.status = returnResponse.status;
                loginUIModel.Message = returnResponse.message;

                if (!returnResponse.status)
                {
                    loginUIModel.registerUser.DesignationList = _accountRepository.GetDesignationList()
                        .Select(x => new KeyValueModel<int, string> { key = x.Id, value = x.Designation })
                        .ToList();
                    loginUIModel.registerUser.DepartmentList = _accountRepository.GetDepartmentList()
                        .Select(x => new KeyValueModel<int, string> { key = x.Id, value = x.Department })
                        .ToList();

                    ModelState.Clear();
                }

                return View("Login", loginUIModel);
            }
            catch (Exception ex)
            {
                var loginUIModel = new LoginUIModel
                {
                    status = false,
                    Message = ex.Message
                };
                return View("Login", loginUIModel);
            }
        }

    }
}