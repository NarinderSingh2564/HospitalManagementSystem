using HospitalManagementSystem.API.Helpers;
using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.Models;
using HospitalManagementSystem.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientRepository _patientRepository;
        private JwtService _jwtService;

        public PatientController(IPatientRepository patientRepository, JwtService jwtService)
        {
            _patientRepository = patientRepository;
            _jwtService = jwtService;
        }

        [Authorize]
        [HttpGet("GetPatientList")]
        public IActionResult GetPatientList()
        {
            var returnResponse = new ReturnResponseModel<string>();
            var patientList = new List<PatientModel>();

            try
            {
                patientList = _patientRepository.GetPatientList();
                return Ok(patientList);
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
