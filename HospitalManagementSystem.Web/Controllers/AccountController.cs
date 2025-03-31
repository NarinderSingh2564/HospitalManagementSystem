using AutoMapper;
using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.InputModels;
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
        public IActionResult CheckUserByEmailOrPhoneNumber(ForgotPasswordUIModel forgetPasswordUIModel)
        {
            var returnResponseModel = new ForgotPasswordUIModel();
            try
            {
                ModelState.Clear();

                if (ModelState.IsValid)
                {
                    var returnResponse = _accountRepository.CheckUserByEmailOrPhoneNumber(forgetPasswordUIModel.EmailPhoneNumber);
                    returnResponseModel.Status = returnResponse.status;
                    returnResponseModel.Message = returnResponse.message;

                    if (returnResponse.status)
                    {
                        returnResponseModel.EmailPhoneNumber = forgetPasswordUIModel.EmailPhoneNumber;

                        if (!string.IsNullOrEmpty(forgetPasswordUIModel.NewPassword) && !string.IsNullOrEmpty(forgetPasswordUIModel.ConfirmPassword))
                        {
                            var updatePasswordResponse = _accountRepository.UpdatePassword(forgetPasswordUIModel.EmailPhoneNumber, forgetPasswordUIModel.NewPassword, forgetPasswordUIModel.ConfirmPassword);
                            returnResponseModel.Status = updatePasswordResponse.status;
                            returnResponseModel.Message = updatePasswordResponse.message;
                        }
                    }
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
            var returnRegisterUser = new RegisterUserUIModel();

            try
            {
                returnRegisterUser.DesignationList = _accountRepository.GetDesignationList().Select(x => new KeyValueModel<int, string> { key = x.Id, value = x.Designation }).ToList();
                returnRegisterUser.DepartmentList = _accountRepository.GetDepartmentList().Select(x => new KeyValueModel<int, string> { key = x.Id, value = x.Department }).ToList();

                if (ModelState.IsValid)
                {
                    var registerUserInputModel = _mapper.Map<RegisterUserInputModel>(registerUser);
                    var returnResponse = _accountRepository.RegisterUser(registerUserInputModel);

                    returnRegisterUser.Status = returnResponse.status;
                    returnRegisterUser.Message = returnResponse.message;
                }
                else
                {
                    returnRegisterUser.Status = false;
                    returnRegisterUser.Message = "Invalid registration attempt.";
                }
            }
            catch (Exception ex)
            {
                returnRegisterUser.Status = false;
                returnRegisterUser.Message = ex.Message;
            }

            ModelState.Clear();
            return PartialView("_SignUp", returnRegisterUser);
        }

    }
}