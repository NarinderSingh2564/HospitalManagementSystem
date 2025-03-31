using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.InputModels;
using HospitalManagementSystem.Models.Models;
using HospitalManagementSystem.Models.UIModels;

namespace HospitalManagementSystem.Repository.Abstract
{
    public interface IAccountRepository
    {
        ReturnResponseModel<UserModel> LoginCredentialCheck(string email, string password);
        ReturnResponseModel<UserModel> CheckUserByEmailOrPhoneNumber(string emailphonenumber);
        ReturnResponseModel<string> RegisterUser(RegisterUserInputModel registerUser);
        List<DesignationModel> GetDesignationList();
        List<DepartmentModel> GetDepartmentList();
        ReturnResponseModel<UserModel> UpdatePassword(string emailphonenumber, string newPassword, string confirmPassword);

    }
}
