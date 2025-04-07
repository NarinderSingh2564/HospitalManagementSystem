using AutoMapper;
using HospitalManagementSystem.Data;
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

        public List<PatientModel> GetPatientList()
        {
            using (PatientService patientService = new PatientService(_dBContext, _mapper))
            {
                return patientService.GetPatientList();
            }
        }
    }
}
