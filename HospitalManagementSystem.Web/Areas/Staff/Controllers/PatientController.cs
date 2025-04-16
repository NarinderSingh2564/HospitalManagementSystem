using AutoMapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.InputModels;
using HospitalManagementSystem.Models.Models;
using HospitalManagementSystem.Models.UIModels;
using HospitalManagementSystem.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Web.Areas.Staff.Controllers
{
    [Area("Staff")]
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public PatientController(IPatientRepository patientRepository, IMapper mapper, IConfiguration configuration)
        {
            _configuration = configuration;
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPatientList()
        {
            List<PatientModel> patients = _patientRepository.GetPatientList();
            return View("PatientList", patients);
        }

        public IActionResult AddPatientAppointment()
        {
            var PatientUIModel = new PatientUIModel
            {
                PatientAppointmentUIModel = new PatientAppointmentUIModel()
            };

            PatientUIModel.PatientAppointmentUIModel.DepartmentList = _patientRepository.GetDepartmentList().Select(x => new KeyValueModel<int, string> { key = x.Id, value = x.Department }).ToList();

            return View("AddPatientForm", PatientUIModel);
        }

        [HttpPost]
        public IActionResult AddPatientAppointment(PatientUIModel PatientUIModel)
        {
            var returnAddPatientAppointment = new PatientUIModel();

            try
            {
                returnAddPatientAppointment = _mapper.Map<PatientUIModel>(PatientUIModel);
                
                returnAddPatientAppointment.PatientAppointmentUIModel.DepartmentList = _patientRepository.GetDepartmentList().Select(x => new KeyValueModel<int, string> { key = x.Id, value = x.Department }).ToList();
                returnAddPatientAppointment.PatientAppointmentUIModel.DoctorList = _patientRepository.GetDoctorByDepartmentId(PatientUIModel.PatientAppointmentUIModel.DepartmentId);

                var isOldPatient = returnAddPatientAppointment.PatientAppointmentUIModel.PatientType == "Old Patient";
                var isBookAppointmentClicked = !string.IsNullOrEmpty(Request.Form["btnAddAppointment"]);


                if (isOldPatient && !isBookAppointmentClicked)
                {

                    var crmNumber = PatientUIModel.PatientAppointmentUIModel.CRMNumber;
                    var returnResponse = _patientRepository.CheckPatientByCRMNumber(crmNumber);

                    if (returnResponse.status && returnResponse.Data != null)
                    {
                        returnAddPatientAppointment = _mapper.Map<PatientUIModel>(returnResponse.Data);

                        returnAddPatientAppointment.PatientAppointmentUIModel.DepartmentList = _patientRepository.GetDepartmentList().Select(x => new KeyValueModel<int, string> { key = x.Id, value = x.Department }).ToList();
                        returnAddPatientAppointment.PatientAppointmentUIModel.DoctorList = _patientRepository.GetDoctorByDepartmentId(returnAddPatientAppointment.PatientAppointmentUIModel.DepartmentId);
                        
                        returnAddPatientAppointment.Status = returnResponse.status;
                        returnAddPatientAppointment.Message = returnResponse.message;
                    }
                    else
                    {
                        returnAddPatientAppointment.Message = returnResponse.message;
                        returnAddPatientAppointment.Status = false;

                    }
                }

                
                if (isBookAppointmentClicked)
                {
                    if (ModelState.IsValid)
                    {
                        var patientInputModel = _mapper.Map<PatientInputModel>(PatientUIModel);

                        patientInputModel.PatientAppointmentInputModel.CreatedBy = 1;
                        patientInputModel.PatientAppointmentInputModel.CreatedOn = DateTime.Now;

                        var returnResponse = _patientRepository.AddPatientAppointment(patientInputModel);

                        returnAddPatientAppointment.Status = returnResponse.status;
                        returnAddPatientAppointment.Message = returnResponse.message;

                    }
                    else
                    {
                        returnAddPatientAppointment.Status = false;
                        returnAddPatientAppointment.Message = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                    }
                }
            }
            catch (Exception ex)
            {
                returnAddPatientAppointment.Status = false;
                returnAddPatientAppointment.Message = ex.Message;
            }

            ModelState.Clear();
            return View("AddPatientForm", returnAddPatientAppointment);
        }
    }
}
