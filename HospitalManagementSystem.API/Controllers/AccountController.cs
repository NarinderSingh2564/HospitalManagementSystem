using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.Models;
using HospitalManagementSystem.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("Login")]
        public IActionResult Login(string username, string password)
        {
            var returnResponse = new ReturnResponseModel<UserModel>();

            try
            {
                returnResponse = _accountRepository.CheckLoginDetails(username, password);
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
    }
}
