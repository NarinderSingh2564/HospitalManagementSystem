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

            loginUIModel.registerUser.DepartmentList = _accountRepository.GetDepartmentList().Select(x => new KeyValueModel<int, string> { key = x.Id, value = x.Department }).ToList();
            
            loginUIModel.Message = TempData["RegistrationMessage"] as string;
            loginUIModel.Status = TempData["RegistrationStatus"] as bool?;

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
                    loginUIModel.Status = false;
                    loginUIModel.Message = returnResponse.message;
                }
            }
            catch (Exception ex)
            {
                loginUIModel.Status = false;
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
        public IActionResult RegisterUser(RegisterUserUIModel registerUserUIModel)
        {
            var returnRegisterUser = new RegisterUserUIModel();

            try
            {
                returnRegisterUser = _mapper.Map<RegisterUserUIModel>(registerUserUIModel);

                returnRegisterUser.DepartmentList = _accountRepository.GetDepartmentList().Select(x => new KeyValueModel<int, string> { key = x.Id, value = x.Department }).ToList();
                returnRegisterUser.DesignationList = _accountRepository.GetDesignationsByDepartmentId(registerUserUIModel.DepartmentId);
                returnRegisterUser.Password = registerUserUIModel.Password;
                returnRegisterUser.ConfirmPassword = registerUserUIModel.ConfirmPassword;

                if (!string.IsNullOrEmpty(Request.Form["btnSignup"]))
                {
                    if (ModelState.IsValid)
                    {
                        var registerUserInputModel = _mapper.Map<RegisterUserInputModel>(registerUserUIModel);

                        registerUserInputModel.CreatedBy = 1;
                        registerUserInputModel.CreatedOn = DateTime.Now;

                        var returnResponse = _accountRepository.RegisterUser(registerUserInputModel);

                        returnRegisterUser.Status = returnResponse.status;
                        returnRegisterUser.Message = returnResponse.message;

                        TempData["RegistrationMessage"] = returnResponse.message;
                        TempData["RegistrationStatus"] = returnResponse.status;
                    }
                    else
                    {
                        returnRegisterUser.Status = false;
                        returnRegisterUser.Message = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)); ;
                    }
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