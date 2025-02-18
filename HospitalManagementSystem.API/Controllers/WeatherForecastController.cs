using HospitalManagementSystem.Models.UIModels;
using HospitalManagementSystem.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalManagementSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IAccountRepository _accountRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpPost]
        public IActionResult Login(LoginUIModel loginUIModel)
        {
            var loginUIObject = new LoginUIModel();
            try
            {

                loginUIObject.Email = loginUIModel.Email;
                loginUIObject.Password = loginUIModel.Password;

                var returnResponse = _accountRepository.Login(loginUIObject.Email, loginUIObject.Password);

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

            return Ok(loginUIModel);
        }



    }
}
