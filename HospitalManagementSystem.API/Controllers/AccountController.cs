using HospitalManagementSystem.API.Helpers;
using HospitalManagementSystem.Models.Common;
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
            password = "admin123";
            try
            {
                returnResponse = _accountRepository.CheckLoginDetails(username, password);
               // returnResponse.Data.JwtToken = _jwtService.GenerateToken(returnResponse.Data.Id);
                return Ok(returnResponse);
            }
            catch (Exception ex)
            {
                returnResponse.status = false;
                returnResponse.message = "An unknown error occured, please try again later.";

                return StatusCode(500, returnResponse);
            }
        }

        [HttpGet("CheckUserExist")]
        public IActionResult CheckUserExist(string username)
        {
            var returnResponse = new ReturnResponseModel<UserModel>();

            try
            {
                returnResponse = _accountRepository.ForgetPasswordDetails(username);

                return Ok(returnResponse);
            }
            catch (Exception ex)
            {
                returnResponse.status = false;
                returnResponse.message = "An unknown error occured, please try again later.";

                return StatusCode(500, returnResponse);
            }
        }

        [HttpGet("GetUser")]
        [Authorize]
        public IActionResult GetUser()
        {
            var returnResponse = new ReturnResponseModel<UserModel>();

            try
            {
                returnResponse = _accountRepository.CheckLoginDetails("abc@gmail.com", "admin123");
                return Ok(returnResponse.Data);
            }
            catch (Exception ex)
            {
                returnResponse.status = false;
                returnResponse.message = "An unknown error occured, please try again later.";

                return StatusCode(500, returnResponse);
            }
        }

    }
}
