using HospitalManagementSystem.API.Helpers;
using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.InputModels;
using HospitalManagementSystem.Models.Models;
using HospitalManagementSystem.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using System.Web.Helpers;

namespace HospitalManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountRepository _accountRepository;
        private JwtService _jwtService;

        public AccountController(IAccountRepository accountRepository, JwtService jwtService)
        {
            _accountRepository = accountRepository;
            _jwtService = jwtService;
        }

        [HttpPost("Login")]
        public IActionResult Login(string username, string password)
        {
            var returnResponse = new ReturnResponseModel<UserModel>();
            username = "abc@gmail.com";
            password = "123456";
            try
            {
                returnResponse = _accountRepository.LoginCredentialCheck(username, password);
                if (returnResponse.status)
                {
                    returnResponse.Data.JwtToken = _jwtService.GenerateToken(returnResponse.Data.Id);
                }
                return Ok(returnResponse);
            }
            catch (Exception ex)
            {
                returnResponse.status = false;
                returnResponse.message = "An unknown error occured, please try again later.";

                return StatusCode(500, returnResponse);
            }
        }

        [HttpGet("CheckUserByEmailOrPhoneNumber")]
        public IActionResult CheckUserByEmailOrPhoneNumber(string username)
        {
            var returnResponse = new ReturnResponseModel<string>();

            try
            {
                returnResponse = _accountRepository.CheckUserByEmailOrPhoneNumber(username);

                return Ok(returnResponse);
            }
            catch (Exception ex)
            {
                returnResponse.status = false;
                returnResponse.message = "An unknown error occured, please try again later.";

                return StatusCode(500, returnResponse);
            }
        }

        [HttpPost("UpdatePassword")]
        public IActionResult UpdatePassword(string username, string newPassword, string confirmPassword)
        {
            var returnResponse = new ReturnResponseModel<UserModel>();

            try
            {
                returnResponse = _accountRepository.UpdatePassword(username, newPassword, confirmPassword);

                return Ok(returnResponse);
            }

            catch (Exception ex)
            {
                returnResponse.status = false;
                returnResponse.message = "An unknown error occured, please try again later.";

                return StatusCode(500, returnResponse);
            }
        }

        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser(RegisterUserInputModel registerUserInputModel)
        {
            var returnResponse = new ReturnResponseModel<string>();

            try
            {
                returnResponse = _accountRepository.RegisterUser(registerUserInputModel);

                return Ok(returnResponse);
            }

            catch (Exception ex)
            {
                returnResponse.status = false;
                returnResponse.message = "An unknown error occured, please try again later.";

                return StatusCode(500, returnResponse);
            }
        }

        [HttpGet("GetDepartmentList")]
        public IActionResult GetDepartmentList()
        {
            var departmentList = new List<DepartmentModel>();
            var returnResponse = new ReturnResponseModel<string>();

            try
            {
                departmentList = _accountRepository.GetDepartmentList();

                return Ok(departmentList);
            }

            catch (Exception ex)
            {
                returnResponse.status = false;
                returnResponse.message = "An unknown error occured, please try again later.";

                return StatusCode(500, returnResponse);
            }
        }

        [HttpGet("GetDesignationsByDepartmentId")]
        public IActionResult GetDesignationsByDepartmentId(int departmentId)
        {
            var designationList = new List<KeyValueModel<int, string>>();
            var returnResponse = new ReturnResponseModel<string>();

            try
            {
                designationList = _accountRepository.GetDesignationsByDepartmentId(departmentId);

                return Ok(designationList);
            }

            catch (Exception ex)
            {
                returnResponse.status = false;
                returnResponse.message = "An unknown error occured, please try again later.";

                return StatusCode(500, returnResponse);
            }
        }






        //[HttpGet("GetUser")]
        //[Authorize]
        //public IActionResult GetUser()
        //{
        //    var returnResponse = new ReturnResponseModel<UserModel>();

        //    try
        //    {
        //        returnResponse = _accountRepository.CheckUserByEmailOrPhoneNumber("abc@gmail.com", "admin123");
        //        return Ok(returnResponse.Data);
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResponse.status = false;
        //        returnResponse.message = "An unknown error occured, please try again later.";

        //        return StatusCode(500, returnResponse);
        //    }
        //}

    }
}
