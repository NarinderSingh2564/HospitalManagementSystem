
using HospitalManagementSystem.Models.Models;

namespace HospitalManagementSystem.Repository.Abstract
{
    public interface IPatientRepository
    {
        List<PatientModel> GetPatientList();
    }
}
