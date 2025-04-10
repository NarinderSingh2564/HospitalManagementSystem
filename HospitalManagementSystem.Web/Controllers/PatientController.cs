using AutoMapper;
using HospitalManagementSystem.Models.Models;
using HospitalManagementSystem.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public PatientController(IPatientRepository patientRepository, IConfiguration configuration, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        //public IActionResult Index()
        //{
        //    var patientList = _patientRepository.GetPatientList();

        //    if (patientList == null)
        //    {
        //        patientList = new List<PatientModel>();
        //    }


        //    return View(patientList);
        //}
    }
}
