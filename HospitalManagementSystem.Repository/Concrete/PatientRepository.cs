using AutoMapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.InputModels;
using HospitalManagementSystem.Models.Models;
using HospitalManagementSystem.Repository.Abstract;
using HospitalManagementSystem.Service.Interactions;

namespace HospitalManagementSystem.Repository.Concrete
{
    public class PatientRepository:IPatientRepository
    {
        ApplicationDBContext _dBContext;
        IMapper _mapper;

        public PatientRepository(ApplicationDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }

        public List<DepartmentModel> GetDepartmentList()
        {
            using (AccountService accountService = new AccountService(_dBContext, _mapper))
            {
                return accountService.GetDepartmentList();
            }
        }
        public List<PatientModel> GetPatientList()
        {
            using (PatientService patientService = new PatientService(_dBContext, _mapper))
            {
                return patientService.GetPatientList();
            }
        }
        public ReturnResponseModel<PatientInputModel> CheckPatientByCRMNumber(string crmNumber)
        {
            using (PatientService patientService = new PatientService(_dBContext, _mapper))
            {
                return patientService.CheckPatientByCRMNumber(crmNumber);
            }
        }
        public ReturnResponseModel<string> AddPatientAppointment(PatientInputModel patientInputModel)
        {
            using (PatientService patientService = new PatientService(_dBContext, _mapper))
            {
                return patientService.AddPatientAppointment(patientInputModel);
            }
        }

        public List<KeyValueModel<int, string>> GetDoctorByDepartmentId(int departmentId)
        {
            using (PatientService patientService = new PatientService(_dBContext, _mapper))
            {
                return patientService.GetDoctorByDepartmentId(departmentId);
            }
        }

    }
}
