
using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.InputModels;
using HospitalManagementSystem.Models.Models;

namespace HospitalManagementSystem.Repository.Abstract
{
    public interface IPatientRepository
    {
        List<DepartmentModel> GetDepartmentList();
        List<KeyValueModel<int, string>> GetDoctorByDepartmentId(int departmentId);
        List<PatientModel> GetPatientList();

        ReturnResponseModel<PatientInputModel> CheckPatientByCRMNumber(string crmNumber);
        ReturnResponseModel<string> AddPatientAppointment(PatientInputModel patientInputModel);

    }
}
