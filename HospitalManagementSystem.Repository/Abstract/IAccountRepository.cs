using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.InputModels;
using HospitalManagementSystem.Models.Models;

namespace HospitalManagementSystem.Repository.Abstract
{
    public interface IAccountRepository
    {
        ReturnResponseModel<UserModel> LoginCredentialCheck(string email, string password);
        ReturnResponseModel<string> CheckUserByEmailOrPhoneNumber(string emailphonenumber);
        ReturnResponseModel<string> RegisterUser(RegisterUserInputModel registerUser);
        List<DepartmentModel> GetDepartmentList();
        //List<DesignationModel> GetDesignationList();
        List<KeyValueModel<int, string>> GetDesignationsByDepartmentId(int departmentId);
        ReturnResponseModel<UserModel> UpdatePassword(string emailphonenumber, string newPassword, string confirmPassword);

    }
}
